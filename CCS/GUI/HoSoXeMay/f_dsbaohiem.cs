using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BUS;
using DAL;

namespace GUI.HoSoXeMay
{
    public partial class f_dsbaohiem : frmdsmo
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        private bool dble;
        public f_dsbaohiem()
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
            if (dble)
            {
                try
                {
                    Biencucbo.ma = gv.GetFocusedRowCellValue("key").ToString();
                    DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        protected override void exportex()
        {
            string path = "output.xls";
            gd.ExportToXls(path);
            Process.Start(path);
        }
        protected override void search()
        {
            try
            {
                gd.DataSource = (from a in dbData.baohiems where a.idpt == Biencucbo.idpt && a.ngaydk >= DateTime.Parse(tungay.EditValue.ToString()) && a.ngaydk <= DateTime.Parse(denngay.EditValue.ToString()) select a);
                gv.ExpandAllGroups();
                gv.BestFitColumns();
            }
            catch (Exception ex)
            {
                
            }
        }

        protected override void searchall()
        {
            try
            {
                gd.DataSource = (from a in dbData.baohiems where a.idpt == Biencucbo.idpt select a);
                gv.ExpandAllGroups();
                gv.BestFitColumns();
            }
            catch (Exception ex)
            {
            }
        }


    }
}