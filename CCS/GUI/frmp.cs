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
using BUS;
using DevExpress.XtraBars;
using GUI.Properties;

namespace GUI
{
    public partial class frmp : DevExpress.XtraEditors.XtraForm
    {
        public frmp()
        {
            InitializeComponent();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            var q = Biencucbo.QuyenDangChon;
            if (q == null) return;

            if ((bool)q.Them)
            {
                btnthem.Visibility = BarItemVisibility.Always;
            }
            else
            {
                btnthem.Visibility = BarItemVisibility.Never;
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
            if ((bool)q.duyet)
            {
                btnduyet.Visibility = BarItemVisibility.Always;
            }
            else
            {
                btnduyet.Visibility = BarItemVisibility.Never;
            }
        }




        private void loadbtn()
        {
            btnmo.Enabled = true;
            btnthem.Enabled = true;
            btnluu.Enabled = false;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnin.Enabled = true;
            btnreload.Enabled = false;
            btntop.Enabled = true;
            btnprev.Enabled = true;
            btnnext.Enabled = true;
            btnend.Enabled = true;
            btnduyet.Enabled = true;
            if (duyeths())
            {

                btnduyet.Glyph = Resources.folder_full_accept_icon;
                btnduyet.Caption = "Đã duyệt";

            }
            else
            {
                btnduyet.Glyph = Resources.folder_full_icon;
                btnduyet.Caption = "Chưa duyệt";
            }
        }

        private void editbtn()
        {
            btnmo.Enabled = false;
            btnthem.Enabled = false;
            btnluu.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnin.Enabled = false;
            btnreload.Enabled = true;
            btntop.Enabled = false;
            btnprev.Enabled = false;
            btnnext.Enabled = false;
            btnend.Enabled = false;
            btnduyet.Enabled = false;

        }

       
        protected virtual void load()
        {

        }
        protected virtual void mo()
        {

        }

        protected virtual void duyet()
        {

        }
        protected virtual void them()
        {

        }
        protected virtual bool luu()
        {
            return true;
        }
        protected virtual void sua()
        {

        }
        protected virtual bool xoa()
        {
            return false;
        }
        protected virtual bool duyeths()
        {
            return false;
        }

       protected virtual void print()
        {

        }
        protected virtual void top()
        {

        }
        protected virtual void prev()
        {

        }
        protected virtual void next()
        {

        }
        protected virtual void end()
        {

        }

        private void frmp_Load(object sender, EventArgs e)
        {
            loadbtn();
            load();
            if (duyeths())
            {

                btnduyet.Glyph = Resources.folder_full_accept_icon;
                btnduyet.Caption = "Đã duyệt";

            }
            else
            {
                btnduyet.Glyph = Resources.folder_full_icon;
                btnduyet.Caption = "Chưa duyệt";
            }
        }

        protected virtual void reload()
        {

        }

        private void btnreload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadbtn();
            reload();
            if (duyeths())
            {

                btnduyet.Glyph = Resources.folder_full_accept_icon;
                btnduyet.Caption = "Đã duyệt";

            }
            else
            {
                btnduyet.Glyph = Resources.folder_full_icon;
                btnduyet.Caption = "Chưa duyệt";
            }
        }

        private void btnxoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            if (duyeths())
            {

                XtraMessageBox.Show("Hồ sơ này đã được duyệt, không thể Xóa");
            }
            else
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa?", "Thông Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)

                {
                    if (xoa())
                    {
                        loadbtn();
                        if (duyeths())

                            btnduyet.Glyph = Resources.folder_full_icon;
                        btnduyet.Caption = "Duyệt";
                    }
                }
            }
        }

        private void btnmo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            mo();
            if (duyeths())
            {

                btnduyet.Glyph = Resources.folder_full_accept_icon;
                btnduyet.Caption = "Đã duyệt";

            }
            else
            {
                btnduyet.Glyph = Resources.folder_full_icon;
                btnduyet.Caption = "Chưa duyệt";
            }
        }

        private void btnthem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            them();
            editbtn();
        }

        private void btnluu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (luu())
                loadbtn();
        }

        private void btnsua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (duyeths())
            {

                XtraMessageBox.Show("Hồ sơ này đã được duyệt, không thể sửa");
            }
            else
            {
                sua();
                editbtn();
            }

        }

        private void btnin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            print();
        }

        private void btntop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            top();
            if (duyeths())
            {

                btnduyet.Glyph = Resources.folder_full_accept_icon;
                btnduyet.Caption = "Đã duyệt";

            }
            else
            {
                btnduyet.Glyph = Resources.folder_full_icon;
                btnduyet.Caption = "Chưa duyệt";
            }
        }

        private void btnprev_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            prev();
            if (duyeths())
            {

                btnduyet.Glyph = Resources.folder_full_accept_icon;
                btnduyet.Caption = "Đã duyệt";

            }
            else
            {
                btnduyet.Glyph = Resources.folder_full_icon;
                btnduyet.Caption = "Chưa duyệt";
            }
        }

        private void btnnext_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            next();
            if (duyeths())
            {

                btnduyet.Glyph = Resources.folder_full_accept_icon;
                btnduyet.Caption = "Đã duyệt";

            }
            else
            {
                btnduyet.Glyph = Resources.folder_full_icon;
                btnduyet.Caption = "Chưa duyệt";
            }
        }

        private void btnend_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            end();
            if (duyeths())
            {

                btnduyet.Glyph = Resources.folder_full_accept_icon;
                btnduyet.Caption = "Đã duyệt";

            }
            else
            {
                btnduyet.Glyph = Resources.folder_full_icon;
                btnduyet.Caption = "Chưa duyệt";
            }
        }

        private void btnduyet_ItemClick(object sender, ItemClickEventArgs e)
        {
            duyet();
            if (duyeths())
            {

                btnduyet.Glyph = Resources.folder_full_accept_icon;
                btnduyet.Caption = "Đã duyệt";

            }
            else
            {
                btnduyet.Glyph = Resources.folder_full_icon;
                btnduyet.Caption = "Chưa duyệt";
            }
        }
    }
}