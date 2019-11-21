using System;
using DevExpress.XtraReports.UI;

namespace GUI.report.pnhap
{
    public partial class r_thpnhap : XtraReport
    {
        public r_thpnhap()
        {
            InitializeComponent();
            ngay2.Text = "Ngày " + DateTime.Now.Day + ", Tháng " + DateTime.Now.Month + ", Năm " + DateTime.Now.Year;
        }
    }
}