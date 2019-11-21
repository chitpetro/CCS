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
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraReports.UI;
using GUI.Properties;
using DevExpress.Utils.Win;
using DevExpress.XtraLayout;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraGrid.Views.Grid;
using System.Diagnostics;
using DevExpress.XtraSplashScreen;

namespace GUI
{
    public partial class f_pxmnhapkho : frmp
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        t_pxmnhapkho pn = new t_pxmnhapkho();
        t_history hs = new t_history();
        t_todatatable _tTodatatable = new t_todatatable();
        private string _idct;
        private int _hdong;
        private int _so;
        private string _key;
        private string _keytemp;

        public f_pxmnhapkho()
        {
            InitializeComponent();
        }

        protected override void load()
        {
            loaddatadoituong();
            loadsp();
            _idct = Biencucbo.mact;
            try
            {

                if (Biencucbo.xembc)
                {
                    Biencucbo.xembc = false;
                    loadinfo(Biencucbo.ma);
                   
                }
                else
                {
                    var so = (from a in dbData.pxm_nhapkhos where a.idct == _idct select a.so).Max();
                    if (so == null)
                        return;
                    var lst = (from a in dbData.pxm_nhapkhos where a.idct == _idct select a).Single(t => t.so == so);
                    loadinfo(lst.key);
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
            f_pxmdsnhapkho frm = new f_pxmdsnhapkho();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                loadinfo(Biencucbo.ma);
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
                var c1 = dbData.pxm_nhapkhocts.Context.GetChangeSet();
                /* db.pnhaps.Context.SubmitChanges(); */
                // dang báo lỗi là vi không có thay đổi. kiem tra neu có thay doi hãy submit

                dbData.pxm_nhapkhocts.Context.SubmitChanges();
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
            try
            {
                gv.PostEditor();
                gv.UpdateCurrentRow();
                if (txtid.Text == string.Empty || txtiddt.Text == string.Empty || txtngaynhap.Text == string.Empty)
                {
                    XtraMessageBox.Show("Thông tin chưa đầy đủ không thể lưu, vui lòng kiểm tra lại");
                    return false;
                }
                for (int i = 0; i < gv.DataRowCount; i++)
                {
                    if (gv.GetRowCellValue(i, "idsp").ToString() == string.Empty)
                    {
                        XtraMessageBox.Show("Không được để trống vật tư, vui lòng kiểm tra lại");
                        return false;
                    }
                }
                if (_hdong == 0)
                {

                    int mact = int.Parse(_idct.Substring(4, _idct.Length - 4));
                    string macheck = "PNK" + mact;
                    txtid.Text = custom.matutang(macheck);
                    _so = Biencucbo.so;
                    pn.them(_key, txtid.Text, txtiddv.Text, txtidnv.Text, txtngaynhap.DateTime, txtiddt.Text, _idct, txtdiengiai.Text, _so);
                    LuuPhieu();
                    hs.add(txtid.Text, "Thêm Phiếu Nhập kho (PXM)");
                    XtraMessageBox.Show("Done");
                    dongedit();
                    _hdong = 2;
                    return true;
                }
                if (_hdong == 1)
                {
                    pn.sua(_key, txtid.Text, txtiddv.Text, txtidnv.Text, txtngaynhap.DateTime, txtiddt.Text, _idct, txtdiengiai.Text, _so);
                    LuuPhieu();
                    hs.add(txtid.Text, "Sửa Phiếu Nhập kho (PXM)");
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
            if (txtid.Text != string.Empty)
            {
                dbData = new KetNoiDBDataContext();
                _hdong = 1;
                gd.DataSource = (from a in dbData.pxm_nhapkhocts where a.keypn == _key select a);
                moedit();
            }
        }

        protected override bool xoa()
        {
            if (txtid.Text == string.Empty)
            {
                XtraMessageBox.Show("Không có thông tin để xóa");
                return false;
            }
            try
            {
                for (var i = gv.DataRowCount - 1; i >= 0; i--)
                {
                    pn.xoact(gv.GetRowCellValue(i, "key").ToString());
                    gv.DeleteRow(i);
                }
                pn.xoa(_key);
                hs.add(txtid.Text, "Xóa Phiếu Nhập Kho (PXM)");

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
            var report = new r_pxmnhapkho();
            report.DataSource = dbData.InPhieuNhapKho(_key);
            report.ShowPreviewDialog();
        }

        protected override void top()
        {
            try
            {
                var lst = (from a in dbData.pxm_nhapkhos where a.idct == _idct select a.so).Min();
                if (lst == null)
                    return;
                var lst1 = (from a in dbData.pxm_nhapkhos where a.idct == _idct select a).Single(t => t.so == lst);
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
                var lst = (from a in dbData.pxm_nhapkhos where a.idct == _idct && a.so < _so select a.so).Max();
                if (lst == null)
                {
                    XtraMessageBox.Show("Đây là phiếu đầu tiên");
                    return;
                }
                var lst1 = (from a in dbData.pxm_nhapkhos where a.idct == _idct && a.so == lst select a).Single();
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
                var lst = (from a in dbData.pxm_nhapkhos where a.idct == _idct && a.so > _so select a.so).Min();
                if (lst == null)
                {
                    XtraMessageBox.Show("Đây là phiếu cuối cùng");
                    return;
                }
                var lst1 = (from a in dbData.pxm_nhapkhos where a.idct == _idct && a.so == lst select a).Single();
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
        protected override void duyet()
        {

            try
            {
                KetNoiDBDataContext db = new KetNoiDBDataContext();
                var lst = (from a in db.pxm_nhapkhos select a).Single(t => t.key == _key);
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


        protected override bool duyeths()
        {

            var lst = (from a in new KetNoiDBDataContext().pxm_nhapkhos where a.key == _key & a.duyet == true select a);

            if (lst.Count() != 0)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        #region Method

        private void loadinfo(string key)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().pxm_nhapkhos select a).Single(t => t.key == key);
                txtiddv.Text = lst.iddv;
                txtid.Text = lst.id;
                custom.showdate(txtngaynhap, lst.ngaynhap.ToString());

                txtidnv.Text = lst.idnv;
                layttnhanvien(lst.idnv);
                txtiddt.Text = lst.iddt;
                layttdoituong(lst.iddt);
                txtdiengiai.Text = lst.diengiai;
                _key = lst.key;
                _so = Convert.ToInt32(lst.so.ToString());
                gd.DataSource = lst.pxm_nhapkhocts;
                dongedit();
                duyeths();
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
            txtngaynhap.ReadOnly = true;
            txtidnv.ReadOnly = true;
            txtiddt.ReadOnly = true;
            txtdiengiai.ReadOnly = true;
            gv.OptionsBehavior.Editable = false;
            _hdong = 2;
        }

        private void moedit()
        {

            txtiddv.ReadOnly = true;
            txtid.ReadOnly = true;
            txtngaynhap.ReadOnly = false;
            txtidnv.ReadOnly = true;
            txtiddt.ReadOnly = false;
            txtdiengiai.ReadOnly = false;
            gv.OptionsBehavior.Editable = true;
        }

        private void themtxt()
        {
            _key = MD5.laykey();
            _keytemp = MD5.Decrypt(MD5.laykey());
            try
            {
                gd.DataSource = (from a in dbData.pxm_nhapkhocts where a.keypn == _key select a);
            }
            catch (Exception ex)
            {

                gd.DataSource = dbData.pxm_nhapkhocts;
            }

            gv.AddNewRow();
            txtiddv.Text = Biencucbo.donvi;
            txtid.Text = "YYYY";
            txtngaynhap.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            txtidnv.Text = Biencucbo.idnv;
            layttnhanvien(Biencucbo.idnv);

            txtiddt.Text = "";

            lbliddt.Text = "";
            txtdiengiai.Text = string.Empty;
            _hdong = 0;
            moedit();

        }

        private void xoatxt()
        {
            txtiddv.Text = string.Empty;
            txtid.Text = string.Empty;
            txtngaynhap.Text = string.Empty;
            txtidnv.Text = string.Empty;
            lblidnv.Text = "";
            txtiddt.Text = string.Empty;
            lbliddt.Text = "";
            txtdiengiai.Text = string.Empty;
            dongedit();

        }

        public void loaddatadoituong()
        {

            txtiddt.Properties.DataSource = new KetNoiDBDataContext().v_pxmdsdoituongs;

        }

        public void loadsp()
        {
            var lst = (from a in new KetNoiDBDataContext().pxm_sanphams select a).ToList();
            slu.DataSource = _tTodatatable.addlst(lst);
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

        private void f_pxmnhapkho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                loaddatadoituong();
                loadsp();
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
                                (from c in dbData.pxm_nhapkhocts select c).Single(
                                    x => x.key == gv.GetFocusedRowCellValue("key").ToString());
                            dbData.pxm_nhapkhocts.DeleteOnSubmit(ct);
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

        private void gv_CustomDrawRowIndicator(object sender,
            DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            custom.sttgv(gv, e);
            BeginInvoke(new MethodInvoker(delegate
            {
                custom.cal(gd, gv);
            }));
        }



        private void gv_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {

            var ct = gv.GetFocusedRow() as pxm_nhapkhoct;
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

            ct.keypn = _key;
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
            //slu.DataSource = (from a in new KetNoiDBDataContext().pxm_sanphams select a);
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

        private void btnExportExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(SplashScreen2), true, true, false);

            gv.ExpandAllGroups();
            gv.BestFitColumns();

            //check 
            var report = new r_dsNhapKho_excel();
            report.GridControl = gd;

            var printTool = new ReportPrintTool(report);
            //printTool.PrintingSystem.PageMargins.Right = 0;

            printTool.ShowPreviewDialog();
            gv.ClearGrouping();
            gv.ClearSorting();

            SplashScreenManager.CloseForm(false);
        }

        private void btnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(SplashScreen2), true, true, false);

            gv.ExpandAllGroups();
            gv.BestFitColumns();

            //check 
            var report = new r_dsNhapKho_excel();
            report.GridControl = gd;

            var printTool = new ReportPrintTool(report);
            //printTool.PrintingSystem.PageMargins.Right = 0;

            printTool.ShowPreviewDialog();
            gv.ClearGrouping();
            gv.ClearSorting();

            SplashScreenManager.CloseForm(false);
        }
    }
}