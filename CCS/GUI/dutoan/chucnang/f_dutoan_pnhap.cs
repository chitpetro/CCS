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
using DevExpress.Utils;
using DevExpress.Utils.Win;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using GUI.Properties;

namespace GUI.dutoan.chucnang
{
    public partial class f_dutoan_pnhap : frm.frmp
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        c_dutoan_pnhap pn = new c_dutoan_pnhap();
        t_history hs = new t_history();

        /// <summary>
        /// 0: default
        /// 1: add
        /// 2: edit
        /// 3: coppy
        /// </summary>
        private int _hdong;
        private string _idct = string.Empty;
        private int _so;
        private string _key;
        private string _keytemp;
        private string _donvi = string.Empty;

        public f_dutoan_pnhap()
        {
            InitializeComponent();

            try
            {
                this.Text = Text + " - " + (from a in dbData.congtrinhs select a).Single(t => t.id == Biencucbo.mact).tencongtrinh;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }

        }

        #region Khai Báo Đầu

        private void gv_CustomDrawRowIndicator(object sender,
            RowIndicatorCustomDrawEventArgs e)
        {
            custom.sttgv(gv, e);
            BeginInvoke(new MethodInvoker(delegate
            {
                custom.cal(gd, gv);
            }));
        }

        private void layttlbliddv(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().donvis select a).Single(t => t.id == id);
                lbliddv.Text = lst.tendonvi;
            }
            catch (Exception ex)
            {
                lbliddv.Text = "";
            }
        }

        private void layttlblidnv(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().accounts select a).Single(t => t.id == id);
                lblidnv.Text = lst.name;
            }
            catch (Exception ex)
            {
                lblidnv.Text = "";
            }
        }

        private void laytttygiaSpinEdit(string tiente1)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().tientes select a).Single(t => t.tiente1 == tiente1);
                tygiaSpinEdit.Text = lst.tygia.ToString();
            }
            catch (Exception ex)
            {
                tygiaSpinEdit.Text = "";
            }
        }

        private void iddvTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            layttlbliddv(iddvTextEdit.Text);
        }

        private void idnvTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            layttlblidnv(idnvTextEdit.Text);
        }

        private void tienteSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            laytttygiaSpinEdit(tienteSearchLookUpEdit.Text);
        }

        private void tienteSearchLookUpEdit_Popup(object sender, EventArgs e)
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

        private void loadslutienteSearchLookUpEdit()
        {
            tienteSearchLookUpEdit.Properties.DataSource = (from a in new KetNoiDBDataContext().tientes select a);
        }

        public void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                Biencucbo.QuyenDangChon =
                    (from a in new KetNoiDBDataContext().PhanQuyen2s select a).Single(
                        t => t.TaiKhoan == Biencucbo.phongban && t.ChucNang == "barButtonItem11");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            var frm = new f_tiente();
            frm.ShowDialog();
            loadslutienteSearchLookUpEdit();
            tienteSearchLookUpEdit.ShowPopup();
        }

        public void btnreload_Click(object sender, EventArgs e)
        {
            loadslutienteSearchLookUpEdit();
            tienteSearchLookUpEdit.ShowPopup();
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

        #endregion

        #region Method

        private void dongedit()
        {
            dataLayoutControl1.OptionsView.IsReadOnly = DefaultBoolean.True;
            gv.OptionsBehavior.Editable = false;
            _hdong = 0;
        }

        private void moedit()
        {
            dataLayoutControl1.OptionsView.IsReadOnly = DefaultBoolean.False;
            dataLayoutControl1.OptionsView.IsReadOnly = DefaultBoolean.Default;
            // Textbox readonly = true
            iddvTextEdit.ReadOnly = true;
            idTextEdit.ReadOnly = true;
            idnvTextEdit.ReadOnly = true;
            //tenphongbanTextEdit.ReadOnly = true;
            //diachiTextEdit.ReadOnly = true;
            //tygiaSpinEdit.ReadOnly = true;
            //continue

            gv.OptionsBehavior.Editable = true;
        }

        private void themtxt()
        {
            _keytemp = _key;
            _key = custom.laykey();
            xoatxt();
            _hdong = 1;


            try
            {
                gd.DataSource = (from a in dbData.dutoan_pnhapcts where a.keypn == _key select a);

            }
            catch (Exception ex)
            {

            }

            gv.AddNewRow();
            iddvTextEdit.Text = _donvi;
            idTextEdit.Text = "YYYY";
            ngaylapDateEdit.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            tienteSearchLookUpEdit.Text = "KIP";
            idnvTextEdit.Text = Biencucbo.idnv;
            //iddtSearchLookUpEdit.Text = "";
            moedit();

        }

        private void xoatxt()
        {
            dataLayoutControl1.DataSource = (from a in dbData.dutoan_pnhaps where a.key == _key select a);
            //Textbox.text = string.empty

            iddvTextEdit.Text = string.Empty;
            idTextEdit.Text = string.Empty;
            ngaylapDateEdit.Text = string.Empty;
            idnvTextEdit.Text = string.Empty;
            //iddtSearchLookUpEdit.Text = string.Empty;
            diengiaiMemoEdit.Text = string.Empty;
            //tieptuc


            dongedit();


        }

        private void loadinfo(string key)
        {
            dongedit();
            try
            {
                var lst = (from a in new KetNoiDBDataContext().dutoan_pnhaps where a.idct == _idct select a).Single(t => t.key == key);
                dataLayoutControl1.DataSource = lst;
                var lst2 = (from a in new KetNoiDBDataContext().dutoan_pnhaps where a.idct == _idct select a).Single(t => t.key == key);
                gd.DataSource = lst2.dutoan_pnhapcts;
                _key = lst.key;
                _so = Convert.ToInt32(lst.so);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        private bool kiemtra()
        {
            int checknull = 0;

            ngaylapDateEdit.Properties.ContextImage = null;
            if (custom.checknulltext(ngaylapDateEdit))
                checknull++;
            tienteSearchLookUpEdit.Properties.ContextImage = null;
            if (custom.checknulltext(tienteSearchLookUpEdit))
                checknull++;
          
            if (checknull > 0)
            {
                custom.mes_thongtinchuadaydu();
                return false;
            }
            return true;
        }

        #region override


        protected override void load()
        {

            if (_donvi == string.Empty)
            {
                _donvi = Biencucbo.donvi;
            }
            // Load dữ liệu searchlookup 

            //  
            loadslutienteSearchLookUpEdit();
            loadslusluidsp();
            if (_idct == string.Empty)
            {
                _idct = Biencucbo.mact;
            }



            dongedit();
            try
            {
                var so = (from a in new KetNoiDBDataContext().dutoan_pnhaps where a.idct == _idct select a.so).Max();
                if (so == null)
                    return;
                var lst = (from a in new KetNoiDBDataContext().dutoan_pnhaps where a.idct == _idct select a).Single(t => t.so == so);
                loadinfo(lst.key);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        protected override void mo()
        {
            f_dutoan_dspnhap frm = new f_dutoan_dspnhap();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _key = Biencucbo.key;
                loadinfo(_key);
            }
        }

        protected override void them()
        {
            themtxt();
        }

        protected override void saochep()
        {
            
            XtraMessageBox.Show("Chức năng này không được sử dụng trong form");
            
        }

        private bool LuuPhieu()
        {
            dataLayoutControl1.Validate();
            gv.CloseEditor();
            gv.PostEditor();
            gv.UpdateCurrentRow();

            try
            {
                var c1 = dbData.dutoan_pnhapcts.Context.GetChangeSet();
                dbData.dutoan_pnhapcts.Context.SubmitChanges();
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
                if (kiemtra())
                {
                    if (_hdong == 1)
                    {
                        idTextEdit.Text = custom.matutang("DTPN" + _donvi);
                        _so = Biencucbo.so;
                        pn.them(_key, idTextEdit.Text, ngaylapDateEdit.DateTime, iddvTextEdit.Text, idnvTextEdit.Text,
                            _idct, tienteSearchLookUpEdit.Text, double.Parse(tygiaSpinEdit.Text), diengiaiMemoEdit.Text,
                            _so);   
                        LuuPhieu();
                        hs.add(idTextEdit.Text, "Thêm Dự Toán Vật Tư");
                        XtraMessageBox.Show("Done");
                        dongedit();
                        return true;

                    }
                    if (_hdong == 2)
                    {
                        pn.sua(_key,ngaylapDateEdit.DateTime,tienteSearchLookUpEdit.Text,double.Parse(tygiaSpinEdit.Text),diengiaiMemoEdit.Text);
                        LuuPhieu();
                        hs.add(idTextEdit.Text, "Sửa Dự Toán Vật Tư");
                        XtraMessageBox.Show("Done");
                        dongedit();
                        return true;
                    }
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
            if (idTextEdit.Text != string.Empty)
            {
                dbData = new KetNoiDBDataContext();
                _hdong = 2;
                gd.DataSource = (from a in dbData.dutoan_pnhapcts where a.keypn == _key select a);
                moedit();
                
            }
     
        }

        protected override bool xoa()
        {
            if (idTextEdit.Text == string.Empty)
            {
                XtraMessageBox.Show("Không có thông tin để xóa");
                return false;
            }
            try
            {

                for (var i = gv.DataRowCount - 1; i >= 0; i--)
                {
                    var ct = gv.GetRow(i) as dutoan_pnhapct;
                    pn.xoact(ct.key);
                    gv.DeleteRow(i);
                }
                pn.xoa(_key);
                hs.add(idTextEdit.Text, "Xóa Dự Toán Vật Tư");
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

        protected override void reload()
        {
            if (_hdong == 1)
            {
                _key = _keytemp;
            }
            loadinfo(_key);
            dongedit();
        }

        protected override void print()
        {

        }

        protected override void first()
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().dutoan_pnhaps where a.idct == _idct  select a.so).Min();
                if (lst == null)
                    return;
                var lst1 =
                    (from a in new KetNoiDBDataContext().dutoan_pnhaps where a.idct == _idct select a).Single(t => t.so == lst);
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
                var lst = (from a in new KetNoiDBDataContext().dutoan_pnhaps where a.idct == _idct && a.so < _so select a.so).Max();
                if (lst == null)
                {
                    XtraMessageBox.Show("Đây là phiếu đầu tiên");
                    return;
                }
                var lst1 =
                    (from a in new KetNoiDBDataContext().dutoan_pnhaps where a.idct == _idct && a.so == lst select a).Single();
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
                var lst = (from a in new KetNoiDBDataContext().dutoan_pnhaps where a.idct == _idct && a.so > _so select a.so).Max();
                if (lst == null)
                {
                    XtraMessageBox.Show("Đây là phiếu cuối cùng");
                    return;
                }
                var lst1 =
                    (from a in new KetNoiDBDataContext().dutoan_pnhaps where a.idct == _idct && a.so == lst select a).Single();
                loadinfo(lst1.key);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        protected override void last()
        {
            load();
        }


        #endregion

        private void f_dutoan_pnhap_Load(object sender, EventArgs e)
        {
            btnin.Visibility = BarItemVisibility.Never;
            btnsaochep.Visibility = BarItemVisibility.Never;
        }

        private void sluidsp_Popup(object sender, EventArgs e)
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
         

            // BTN load
            var btnreloadsluidsp = new SimpleButton
            {
                Image = Resources.refresh_16x16,
                Text = "Refresh",
                BorderStyle = BorderStyles.Default
            };
            btnreloadsluidsp.Click += btnreloadsluidsp_Click;
            var edit = sender as SearchLookUpEdit;
            var popupForm = edit.GetPopupEditForm();
            popupForm.KeyPreview = true;
            popupForm.KeyUp -= txt_KeyUp;
            popupForm.KeyUp += txt_KeyUp;


            if (checkbtnsluidsp)
            {
            
                myrefresh.Control = btnreloadsluidsp;
                myrefresh.Move(myLCI, InsertType.Left);

                checkbtnsluidsp = false;
            }
        }

        private bool checkbtnsluidsp = true;

        private void loadslusluidsp()
        {
          sludvt.DataSource = slutensp.DataSource =  sluidsp.DataSource = (from a in new KetNoiDBDataContext().sanphams select a).ToList();
            checkbtnsluidsp = true;}

        

        public void btnreloadsluidsp_Click(object sender, EventArgs e)
        {
            loadslusluidsp();
         }

        private void sluidsp_EditValueChanged(object sender, EventArgs e)
        {
            gv.PostEditor();
            gv.UpdateCurrentRow();
        }

        private void gv_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var ct = gv.GetFocusedRow() as dutoan_pnhapct;
            if (ct == null)
                return;
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

            for (i = 0; i <= gv.DataRowCount - 1;)
            {
                if (k.ToString() == gv.GetRowCellValue(i, "stt").ToString())
                {
                    k = k + 1;
                    i = 0;
                }
                else
                {
                    i++;
                }
            }

            ct.key = custom.laykey();
            ct.keypn = _key;
            ct.idsp = string.Empty;
            ct.soluong = 0.00;
            ct.dongia = 0.00;
            ct.ghichu = string.Empty;
            ct.stt = k;
            ct.nguyente = 0.00;
            ct.thanhtien = 0.00;

           
        }

        private void gv_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            gv.PostEditor();
            gv.UpdateCurrentRow();
            var ct = gv.GetFocusedRow() as dutoan_pnhapct;
            try
            {
                ct.nguyente = ct.soluong * ct.dongia;
                ct.thanhtien = (ct.soluong * ct.dongia) * double.Parse(tygiaSpinEdit.Text);
                gv.PostEditor();
                gv.UpdateCurrentRow();
            }
            catch (Exception ex)
            {

            }
        }

        private void f_dutoan_pnhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (_hdong != 0)
            {
                if (e.KeyCode == Keys.Insert)
                {
                    gv.AddNewRow();
                }
                if (e.Control)
                {
                    if (e.KeyCode == Keys.Delete)
                    {
                        var ct = gv.GetFocusedRow() as dutoan_pnhapct;
                        dbData.dutoan_pnhapcts.DeleteOnSubmit(ct);
                        gv.DeleteRow(gv.FocusedRowHandle);
                    }
                }
            }
        }
    }
}