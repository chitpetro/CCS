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
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraReports.UI;
using DevExpress.XtraLayout;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraGrid.Views.Grid;
using GUI.Properties;

namespace GUI
{
    public partial class f_pxmpnhapkhoNB : frmp
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        t_pxmnhapkhoNB pn = new t_pxmnhapkhoNB();
        t_history hs = new t_history();
        t_todatatable _tTodatatable = new t_todatatable();
        private string _idct;
        private int _hdong;
        private int _so;
        private string _key;

        public f_pxmpnhapkhoNB()
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
                    var so = (from a in dbData.pxm_nhapkho_NBs where a.idct == _idct select a.so).Max();
                if (so == null)
                    return;
                var lst = (from a in dbData.pxm_nhapkho_NBs where a.idct == _idct select a).Single(t => t.so == so);
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
            f_pxmdsnhapkhoNB frm = new f_pxmdsnhapkhoNB();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                loadinfo(Biencucbo.ma);
            }
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
                var c1 = dbData.pxm_nhapkhoct_NBs.Context.GetChangeSet();
                /* db.pnhaps.Context.SubmitChanges(); */
                // dang báo lỗi là vi không có thay đổi. kiem tra neu có thay doi hãy submit

                dbData.pxm_nhapkhoct_NBs.Context.SubmitChanges();
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
                pn.sua(_key, Biencucbo.donvi, Biencucbo.idnv, txtngaynhap.DateTime, txtdiengiai.Text);
                LuuPhieu();
                hs.add(txtid.Text, "Duyệt nhận HS");
                loadinfo(_key);
                duyeths();
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
            var report = new r_pxmpnhapkhonb();report.DataSource = dbData.InPhieuNhapKhoNB(_key);
            report.ShowPreviewDialog();
        }

        protected override void top()
        {
            try
            {
                var lst = (from a in dbData.pxm_nhapkho_NBs where a.idct == _idct select a.so).Min();
                if (lst == null)
                    return;
                var lst1 = (from a in dbData.pxm_nhapkho_NBs where a.idct == _idct select a).Single(t => t.so == lst);
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
                var lst = (from a in dbData.pxm_nhapkho_NBs where a.idct == _idct && a.so < _so select a.so).Max();
                if (lst == null)
                {
                    XtraMessageBox.Show("Đây là phiếu đầu tiên");
                    return;
                }
                var lst1 = (from a in dbData.pxm_nhapkho_NBs where a.idct == _idct && a.so == lst select a).Single();
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
                var lst = (from a in dbData.pxm_nhapkho_NBs where a.idct == _idct && a.so > _so select a.so).Min();
                if (lst == null)
                {
                    XtraMessageBox.Show("Đây là phiếu cuối cùng");
                    return;
                }
                var lst1 = (from a in dbData.pxm_nhapkho_NBs where a.idct == _idct && a.so == lst select a).Single();
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
                loadinfo(_key);
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
                var lst = (from a in db.pxm_nhapkho_NBs select a).Single(t => t.key == _key);
                if (lst.duyet != true)
                {
                    if (
                        XtraMessageBox.Show("Bạn có muốn duyệt hồ sơ này không?", "Thông Báo", MessageBoxButtons.YesNo) ==
                        DialogResult.Yes)
                    {
                        gd.DataSource = (from a in dbData.pxm_nhapkhoct_NBs where a.keypn == _key select a);
                        moedit();

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

            var lst = (from a in new KetNoiDBDataContext().pxm_nhapkho_NBs where a.key == _key & a.duyet == true select a);

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

        protected override void OnActivated(EventArgs e)
        {
            btnthem.Visibility = BarItemVisibility.Never;
            btnsua.Visibility = BarItemVisibility.Never;
            btnxoa.Visibility = BarItemVisibility.Never;
        }
        private void loadinfo(string key)
        {

            try
            {
                var lst = (from a in new KetNoiDBDataContext().pxm_nhapkho_NBs select a).Single(t => t.key == key);
                txtiddv.Text = lst.iddv;
                txtid.Text = lst.id;
                custom.showdate(txtngaynhap, lst.ngaynhap.ToString());
                txtidnv.Text = lst.idnv;
                layttnhanvien(lst.idnv);
                txtiddt.Text = lst.iddt;
                layttdoituong(lst.iddt);
                txtctxuat.Text = lst.ctxuat;
                latttctxuat(lst.ctxuat);
                txtdiengiai.Text = lst.diengiai;
                _key = lst.key;
                _so = Convert.ToInt32(lst.so.ToString());
                gd.DataSource = lst.pxm_nhapkhoct_NBs;
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
            txtctxuat.ReadOnly = true;

            btnluu.Enabled = false;
            btnreload.Enabled = false;
            btnmo.Enabled = true;
            btnend.Enabled = true;
            btnprev.Enabled = true;
            btnnext.Enabled = true;
            btntop.Enabled = true;
            gv.OptionsBehavior.Editable = false;
            _hdong = 2;
        }

        private void moedit()
        {

            txtiddv.ReadOnly = true;
            txtid.ReadOnly = true;
            txtngaynhap.ReadOnly = false;
            txtidnv.ReadOnly = true;
            txtiddt.ReadOnly = true;
            txtdiengiai.ReadOnly = false;
            txtctxuat.ReadOnly = true;

            btnluu.Enabled = true;
            btnreload.Enabled = true;
            btnmo.Enabled = false;
            btnend.Enabled = false;
            btnprev.Enabled = false;
            btnnext.Enabled = false;
            btntop.Enabled = false;
            gv.OptionsBehavior.Editable = true;
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
        public void latttctxuat(string id)
        {

            try
            {
                var lst = (from a in dbData.congtrinhs select a).Single(t => t.id == id);
                lblctxuat.Text = lst.tencongtrinh;
            }
            catch (Exception ex)
            {
                lblctxuat.Text = "";

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

        private void gv_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            custom.sttgv(gv, e);
            BeginInvoke(new MethodInvoker(delegate
            {
                custom.cal(gd, gv);
            }));
        }
        #endregion

        private void spntn_EditValueChanged(object sender, EventArgs e)
        {
            gv.PostEditor();
            double sl = double.Parse(gv.GetFocusedRowCellValue("soluong").ToString());
            double tn = double.Parse(gv.GetFocusedRowCellValue("soluongtn").ToString());
            double cl = sl - tn;
            gv.SetFocusedRowCellValue("chenhlech", cl);
        }

        private void gv_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            gv.PostEditor();
            try
            {
                if (e.Column.FieldName == "soluongtn")
                {
                    double sl = double.Parse(gv.GetFocusedRowCellValue("soluong").ToString());
                    double tn = double.Parse(gv.GetFocusedRowCellValue("soluongtn").ToString());
                    double cl = sl - tn;
                    gv.SetFocusedRowCellValue("chenhlech", cl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void f_pxmpnhapkhoNB_Load(object sender, EventArgs e)
        {

        }

        private void txtiddt_Popup(object sender, EventArgs e)
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
    }
}