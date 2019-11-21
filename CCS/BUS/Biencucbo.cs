using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class Biencucbo
    {
        public static string key = "";

        public static bool sua = false;
        //in bao cao
        public static string ngaybc;
        public static string info;
        public static bool xembc = false;

        // hoạt động mới
        public static int hdong;
        public static int so;
        public static string form;
        //chucvu
        public static int hdcv = 0;
        public static string idcvu = "";

        // calc
        public static double value = 0;

        // mo phieu
        public static string mamo = "";

        // chamcong
        public static string id = "";
        public static int hdcc = 0;
        public static int thang = 0;
        public static int nam = 0;

        // in van ban
        public static DateTime tungay2, denngay2;

        // lịch sử giao nhận hồ sơ

        public static string idgoc = "";

        // Thanh toán hợp đồng
        public static int hdtthdtp = 0;
        //public static string mahdtp = "";
        public static string matthdtp = "";

        //
        public static double theodoitt;
        public static double theodoith;
        public static int hdtdtt = 0;
        // văn bản nội bộ 
        public static int nb = 0;
        public static int dsnb = 0;
        // hethong
        public static string ten = "admin";
        public static string ngay;
        public static string tit = "";
        public static string idnv = "admin";
        public static string phongban = "IT";
        public static string donvi = "00";
        public static string tendvbc = "";
        public static string sohd = "";
        public static string dvTen = "";
        public static string ma = "";
        public static string tien = "";
        public static int getID = 0;
        public static string skin = "";
        public static string skin2 = "";
        public static string hostname = "";
        public static string IPaddress = "";
        public static string DbName;
        public static string ServerName;

        //moi
        public static string linkHS = "";
        //pchi
        public static int hdpc = 0;

        // account
        public static int hdaccount = 0;
        public static int hdaccount2 = 2;
        public static int soaccount = 1;
        public static string account = "";

        // donvi
        public static int hddv = 0;

        // doituong 
        public static int hddt = 0;

        //loaihd
        public static int hdlhd = 0;
        // cong trinh
        public static int hdct = 0;
        public static int soct = 0;
        //khuvuc
        public static int hdkv = 0;

        // loai cong trinh
        public static int hdlct = 0;

        // chon cong trinh
        public static string mact = "";

        //nhomdoituong
        public static int hdndt = 0;

        // file hop dong
        public static int fhd = 0;

        // Sản Phẩm
        public static int hdsp = 0;

        //Hopdong
        public static int hdhdtp = 0;
        public static int hdhdcdt = 0;
        public static int acthd = 0;

        //Thanhtoan_tp
        public static double tt_tp;
        public static int hdtt = 0;

        //public static int hdct = 0;
        public static string hopdong = "";

        //công việc

        public static int cv = 0;


        //báo cáo
        public static string Congtrinh = "Tất cả";
        public static string sp = "Tất cả";

        public static string doituong = "Tất cả";
        public static string congviec = "Tất cả";
        public static string title = "";
        public static string taikhoan = "";
        public static string khuvuc = "";
        public static string loaict = "";
        public static string nguoncap = "";
        public static string loaihd = "";
        public static string kho = "";
        public static string time = "";
        public static string loai = "";
        public static string muccp = "";

        public static double tondau = 0;
        public static double tondau2 = 0;
        public static double toncuoi = 0;
        public static double tonxuat = 0;
        public static double tonxuat2 = 0;

        //ngon ngu
        public static object ngonngu;

        //tiền tệ
        public static int hdttoan = 0;

        // Doi tuong    
        public static string iddt = "";

        // bao cao cong trinh

        public static string bcct = "";
        public static string bcdc = "";
        public static string bccht = "";


        // Phieu Nhap

        public static int hdpn = 0;

        // Loại Nguồn Cấp

        public static int hdlnc = 0;


        // Xe Máy

        public static int dcpt = 0;
        public static int ltlc = 0;
        public static int tdpt = 0;
        public static int npt = 0;
        public static int pt = 0;
        public static string idpt = "";
        public static int tthd = 0;

        //Quản lý hồ sơ

        //vanbanden
        public static int vbden = 0;
        //vanbandi
        public static int vbdi = 0;
        public static int linkvb = 0;

        public static byte[] test = null;


        //loại văn bản
        public static int lvb = 0;

        //luu file
        public static int file = 0;

        // duyeths
        public static string idduyet = "";
        public static string loaiduyet = "";
        public static int hdduyet = 0;

        //phuong tien
        public static DateTime g_ngaycapnhat;


        // phân quyền
        public static PhanQuyen2 QuyenDangChon { get; set; }
      //  public static PhanQuyen2 QuyenDangChonpopup { get; set; }



    }
}
