using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace GUI.report.chiphikhac
{
    public partial class r_inpchi : DevExpress.XtraReports.UI.XtraReport
    {
        private int _stt = 0;
        public r_inpchi()
        {
            InitializeComponent();
        }

        private void stt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            _stt ++;
            stt.Text = _stt.ToString();
        }
    }
}
