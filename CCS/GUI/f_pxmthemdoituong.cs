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
using DevExpress.XtraLayout.Utils;
using DevExpress.Utils.Win;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraLayout;
using GUI.Properties;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;

namespace GUI
{
    public partial class f_pxmthemdoituong : frmthemds
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        t_pxm_doituong dt = new t_pxm_doituong();
        t_history hs = new t_history();
        private string _ma;
        private int _hdong;
        public f_pxmthemdoituong()
        {
            InitializeComponent();
        }

        private void f_pxmthemdoituong_Load(object sender, EventArgs e)
        {
            loaddatanhom();
        }

        private void loaddatanhom()
        {
            using (dbData = new KetNoiDBDataContext())
            {
                var lst = (from a in dbData.pxm_nhomdoituongs select a);
                txtnhom.Properties.DataSource = lst;

            }
        }

        private void layttnhom(string nhom)
        {
            try
            {
                using (dbData = new KetNoiDBDataContext())
                {
                    var lst = (from a in dbData.pxm_nhomdoituongs select a).Single(t => t.id == nhom);
                    lblnhom.Text = lst.ten;
                }
            }
            catch (Exception ex)
            {
                lblnhom.Text = "";
            }
        }

        protected override void load()
        {
            _hdong = Biencucbo.hdong;
            if (_hdong == 1)
            {
                _ma = Biencucbo.ma;
                txtid.ReadOnly = true;
                try
                {
                    var lst = (from a in dbData.pxm_doituongs select a).Single(t => t.id == _ma);
                    txtid.Text = lst.id;
                    txtten.Text = lst.ten;
                    txtnhom.Text = lst.nhom;
                    layttnhom(lst.nhom);
                    txtdiachi.Text = lst.diachi;
                    txtmsthue.Text = lst.msthue;
                    txtdienthoai.Text = lst.dienthoai;
                    txtemail.Text = lst.email;
                    txtfax.Text = lst.fax;
                    txttaikhoan.Text = lst.taikhoan;
                    txtnganhang.Text = lst.nganhang;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }

        }

        private bool obj;
        t_todatatable _tTodatatable = new t_todatatable();
        private void txtnhom_Popup(object sender, EventArgs e)
        {
            //custom.popupslu<f_pxm_dsnhomdoituong>(sender, e, txtnhom, "btnnpxmhomdoituong");

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

        private void loadslutxtnhom()
        {
            txtnhom.Properties.DataSource = (from a in new KetNoiDBDataContext().pxm_nhomdoituongs select a);
        }

        public void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                Biencucbo.QuyenDangChon =
                    (from a in new KetNoiDBDataContext().PhanQuyen2s select a).Single(
                        t => t.TaiKhoan == Biencucbo.phongban && t.ChucNang == "btnnpxmhomdoituong");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            var frm = new f_pxm_dsnhomdoituong();
            frm.ShowDialog();
            loadslutxtnhom();
            txtnhom.ShowPopup();
        }

        public void btnreload_Click(object sender, EventArgs e)
        {
            loadslutxtnhom();
            txtnhom.ShowPopup();
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

        private void txtnhom_EditValueChanged(object sender, EventArgs e)
        {
            layttnhom(txtnhom.Text);
        }

        protected override void luu()
        {
            if (txtid.Text == string.Empty || txtten.Text == string.Empty)
            {
                XtraMessageBox.Show("Thông tin chưa đầy đủ, vui lòng kiểm tra lại!", "Thông Báo");
                return;
            }
            try
            {
                if (_hdong == 0)
                {
                    using (dbData = new KetNoiDBDataContext())
                    {
                        var lst = (from a in dbData.pxm_doituongs where a.id == txtid.Text select a);
                        if (lst.Count() > 0)
                        {
                            XtraMessageBox.Show("Thông tin đối tượng bị trùng, vui lòng kiểm tra lại");
                            return;
                        }
                    }
                    dt.them(txtid.Text, txtten.Text, txtnhom.Text, txtdiachi.Text, txtmsthue.Text, txtdienthoai.Text,
                        txtemail.Text, txtfax.Text, txttaikhoan.Text, txtnganhang.Text);
                    hs.add(txtid.Text, "Thêm mới đối tượng (PXM)");

                }
                else
                {
                    dt.sua(txtid.Text, txtten.Text, txtnhom.Text, txtdiachi.Text, txtmsthue.Text, txtdienthoai.Text,
                        txtemail.Text, txtfax.Text, txttaikhoan.Text, txtnganhang.Text);
                    hs.add(txtid.Text, "Sửa đối tượng (PXM)");
                }
                XtraMessageBox.Show("Done");
                DialogResult = DialogResult.OK;
                huy();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        protected override void huy()
        {
            Close();
        }

        private void f_pxmthemdoituong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                loaddatanhom();
            }
        }
    }
}