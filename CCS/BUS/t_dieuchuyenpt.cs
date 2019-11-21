using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class t_dieuchuyenpt
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void moi(string mapt,DateTime thoigian, string madv, double sogio, double soca, double tondk, double captk, double chuyencho, double tonck, double tieuhaotk, double tieuhaodv, double chenhlech)
        {
            theodoi_phuongtien dt = new theodoi_phuongtien();
            dt.mapt = mapt;
            dt.thoigian = thoigian;
            //dt.soluong = soluong;
            dt.madv = madv;
            dt.sogiohd = sogio;
            dt.socahd = soca;

            dt.tondk = tondk;
            dt.captk = captk;
            dt.chuyencho = chuyencho;
            dt.tonck = tonck;
            dt.tieuhaothuctetk = tieuhaotk;
            dt.tieuhaodv = tieuhaodv;
            dt.chenhlech = chenhlech;

            db.theodoi_phuongtiens.InsertOnSubmit(dt);
            db.SubmitChanges();
        }
        public void sua(string mapt, DateTime thoigian,   string madv, double sogio, double soca, double tondk, double captk, double chuyencho, double tonck, double tieuhaotk, double tieuhaodv, double chenhlech)
        {
            theodoi_phuongtien dt = (from d in db.theodoi_phuongtiens select d).Single(t => t.mapt == mapt);
            dt.thoigian = thoigian;
            //dt.soluong = soluong;
            dt.madv = madv;
            dt.sogiohd = sogio;
            dt.socahd = soca;

            dt.tondk = tondk;
            dt.captk = captk;
            dt.chuyencho = chuyencho;
            dt.tonck = tonck;
            dt.tieuhaothuctetk = tieuhaotk;
            dt.tieuhaodv = tieuhaodv;
            dt.chenhlech = chenhlech;

            db.SubmitChanges();
        }
        public void xoa(string mapt)
        {
            theodoi_phuongtien dt = (from d in db.theodoi_phuongtiens select d).Single(t => t.mapt == mapt);
            db.theodoi_phuongtiens.DeleteOnSubmit(dt);
            db.SubmitChanges();
        }
    }
}