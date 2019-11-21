using System;
using BUS;
using DevExpress.XtraReports.UI;

namespace GUI.report
{
    public partial class hdtp1_ct : XtraReport
    {
        public hdtp1_ct()
        {
            InitializeComponent();
            lblcongtrinh.Text = Biencucbo.bcct;
            lbldiadiem.Text = Biencucbo.bcdc;
            lblcht.Text = Biencucbo.bccht;
            ngay2.Text = "Ngày " + DateTime.Now.Day + ", Tháng " + DateTime.Now.Month + ", Năm " + DateTime.Now.Year;
        }
    }
}