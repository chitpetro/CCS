using System;
using BUS;
using ControlLocalizer;
using DevExpress.XtraReports.UI;

namespace GUI
{
    public partial class r_DsPhuongTien : XtraReport
    {
        public r_DsPhuongTien()
        {
            InitializeComponent();
            LanguageHelper.Translate(this);
            changeFont.Translate(this);

            txtcongtrinh.Text += Biencucbo.kho;
            txtngay.Text += DateTime.Now.ToShortDateString();
        }
    }
}