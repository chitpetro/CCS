using System;
using BUS;
using DevExpress.XtraReports.UI;

namespace GUI.report.chiphimay
{
    public partial class r_bcthcpall : XtraReport
    {
        public r_bcthcpall()
        {
            InitializeComponent();
            lbltit.Text = Biencucbo.tit;
            ngay2.Text = "Ngày " + DateTime.Now.Day + ", Tháng " + DateTime.Now.Month + ", Năm " + DateTime.Now.Year;
        }
    }
}