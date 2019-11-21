using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace GUI
{
    public partial class r_pxmnhapkho : DevExpress.XtraReports.UI.XtraReport
    {
        public r_pxmnhapkho()
        {
            InitializeComponent();
            txtngayky.Text = "Ngày " + DateTime.Now.Day + " Tháng " + DateTime.Now.Month + " Năm " + DateTime.Now.Year;

        }

        private void r_pxmnhapkho_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
       
        }

        private void txtngay_TextChanged(object sender, EventArgs e)
        {
              
        }
    }
}
