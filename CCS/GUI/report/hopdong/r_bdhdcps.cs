using System;
using BUS;
using DevExpress.XtraReports.UI;

namespace GUI.report
{
    public partial class r_bdhdcps : XtraReport
    {
        public r_bdhdcps()
        {
            InitializeComponent();
            //lblcongtrinh.Text = Biencucbo.bcct;
            //lbldiadiem.Text = Biencucbo.bcdc;
            //lblcht.Text = Biencucbo.bccht;
            ngay2.Text = "Ngày " + DateTime.Now.Day + ", Tháng " + DateTime.Now.Month + ", Năm " + DateTime.Now.Year;
            ngay.Text = Biencucbo.ngay;
        }
    }
}