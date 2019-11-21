using System;
using DevExpress.XtraReports.UI;

namespace GUI.report
{
    public partial class hdcdt_ct : XtraReport
    {
        public hdcdt_ct()
        {
            InitializeComponent();
            //lblcongtrinh.Text = Biencucbo.bcct;
            //lbldiadiem.Text = Biencucbo.bcdc;
            //lblcht.Text = Biencucbo.bccht;
            ngay2.Text = "Ngày " + DateTime.Now.Day + ", Tháng " + DateTime.Now.Month + ", Năm " + DateTime.Now.Year;
        }
    }
}