using System;
using DevExpress.XtraReports.UI;

namespace GUI.report.chiphikhac
{
    public partial class r_pchi : XtraReport
    {
        public r_pchi()
        {
            InitializeComponent();
            ngay2.Text = "Ngày " + DateTime.Now.Day + ", Tháng " + DateTime.Now.Month + ", Năm " + DateTime.Now.Year;
            //ngay.Text = Biencucbo.ngay;
        }
    }
}