using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using BUS;

namespace GUI
{
    public partial class r_dsnhanvien : DevExpress.XtraReports.UI.XtraReport
    {
        public r_dsnhanvien()
        {
            InitializeComponent();
            txttitle.Text = "BẢNG CHẤM CÔNG THÁNG " + Biencucbo.thang + " NĂM " + Biencucbo.nam;
        }

        private int index;
        private string stt = string.Empty;
        private void xrSTT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (lbNoiDung.Text != stt)
            {
                stt = lbNoiDung.Text;
                index++;
            }
            else
            {
                stt = lbNoiDung.Text;
                index++;
            }
            xrSTT.Text = index.ToString();
        }
    }
}
