using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using BUS;
using DevExpress.XtraReports.UI;

namespace GUI.report
{
    public partial class r_BCnhapkhopn_CT : DevExpress.XtraReports.UI.XtraReport
    {
        private int _stt1 = 0;
        private int _stt2 = 0;
        private int _stt3 = 0;
        public r_BCnhapkhopn_CT()
        {
            InitializeComponent();
            txtngayxem.Text = Biencucbo.ngaybc;
            txtinfo.Text = Biencucbo.info;
            //Phiếu nhập: [idpn] - Ngày nhập: [ngaynhap] - Diễn giải: [diengiai]
        }

        private void stt1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            _stt1++;
            _stt2 = 0;
            _stt3 = 0;
            stt1.Text = _stt1.ToString();
        }

        private void stt2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            _stt2++;
            _stt3 = 0;
            stt2.Text = stt1.Text + "." + _stt2;
        }

        private void stt3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            _stt3++;
            stt3.Text = stt2.Text + "." + _stt3;
        }
    }
}
