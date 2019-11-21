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

namespace GUI
{
    public partial class f_pxmdsloaisp : frmds
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        t_pxmloaisp sp = new t_pxmloaisp();
        t_history hs = new t_history();
        private bool dble;
        public f_pxmdsloaisp()
        {
            InitializeComponent();
        }

        private void gv_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            custom.sttgv(gv, e);
            BeginInvoke(new MethodInvoker(delegate
            {
                custom.cal(gd, gv);
            }));
        }

        protected override void load()
        {
            using (dbData = new KetNoiDBDataContext())
            {
                var lst = (from a in dbData.pxm_loaisps select a);
                gd.DataSource = lst;
            }
        }

        protected override bool them()
        {
            Biencucbo.hdong = 0;
            var frm = new f_pxmthemloaisp();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                return true;
            }
            return false;
        }
        protected override bool sua()
        {
            try
            {
                Biencucbo.hdong = 1;
                Biencucbo.ma = gv.GetFocusedRowCellValue("id").ToString();
                var frm = new f_pxmthemloaisp();
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
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

        protected override bool xoa()
        {
            try
            {
                sp.xoa(gv.GetFocusedRowCellValue("id").ToString());
                hs.add(gv.GetFocusedRowCellValue("id").ToString(),"Xóa loại sản phẩm");
                XtraMessageBox.Show("Done");
                return true;}
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        private void gv_Click(object sender, EventArgs e)
        {
            dble = false;
        }

        private void gv_DoubleClick(object sender, EventArgs e)
        {
            dble = true;
        }

        private void gv_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (btnsua.Visibility == BarItemVisibility.Always)
            {
                if (dble)
                    if (sua())
                        load();
            }
        }
    }
}