using System;
using System.Drawing;
using System.Drawing.Printing;
using BUS;
using DevExpress.XtraReports.UI;

namespace GUI
{
    public partial class r_lichtrinh : XtraReport
    {
        private int index;
        private string stt = string.Empty;

        public r_lichtrinh()
        {
            InitializeComponent();
            //LanguageHelper.Translate(this);
            //changeFont.Translate(this);

            txtngay.Text = "Từ ngày " + Biencucbo.tungay2.ToShortDateString() + " đến ngày " +
                           Biencucbo.denngay2.ToShortDateString();
            lbngay.Text =
                lbngay2.Text =
                    "Vientiane, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
        }

        private void xrTableCell14_BeforePrint(object sender, PrintEventArgs e)
        {
            if (lbNoiDung.Text != stt)
            {
                stt = lbNoiDung.Text;
                index++;
            }
            xrTableCell14.Text = index.ToString();
        }

        private void xrTableCell15_BeforePrint(object sender, PrintEventArgs e)
        {
            if (xrTableCell15.Text == "Đã Xử Lý")
            {
                xrTableCell15.BackColor = Color.GreenYellow;
            }
        }
    }
}