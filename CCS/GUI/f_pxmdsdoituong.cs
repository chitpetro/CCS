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
    public partial class f_pxmdsdoituong : frmds
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        t_pxm_doituong dt = new t_pxm_doituong();
        t_history hs = new t_history();
        private bool dble;
        public f_pxmdsdoituong()
        {
            InitializeComponent();
            if (Biencucbo.idnv != "AD")
            {
                btnimport.Visibility = BarItemVisibility.Never;
            }
        }

        protected override void load()
        {
            try
            {
                using (dbData = new KetNoiDBDataContext())
                {
                    var lst = (from a in dbData.v_pxmdsdoituongs select a);
                    gd.DataSource = lst;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        protected override bool them()
        {
            Biencucbo.hdong = 0;
            f_pxmthemdoituong frm = new f_pxmthemdoituong();
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
                var frm = new f_pxmthemdoituong();
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
                dt.xoa(gv.GetFocusedRowCellValue("id").ToString());
                hs.add(gv.GetFocusedRowCellValue("id").ToString(),"Xóa đối tượng (PXM)");
                XtraMessageBox.Show("Done");
              
                return true;
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString());
                return false;
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

        private void btnimport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Biencucbo.ma = "pxm_doituong";
            f_import frm = new f_import();
            frm.ShowDialog();

            load();

        }
    }
}