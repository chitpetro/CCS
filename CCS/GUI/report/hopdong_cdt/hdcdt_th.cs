using System;
using DevExpress.XtraReports.UI;

namespace GUI.report
{
    public partial class hdcdt_th : XtraReport
    {
        public hdcdt_th()
        {
            InitializeComponent();

            ngay2.Text = "Ngày " + DateTime.Now.Day + ", Tháng " + DateTime.Now.Month + ", Năm " + DateTime.Now.Year;
        }
    }
}