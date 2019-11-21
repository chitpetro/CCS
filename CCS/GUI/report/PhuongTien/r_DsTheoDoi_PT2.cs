using BUS;
using DevExpress.XtraReports.UI;
using GUI.Report.PhuongTien;

namespace GUI
{
    public partial class r_DsTheoDoi_PT2 : XtraReport
    {
        public r_DsTheoDoi_PT2()
        {
            InitializeComponent();
            //LanguageHelper.Translate(this);
            //changeFont.Translate(this);

            //1 LÍT / KM(XE) --> xe
            //1 LÍT / GIỜ(MÁY) -->máy

            lbthoigian.Text = Biencucbo.time;
            lbcongtrinh.Text = f_DsTheoDoiPT.ct;
            lbtenxe.Text = f_DsTheoDoiPT.tenxe;

            var loai = f_DsTheoDoiPT.loaixemay;
            if (loai == "1 LÍT / KM(XE)")
            {
                txttitle.Text = "NHẬT TRÌNH XE HOẠT ĐỘNG";
                lbCaKm.Text = "Số Chuyến";
                lbTong1.Text = "Tổng số chuyến :";
                lbTong2.Text = "Tổng số giờ :";
                lbTong3.Text = "Tổng số nhiên liệu";
            }
            else if (loai == "1 LÍT / GIỜ(MÁY)")
            {
                txttitle.Text = "NHẬT TRÌNH MÁY HOẠT ĐỘNG";
                lbCaKm.Text = "Số Ca";
                lbTong1.Text = "Tổng số KM :";
                lbTong2.Text = "Tổng số ca :";
                lbTong3.Text = "Tổng số nhiên liệu";
            }
            else
            {
                txttitle.Text = "NHẬT TRÌNH XE/MÁY HOẠT ĐỘNG";
                lbCaKm.Text = "Số Ca";
                lbTong1.Text = "Tổng số giờ/chuyến :";
                lbTong2.Text = "Tổng số ca/ngày :";
                lbTong3.Text = "Tổng số nhiên liệu";
            }
        }
    }
}