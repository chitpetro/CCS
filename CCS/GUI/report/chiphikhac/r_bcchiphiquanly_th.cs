using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using BUS;
using DevExpress.XtraReports.UI;


namespace GUI.report.chiphikhac
{
    public partial class r_bcchiphiquanly_th : frm.rp
    {
        int _stt = 0;
        int _stt1 = 0;
        int _stt2 = 0;
        
        DataTable dt = new DataTable();
        public r_bcchiphiquanly_th()
        {
            InitializeComponent();
            
            
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
          
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
            _stt1 ++;
            stt1.Text = stt.Text + "." + _stt1;
        }

       
    }
}
