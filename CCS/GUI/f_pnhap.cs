using System;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS;
using ControlLocalizer;
using DAL;
using DevExpress.Data;
using DevExpress.Utils.Win;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using GUI.Properties;
using Lotus;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Repository;
using System.Text;
using DevExpress.XtraEditors.Popup;
using System.Runtime.InteropServices;
using DevExpress.Utils.Extensions;
using GUI.theodoitt.Chiphivattu;

namespace GUI
{
    public partial class f_pnhap : Form
    {
        private KetNoiDBDataContext db = new KetNoiDBDataContext();
        private readonly t_pnhap pnct = new t_pnhap();
        private string _mact = "";
        private bool _duyet = false;
        public f_pnhap()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            var lst = from a in db.sanphams select new { a.id, a.tensp, a.dvt };
            if (lst == null) return;

            btnmasp1.DataSource = _tTodatatable.addlst(lst.ToList());
            rstensp.DataSource = btnmasp1.DataSource;
            rsdvt.DataSource = btnmasp1.DataSource;

            txttiente.Properties.DataSource = new KetNoiDBDataContext().tientes;

            txttygia.Properties.Mask.EditMask = "n";
            btncongviec1.DataSource = new KetNoiDBDataContext().congviecs;
            txtiddt.Properties.DataSource = new KetNoiDBDataContext().doituongs;
            txtloainhap.Properties.DataSource = new KetNoiDBDataContext().nguoncaps;

            var lst2 = (from a in db.vanbandens
                        join d in db.donvis on a.iddv equals d.id
                        //where a.iddv == Biencucbo.donvi
                        select new
                        {
                            a.id,
                            a.ngaynhan,
                            a.sovb,
                            a.noidung
                        }).ToList();
            slulink.Properties.DataSource = _tTodatatable.addlst(lst2.ToList());
            txtlinkgoc.Properties.DataSource = _tTodatatable.addlst(lst2.ToList());

            //lay quyen
            //var quyen1 =
            //    db.PhanQuyen2s.FirstOrDefault(
            //        p => p.TaiKhoan == Biencucbo.phongban && p.ChucNang == "PhieuNhap_DuyetHoSo");

            //if (quyen1 == null)
            //{
            //    quyen1 = new PhanQuyen2();
            //    quyen1.TaiKhoan = Biencucbo.phongban;
            //    quyen1.ChucNang = "PhieuNhap_DuyetHoSo";

            //    quyen1.Xem = quyen1.Them = quyen1.Sua = quyen1.Xoa = false;

            //    db.PhanQuyen2s.InsertOnSubmit(quyen1);
            //    db.SubmitChanges();
            //}
            //btnduyet.Enabled = (bool)quyen1.Xem;
        }

        //load
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

        private string layttnd(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().accounts select a).Single(t => t.id == id);
               return  lst.name;
            }
            catch (Exception ex)
            {
                return  "";
            }
        }
        public void duyethd()
        {
          
            var lst3 = (from dt in new KetNoiDBDataContext().duyeths where dt.id == txtid.Text select dt).ToList();
            if (lst3.Count() != 0)
            {
                var lst4 = (from a in new KetNoiDBDataContext().duyeths select a).First(t => t.id == txtid.Text);
                if (lst4.T == true)
                {
                    btnduyet.Glyph = Resources.folder_full_accept_icon;
                   btnnoidungduyet.Caption = "Người Lập: " + lst4.iduser + "-" + layttnd(lst4.iduser) + ".Ghi chú: " + lst4.ghichu;

                }
                else if (lst4.T == false)
                {
                    btnduyet.Glyph = Resources.folder_full_delete_icon;
                    btnnoidungduyet.Caption = "Người Lập: " + lst4.iduser + "-" + layttnd(lst4.iduser) + ".Ghi chú: " + lst4.ghichu;
                }
            }
            else
            {
                btnduyet.Glyph = Resources.folder_full_icon;
                btnnoidungduyet.Caption = "Chưa duyệt";

            }
        }
        private void laychuyentien()
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().theodoitt_cpvts where a.idpn == txtid.Text select a);
                if (lst.Count() > 0)
                {
                    txtdachuyen.Text = lst.Sum(t => t.sotienchuyen).ToString();
                    txtconlai.Text =
                        (double.Parse(colsotien.SummaryItem.SummaryValue.ToString()) - lst.Sum(t => t.sotienchuyen))
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
        public void load()
        {
            db = new KetNoiDBDataContext();
            Biencucbo.hdpn = 2;
            txt1.Enabled = false;

            //btn
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
            txttiente.ReadOnly = true;
            txttygia.ReadOnly = true;

            // Enable
            txtghichu.ReadOnly = true;
            txtsohd.ReadOnly = true;
            txtngaynhap.ReadOnly = true;
            txtiddt.ReadOnly = true;
            slulink.ReadOnly = true;
            txtlinkgoc.ReadOnly = true;
            txtloainhap.ReadOnly = true;

            gridView1.OptionsBehavior.Editable = false;

            try
            {
                if (Biencucbo.xembc)
                {
                    var lst1 =
                        (from b in db.pnhaps where b.idct == _mact select b).Single(t => t.id == Biencucbo.ma);
                            
                    if (lst1 == null) return;

                    gcchitiet.DataSource = lst1.pnhapcts;

                    txtid.Text = lst1.id;
                    laychuyentien();
                    txtidnv.Text = lst1.idnv;
                    layttnhanvien(lst1.idnv);
                    txtdv.Text = lst1.iddv;
                    txtngaynhap.DateTime = DateTime.Parse(lst1.ngaynhap.ToString());
                    txtiddt.Text = lst1.iddt;
                    slulink.Text = lst1.link;
                    txtlinkgoc.Text = lst1.linkgoc;
                    try
                    {
                        var lst2 = (from a in db.doituongs select a).Single(t => t.id == txtiddt.Text);
                        lbltendt.Text = lst2.ten;
                        txtdiachi.Text = lst2.diachi;
                    }
                    catch (Exception)
                    {
                    }
                    txttiente.Text = lst1.tiente;
                    txttygia.Text = lst1.tygia.ToString();
                    txtghichu.Text = lst1.ghichu;
                    txtsohd.Text = lst1.sohd;
                    txt1.Text = lst1.so.ToString();
                    txtloainhap.Text = lst1.idnc;
                    try
                    {
                        var lst2 = (from a in db.nguoncaps select a).Single(t => t.id == txtloainhap.Text);
                        lblnc.Text = lst2.tennguoncap;
                    }
                    catch
                    {
                    }
                    Biencucbo.xembc = false;
                    duyethd();
                }
                else
                {
                    var lst =
                    (from a in db.pnhaps where a.iddv == Biencucbo.donvi && a.idct == _mact select a.so).Max();
                    var lst1 =
                        (from b in db.pnhaps where b.iddv == Biencucbo.donvi && b.idct == _mact select b)
                            .FirstOrDefault(t => t.so == lst);
                    if (lst1 == null) return;

                    gcchitiet.DataSource = lst1.pnhapcts;

                    txtid.Text = lst1.id;
                    laychuyentien();
                    txtidnv.Text = lst1.idnv;
                    layttnhanvien(lst1.idnv);
                    txtdv.Text = lst1.iddv;
                    txtngaynhap.DateTime = DateTime.Parse(lst1.ngaynhap.ToString());
                    txtiddt.Text = lst1.iddt;
                    slulink.Text = lst1.link;
                    txtlinkgoc.Text = lst1.linkgoc;
                    try
                    {
                        var lst2 = (from a in db.doituongs select a).Single(t => t.id == txtiddt.Text);
                        lbltendt.Text = lst2.ten;
                        txtdiachi.Text = lst2.diachi;
                    }
                    catch (Exception)
                    {
                    }
                    txttiente.Text = lst1.tiente;
                    txttygia.Text = lst1.tygia.ToString();
                    txtghichu.Text = lst1.ghichu;
                    txtsohd.Text = lst1.sohd;
                    txt1.Text = lst1.so.ToString();
                    txtloainhap.Text = lst1.idnc;
                    try
                    {
                        var lst2 = (from a in db.nguoncaps select a).Single(t => t.id == txtloainhap.Text);
                        lblnc.Text = lst2.tennguoncap;
                    }
                    catch
                    {
                    }

                    duyethd();
                }
            }
            catch
            {
            }
        }

        //phân quyền
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

        private void f_pnhap_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            Text = "Phiếu Nhập Vật Tư - Công trình: " +
                   (from a in db.congtrinhs select a).Single(t => t.id == Biencucbo.mact).tencongtrinh;

            changeFont.Translate(this);
            changeFont.Translate(barManager1);

            _mact = Biencucbo.mact;
            load();
        }

        // Mở
        private void mo()
        {

            Biencucbo.mamo = _mact;
            var frm = new f_PN();
            frm.ShowDialog();
            if (Biencucbo.getID == 1)
            {
                //load pnhap
                try
                {
                    var lst = (from pn in db.pnhaps select new { a = pn }).FirstOrDefault(x => x.a.id == Biencucbo.ma);
                    if (lst == null) return;
                    txtid.Text = lst.a.id;
                    txtidnv.Text = lst.a.idnv;
                    layttnhanvien(lst.a.idnv);
                    txtdv.Text = lst.a.iddv;
                    txtngaynhap.DateTime = DateTime.Parse(lst.a.ngaynhap.ToString());
                    txtiddt.Text = lst.a.iddt;
                    slulink.Text = lst.a.link;
                    txtlinkgoc.Text = lst.a.linkgoc;
                    txtghichu.Text = lst.a.ghichu;
                    txtsohd.Text = lst.a.sohd;
                    txt1.Text = lst.a.so.ToString();
                    txtloainhap.Text = lst.a.idnc;
                    var lst2 = (from a in db.nguoncaps select a).Single(t => t.id == txtloainhap.Text);
                    lblnc.Text = lst2.tennguoncap;
                    gcchitiet.DataSource = lst.a.pnhapcts;
                    txttiente.Text = lst.a.tiente;
                    laychuyentien();
                    txttygia.Text = lst.a.tygia.ToString();
                    duyethd();
                }
                catch
                {
                }

                //btn
                btnnew.Enabled = true;
                btnsua.Enabled = true;
                btnLuu.Enabled = false;
                btnmo.Enabled = true;
                btnxoa.Enabled = true;
                btnin.Enabled = true;
                btnreload.Enabled = false;
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
            Biencucbo.hdpn = 0;
            txtid.DataBindings.Clear();
            txtid.Text = "YYYYY";

            gcchitiet.DataSource = new KetNoiDBDataContext().Views_pnhaps;
            laychuyentien();
            for (var i = 0; i <= gridView1.DataRowCount - 1; i++)
            {
                gridView1.DeleteRow(i);
            }
            gridView1.AddNewRow();

            txtdv.Text = Biencucbo.donvi;
            txtngaynhap.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            txtphongban.Text = Biencucbo.phongban;
            txtidnv.Text = Biencucbo.idnv.Trim();
            lbltennv.Text = Biencucbo.ten;
            txtngaynhap.Focus();
            txtiddt.Text = "";
            slulink.Text = "";
            txtlinkgoc.Text = "";
            lbltendt.Text = "";
            txtloainhap.Text = "";
            txtghichu.Text = "";
            txtsohd.Text = "";
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
            txtsohd.ReadOnly = false;
            txtngaynhap.ReadOnly = false;
            txtiddt.ReadOnly = false;
            slulink.ReadOnly = false;
            txtlinkgoc.ReadOnly = false;
            txtloainhap.ReadOnly = false;
            txttiente.ReadOnly = false;
            txttygia.ReadOnly = false;
            gridView1.OptionsBehavior.Editable = true;
        }
        private void btnnew_ItemClick(object sender, ItemClickEventArgs e)
        {
            them();
        }


        //Lưu
        public void luu()
        {
            var hs = new t_history();
            var td = new t_tudong();
            gridView1.PostEditor();
            gridView1.UpdateCurrentRow();
            var check1 = 0;
            if (txtngaynhap.Text == "" || txtiddt.Text == "" || txtloainhap.Text == "" || txttiente.Text == "" ||
                txttygia.Text == "")
            {
                MsgBox.ShowWarningDialog("Thông tin chưa đầy đủ - Vui lòng kiểm tra lại!");
            }
            else
            {
                try
                {
                    for (var i = 0; i <= gridView1.RowCount - 1; i++)
                    {
                        if (gridView1.GetRowCellDisplayText(i, "soluong") == "" ||
                            gridView1.GetRowCellDisplayText(i, "dongia") == "")
                        {
                            check1 = 1;
                        }
                        else if (gridView1.GetRowCellDisplayText(i, "idsanpham") == "")
                        {
                            check1 = 2;
                        }
                    }
                }
                catch (Exception)
                {
                }

                if (check1 == 1)
                {
                    MsgBox.ShowErrorDialog("Thông tin chi tiết sản phẩm chưa đầy đủ - Vui Lòng Kiểm Tra Lại");
                }
                else if (check1 == 2)
                {
                    MsgBox.ShowErrorDialog("Mã sản phẩm không được để trống - Vui Lòng Kiểm Tra Lại");
                }
                else
                {
                    if (Biencucbo.hdpn == 0)
                    {
                        db = new KetNoiDBDataContext();
                        try
                        {
                            var check = "PN" + Biencucbo.donvi.Trim();
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
                            pnct.moipn(txtid.Text, txtngaynhap.DateTime, txtiddt.Text, txtdv.Text, txtidnv.Text,
                                txtghichu.Text, Convert.ToInt32(txt1.Text), txtloainhap.Text, txttiente.Text,
                                double.Parse(txttygia.Text), _mact, slulink.Text, txtsohd.Text,txtlinkgoc.Text);

                            try
                            {
                                gridView1.ClearSorting();
                                for (var i = 0; i <= gridView1.RowCount - 1; i++)
                                {
                                    gridView1.SetRowCellValue(i, "idpn", txtid.Text);
                                    gridView1.SetRowCellValue(i, "id", txtid.Text + i);
                                    gridView1.SetRowCellValue(i, "stt", i.ToString());
                                    pnct.moict(gridView1.GetRowCellValue(i, "idsp").ToString(),
                                        gridView1.GetRowCellValue(i, "diengiai").ToString(),
                                        double.Parse(gridView1.GetRowCellValue(i, "soluong").ToString()),
                                        double.Parse(gridView1.GetRowCellValue(i, "dongia").ToString()),
                                        gridView1.GetRowCellValue(i, "idcv").ToString(),
                                        double.Parse(gridView1.GetRowCellValue(i, "thanhtien").ToString()),
                                        gridView1.GetRowCellValue(i, "idpn").ToString(),
                                        gridView1.GetRowCellValue(i, "id").ToString(),
                                        double.Parse(gridView1.GetRowCellValue(i, "nguyente").ToString()),
                                        int.Parse(gridView1.GetRowCellValue(i, "stt").ToString()), double.Parse(gridView1.GetRowCellValue(i, "catgiam").ToString()), gridView1.GetRowCellValue(i, "lydocg").ToString());
                                }
                                gridView1.Columns["stt"].SortOrder = ColumnSortOrder.Ascending;
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
                            txtsohd.ReadOnly = true;
                            txtngaynhap.ReadOnly = true;
                            txtiddt.ReadOnly = true;
                            slulink.ReadOnly = true;
                            txtlinkgoc.ReadOnly = true;
                            txtloainhap.ReadOnly = true;
                            txttiente.ReadOnly = true;
                            txttygia.ReadOnly = true;
                            gridView1.OptionsBehavior.Editable = false;
                            Biencucbo.hdpn = 2;
                            // History
                            hs.add(txtid.Text, "Thêm mới chứng từ");
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        try
                        {
                            pnct.suapn(txtid.Text, DateTime.Parse(txtngaynhap.Text), txtiddt.Text, txtghichu.Text,
                                int.Parse(txt1.Text), txtloainhap.Text, txttiente.Text, double.Parse(txttygia.Text),
                                slulink.Text, txtsohd.Text,txtlinkgoc.Text);
                            //sua ct
                            LuuPhieu();
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show(ex.ToString());
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
                        txtsohd.ReadOnly = true;
                        txtngaynhap.ReadOnly = true;
                        txtiddt.ReadOnly = true;
                        slulink.ReadOnly = true;
                        txtlinkgoc.ReadOnly = true;
                        txtloainhap.ReadOnly = true;
                        txttiente.ReadOnly = true;
                        txttygia.ReadOnly = true;
                        gridView1.OptionsBehavior.Editable = false;
                        Biencucbo.hdpn = 2;
                        hs.add(txtid.Text, "Sửa chứng từ");
                    }
                }
            }
        }

        private void btnLuu_ItemClick(object sender, ItemClickEventArgs e)
        {


            luu();

        }

        private bool LuuPhieu()
        {
            // kiem tra truoc khi luu
            layoutControl1.Validate();
            gridView1.CloseEditor();
            gridView1.UpdateCurrentRow();
            try
            {
                var c1 = db.pnhaps.Context.GetChangeSet();

                /* db.pnhaps.Context.SubmitChanges(); */
                // dang báo lỗi là vi không có thay đổi. kiem tra neu có thay doi hãy submit

                db.pnhapcts.Context.SubmitChanges();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return false;
            }


            return true;
        }

        //Sửa
        private void sua()
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

            try

            {
                var lst = (from pn in db.pnhaps select pn).FirstOrDefault(x => x.id == txtid.Text);
                if (lst == null) return;
                gcchitiet.DataSource = lst.pnhapcts;
                //enabled
                txtghichu.ReadOnly = false;
                txtsohd.ReadOnly = false;
                txtngaynhap.ReadOnly = false;
                txtiddt.ReadOnly = false;
                slulink.ReadOnly = false;
                txtlinkgoc.ReadOnly = false;
                txtloainhap.ReadOnly = false;
                txttiente.ReadOnly = false;
                txttygia.ReadOnly = false;
                laychuyentien();
                gridView1.OptionsBehavior.Editable = true;
                // btn
                btnsua.Enabled = false;
                btnLuu.Enabled = true;
                btnmo.Enabled = false;
                btnnew.Enabled = false;
                btnxoa.Enabled = false;
                btnin.Enabled = false;
                btnreload.Enabled = true;

                Biencucbo.hdpn = 1;
            }
            catch
            {
            }
        }
        private void btnsua_ItemClick(object sender, ItemClickEventArgs e)
        {

            sua();

            //load 
        }

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
                var hs = new t_history();

                try
                {
                    hs.add(txtid.Text, "Xóa chứng từ");
                    //tk.xoa(txtid.Text);
                    for (var i = gridView1.DataRowCount - 1; i >= 0; i--)
                    {
                        pnct.xoact(gridView1.GetRowCellValue(i, "id").ToString());
                        gridView1.DeleteRow(i);
                    }
                    pnct.xoaPN(txtid.Text);

                    ////btn
                    btnmo.Enabled = true;
                    btnnew.Enabled = true;
                    btnLuu.Enabled = false;
                    btnsua.Enabled = true;
                    btnxoa.Enabled = true;
                    btnin.Enabled = true;
                    btnreload.Enabled = false;

                    //enabled
                    txtghichu.ReadOnly = true;
                    txtsohd.ReadOnly = true;
                    txtngaynhap.ReadOnly = true;
                    txtiddt.ReadOnly = true;
                    slulink.ReadOnly = true;
                    txtlinkgoc.ReadOnly = true;
                    txtloainhap.ReadOnly = true;
                    txttiente.ReadOnly = true;
                    txttygia.ReadOnly = true;
                    gridView1.OptionsBehavior.Editable = false;
                    //gcchitiet.DataSource = new DAL.KetNoiDBDataContext().View_pnhapcts;
                    txtdv.Text = "";
                    txtid.Text = "";
                    txtidnv.Text = "";
                    txtdv.Text = "";
                    txtngaynhap.Text = "";
                    txtiddt.Text = "";
                    slulink.Text = "";
                    txtlinkgoc.Text = "";
                    txtghichu.Text = "";
                    txtsohd.Text = "";
                    txt1.Text = "";
                    txtloainhap.Text = "";
                    lbltendt.Text = "";
                    lbltennv.Text = "";
                    txtphongban.Text = "";
                    txttiente.Text = "";
                    txttygia.Text = "";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.ToString());
                }
            }
        }

        //Xóa
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
        private void btnin_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        //reload

        private void reload()
        {
            if (Biencucbo.hdpn == 1)
            {
             
                try
                {
                    var lst = (from pn in new KetNoiDBDataContext().pnhaps select pn).FirstOrDefault(x => x.id == txtid.Text);

                    if (lst == null) return;

                   // db.Refresh(RefreshMode.OverwriteCurrentValues, db.pnhapcts);


                    txtidnv.Text = lst.idnv;
                    layttnhanvien(lst.idnv);
                    txtdv.Text = lst.iddv;
                    txtngaynhap.DateTime = DateTime.Parse(lst.ngaynhap.ToString());
                    txtiddt.Text = lst.iddt;
                    slulink.Text = lst.link;
                    txtlinkgoc.Text = lst.linkgoc;
                    txtghichu.Text = lst.ghichu;
                    txtsohd.Text = lst.sohd;
                    txt1.Text = lst.so.ToString();
                    txtloainhap.Text = lst.idnc;
                    var lst2 = (from a in db.nguoncaps select a).Single(t => t.id == lst.idnc);
                    lblnc.Text = lst2.tennguoncap;
                    txttiente.Text = lst.tiente;
                    txttygia.Text = lst.tygia.ToString();
                    gcchitiet.DataSource = lst.pnhapcts;


                    laychuyentien();
                    txtghichu.ReadOnly = true;
                    txtsohd.ReadOnly = true;
                    txtngaynhap.ReadOnly = true;
                    txtiddt.ReadOnly = true;
                    slulink.ReadOnly = true;
                    txtlinkgoc.ReadOnly = true;
                    txtloainhap.ReadOnly = true;
                    txttiente.ReadOnly = true;
                    txttygia.ReadOnly = true;
                    gridView1.OptionsBehavior.Editable = false;
                }

                catch
                {
                }

                //btn
                btnnew.Enabled = true;
                btnsua.Enabled = true;
                btnLuu.Enabled = false;
                btnmo.Enabled = true;
                btnxoa.Enabled = true;
                btnin.Enabled = true;

                gridView1.OptionsBehavior.Editable = false;
            }

            else if (Biencucbo.hdpn == 0)
            {
                load();
                ////btn
                btnnew.Enabled = true;
                btnsua.Enabled = true;
                btnLuu.Enabled = false;
                btnmo.Enabled = true;
                btnxoa.Enabled = true;
                btnin.Enabled = true;
                btnreload.Enabled = false;

                gridView1.OptionsBehavior.Editable = false;
            }
            Biencucbo.hdpn = 2;
        }
        private void btnload_ItemClick(object sender, ItemClickEventArgs e)
        {
            reload();
        }


        // thay đổi
        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            gridView1.PostEditor();
            if (e.Column.FieldName == "soluong" || e.Column.FieldName == "dongia")
            {
                try
                {

                    gridView1.SetFocusedRowCellValue("nguyente",
                        double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString()) *
                        double.Parse(gridView1.GetFocusedRowCellValue("dongia").ToString()));
                }
                catch (Exception)
                {
                    //MessageBox.Show(ex.ToString());
                }
            }
            else if (e.Column.FieldName == "nguyente")
            {
                try

                {
                    gridView1.SetFocusedRowCellValue("thanhtien",
                        (double.Parse(gridView1.GetFocusedRowCellValue("nguyente").ToString()) -
                        double.Parse(gridView1.GetFocusedRowCellValue("catgiam").ToString()) )*
                        double.Parse(txttygia.Text));
                    gridView1.PostEditor();
                    gridView1.UpdateCurrentRow();
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
                    gridView1.SetFocusedRowCellValue("thanhtien",
                        (double.Parse(gridView1.GetFocusedRowCellValue("nguyente").ToString()) -
                        double.Parse(gridView1.GetFocusedRowCellValue("catgiam").ToString())) *
                        double.Parse(txttygia.Text));
                    gridView1.PostEditor();
                    gridView1.UpdateCurrentRow();
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
            //if (Biencucbo.hdpn != 2)
            //{
            //    if (e.KeyCode == Keys.Insert)
            //    {
            //        gridView1.AddNewRow();
            //    }
            //    else if (e.KeyCode == Keys.Delete)
            //    {
            //        if (Biencucbo.hdpn == 1)
            //        {
            //            try
            //            {
            //                var ct =
            //                    (from c in db.pnhapcts select c).Single(
            //                        x => x.id == gridView1.GetFocusedRowCellValue("id").ToString());
            //                db.pnhapcts.DeleteOnSubmit(ct);
            //            }
            //            catch
            //            {
            //            }
            //        }
            //        gridView1.DeleteRow(gridView1.FocusedRowHandle);
            //    }
            //}
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

        private void btnthue1_EditValueChanged(object sender, EventArgs e)
        {
            //gridView1.PostEditor();
        }

        //Dòng mới
        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            if (Biencucbo.hdpn == 1)
            {
                var ct = gridView1.GetFocusedRow() as pnhapct;
                if (ct == null) return;

                int i = 0, k = 0;
                string a;

                try
                {
                    k = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.DataRowCount - 1, "stt").ToString());
                    k = k + 1;
                  
                }
                catch (Exception ex)
                {
                    
                }
                a = txtid.Text + k;

                for (i = 0; i <= gridView1.DataRowCount - 1;)
                {
                    if (a == gridView1.GetRowCellValue(i, "id").ToString())
                    {
                        k = k + 1;
                        a = txtid.Text + k;
                        i = 0;
                    }
                    else
                    {
                        i++;}
                }

                ct.idpn = txtid.Text;
                ct.soluong = 0;
                ct.dongia = 0;
                ct.catgiam = 0;
                ct.lydocg = "";
                ct.diengiai = "";
                ct.idcv = "";
                ct.thanhtien = 0;
                ct.id = a;
                ct.stt = Convert.ToInt32(ct.id.Substring(ct.idpn.Length, ct.id.Length - ct.idpn.Length));
                ct.nguyente = 0;
            }

            else
            {
                gridView1.SetFocusedRowCellValue("diengiai", "");
                gridView1.SetFocusedRowCellValue("soluong", 0);
                gridView1.SetFocusedRowCellValue("dongia", 0);
                gridView1.SetFocusedRowCellValue("catgiam", 0);
                gridView1.SetFocusedRowCellValue("idcv", "");
                gridView1.SetFocusedRowCellValue("lydocg", "");

            }
        }

        //Xóa dòng
        private void gridView1_RowDeleted(object sender, RowDeletedEventArgs e)
        {
        }

        private void print()
        {
            try
            {
                db = new KetNoiDBDataContext();
                var lstsp = from a in db.pnhapcts
                            join b in db.sanphams on a.idsp equals b.id
                            select new
                            {
                                a.idpn,
                                a.idsp,
                                b.tensp,
                                a.soluong,
                                a.dongia,
                                a.thanhtien,
                                a.nguyente,
                                a.diengiai,
                                b.dvt,
                                a.catgiam,
                                a.lydocg,
                                
                            };

                var lst = from a in db.pnhaps
                          join b in lstsp on a.id equals b.idpn
                          join c in db.congtrinhs on a.idct equals c.id
                          join d in db.accounts on a.idnv equals d.id
                          join f in db.nguoncaps on a.idnc equals f.id
                          join g in db.doituongs on a.iddt equals g.id
                          where a.id == txtid.Text
                          select new
                          {
                              c.tencongtrinh,
                              a.id,
                              a.ngaynhap,
                              d.name,
                              loainhap = f.tennguoncap,
                              g.ten,
                              a.ghichu,
                              a.tiente,
                              a.tygia,
                              idsanpham = b.idsp,
                              b.tensp,
                              b.soluong,
                              b.dongia,
                              b.catgiam,
                              b.lydocg,
                              b.diengiai,
                              b.dvt,
                              b.thanhtien,
                              b.nguyente
                          };
                var xtra = new r_pnhap();
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


        private void f_pnhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Biencucbo.hdpn != 2)
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
            if (!gridView1.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
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
                    BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView1); }));
                    //Tăng kích thước nếu Text vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", e.RowHandle * -1); //Nhân -1 để đánh lại số thứ tự tăng dần
                var _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                var _Width = Convert.ToInt32(_Size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView1); }));
            }
        }

        private bool cal(int _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }

        private void btnthue1_EditValueChanged_1(object sender, EventArgs e)
        {
            gridView1.PostEditor();
        }

        private void rsearchtiente1_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void btnmasp1_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.PostEditor();
        }

        private void txttiente_EditValueChanged(object sender, EventArgs e)
        {
            var lst = (from a in new KetNoiDBDataContext().tientes select a).FirstOrDefault(t => t.tiente1 == txttiente.Text);
            txttygia.Text = lst.tygia.ToString();


            for (var i = 0; i <= gridView1.RowCount - 1; i++)
            {
                try
                {
                    gridView1.SetRowCellValue(i, "thanhtien",
                        (double.Parse(gridView1.GetRowCellValue(i, "nguyente").ToString()) -
                        double.Parse(gridView1.GetRowCellValue(i, "catgiam").ToString())  )* double.Parse(txttygia.Text));
                    gridView1.PostEditor();
                    gridView1.UpdateCurrentRow();
                    laychuyentien();
                }
                catch
                {
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

        private void txtloainhap_Popup(object sender, EventArgs e)
        {
            var popupControl = sender as IPopupControl;
            var button = new SimpleButton
            {
                Image = Resources.icons8_Add_File_16,
                Text = "Add",
                BorderStyle = BorderStyles.NoBorder
            };

            button.Click += button2_Click;

            button.Location = new Point(5, popupControl.PopupWindow.Height - button.Height - 5);
            popupControl.PopupWindow.Controls.Add(button);
            button.BringToFront();
        }

        public void button2_Click(object sender, EventArgs e)
        {
            var frm = new f_themnguoncap();
            frm.ShowDialog();
            txtloainhap.Properties.DataSource = new KetNoiDBDataContext().nguoncaps;
        }

        private void txttiente_Popup(object sender, EventArgs e)
        {
            var popupControl = sender as IPopupControl;
            var button = new SimpleButton
            {
                Image = Resources.icons8_Add_File_16,
                Text = "Edit",
                BorderStyle = BorderStyles.NoBorder
            };

            button.Click += button3_Click;

            button.Location = new Point(5, popupControl.PopupWindow.Height - button.Height - 5);
            popupControl.PopupWindow.Controls.Add(button);
            button.BringToFront();
        }

        public void button3_Click(object sender, EventArgs e)
        {
            var frm = new f_tiente();
            frm.ShowDialog();
            txttiente.Properties.DataSource = new KetNoiDBDataContext().tientes;
        }

        private void btndmvt_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new f_sanpham();
            frm.ShowDialog();

            var lst = from a in db.sanphams select new { a.id, a.tensp, a.dvt };
            if (lst == null) return;
            btnmasp1.DataSource = _tTodatatable.addlst(lst.ToList());
            rsearchTenSP.DataSource = btnmasp1.DataSource;
            btndvt.DataSource = btnmasp1.DataSource;
        }

        private void txtloainhap_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var lst = (from a in db.nguoncaps select a).Single(t => t.id == txtloainhap.Text);
                lblnc.Text = lst.tennguoncap;
            }
            catch
            {
                lblnc.Text = "";
            }
        }

        private void btnduyet_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Biencucbo.hdpn == 2)
            {
                if (_duyet)
                {
                    var hs = new t_history();
                    if (Biencucbo.hdpn == 2)
                    {
                        Biencucbo.idduyet = txtid.Text;
                        Biencucbo.loaiduyet = "Nhập Vật Tư";
                        var frm = new f_duyeths();
                        frm.ShowDialog();
                        duyethd();
                        hs.add(txtid.Text, "Duyệ Nhập Vật Tư");
                    }
                }
                else
                {
                    XtraMessageBox.Show("Bạn chưa được cấp quyền duyệt hồ sơ");
                }
            }
        }

        private void gridView1_GotFocus(object sender, EventArgs e)
        {
            //if (/*readyToOperate &&*/ gridView1.ActiveEditor is CalcEdit)
            //{
            //    StringBuilder charPressed = new StringBuilder(256);
            //    //ToUnicode((uint)e.KeyCode, 0, new byte[256], charPressed, charPressed.Length, 0);
            //    CalcEdit edit = (gridView1.ActiveEditor as CalcEdit);
            //    edit.ShowPopup();
            //    PopupCalcEditForm frm = (edit as IPopupControl).PopupWindow as PopupCalcEditForm;
            //    CalculatorButton button = frm.Controls.OfType<CalculatorButton>().Where((sb) => sb.Text == charPressed.ToString()).FirstOrDefault();
            //    button.PerformClick();
            //    readyToOperate = false;
            //}
            //else
            //    readyToOperate = false; ;
        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private double so = 0;
        private void gcchitiet_EditorKeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Add)
            {
                gridView1.PostEditor();

                if (gridView1.FocusedColumn.FieldName == "soluong")
                {
                    Biencucbo.value = double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString());
                    f_value frm = new f_value();
                    frm.ShowDialog();
                    gridView1.SetFocusedRowCellValue("soluong", Biencucbo.value);
                }
                if (gridView1.FocusedColumn.FieldName == "dongia")
                {
                    Biencucbo.value = double.Parse(gridView1.GetFocusedRowCellValue("dongia").ToString());
                    f_value frm = new f_value();
                    frm.ShowDialog();
                    gridView1.SetFocusedRowCellValue("dongia", Biencucbo.value);

                }
            }

        }

        private bool readyToOperate = false;
        private bool edited = false;
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int ToUnicode(uint virtualKeyCode, uint scanCode, byte[] keyboardState, StringBuilder receivingBuffer, int bufferSize, uint flags);

        private void gcchitiet_EditorKeyUp(object sender, KeyEventArgs e)
        {

        }

        private void f_pnhap_KeyDown(object sender, KeyEventArgs e)
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
                else if (Biencucbo.hdpn != 2)
                {

                    if (e.KeyCode == Keys.Delete)
                    {
                        if (Biencucbo.hdpn == 1)
                        {
                            try
                            {
                                var ct =
                                    (from c in db.pnhapcts select c).Single(
                                        x => x.id == gridView1.GetFocusedRowCellValue("id").ToString());
                                db.pnhapcts.DeleteOnSubmit(ct);
                            }
                            catch
                            {
                            }

                        }
                        gridView1.DeleteRow(gridView1.FocusedRowHandle);
                    }
                }
            }

            else if (e.KeyCode == Keys.F5)
            {
                if (btnload.Enabled)
                    reload();
            }
            else if (e.KeyCode == Keys.F1)
            {
                var lst = from a in db.sanphams select new { a.id, a.tensp, a.dvt };
                if (lst == null) return;
                btnmasp1.DataSource = _tTodatatable.addlst(lst.ToList());
                rsearchTenSP.DataSource = btnmasp1.DataSource;
                btndvt.DataSource = btnmasp1.DataSource;
            }

            else if (Biencucbo.hdpn != 2)
            {
                if (e.KeyCode == Keys.Insert)
                {
                    gridView1.PostEditor();
                    gridView1.Focus();
                    gridView1.AddNewRow();
                }
            }
        }

        private void btnchuyentien_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Biencucbo.hdpn == 2 && txtid.Text != string.Empty)
            {
                Biencucbo.ma = txtid.Text;
               theodoitt.Chiphivattu.f_theodoitt_cpvt frm = new f_theodoitt_cpvt();
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
        private void slulink_EditValueChanged(object sender, EventArgs e)
        {
            layttlbllink(slulink.Text);
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
        private void txtlinkgoc_EditValueChanged(object sender, EventArgs e)
        {
            layttlbllinkgoc(txtlinkgoc.Text);
        }
    }
}