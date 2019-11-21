using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using DevExpress.XtraReports.UI;

namespace GUI.report.hopdong
{
    public partial class r_bccphdtp_ct : frm.rp
    {
        private int _stt = 0;
        private int _stt1 = 0;
        private int _stt2 = 0;

        

        public r_bccphdtp_ct()
        {
            InitializeComponent();
        }

        private void stt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            _stt1 = 0;
            _stt2 = 0;
            _stt++;
            stt.Text = _stt.ToString();
        }

        private void stt1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
            _stt2 = 0;
            _stt1++;
            stt1.Text = stt.Text + "." + _stt1.ToString();
        }

        private void stt2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            _stt2++;
            stt2.Text = stt1.Text + "." + _stt2.ToString();
        }
    }
}
