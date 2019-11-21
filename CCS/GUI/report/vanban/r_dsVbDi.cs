using System;
using BUS;
using DevExpress.XtraReports.UI;

namespace GUI
{
    public partial class r_dsVbDi : XtraReport
    {
        public r_dsVbDi()
        {
            InitializeComponent();
            //LanguageHelper.Translate(this);
            //changeFont.Translate(this);
            txttitle.Text = Biencucbo.title;
            txtngay.Text = "Từ ngày " + Biencucbo.tungay2.ToShortDateString() + " đến ngày " +
                           Biencucbo.denngay2.ToShortDateString();
            lbngay.Text =
                lbngay2.Text =
                    "Vientiane, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
        }
    }
}