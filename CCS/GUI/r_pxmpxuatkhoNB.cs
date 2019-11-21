using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace GUI
{
    public partial class r_pxmpxuatkhoNB : DevExpress.XtraReports.UI.XtraReport
    {
        public r_pxmpxuatkhoNB()
        {
            InitializeComponent();
            txtngayky.Text = "Ngày " + DateTime.Now.Day + " Tháng " + DateTime.Now.Month + " Năm " + DateTime.Now.Year;
        }

    }
}
