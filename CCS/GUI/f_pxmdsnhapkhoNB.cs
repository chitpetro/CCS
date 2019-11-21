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
using DAL;
using System.Diagnostics;

namespace GUI
{
    public partial class f_pxmdsnhapkhoNB : frmdsmo
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        private bool dble;
        public f_pxmdsnhapkhoNB()
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
        protected override void exportex()
        {
            string path = "output.xls";
            gd.ExportToXls(path);
            Process.Start(path);
        }
        protected override void search()
        {
            gd.DataSource = dbData.LayDsPnhapkhoNB(DateTime.Parse(tungay.EditValue.ToString()), DateTime.Parse(denngay.EditValue.ToString()), Biencucbo.mact);
            gv.ExpandAllGroups();
            gv.BestFitColumns();
        }

        protected override void searchall()
        {
            gd.DataSource = dbData.LayDsPnhapkhoNBALL(Biencucbo.mact);
            gv.ExpandAllGroups();
            gv.BestFitColumns();
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
            try
            {
                if (dble)
                {
                    Biencucbo.ma = gv.GetFocusedRowCellValue("key").ToString();
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}