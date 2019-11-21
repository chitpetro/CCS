using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using BUS;
using DevExpress.XtraReports.UI;

namespace GUI.report.PXM
{
    public partial class r_BCXuatkho_TH : DevExpress.XtraReports.UI.XtraReport
    {
        private int _stt1 = 0;
        private int _stt2 = 0;
        public r_BCXuatkho_TH()
        {
            InitializeComponent();
            txtngayxem.Text = Biencucbo.ngaybc;
            txtinfo.Text = Biencucbo.info;
        }
        
        private void stt1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            _stt1++;
            _stt2 = 0;
            stt1.Text = _stt1.ToString();
        }
        
        private void stt2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            _stt2 ++;
            stt2.Text = stt1.Text +"." + _stt2;
        }
    }
}
