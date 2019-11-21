using BUS;
using DevExpress.XtraReports.UI;
using GUI.Report.PhuongTien;

namespace GUI
{
    public partial class r_DsTheoDoi_PT_CT : XtraReport
    {
        public r_DsTheoDoi_PT_CT()
        {
            InitializeComponent();
            //LanguageHelper.Translate(this);
            //changeFont.Translate(this);

            //1 LÍT / KM(XE) --> xe
            //1 LÍT / GIỜ(MÁY) -->máy

            lbthoigian.Text = Biencucbo.time;
            lbcongtrinh.Text = f_DsTheoDoiPT.ct;
        }
    }
}