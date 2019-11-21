using System;
using BUS;
using DevExpress.XtraReports.UI;

namespace GUI.report.chiphimay
{
    public partial class r_bccttb : XtraReport
    {
        public r_bccttb()
        {
            InitializeComponent();
            lblcongtrinh.Text = Biencucbo.bcct;
            lbldiadiem.Text = Biencucbo.bcdc;
            lblcht.Text = Biencucbo.bccht;
            ngay2.Text = "Ngày " + DateTime.Now.Day + ", Tháng " + DateTime.Now.Month + ", Năm " + DateTime.Now.Year;
        }
    }
}