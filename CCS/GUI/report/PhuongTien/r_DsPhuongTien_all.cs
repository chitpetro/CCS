using ControlLocalizer;
using DevExpress.XtraReports.UI;

namespace GUI
{
    public partial class r_DsPhuongTien_all : XtraReport
    {
        public r_DsPhuongTien_all()
        {
            InitializeComponent();
            //LanguageHelper.Translate(this);
            //changeFont.Translate(this);

            lbnhom.Text = "Nhóm Phương Tiện : " + f_phuongtien.nhom;
            lbngaycapnhat.Text = "Ngày Cập Nhật: " + f_phuongtien.g_ngaycapnhat;
            lbCT.Text = "Công Trình: " + f_phuongtien.g_tenct;
        }
    }
}