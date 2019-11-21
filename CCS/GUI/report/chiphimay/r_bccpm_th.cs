using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace GUI.report.chiphimay
{
    public partial class r_bccpm_th : frm.rp
    {
        private int _stt = 0;
        int _stt1 = 0;

        public r_bccpm_th()
        {
            InitializeComponent();
        }

        private void stt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            _stt1 = 0;
            _stt++;
            stt.Text = _stt.ToString();

        }

        private void stt1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            _stt1++;
            stt1.Text = stt.Text + "." + _stt1.ToString();
        }
    }
}
