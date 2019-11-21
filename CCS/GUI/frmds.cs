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

namespace GUI
{
    public partial class frmds : DevExpress.XtraEditors.XtraForm
    {
        public frmds()
        {
            InitializeComponent();
        }

        protected virtual bool them()
        {
            return false;
        }
        protected virtual bool sua()
        {
            return false;
        }
        protected virtual bool xoa()
        {
            return false;
        }
        protected virtual void load()
        {
            
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
        }

        private void frmds_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnthem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(them())
                load();
        }

        private void btnsua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(sua())
                load();
        }

        private void btnxoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa?","Thông Báo",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (xoa())
                    load();
            }
        }

        private void btnreload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            load();
        }
    }
}