using System;
using DevExpress.XtraReports.UI;

namespace GUI.report.pnhap
{
    public partial class r_ctpnhap : XtraReport
    {
        public r_ctpnhap()
        {
            InitializeComponent();
            ngay2.Text = "Ngày " + DateTime.Now.Day + ", Tháng " + DateTime.Now.Month + ", Năm " + DateTime.Now.Year;
        }
    }
}