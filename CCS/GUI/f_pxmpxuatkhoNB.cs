using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DAL;
using BUS;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraReports.UI;
using GUI.Properties;
using DevExpress.Utils.Win;

namespace GUI
{
    public partial class f_pxmpxuatkhoNB : frmp
    {

        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        t_pxmxuatkhoNB px = new t_pxmxuatkhoNB();
        t_history hs = new t_history();
        t_todatatable _tTodatatable = new t_todatatable();
        DateTime _tempdate;
        private string _idct;
        private int _hdong;
        private int _so;
        private string _key;
        public f_pxmpxuatkhoNB()
        {
            InitializeComponent();
        }


        protected override void load()
        {
            btnsua.Visibility = BarItemVisibility.Never;
            _idct = Biencucbo.mact;
            loaddatadoituong();
            loaddatapt();
          
            loaddatact();
            
            try
            {
                if (Biencucbo.xembc)
                {
                    Biencucbo.xembc = false;
                    loadinfo(Biencucbo.ma);

                }
                else
                {
                    var so = (from a in dbData.pxm_xuatkho_NBs where a.idct == _idct select a.so).Max();
                    if (so == null)
                        return;
                    var lst = (from a in dbData.pxm_xuatkho_NBs where a.idct == _idct select a).Single(t => t.so == so);
                    loadinfo(lst.key);
                    
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        protected override void duyet()
        {

            try
            {
                KetNoiDBDataContext db = new KetNoiDBDataContext();
                var lst = (from a in db.pxm_xuatkho_NBs select a).Single(t => t.key == _key);
                if (lst.duyet != true)
                {
                    if (
                        XtraMessageBox.Show("Bạn có muốn duyệt hồ sơ này không?", "Thông Báo", MessageBoxButtons.YesNo) ==
                        DialogResult.Yes)
                    {
                        lst.duyet = true;
                        db.SubmitChanges();
                        hs.add(txtid.Text, "Duyệt HS");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        protected override void reload()
        {
            try
            {
                if (_hdong == 1)
                    loadinfo(_key);
                else
                {
                    load();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        protected override void mo()
        {
            Biencucbo.mact = _idct;
            f_pxmdsxuatkhoNB frm = new f_pxmdsxuatkhoNB();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                loadinfo(Biencucbo.ma);
            }
        }
        protected override bool duyeths()
        {

            var lst2 = (from a in dbData.pxm_nhapkho_NBs where a.key == _key & a.duyet == true select a);
            if (lst2.Count() > 0)
            {
                lbltinhtrang.Text = "Tình Trạng: Đã Nhập Kho";
            }
            else
            {
                lbltinhtrang.Text = "Tình Trạng: Chưa Nhập Kho";
            }
            



            var lst = (from a in new KetNoiDBDataContext().pxm_xuatkho_NBs where a.key == _key & a.duyet == true select a);

            if (lst.Count() != 0)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void them()
        {
            themtxt();
        }
        private bool LuuPhieu()
        {
            // kiem tra truoc khi luu
            layoutControl1.Validate();
            gv.CloseEditor();
            gv.PostEditor();
            gv.UpdateCurrentRow();
            try
            {
                var c1 = dbData.pxm_xuatkhoct_NBs.Context.GetChangeSet();
                /* db.pnhaps.Context.SubmitChanges(); */
                // dang báo lỗi là vi không có thay đổi. kiem tra neu có thay doi hãy submit

                dbData.pxm_xuatkhoct_NBs.Context.SubmitChanges();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return false;
            }


            return true;
        }
        protected override bool luu()
        {
            gv.PostEditor();
            gv.UpdateCurrentRow();
            try
            {

                // kiểm tra tồn kho trước khi lưu
                string _mavt;
                double _soluong;
                for (int j = 0; j < gv.DataRowCount; j++)
                {
                    _mavt = gv.GetRowCellValue(j, "idsp").ToString();
                    _soluong = double.Parse(gv.GetRowCellValue(j, "soluong").ToString());
                    for (int i = 0; i < gv.DataRowCount; i++)
                    {
                        if (i != j)
                            if (gv.GetRowCellValue(i, "idsp").ToString() == _mavt)
                            {
                                _soluong = _soluong + double.Parse(gv.GetRowCellValue(i, "soluong").ToString());
                            }
                    }
                    string abc = "";
                    if (txtid.Text != string.Empty || txtid.Text != "YYYY")
                        abc = txtid.Text;
                    if (kiemtratonkho(_mavt, _soluong, abc) == false)
                    {
                        return false;
                    }}


                if (txtid.Text == string.Empty || txtiddt.Text == string.Empty || txtngayxuat.Text == string.Empty || txtctnhap.Text == string.Empty)
                {
                    XtraMessageBox.Show("Thông tin chưa đầy đủ không thể lưu, vui lòng kiểm tra lại");
                    return false;
                }
                for (int i = 0; i < gv.DataRowCount; i++)
                {

                    string a = gv.GetRowCellValue(i, "idsp").ToString();
                    if (gv.GetRowCellValue(i, "idsp").ToString() == "")
                    {
                        XtraMessageBox.Show("Không được để trống vật tư, vui lòng kiểm tra lại");
                        return false;
                    }
                }
                if (_hdong == 0)
                {

                    int mact = int.Parse(_idct.Substring(4, _idct.Length - 4));

                    string macheck = "XNB" + mact;

                    txtid.Text = custom.matutang(macheck);
                    _so = Biencucbo.so;
                    px.them(_key, txtid.Text, txtiddv.Text, txtngayxuat.DateTime, txtidnv.Text, txtiddt.Text, _idct, txtdiengiai.Text, _so, txtctnhap.Text);
                    LuuPhieu();
                    hs.add(txtid.Text, "Thêm Phiếu Xuất kho Nội Bộ (PXM)");

                    mact = int.Parse(txtctnhap.Text.Substring(4, _idct.Length - 4));
                    macheck = "NNB" + mact;
                    string idnew = custom.matutang(macheck);
                    int sonew = Biencucbo.so;
                    px.themnhap(_key, idnew, "", txtngayxuat.DateTime, txtiddt.Text, txtctnhap.Text, "", sonew, _idct);
                    for (int i = 0; i < gv.DataRowCount; i++)
                    {
                        px.themnhapct(gv.GetRowCellValue(i, "key").ToString(), gv.GetRowCellValue(i, "keypx").ToString(), gv.GetRowCellValue(i, "idsp").ToString(), gv.GetRowCellValue(i, "ghichu").ToString(), double.Parse(gv.GetRowCellValue(i, "soluong").ToString()), double.Parse(gv.GetRowCellValue(i, "soluong").ToString()), 1.00 - 1.00, int.Parse(gv.GetRowCellValue(i, "stt").ToString()));
                    }
                    hs.add(idnew, "Tự động phiếu nhập nội bộ (PXM)");
                    XtraMessageBox.Show("Done");
                    dongedit();
                    _hdong = 2;
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        protected override void sua()
        {

        }



        protected override bool xoa()
        {
            if (txtid.Text == string.Empty)
            {
                XtraMessageBox.Show("Không có thông tin để xóa");
                return false;
            }


            var lst2 = (from a in dbData.pxm_nhapkho_NBs where a.key == _key & a.duyet == true select a);
            if (lst2.Count() > 0)
            {
                XtraMessageBox.Show("Vật tự đã được nhập kho không thể xóa");
                return false;
            }
            try
            {
                for (var i = gv.DataRowCount - 1; i >= 0; i--)
                {
                    px.xoact(gv.GetRowCellValue(i, "key").ToString());
                    gv.DeleteRow(i);
                }
                px.xoa(_key);
                hs.add(txtid.Text, "Xóa Phiếu Xuất Kho Nội Bộ (PXM)");
                var lst = (from a in dbData.pxm_nhapkho_NBs select a).Single(t => t.key == _key);
                hs.add(lst.id, "Xóa Phiếu Tự Động Nhập Nội Bộ (PXM)");
                px.xoanhap(_key);
                px.xoanhapct(_key);


                XtraMessageBox.Show("Done");
                dongedit();
                xoatxt();
                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        protected override void print()
        {
            var report = new r_pxmpxuatkhoNB();
            report.DataSource = dbData.InPhieuXuatKhoNB(_key);
            report.ShowPreviewDialog();
        }

        protected override void top()
        {
            try
            {
                var lst = (from a in dbData.pxm_xuatkho_NBs where a.idct == _idct select a.so).Min();
                if (lst == null)
                    return;
                var lst1 = (from a in dbData.pxm_xuatkho_NBs where a.idct == _idct select a).Single(t => t.so == lst);
                loadinfo(lst1.key);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        protected override void prev()
        {
            try
            {
                var lst = (from a in dbData.pxm_xuatkho_NBs where a.idct == _idct && a.so < _so select a.so).Max();
                if (lst == null)
                {
                    XtraMessageBox.Show("Đây là phiếu đầu tiên");
                    return;
                }
                var lst1 = (from a in dbData.pxm_xuatkho_NBs where a.idct == _idct && a.so == lst select a).Single();
                loadinfo(lst1.key);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        protected override void next()
        {
            try
            {
                var lst = (from a in dbData.pxm_xuatkho_NBs where a.idct == _idct && a.so > _so select a.so).Min();
                if (lst == null)
                {
                    XtraMessageBox.Show("Đây là phiếu cuối cùng");
                    return;
                }
                var lst1 = (from a in dbData.pxm_xuatkho_NBs where a.idct == _idct && a.so == lst select a).Single();
                loadinfo(lst1.key);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        protected override void end()
        {
            load();
        }

        #region Method

        private bool kiemtratonkho(string mavt, double soluong, string id)
        {
            try
            {
                KetNoiDBDataContext db = new KetNoiDBDataContext();
                double lst = double.Parse((from a in db.LayTonSP(mavt, _idct, txtngayxuat.DateTime, id) select a).Sum(t => t.sl).ToString());
                if (soluong <= lst)
                    return true;
                XtraMessageBox.Show("Hàng tồn kho không đủ, không thể xuất (" + mavt + ")", "Thông Báo");
                return false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
                return false;
            }

        }

        //protected override void OnActivated(EventArgs e)
        //{
        //    btnsua.Visibility = BarItemVisibility.Never;
        //}

        private void loadinfo(string key)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().pxm_xuatkho_NBs select a).Single(t => t.key == key);
                txtiddv.Text = lst.iddv;
                txtid.Text = lst.id;
                custom.showdate(txtngayxuat, lst.ngayxuat.ToString());
                txtidnv.Text = lst.idnv;
                layttnhanvien(lst.idnv);
                txtiddt.Text = lst.iddt;
                layttdoituong(lst.iddt);
                txtctnhap.Text = lst.ctnhap;
                layttct(lst.ctnhap);
                txtdiengiai.Text = lst.diengiai;
                _key = lst.key;
                _so = Convert.ToInt32(lst.so.ToString());
                gd.DataSource = lst.pxm_xuatkhoct_NBs;
                loadsp();
                dongedit();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void dongedit()
        {
            txtiddv.ReadOnly = true;
            txtid.ReadOnly = true;
            txtngayxuat.ReadOnly = true;
            txtidnv.ReadOnly = true;
            txtiddt.ReadOnly = true;
            txtdiengiai.ReadOnly = true;
            txtctnhap.ReadOnly = true;
            gv.OptionsBehavior.Editable = false;
            _hdong = 2;
        }

        private void moedit()
        {

            txtiddv.ReadOnly = true;
            txtid.ReadOnly = true;
            txtngayxuat.ReadOnly = false;
            txtidnv.ReadOnly = true;
            txtiddt.ReadOnly = false;
            txtctnhap.ReadOnly = false;
            txtdiengiai.ReadOnly = false;
            gv.OptionsBehavior.Editable = true;
        }

        private void themtxt()
        {
            _key = MD5.laykey();
            //_keytemp = MD5.Decrypt(MD5.laykey());
            try
            {
                gd.DataSource = (from a in dbData.pxm_xuatkhoct_NBs where a.keypx == _key select a);
          
            }
            catch (Exception ex)
            {

                //gd.DataSource = dbData.pxm_xuatkhoct_NBs;
            }
            loadsp();
            gv.AddNewRow();
            txtiddv.Text = Biencucbo.donvi;
            txtid.Text = "YYYY";
            txtngayxuat.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            txtidnv.Text = Biencucbo.idnv;
            layttnhanvien(Biencucbo.idnv);

            txtiddt.Text = "";
            lbliddt.Text = "";
            txtctnhap.Text = "";
            lblct.Text = "";
            txtdiengiai.Text = string.Empty;
            _hdong = 0;
            moedit();

        }

        private void xoatxt()
        {
            txtiddv.Text = string.Empty;
            txtid.Text = string.Empty;
            txtngayxuat.Text = string.Empty;
            txtidnv.Text = string.Empty;
            lblidnv.Text = "";
            txtiddt.Text = string.Empty;
            lbliddt.Text = "";
            txtctnhap.Text = "";
            lblct.Text = "";
            txtdiengiai.Text = string.Empty;
            dongedit();

        }

        public void loaddatadoituong()
        {

            txtiddt.Properties.DataSource = new KetNoiDBDataContext().v_pxmdsdoituongs;

        }

        public void loaddatact()
        {
            txtctnhap.Properties.DataSource = (from a in new KetNoiDBDataContext().congtrinhs where a.khopxm == true select a);
        }

        public void loaddatapt()
        {

            slupt.DataSource = new KetNoiDBDataContext().phuongtiens;

        }
        public void loadsp()
        {
            var lst = (from a in new KetNoiDBDataContext().pxm_sanphams select a).ToList();
            //slu.DataSource = _tTodatatable.addlst(lst);
            slu.DataSource = new KetNoiDBDataContext().LayDSTonSP(_idct,txtngayxuat.DateTime);
            slutensp.DataSource = slu.DataSource;
            sludvt.DataSource = slu.DataSource;


        }

        public void layttdoituong(string id)
        {

            try
            {
                var lst = (from a in dbData.v_pxmdsdoituongs select a).Single(t => t.id == id);
                lbliddt.Text = lst.ten;
            }
            catch (Exception ex)
            {
                lbliddt.Text = "";

            }

        }

        public void layttct(string id)
        {

            try
            {
                var lst = (from a in dbData.congtrinhs select a).Single(t => t.id == id);
                lblct.Text = lst.tencongtrinh;
            }
            catch (Exception ex)
            {
                lblct.Text = "";

            }

        }

        public void layttnhanvien(string id)
        {

            try
            {
                var lst = (from a in dbData.accounts select a).Single(t => t.id == id);
                lblidnv.Text = lst.name;
            }
            catch (Exception ex)
            {
                lblidnv.Text = "";

            }

        }


        private void txtiddt_EditValueChanged(object sender, EventArgs e)
        {
            layttdoituong(txtiddt.Text);
        }

        private void txtiddt_Popup(object sender, EventArgs e)
        {
            //custom.popupslu<f_pxmdsdoituong>(sender, e, txtiddt, "btnpxmdoituong");
            var form = (sender as IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            var pop = form.Controls.OfType<SearchEditLookUpPopup>().FirstOrDefault();
            LayoutControl popupControl = pop.Controls.OfType<LayoutControl>().FirstOrDefault();
            Control clearBtn =
                popupControl.Controls.OfType<Control>().Where(ct => ct.Name == "btClear").FirstOrDefault();
            LayoutControlItem clearLCI = (LayoutControlItem) popupControl.GetItemByControl(clearBtn);
            LayoutControlItem myLCI = (LayoutControlItem) clearLCI.Owner.CreateLayoutItem(clearLCI.Parent);
            LayoutControlItem myrefresh = (LayoutControlItem) clearLCI.Owner.CreateLayoutItem(clearLCI.Parent);

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

        private void loadslutxtiddt()
        {
            txtiddt.Properties.DataSource = (from a in new KetNoiDBDataContext().pxm_doituongs select a);
        }

        public void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                Biencucbo.QuyenDangChon =
                    (from a in new KetNoiDBDataContext().PhanQuyen2s select a).Single(
                        t => t.TaiKhoan == Biencucbo.phongban && t.ChucNang == "btnpxmdoituong");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            var frm = new f_pxmdsdoituong();
            frm.ShowDialog();
            loadslutxtiddt();
            txtiddt.ShowPopup();
        }

        public void btnreload_Click(object sender, EventArgs e)
        {
            loadslutxtiddt();
            txtiddt.ShowPopup();
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

        private void f_pxmpxuatkhoNB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                loaddatadoituong();
                loadsp();
                loaddatact();
                loaddatapt();
                XtraMessageBox.Show("Đã load thông tin");
            }
            if (_hdong != 2)
            {
                if (e.Control)
                {
                    if (e.KeyCode == Keys.Insert)
                        gv.AddNewRow();
                    else if (e.KeyCode == Keys.Delete)
                    {
                        try
                        {
                            var ct =
                                (from c in dbData.pxm_xuatkhocts select c).Single(
                                    x => x.key == gv.GetFocusedRowCellValue("key").ToString());
                            dbData.pxm_xuatkhocts.DeleteOnSubmit(ct);
                            gv.DeleteRow(gv.FocusedRowHandle);
                        }
                        catch
                        {
                            gv.DeleteRow(gv.FocusedRowHandle);
                        }
                    }
                }
            }
        }

        private void gv_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            custom.sttgv(gv, e);
            BeginInvoke(new MethodInvoker(delegate
            {
                custom.cal(gd, gv);
            }));
        }

        private void gv_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var ct = gv.GetFocusedRow() as pxm_xuatkhoct_NB;
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
            a = MD5.Decrypt(_key) + k;

            for (i = 0; i <= gv.DataRowCount - 1;)
            {
                if (a == gv.GetRowCellValue(i, "key").ToString())
                {
                    k = k + 1;
                    a = MD5.Decrypt(_key) + k;
                    i = 0;
                }
                else
                {
                    i++;
                }
            }

            ct.keypx = _key;
            ct.soluong = 0.00;
            ct.ghichu = "";
            ct.idsp = "";
            ct.key = MD5.Encrypt(a);
            //ct.stt = Convert.ToInt32(ct.key.Substring(ct.idpn.Length, ct.key.Length - ct.idpn.Length));
            ct.stt = k;
        }

        private void slu_EditValueChanged(object sender, EventArgs e)
        {
            gv.PostEditor();
        }
        #endregion

        private void slu_Popup(object sender, EventArgs e)
        {

            var form = (sender as IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            var pop = form.Controls.OfType<SearchEditLookUpPopup>().FirstOrDefault();
            LayoutControl popupControl = pop.Controls.OfType<LayoutControl>().FirstOrDefault();
            Control clearBtn =
                popupControl.Controls.OfType<Control>().Where(ct => ct.Name == "btClear").FirstOrDefault();
            LayoutControlItem clearLCI = (LayoutControlItem) popupControl.GetItemByControl(clearBtn);
            LayoutControlItem myLCI = (LayoutControlItem) clearLCI.Owner.CreateLayoutItem(clearLCI.Parent);
            LayoutControlItem myrefresh = (LayoutControlItem) clearLCI.Owner.CreateLayoutItem(clearLCI.Parent);

            //btn edit
            var btnaddslu = new SimpleButton
            {
                Image = Resources.edit_16x16,
                Text = "Add/Edit",
                BorderStyle = BorderStyles.Default
            };
            btnaddslu.Click += btnaddslu_Click;

            // BTN load
            var btnreloadslu = new SimpleButton
            {
                Image = Resources.refresh_16x16,
                Text = "Refresh",
                BorderStyle = BorderStyles.Default
            };
            btnreloadslu.Click += btnreloadslu_Click;
            var edit = sender as SearchLookUpEdit;
            var popupForm = edit.GetPopupEditForm();
            popupForm.KeyPreview = true;
            popupForm.KeyUp -= txt_KeyUp;
            popupForm.KeyUp += txt_KeyUp;


            if (checkbtnslu)
            {
                myLCI.Control = btnaddslu;
                myLCI.Move(clearLCI, InsertType.Left);
                myrefresh.Control = btnreloadslu;
                myrefresh.Move(myLCI, InsertType.Left);

                checkbtnslu = false;
            }
        }

        private bool checkbtnslu = true;

        private void loadsluslu()
        {
            loadsp();
            checkbtnslu = true;
        }

        public void btnaddslu_Click(object sender, EventArgs e)
        {
            try
            {
                Biencucbo.QuyenDangChon =
                    (from a in new KetNoiDBDataContext().PhanQuyen2s select a).Single(
                        t => t.TaiKhoan == Biencucbo.phongban && t.ChucNang == "btnvattu");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            var frm = new f_pxmdssanpham();
            frm.ShowDialog();
            loadsluslu();
            
        }

        public void btnreloadslu_Click(object sender, EventArgs e)
        {
            loadsluslu();
            
        
        }

        private void txtngayxuat_EditValueChanged(object sender, EventArgs e)
        {
            loadsp();
        }
    }
}