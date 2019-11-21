using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class t_theodoiphuongtien
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void moi(string id, string mapt, DateTime thoigian, string madv, double sogio, double sogiodau, double sogiocuoi, double soca, double sochuyen, double songay, double sokm, double sokmdau, double sokmcuoi, string iddv, double tondk, double captk, double tieuhaokhac, string ghichu, double tonck, double tieuhaotk, double tieuhaodv, double chenhlech, DateTime ngaycapnhat, string iddt, double dinhmuc)
        {
            theodoi_phuongtien dt = new theodoi_phuongtien();
            dt.mapt = mapt;
            dt.thoigian = thoigian;
            //dt.soluong = soluong;
            dt.madv = madv;
            dt.sogiohd = sogio;
            dt.sogiodau = sogiodau;
            dt.sogiocuoi = sogiocuoi;
            dt.socahd = soca;
            dt.sochuyen = sochuyen;
            dt.songay = songay;
            dt.sokm = sokm;
            dt.sokmdau = sokmdau;
            dt.sokmcuoi = sokmcuoi;
            dt.iddv = iddv;
            dt.id = id;
            dt.tondk = tondk;
            dt.captk = captk;
            dt.tieuhaokhac = tieuhaokhac;
            dt.ghichu = ghichu;
            dt.tonck = tonck;
            dt.tieuhaothuctetk = tieuhaotk;
            dt.tieuhaodv = tieuhaodv;
            dt.chenhlech = chenhlech;

            dt.ngaycapnhat = ngaycapnhat;
            dt.iddt = iddt;
            dt.dinhmuc = dinhmuc;

            db.theodoi_phuongtiens.InsertOnSubmit(dt);
            db.SubmitChanges();
        }
        public void sua(string id, string mapt, DateTime thoigian, string madv, double sogio, double sogiodau, double sogiocuoi, double soca, double sochuyen, double songay, double sokm, double sokmdau, double sokmcuoi, double tondk, double captk, double tieuhaokhac, string ghichu, double tonck, double tieuhaotk, double tieuhaodv, double chenhlech, DateTime ngaycapnhat, string iddt, double dinhmuc)
        {
            theodoi_phuongtien dt = (from d in db.theodoi_phuongtiens select d).Single(t => t.id == id);
            dt.thoigian = thoigian;
            //dt.soluong = soluong;
            dt.madv = madv;
            dt.sogiohd = sogio;
            dt.sogiodau = sogiodau;
            dt.sogiocuoi = sogiocuoi;
            dt.socahd = soca;
            dt.sochuyen = sochuyen;
            dt.songay = songay;
            dt.sokm = sokm;
            dt.sokmdau = sokmdau;
            dt.sokmcuoi = sokmcuoi;
            dt.tondk = tondk;
            dt.captk = captk;
            dt.tieuhaokhac = tieuhaokhac;
            dt.ghichu = ghichu;
            dt.tonck = tonck;
            dt.tieuhaothuctetk = tieuhaotk;
            dt.tieuhaodv = tieuhaodv;
            dt.chenhlech = chenhlech;
            dt.ngaycapnhat = ngaycapnhat;
            dt.iddt = iddt;
            dt.dinhmuc = dinhmuc;
            db.SubmitChanges();
        }
        public void xoa(string id)
        {
            theodoi_phuongtien dt = (from d in db.theodoi_phuongtiens select d).Single(t => t.id == id);
            db.theodoi_phuongtiens.DeleteOnSubmit(dt);
            db.SubmitChanges();
        }
    }
}