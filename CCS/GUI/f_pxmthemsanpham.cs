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
using DevExpress.Utils.Win;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using GUI.Properties;

namespace GUI
{
    public partial class f_pxmthemsanpham : frmthemds
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        t_pxmsanpham sp = new t_pxmsanpham();
        t_history hs = new t_history();

        private string _ma;
        private int _hdong;
        public f_pxmthemsanpham()
        {

            InitializeComponent();
        }

        #region Metthod
        public void layttloaisp(string id)
        {
            try
            {
                using (dbData = new KetNoiDBDataContext())
                {
                    var lst = (from a in dbData.pxm_loaisps select a).Single(t => t.id == id);
                    lblloai.Text = lst.tenloai;
                }
            }
            catch (Exception ex)
            {
                lblloai.Text = "";
            }
        }
        public void loaddataloai()
        {
            using (dbData = new KetNoiDBDataContext())
            {
                txtloai.Properties.DataSource = (from a in dbData.pxm_loaisps select a);
            }
        }
        private void txtloai_EditValueChanged(object sender, EventArgs e)
        {
            layttloaisp(txtloai.Text);
        }

        private void f_pxmthemsanpham_Load(object sender, EventArgs e)
        {
            loaddataloai();
        }

        private void txtloai_Popup(object sender, EventArgs e)
        {
            //custom.popupslu<f_pxmdsloaisp>(sender, e, txtloai, "btnloaisp");
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

        private void loadslutxtloai()
        {
            txtloai.Properties.DataSource = (from a in new KetNoiDBDataContext().pxm_loaisps select a);
        }

        public void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                Biencucbo.QuyenDangChon =
                    (from a in new KetNoiDBDataContext().PhanQuyen2s select a).Single(
                        t => t.TaiKhoan == Biencucbo.phongban && t.ChucNang == "btnloaisp");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            var frm = new f_pxmdsloaisp();
            frm.ShowDialog();
            loadslutxtloai();
            txtloai.ShowPopup();
        }

        public void btnreload_Click(object sender, EventArgs e)
        {
            loadslutxtloai();
            txtloai.ShowPopup();
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

        private void f_pxmthemsanpham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                loaddataloai();
                XtraMessageBox.Show("Đã tải lại dữ liệu loại Vật Tư");
            }
        }
        #endregion

        protected override void load()
        {
            _hdong = Biencucbo.hdong;
            if (_hdong == 1)
            {
                txtid.ReadOnly = true;
                _ma = Biencucbo.ma;
                try
                {
                    var lst = (from a in dbData.pxm_sanphams select a).Single(t => t.id == _ma);
                    txtid.Text = lst.id;
                    txttensp.Text = lst.tensp;
                    txtdvt.Text = lst.dvt;
                    txtloai.Text = lst.loai;
                    layttloaisp(lst.loai);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
        }

        protected override void huy()
        {
            Close();
        }

        protected override void luu()
        {
            if (txtid.Text == string.Empty || txttensp.Text == string.Empty)
            {
                XtraMessageBox.Show("Thông tin chưa đầy đủ vui lòng kiểm tra lại", "Thông Báo");
                return;
            }
            try
            {
                if (_hdong == 0)
                {
                    using (dbData = new KetNoiDBDataContext())
                    {
                        var lst = (from a in dbData.pxm_sanphams where a.id == txtid.Text select a);
                        if (lst.Count() > 0)
                        {
                            XtraMessageBox.Show("Mã vật tư bị trùng, vui lòng kiểm tra lại", "Thông Báo");
                            return;
                        }
                    }
                    sp.them(txtid.Text,txttensp.Text,txtdvt.Text,txtloai.Text);
                    hs.add(txtid.Text,"Thêm mới vật tư (PXM)");
                    XtraMessageBox.Show("Done");
                    DialogResult =DialogResult.OK;
                    huy();
                    
                }
                else
                {
                    sp.sua(txtid.Text, txttensp.Text, txtdvt.Text, txtloai.Text);
                    hs.add(txtid.Text, "Sửa vật tư (PXM)");
                    XtraMessageBox.Show("Done");
                    DialogResult = DialogResult.OK;
                    huy();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

    }

}