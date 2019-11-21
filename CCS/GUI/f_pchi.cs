using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS;
using ControlLocalizer;
using DAL;
using DevExpress.Data;
using DevExpress.Utils.Win;
using DevExpress.XtraBars;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraReports.UI;
using GUI.Properties;
using Lotus;

//using GUI.Libs;

namespace GUI
{
    public partial class f_pchi : Form
    {
        private KetNoiDBDataContext db = new KetNoiDBDataContext();
        private readonly t_pchi pchi = new t_pchi();
        private string _mact = "";
        //form
        public f_pchi()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            rsearchtiente1.DataSource = new KetNoiDBDataContext().tientes;
            txttiente.Properties.DataSource = new KetNoiDBDataContext().tientes;
            btnmuccp.DataSource = new KetNoiDBDataContext().muccps;
            btncongviec1.DataSource = new KetNoiDBDataContext().congviecs;
            txtiddt.Properties.DataSource = new KetNoiDBDataContext().doituongs;


            var lst = (from a in db.vanbandens
                       join d in db.donvis on a.iddv equals d.id
                       //where a.iddv == Biencucbo.donvi
                       select new
                       {
                           a.id,
                           a.ngaynhan,
                           a.sovb,
                           a.noidung
                       }).ToList();
            slulink.Properties.DataSource = _tTodatatable.addlst(lst.ToList());
            txthsgoc.Properties.DataSource = _tTodatatable.addlst(lst.ToList());

            ////lay quyen
            //var quyen1 =
            //    db.PhanQuyen2s.FirstOrDefault(
            //        p => p.TaiKhoan == Biencucbo.phongban && p.ChucNang == "PhieuChi_DuyetHoSo");

            //if (quyen1 == null)
            //{
            //    quyen1 = new PhanQuyen2();
            //    quyen1.TaiKhoan = Biencucbo.phongban;
            //    quyen1.ChucNang = "PhieuChi_DuyetHoSo";

            //    quyen1.Xem = quyen1.Them = quyen1.Sua = quyen1.Xoa = false;

            //    db.PhanQuyen2s.InsertOnSubmit(quyen1);
            //    db.SubmitChanges();
            //}
            //btnduyet.Enabled = (bool)quyen1.Xem;



        }
        private void layttnhanvien(string txt)
        {
            try
            {
                var lst = (from a in db.accounts select a).Single(t => t.id == txt);
                lbltennv.Text = lst.name;
                txtphongban.Text = lst.phongban;
            }
            catch (Exception ex)
            {
                lbltennv.Text = "";
                txtphongban.Text = "";
            }
        }
        private string LayMaTim(donvi d)
        {
            var s = "." + d.id + "." + d.iddv + ".";
            var find = db.donvis.FirstOrDefault(t => t.id == d.iddv);
            if (find != null)
            {
                var iddv = find.iddv;
                if (d.id != find.iddv)
                {
                    if (!s.Contains(iddv))
                        s += iddv + ".";
                }
                while (iddv != find.id)
                {
                    if (!s.Contains(find.id))
                        s += find.id + ".";
                    find = db.donvis.FirstOrDefault(t => t.id == find.iddv);
                }
            }
            return s;
        }


        private void laychuyentien()
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().theodoitt_cpks where a.idcpk == txtid.Text select a);
                if (lst.Count() > 0)
                {
                    txtdachuyen.Text = lst.Sum(t => t.sotienchuyen).ToString();
                    txtconlai.Text = (double.Parse(colsotien.SummaryItem.SummaryValue.ToString()) - lst.Sum(t => t.sotienchuyen))
                            .ToString();
                }
                else
                {
                    txtdachuyen.Text = "0";
                    txtconlai.Text = (double.Parse(colsotien.SummaryItem.SummaryValue.ToString())).ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }
        //load
        public void load()
        {
            db = new KetNoiDBDataContext();
            Biencucbo.hdpc = 2;
            txt1.Enabled = false;

            btnLuu.Enabled = false;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnin.Enabled = true;

            btnreload.Enabled = false;
            txtdv.ReadOnly = true;
            txtid.ReadOnly = true;
            txtdiachi.ReadOnly = true;
            txtidnv.ReadOnly = true;
            txtphongban.ReadOnly = true;

            // Enable
            txtghichu.ReadOnly = true;
            txtngaynhap.ReadOnly = true;
            txtiddt.ReadOnly = true;
            slulink.ReadOnly = true;
            txthsgoc.ReadOnly = true;
            txttiente.ReadOnly = true;

            txttygia.ReadOnly = true;
            gv.OptionsBehavior.Editable = false;

            try
            {

                if (Biencucbo.xembc)
                {
                    var lst1 = (from b in db.pchis where b.idct == _mact select b).Single(t => t.id == Biencucbo.ma);


                    if (lst1 == null) return;


                    txtid.Text = lst1.id;
                    txtidnv.Text = lst1.idnv;
                    layttnhanvien(lst1.idnv);
                    txtdv.Text = lst1.iddv;
                    txtngaynhap.DateTime = DateTime.Parse(lst1.ngaychi.ToString());
                    txtiddt.Text = lst1.iddt;
                    slulink.Text = lst1.link;
                    txthsgoc.Text = lst1.linkgoc;
                    txtghichu.Text = lst1.ghichu;
                    txt1.Text = lst1.so.ToString();
                    txttiente.Text = lst1.tiente;


                    txttygia.Text = lst1.tygia.ToString();
                    gcchitiet.DataSource = lst1.pchicts;
                    laychuyentien();
                    Biencucbo.xembc = false;
                    duyethd();
                }
                else
                {
                    var lst =
                        (from a in db.pchis where a.iddv == Biencucbo.donvi && a.idct == _mact select a.so).Max();
                    var lst1 =
                        (from b in db.pchis where b.iddv == Biencucbo.donvi && b.idct == _mact select b).Single(
                            t => t.so == lst);


                    if (lst1 == null) return;


                    txtid.Text = lst1.id;
                    txtidnv.Text = lst1.idnv;
                    layttnhanvien(lst1.idnv);
                    txtdv.Text = lst1.iddv;
                    txtngaynhap.DateTime = DateTime.Parse(lst1.ngaychi.ToString());
                    txtiddt.Text = lst1.iddt;
                    slulink.Text = lst1.link;
                    txthsgoc.Text = lst1.linkgoc;
                    txtghichu.Text = lst1.ghichu;
                    txt1.Text = lst1.so.ToString();
                    txttiente.Text = lst1.tiente;


                    txttygia.Text = lst1.tygia.ToString();
                    gcchitiet.DataSource = lst1.pchicts;
                    laychuyentien();

                    duyethd();
                }
            }
            catch
            {
            }
        }

        // phân quyền 
        private bool _duyet = false;
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            var q = Biencucbo.QuyenDangChon;
            if (q == null) return;

            if ((bool)q.Them)
            {
                btnnew.Visibility = BarItemVisibility.Always;
            }
            else
            {
                btnnew.Visibility = BarItemVisibility.Never;
            }
            if ((bool)q.Sua)
            {
                btnsua.Visibility = BarItemVisibility.Always;
            }
            else
            {
                btnsua.Visibility = BarItemVisibility.Never;
            }
            if ((bool)q.Xoa)
            {
                btnxoa.Visibility = BarItemVisibility.Always;
            }
            else
            {
                btnxoa.Visibility = BarItemVisibility.Never;
            }
            if ((bool)q.chuyentien)
            {
                btnchuyentien.Visibility = BarItemVisibility.Always;
            }
            else
            {
                btnchuyentien.Visibility = BarItemVisibility.Never;
            }
            if ((bool)q.duyet)
            {
                _duyet = true;
            }
            else
            {
                _duyet = false;
            }
        }

        // Mở
        private void mo()
        {
            Biencucbo.mamo = _mact;
            var frm = new f_dspchi();
            frm.ShowDialog();
            if (Biencucbo.getID == 1)
            {
                //load pnhap
                try
                {
                    var lst = (from pn in db.pchis select new { a = pn }).Single(x => x.a.id == Biencucbo.ma);

                    if (lst == null) return;

                    txtid.Text = lst.a.id;
                    txtidnv.Text = lst.a.idnv;
                    layttnhanvien(lst.a.idnv);
                    txtdv.Text = lst.a.iddv;
                    txtngaynhap.DateTime = DateTime.Parse(lst.a.ngaychi.ToString());
                    txtiddt.Text = lst.a.iddt;
                    slulink.Text = lst.a.link;
                    txthsgoc.Text = lst.a.linkgoc;
                    txttiente.Text = lst.a.tiente;

                    txttygia.Text = lst.a.tygia.ToString();
                    txtghichu.Text = lst.a.ghichu;
                    txt1.Text = lst.a.so.ToString();

                    gcchitiet.DataSource = lst.a.pchicts;
                    laychuyentien();

                    duyethd();

                    //btn
                    btnnew.Enabled = true;
                    btnsua.Enabled = true;
                    btnLuu.Enabled = false;
                    btnmo.Enabled = true;
                    btnxoa.Enabled = true;
                    btnin.Enabled = true;
                    btnreload.Enabled = false;
                }
                catch
                {
                }
            }
        }
        private void btnmo_ItemClick(object sender, ItemClickEventArgs e)
        {
            mo();
        }
        t_todatatable _tTodatatable = new t_todatatable();
        //Thêm
        private void them()
        {
            Biencucbo.hdpc = 0;
            txtid.DataBindings.Clear();
            txtid.Text = "YYYYY";

            gcchitiet.DataSource = new KetNoiDBDataContext().View_pchis;
            laychuyentien();
            for (var i = 0; i <= gv.RowCount - 1; i++)
            {
                gv.DeleteRow(i);
            }
            gv.AddNewRow();

            txtdv.Text = Biencucbo.donvi;
            txtngaynhap.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            txtphongban.Text = Biencucbo.phongban;
            txtidnv.Text = Biencucbo.idnv.Trim();
            lbltennv.Text = Biencucbo.ten;
            txtngaynhap.Focus();
            txtiddt.Text = "";
            slulink.Text = "";
            txthsgoc.Text = "";
            lbltendt.Text = "";
            txtghichu.Text = "";
            txttiente.Text = "KIP";

            txttygia.Text = "1";

            //btn
            btnnew.Enabled = false;
            btnmo.Enabled = false;
            btnLuu.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnin.Enabled = false;
            btnreload.Enabled = false;

            //enabled
            txtghichu.ReadOnly = false;
            txtngaynhap.ReadOnly = false;
            txtiddt.ReadOnly = false;
            slulink.ReadOnly = false;
            txthsgoc.ReadOnly = false;
            txttiente.ReadOnly = false;
            txttygia.ReadOnly = false;


            gv.OptionsBehavior.Editable = true;
        }
        private void btnnew_ItemClick(object sender, ItemClickEventArgs e)
        {
            them();
        }

        //Lưu
        public void luu()
        {
            gv.PostEditor();
            var hs = new t_history();
            var td = new t_tudong();


            gv.UpdateCurrentRow();
            gv.PostEditor();
            for (int i = 0; i <= gv.DataRowCount - 1; i++)
            {
                try
                {

                    if (gv.GetRowCellDisplayText(i, "idmuccp") == "")
                    {
                        XtraMessageBox.Show("Không được để trống mục chi phí. Vui lòng kiểm tra lại", "THÔNG BÁO");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.ToString());
                    return;
                }

            }


            if (txtngaynhap.Text == "" || txtiddt.Text == "" || txttygia.Text == "")
            {
                MsgBox.ShowWarningDialog("Thông tin chưa đầy đủ - Vui lòng kiểm tra lại!");
            }
            else
            {
                if (Biencucbo.hdpc == 0)
                {
                    db = new KetNoiDBDataContext();
                    //try
                    //{
                    var check = "PC" + Biencucbo.donvi.Trim();
                    var lst1 = (from s in db.tudongs where s.maphieu == check select new { s.so }).ToList();

                    if (lst1.Count == 0)
                    {
                        int so;

                        so = 2;
                        td.themtudong(check, so);
                        txtid.Text = check + "_000001";
                        txt1.Text = "1";
                    }
                    else
                    {
                        int k;
                        txt1.DataBindings.Clear();
                        txt1.DataBindings.Add("text", lst1, "so");
                        k = 0;
                        k = Convert.ToInt32(txt1.Text);
                        var so0 = "";
                        if (k < 10)
                        {
                            so0 = "00000";
                        }
                        else if (k >= 10 & k < 100)
                        {
                            so0 = "0000";
                        }
                        else if (k >= 100 & k < 1000)
                        {
                            so0 = "000";
                        }
                        else if (k >= 1000 & k < 10000)
                        {
                            so0 = "00";
                        }
                        else if (k >= 10000 & k < 100000)
                        {
                            so0 = "0";
                        }
                        else if (k >= 100000)
                        {
                            so0 = "";
                        }
                        txtid.Text = check + "_" + so0 + k;

                        k = k + 1;

                        td.suatudong(check, k);
                    }
                    pchi.moiphieu(txtid.Text, txtngaynhap.DateTime, txtiddt.Text, txtdv.Text, txtidnv.Text,
                       txtghichu.Text, Convert.ToInt32(txt1.Text), txttiente.Text,
                       double.Parse(txttygia.Text), _mact, slulink.Text, txthsgoc.Text);

                    try
                    {
                        gv.ClearSorting();
                        for (var i = 0; i <= gv.DataRowCount - 1; i++)
                        {
                            gv.SetRowCellValue(i, "id", txtid.Text + i);
                            gv.SetRowCellValue(i, "idchi", txtid.Text);
                            gv.SetRowCellValue(i, "stt", i);



                            pchi.moict(gv.GetRowCellValue(i, "diengiai").ToString(),
                                gv.GetRowCellValue(i, "idcv").ToString(),
                                gv.GetRowCellValue(i, "idmuccp").ToString(),
                                double.Parse(gv.GetRowCellValue(i, "sotien").ToString()),
                                gv.GetRowCellValue(i, "idchi").ToString(),
                                gv.GetRowCellValue(i, "id").ToString(),
                                double.Parse(gv.GetRowCellValue(i, "nguyentebch").ToString()),
                                double.Parse(gv.GetRowCellValue(i, "nguyentecn").ToString()),
                                double.Parse(gv.GetRowCellValue(i, "nguyentect").ToString()),
                                int.Parse(gv.GetRowCellValue(i, "stt").ToString()),
                                double.Parse(gv.GetRowCellValue(i, "catgiam").ToString()));
                        }
                        gv.Columns["stt"].SortOrder = ColumnSortOrder.Ascending;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    //btn
                    btnmo.Enabled = true;
                    btnnew.Enabled = true;
                    btnLuu.Enabled = false;
                    btnsua.Enabled = true;
                    btnxoa.Enabled = true;
                    btnin.Enabled = true;
                    btnreload.Enabled = false;

                    //enabled
                    txtghichu.ReadOnly = true;
                    txtngaynhap.ReadOnly = true;
                    txtiddt.ReadOnly = true;
                    slulink.ReadOnly = true;
                    txthsgoc.ReadOnly = true;
                    txttiente.ReadOnly = true;
                    txttygia.ReadOnly = true;


                    gv.OptionsBehavior.Editable = false;
                    Biencucbo.hdpc = 2;

                    // History
                    hs.add(txtid.Text, "Thêm mới chứng từ");

                    //ShowAlert.Alert_Add_Success(this);
                    //}
                    //catch (Exception ex)
                    //{
                    //    MsgBox.ShowErrorDialog(ex.ToString());
                    //}
                }
                else
                {
                    try
                    {
                        pchi.suaphieu(txtid.Text, DateTime.Parse(txtngaynhap.Text), txtiddt.Text, txtghichu.Text,
                            int.Parse(txt1.Text), txttiente.Text, double.Parse(txttygia.Text),
                            slulink.Text, txthsgoc.Text);

                        //sua ct
                        LuuPhieu();

                        //btn
                        btnmo.Enabled = true;
                        btnnew.Enabled = true;
                        btnLuu.Enabled = false;
                        btnsua.Enabled = true;
                        btnxoa.Enabled = true;
                        btnin.Enabled = true;
                        btnreload.Enabled = false;

                        //enabled
                        txtghichu.ReadOnly = true;
                        txtngaynhap.ReadOnly = true;
                        txtiddt.ReadOnly = true;
                        slulink.ReadOnly = true;
                        txthsgoc.ReadOnly = true;

                        txttiente.ReadOnly = true;
                        txttygia.ReadOnly = true;

                        gv.OptionsBehavior.Editable = false;
                        Biencucbo.hdpc = 2;


                        hs.add(txtid.Text, "Sửa chứng từ");

                        //ShowAlert.Alert_Edit_Success(this);
                    }
                    catch (Exception ex)
                    {
                        MsgBox.ShowErrorDialog(ex.ToString());
                    }
                }
            }
        }

        private void btnLuu_ItemClick(object sender, ItemClickEventArgs e)
        {
            //check khoa so
            //if (checkKhoaSo.checkkhoaso(txtdv, txtngaynhap) == false) return;


            luu();
        }

        private bool LuuPhieu()
        {
            // kiem tra truoc khi luu
            layoutControl1.Validate();
            gv.CloseEditor();
            gv.UpdateCurrentRow();

            // if(kiem tra rang buoc)
            //  return false;

            try
            {
                db.pchicts.Context.SubmitChanges();
            }
            catch (Exception ex)
            {
                MsgBox.ShowErrorDialog(ex.Message);
                return false;
            }
            return true;
        }

        //Sửa
        private void sua()
        {
            if (Biencucbo.idnv != txtidnv.Text)
            {
                XtraMessageBox.Show("Bạn không có quyền chỉnh sửa phiếu này", "THÔNG BÁO");
                return;
            }
            //else if (txtidnv.Text != Biencucbo.idnv)
            //{
            //    XtraMessageBox.Show("Bạn không có quyền chỉnh sửa phiếu này", "THÔNG BÁO");
            //}
            if (txtid.Text == "")
            {
                return;
            }

            //load 
            try
            {
                var lst = (from pn in db.pchis select pn).FirstOrDefault(x => x.id == txtid.Text);
                if (lst == null) return;
                gcchitiet.DataSource = lst.pchicts;
                laychuyentien();
                //enabled
                txtghichu.ReadOnly = false;
                txtngaynhap.ReadOnly = false;
                txtiddt.ReadOnly = false;
                slulink.ReadOnly = false;
                txthsgoc.ReadOnly = false;
                txttiente.ReadOnly = false;
                txttygia.ReadOnly = false;

                gv.OptionsBehavior.Editable = true;
                Biencucbo.hdpc = 1;

                // btn
                btnsua.Enabled = false;
                btnLuu.Enabled = true;
                btnmo.Enabled = false;
                btnnew.Enabled = false;
                btnxoa.Enabled = false;
                btnin.Enabled = false;
                btnreload.Enabled = true;
            }
            catch
            {
            }
        }
        private void btnsua_ItemClick(object sender, ItemClickEventArgs e)
        {
            var lst3 = (from dt in new KetNoiDBDataContext().duyeths where dt.id == txtid.Text select dt).ToList();
            if (lst3.Count() != 0)
            {
                try
                {
                    if (lst3.Single().T == true)
                    {
                        XtraMessageBox.Show("Phiếu này đã được duyệt không thể sửa");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            sua();

        }

        //Xóa
        private void xoa()
        {
            if (Biencucbo.idnv != txtidnv.Text)
            {
                XtraMessageBox.Show("Bạn không có quyền xóa phiếu này", "THÔNG BÁO");
                return;
            }
            if (txtid.Text == "")
            {
                return;
            }
            if (
                XtraMessageBox.Show("Bạn có chắc chắn muốn xóa Phiếu " + txtid.Text + " không?", "THÔNG BÁO",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    for (var i = gv.DataRowCount - 1; i >= 0; i--)
                    {
                        pchi.xoact(gv.GetRowCellValue(i, "id").ToString());
                        gv.DeleteRow(i);
                    }
                    pchi.xoapphieu(txtid.Text);

                    //btn
                    btnmo.Enabled = true;
                    btnnew.Enabled = true;
                    btnLuu.Enabled = false;
                    btnsua.Enabled = true;
                    btnxoa.Enabled = true;
                    btnin.Enabled = true;
                    btnreload.Enabled = false;

                    //enabled
                    txtghichu.ReadOnly = true;
                    txtngaynhap.ReadOnly = true;
                    txtiddt.ReadOnly = true;
                    slulink.ReadOnly = true;
                    txthsgoc.ReadOnly = true;
                    txttiente.ReadOnly = true;
                    txttygia.ReadOnly = true;

                    gv.OptionsBehavior.Editable = false;
                    txtdv.Text = "";
                    txtid.Text = "";
                    txtidnv.Text = "";
                    txtphongban.Text = "";
                    txtdv.Text = "";
                    txtngaynhap.Text = "";
                    txtiddt.Text = "";
                    slulink.Text = "";
                    txthsgoc.Text = "";
                    txtghichu.Text = "";
                    txt1.Text = "";
                    lbltendt.Text = "";
                    lbltennv.Text = "";
                    txttiente.Text = "";


                    txttygia.Text = "";

                    var hs = new t_history();
                    hs.add(txtid.Text, "Xóa chứng từ - ລົບເອກະສານ");

                    //ShowAlert.Alert_Del_Success(this);
                }

                catch
                {
                }
            }
        }
        private void btnxoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            var lst3 = (from dt in new KetNoiDBDataContext().duyeths where dt.id == txtid.Text select dt).ToList();
            if (lst3.Count() != 0)
            {
                XtraMessageBox.Show("Phiếu này đã được duyệt không thể xóa");
                return;
            }
            xoa();
        }

        //In
        //reload
        private void reload()
        {
            if (Biencucbo.hdpc == 1)
            {
                

                var lst = (from pn in new KetNoiDBDataContext().pchis select pn).FirstOrDefault(x => x.id == txtid.Text);

                if (lst == null) return;

                txtidnv.Text = lst.idnv;
                layttnhanvien(lst.idnv);
                txtdv.Text = lst.iddv;
                txtngaynhap.DateTime = DateTime.Parse(lst.ngaychi.ToString());
                txtiddt.Text = lst.iddt;
                slulink.Text = lst.link;
                txthsgoc.Text = lst.linkgoc;
                txtghichu.Text = lst.ghichu;
                txt1.Text = lst.so.ToString();
                gcchitiet.DataSource = lst.pchicts;
                laychuyentien();


                //readonly
                txtghichu.ReadOnly = true;
                txtngaynhap.ReadOnly = true;
                txttiente.ReadOnly = true;


                txttygia.ReadOnly = true;
                txtiddt.ReadOnly = true;
                slulink.ReadOnly = true;
                txthsgoc.ReadOnly = true;
                //btn
                btnnew.Enabled = true;
                btnsua.Enabled = true;
                btnLuu.Enabled = false;
                btnmo.Enabled = true;
                btnxoa.Enabled = true;
                btnin.Enabled = true;
                btnreload.Enabled = false;

                gv.OptionsBehavior.Editable = false;
            }

            else if (Biencucbo.hdpc == 0)
            {
                load();
                btnnew.Enabled = true;
                btnsua.Enabled = true;
                btnLuu.Enabled = false;
                btnmo.Enabled = true;
                btnxoa.Enabled = true;
                btnin.Enabled = true;
                btnreload.Enabled = false;

                gv.OptionsBehavior.Editable = false;
            }
            Biencucbo.hdpc = 2;
        }
        private void btnload_ItemClick(object sender, ItemClickEventArgs e)
        {
            reload();

        }

        // thay đổi
        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            gv.PostEditor();
            if (e.Column.FieldName == "nguyentebch")
            {
                try
                {
                    gv.SetFocusedRowCellValue("sotien",
                        (double.Parse(gv.GetFocusedRowCellValue("nguyentebch").ToString()) +
                         double.Parse(gv.GetFocusedRowCellValue("nguyentecn").ToString()) +
                         double.Parse(gv.GetFocusedRowCellValue("nguyentect").ToString()) -
                         double.Parse(gv.GetFocusedRowCellValue("catgiam").ToString())) *
                        double.Parse(txttygia.Text));
                    gv.PostEditor();
                    gv.UpdateCurrentRow();
                    laychuyentien();
                }
                catch (Exception)
                {
                }
            }
            else if (e.Column.FieldName == "nguyentecn")
            {
                try
                {
                    gv.SetFocusedRowCellValue("sotien",
                        (double.Parse(gv.GetFocusedRowCellValue("nguyentebch").ToString()) +
                         double.Parse(gv.GetFocusedRowCellValue("nguyentecn").ToString()) +
                         double.Parse(gv.GetFocusedRowCellValue("nguyentect").ToString()) -
                         double.Parse(gv.GetFocusedRowCellValue("catgiam").ToString())) *
                        double.Parse(txttygia.Text));
                    gv.PostEditor();
                    gv.UpdateCurrentRow();
                    laychuyentien();
                }
                catch (Exception)
                {
                }
            }

            else if (e.Column.FieldName == "catgiam")
            {
                try
                {
                    gv.SetFocusedRowCellValue("sotien",
                        (double.Parse(gv.GetFocusedRowCellValue("nguyentebch").ToString()) +
                         double.Parse(gv.GetFocusedRowCellValue("nguyentecn").ToString()) +
                         double.Parse(gv.GetFocusedRowCellValue("nguyentect").ToString()) -
                         double.Parse(gv.GetFocusedRowCellValue("catgiam").ToString())) *
                        double.Parse(txttygia.Text));
                    gv.PostEditor();
                    gv.UpdateCurrentRow();
                    laychuyentien();
                }
                catch (Exception)
                {
                }
            }
            else if (e.Column.FieldName == "nguyentect")
            {
                try
                {
                    gv.SetFocusedRowCellValue("sotien",
                        (double.Parse(gv.GetFocusedRowCellValue("nguyentebch").ToString()) +
                         double.Parse(gv.GetFocusedRowCellValue("nguyentecn").ToString()) +
                         double.Parse(gv.GetFocusedRowCellValue("nguyentect").ToString()) -
                         double.Parse(gv.GetFocusedRowCellValue("catgiam").ToString())) *
                        double.Parse(txttygia.Text));
                    gv.PostEditor();
                    gv.UpdateCurrentRow();
                    laychuyentien();
                }
                catch (Exception)
                {
                }
            }
        }

        //Phím Tắt
        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        //đối tượng
        private void txtiddt_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var lst = (from a in db.doituongs select a).Single(t => t.id == txtiddt.Text);
                lbltendt.Text = lst.ten;
                txtdiachi.Text = lst.diachi;
            }
            catch (Exception)
            {
            }
        }

        //Dòng mới
        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            if (Biencucbo.hdpc == 1)
            {
                var ct = gv.GetFocusedRow() as pchict;
                if (ct == null) return;

                int i = 0, k = 0;
                string a;

                try
                {
                    k = Convert.ToInt32(gv.GetRowCellValue(gv.DataRowCount - 1, "stt").ToString());
                    k = k + 1;
                }
                catch (Exception ex)
                {

                }
                a = txtid.Text + k;

                for (i = 0; i <= gv.DataRowCount - 1;)
                {
                    if (a == gv.GetRowCellValue(i, "id").ToString())
                    {
                        k = k + 1;
                        a = txtid.Text + k;
                        i = 0;
                    }
                    else
                    {
                        i++;
                    }
                }

                ct.idchi = txtid.Text;
                ct.diengiai = "";
                ct.idmuccp = "";
                ct.idcv = "";
                ct.sotien = 0;
                ct.id = a;
                ct.stt = Convert.ToInt32(ct.id.Substring(ct.idchi.Length, ct.id.Length - ct.idchi.Length));
                ct.nguyentebch = 0;
                ct.catgiam = 0;
                ct.lydocg = "";
                ct.nguyentecn = 0;
                ct.nguyentect = 0;
            }
            else
            {
                gv.SetFocusedRowCellValue("diengiai", "");
                gv.SetFocusedRowCellValue("idmuccp", "");
                gv.SetFocusedRowCellValue("lydocg", "");
                gv.SetFocusedRowCellValue("idcv", "");
                gv.SetFocusedRowCellValue("nguyentebch", 0.00);
                gv.SetFocusedRowCellValue("catgiam", 0.00);
                gv.SetFocusedRowCellValue("nguyentecn", 0.00);
                gv.SetFocusedRowCellValue("nguyentect", 0.00);
                gv.SetFocusedRowCellValue("sotien", 0.00);


            }
        }

        //Xóa dòng
        private void print()
        {
            try
            {
                var lst = from a in db.r_pchis where a.id == txtid.Text select a;
                var xtra = new report.chiphikhac.r_inpchi();
                xtra.DataSource = _tTodatatable.addlst(lst.ToList());
                xtra.ShowPreviewDialog();
            }
            catch
            {
            }
        }
        private void btnin_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            print();
        }

        //đóng form
        private void f_pnhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Biencucbo.hdpc != 2)
            {
                var a =
                    MsgBox.ShowYesNoCancelDialog(
                        "Phiếu này chưa được lưu - Bạn có muốn lưu Phiếu này trước khi thoát không?");
                if (a == DialogResult.Yes)
                {
                    luu();
                }
                else if (a == DialogResult.Cancel) e.Cancel = true;
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!gv.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
            {
                if (e.Info.IsRowIndicator) //Nếu là dòng Indicator
                {
                    if (e.RowHandle < 0)
                    {
                        e.Info.ImageIndex = 0;
                        e.Info.DisplayText = string.Empty;
                    }
                    else
                    {
                        e.Info.ImageIndex = -1; //Không hiển thị hình
                        e.Info.DisplayText = (e.RowHandle + 1).ToString(); //Số thứ tự tăng dần
                    }
                    var _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                    //Lấy kích thước của vùng hiển thị Text
                    var _Width = Convert.ToInt32(_Size.Width) + 20;
                    BeginInvoke(new MethodInvoker(delegate { cal(_Width, gv); }));
                    //Tăng kích thước nếu Text vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", e.RowHandle * -1); //Nhân -1 để đánh lại số thứ tự tăng dần
                var _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                var _Width = Convert.ToInt32(_Size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, gv); }));
            }
        }

        private bool cal(int _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }

        private void btnmuccp_EditValueChanged(object sender, EventArgs e)
        {
            gv.PostEditor();
        }

        private void rsearchtiente1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                gv.PostEditor();
                var lst =
                    (from a in db.tientes select a).Single(
                        t => t.tiente1 == gv.GetFocusedRowCellValue("tiente").ToString());
                if (lst == null) return;
                gv.SetFocusedRowCellValue("tygia", lst.tygia);
                gv.SetFocusedRowCellValue("sotien",
                    int.Parse(gv.GetFocusedRowCellValue("nguyentebch").ToString()) * int.Parse(txttygia.Text) +
                    int.Parse(gv.GetFocusedRowCellValue("nguyentecn").ToString()) * int.Parse(txttygia.Text) +
                    int.Parse(gv.GetFocusedRowCellValue("nguyentect").ToString()) * int.Parse(txttygia.Text) -
                    int.Parse(gv.GetFocusedRowCellValue("catgiam").ToString()) * int.Parse(txttygia.Text));
                gv.PostEditor();
                gv.UpdateCurrentRow();
                laychuyentien();
            }
            catch
            {
            }
        }

        private void f_pchi_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            Text = "Chi Phí Quản Lý - Công Trình: " +
                   (from a in db.congtrinhs select a).Single(t => t.id == Biencucbo.mact).tencongtrinh;
            _mact = Biencucbo.mact;
            changeFont.Translate(this);
            changeFont.Translate(barManager1);

            load();
        }

        private void txttiente_EditValueChanged(object sender, EventArgs e)
        {
            if (txttiente.Text != "")
            {
                var lst = (from a in new KetNoiDBDataContext().tientes select a).FirstOrDefault(t => t.tiente1 == txttiente.Text);
                txttygia.Text = lst.tygia.ToString();

                for (var i = 0; i <= gv.RowCount - 1; i++)
                {
                    try
                    {
                        gv.SetRowCellValue(i, "sotien",
                            (double.Parse(gv.GetRowCellValue(i, "nguyentebch").ToString()) +
                             double.Parse(gv.GetRowCellValue(i, "nguyentecn").ToString()) +
                             double.Parse(gv.GetRowCellValue(i, "nguyentect").ToString()) -
                             double.Parse(gv.GetRowCellValue(i, "catgiam").ToString())) *
                            double.Parse(txttygia.Text));
                        gv.PostEditor();
                        gv.UpdateCurrentRow();
                        laychuyentien();
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void txtiddt_Popup(object sender, EventArgs e)
        {
            var popupControl = sender as IPopupControl;
            var button = new SimpleButton
            {
                Image = Resources.icons8_Add_File_16,
                Text = "Edit",
                BorderStyle = BorderStyles.NoBorder
            };

            button.Click += button_Click;

            button.Location = new Point(5, popupControl.PopupWindow.Height - button.Height - 5);
            popupControl.PopupWindow.Controls.Add(button);
            button.BringToFront();
        }

        public void button_Click(object sender, EventArgs e)
        {
            var frm = new f_doituong();
            frm.ShowDialog();
            txtiddt.Properties.DataSource = new KetNoiDBDataContext().doituongs;
        }





        private string layttnd(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().accounts select a).Single(t => t.id == id);
                return lst.name;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public void duyethd()
        {
            db = new KetNoiDBDataContext();
            var lst3 = (from dt in new KetNoiDBDataContext().duyeths where dt.id == txtid.Text select dt).ToList();
            if (lst3.Count() != 0)
            {
                var lst4 = (from a in new KetNoiDBDataContext().duyeths select a).First(t => t.id == txtid.Text);
                if (lst4.T == true)
                {
                    btnduyet.Glyph = Resources.folder_full_accept_icon;
                    btnnoidungduyet.Caption = "Người duyệt: " + lst4.iduser + "-" + layttnd(lst4.iduser) + ". Ghi Chú: " +
                                              lst4.ghichu;
                }
                else if (lst4.T == false)
                {
                    btnduyet.Glyph = Resources.folder_full_delete_icon;
                    btnnoidungduyet.Caption = "Người duyệt: " + lst4.iduser + "-" + layttnd(lst4.iduser) + ". Ghi Chú: " +
                                              lst4.ghichu;
                }
            }
            else
            {
                btnduyet.Glyph = Resources.folder_full_icon;
                btnnoidungduyet.Caption = "Chưa Duyệt";
            }
        }

        private void btnduyet_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Biencucbo.hdpc == 2)
            {
                if (_duyet)
                {
                    var hs = new t_history();
                    if (Biencucbo.hdpc == 2)
                    {
                        Biencucbo.idduyet = txtid.Text;
                        Biencucbo.loaiduyet = "Duyệt chi phí Khác";
                        var frm = new f_duyeths();
                        frm.ShowDialog();
                        duyethd();
                        hs.add(txtid.Text, "Duyệt chi phí khác");
                    }
                }
                else
                {
                    XtraMessageBox.Show("Bạn chưa được cấp quyền duyệt hồ sơ này");
                }
            }
        }

        private void btnimport_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtid.Text == string.Empty || gv.DataRowCount > 0)
                {
                    XtraMessageBox.Show("Phiếu này không thể import, vui lòng liên hệ Admin");
                    return;

                }
                else if (btnLuu.Enabled == true)
                {
                    XtraMessageBox.Show("Vui lòng lưu phiếu trước khi import");
                    return;

                }
                else
                {
                    Biencucbo.ma = "pchict";
                    f_import frm = new f_import();
                    frm.ShowDialog();
                    var lst = (from a in new KetNoiDBDataContext().pchis select a).Single(t => t.id == txtid.Text);
                    gcchitiet.DataSource = lst.pchicts;

                    laychuyentien();


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

            //if (Biencucbo.hdpc != 2)
            //    return;
            //Biencucbo.ma = txtid.Text;
            //var frm = new f_import_pchi();
            //frm.ShowDialog();
            //db = new KetNoiDBDataContext();
            //var lst = (from a in db.pchis select a).Single(t => t.id == txtid.Text);
            //gcchitiet.DataSource = lst.pchicts;

        }

        private void f_pchi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.O)
                {
                    if (btnmo.Enabled)
                        mo();
                }
                else if (e.KeyCode == Keys.N)
                {
                    if (btnthemmoi.Enabled)
                        them();
                }
                else if (e.KeyCode == Keys.S)
                {
                    if (btnLuu.Enabled)
                        luu();
                }
                else if (e.KeyCode == Keys.U)
                {
                    if (btnsua.Enabled)
                        sua();
                }
                else if (e.KeyCode == Keys.D)
                {
                    if (btnxoa.Enabled)
                        xoa();
                }
                else if (e.KeyCode == Keys.P)
                {
                    if (btnin.Enabled)
                        print();
                }
                else if (Biencucbo.hdpc != 2)
                {

                    if (e.KeyCode == Keys.Delete)
                    {
                        if (Biencucbo.hdpc == 1)
                        {
                            try
                            {
                                var ct =
                                    (from c in db.pchicts select c).Single(
                                        x => x.id == gv.GetFocusedRowCellValue("id").ToString());
                                db.pchicts.DeleteOnSubmit(ct);
                            }
                            catch
                            {
                            }

                        }
                        gv.DeleteRow(gv.FocusedRowHandle);
                    }
                }
            }
            else if (e.KeyCode == Keys.F5)
            {
                if (btnload.Enabled)
                    reload();
            }
            if (Biencucbo.hdpc != 2)
            {

                if (e.KeyCode == Keys.Insert)
                {
                    gv.AddNewRow();
                }
            }



        }

        private void gv2_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            custom.sttgv(gv2, e);
            BeginInvoke(new MethodInvoker(delegate
            {
                custom.cal(gcchitiet, gv);
            }));
        }

        private void btnchuyentien_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Biencucbo.hdpc == 2 && txtid.Text != string.Empty)
            {
                Biencucbo.ma = txtid.Text;
                theodoitt.chiphikhac.f_theodoitt_cpk frm = new theodoitt.chiphikhac.f_theodoitt_cpk();
                frm.ShowDialog();
                laychuyentien();
            }
        }

        private void layttlbllink(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().vanbandens select a).Single(t => t.id == id);
                lbllink.Text = lst.noidung;
            }
            catch (Exception ex)
            {
                lbllink.Text = "";
            }
        }

        private void layttlbllinkgoc(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().vanbandens select a).Single(t => t.id == id);
                lbllinkgoc.Text = lst.noidung;
            }
            catch (Exception ex)
            {
                lbllinkgoc.Text = "";
            }
        }

        private void slulink_EditValueChanged(object sender, EventArgs e)
        {
            layttlbllink(slulink.Text);
        }

        private void txthsgoc_EditValueChanged(object sender, EventArgs e)
        {
            layttlbllinkgoc(txthsgoc.Text);
        }

        private void btnmuccp_Popup(object sender, EventArgs e)
        {
            var form = (sender as IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            var pop = form.Controls.OfType<SearchEditLookUpPopup>().FirstOrDefault();
            LayoutControl popupControl = pop.Controls.OfType<LayoutControl>().FirstOrDefault();
            Control clearBtn =
                popupControl.Controls.OfType<Control>().Where(ct => ct.Name == "btClear").FirstOrDefault();
            LayoutControlItem clearLCI = (LayoutControlItem)popupControl.GetItemByControl(clearBtn);
            LayoutControlItem myLCI = (LayoutControlItem)clearLCI.Owner.CreateLayoutItem(clearLCI.Parent);
            LayoutControlItem myrefresh = (LayoutControlItem)clearLCI.Owner.CreateLayoutItem(clearLCI.Parent);

            //btn edit
            var btnadd = new SimpleButton
            {
                Image = Resources.edit_16x16,
                Text = "Add/Edit",
                BorderStyle = BorderStyles.Default
            };
            btnadd.Click += btnadd_Click;

            // BTN load
            var btnreload = new SimpleButton
            {
                Image = Resources.refresh_16x16,
                Text = "Refresh",
                BorderStyle = BorderStyles.Default
            };
            btnreload.Click += btnreload_Click;
            var edit = sender as SearchLookUpEdit;
            var popupForm = edit.GetPopupEditForm();
            popupForm.KeyPreview = true;
            popupForm.KeyUp -= txt_KeyUp;
            popupForm.KeyUp += txt_KeyUp;
            if (checkbtn)
            {
                myLCI.Control = btnadd;
                myLCI.Move(clearLCI, InsertType.Left);
                myrefresh.Control = btnreload;
                myrefresh.Move(myLCI, InsertType.Left);

                checkbtn = false;
            }
        }

        private bool checkbtn = true;

        private void loadslubtnmuccp()
        {
            btnmuccp.DataSource = (from a in new KetNoiDBDataContext().muccps select a);
            checkbtn = true;
        }

        public void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                Biencucbo.QuyenDangChon =
                    (from a in new KetNoiDBDataContext().PhanQuyen2s select a).Single(
                        t => t.TaiKhoan == Biencucbo.phongban && t.ChucNang == "btndmchiphi");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            var frm = new danhmuc.f_dsmuccp();
            frm.ShowDialog();
            loadslubtnmuccp();

        }

        public void btnreload_Click(object sender, EventArgs e)
        {
            loadslubtnmuccp();

        }

        private static void txt_KeyUp(object sender, KeyEventArgs e)
        {
            PopupSearchLookUpEditForm popupForm = sender as PopupSearchLookUpEditForm;
            if (e.KeyData == Keys.Enter)
            {
                GridView view = popupForm.OwnerEdit.Properties.View;
                view.FocusedRowHandle = 0;
                popupForm.OwnerEdit.ClosePopup();
            }
        }

        //}
        //    lbltk.Text = lst.tentk;
        //    var lst = (from a in db.dmtks select a).Single(t => t.matk == txttk.Text);
        //{


        //private void txttk_EditValueChanged(object sender, EventArgs e)
    }
}