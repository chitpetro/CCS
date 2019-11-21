using System;
using DevExpress.XtraReports.UI;

namespace GUI.report
{
    public partial class hdth_th : XtraReport
    {
        public hdth_th()
        {
            InitializeComponent();

            ngay2.Text = "Ngày " + DateTime.Now.Day + ", Tháng " + DateTime.Now.Month + ", Năm " + DateTime.Now.Year;
        }
    }
}