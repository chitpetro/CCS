using System;
using DevExpress.XtraReports.UI;

namespace GUI.report.chiphimay
{
    public partial class r_bcthgtall : XtraReport
    {
        public r_bcthgtall()
        {
            InitializeComponent();
            lblghichu.Text = "ĐẾN NGÀY " + DateTime.Now.Day + " THÁNG " + DateTime.Now.Month + " NĂM " +
                             DateTime.Now.Year;
            ngay2.Text = "Ngày " + DateTime.Now.Day + ", Tháng " + DateTime.Now.Month + ", Năm " + DateTime.Now.Year;
        }
    }
}