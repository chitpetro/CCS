using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class t_hopdong
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        public void moihd(string id, DateTime ngaylap, DateTime ngaybd, DateTime ngaykt, string iddt, string idnv, string iddv, string pt, string ghichu, int so, double hantt, double dmcongno, string sohd, string tiente, double tygia, string idct, string noidung, string loaihd, string link)
        {
            hopdong_tp hd = new hopdong_tp();
            hd.id = id;
            hd.ngayky = ngaylap;
            hd.ngaybd = ngaybd;
            hd.ngaykt = ngaykt;
            hd.iddt = iddt;
            hd.link = link;
            hd.idnv = idnv;
            hd.iddv = iddv;
            hd.idct = idct;
            hd.phuongthuctt = pt;
            hd.ghichu = ghichu;
            hd.hanmuctt = hantt;
            hd.dinhmuccn = dmcongno;
            hd.sohd = sohd;
            hd.so = so;
            hd.tiente = tiente;
            hd.tygia = tygia;
            hd.noidunghd = noidung;
            hd.loaihd = loaihd;
            db.hopdong_tps.InsertOnSubmit(hd);
            db.SubmitChanges();

        }

        public void moihdct(string id, string idhd_tp, string diengiai, double nguyente, double thanhtien, string loai)
        {
            hopdongct_tp hdct = new hopdongct_tp();
            hdct.id = id;
            hdct.idhd_tp = idhd_tp;
            hdct.diengiai = diengiai;
            hdct.nguyente = nguyente;
            hdct.thanhtien = thanhtien;
            hdct.loai = loai;
            db.hopdongct_tps.InsertOnSubmit(hdct);
            db.SubmitChanges();
        }

        public void suahd(string id, DateTime ngaylap, DateTime ngaybd, DateTime ngaykt, string iddt, string idnv, string iddv, string pt, string ghichu, int so, double hantt, double dmcongno, string sohd, string tiente, double tygia, string noidung, string loaihd, string link)
        {
            hopdong_tp hd = (from c in db.hopdong_tps select c).Single(x => x.id == id);


            hd.ngayky = ngaylap;
            hd.ngaybd = ngaybd;
            hd.ngaykt = ngaykt;
            hd.link = link;
            hd.iddt = iddt;
            hd.idnv = idnv;
            hd.iddv = iddv;

            hd.phuongthuctt = pt;
            hd.ghichu = ghichu;
            hd.hanmuctt = hantt;
            hd.dinhmuccn = dmcongno;
            hd.sohd = sohd;
            hd.so = so;
            hd.tiente = tiente;
            hd.tygia = tygia;
            hd.noidunghd = noidung;
            hd.loaihd = loaihd;
            db.SubmitChanges();
        }
        //public void suahdct(string id, string idhd_tp, string diengiai, double nguyente, double thanhtien, string loai)
        //{
        //    hopdongct_tp hdct = (from c in db.hopdongct_tps select c).Single(x => x.id == id);

        //    hdct.idhd_tp = idhd_tp;
        //    hdct.diengiai = diengiai;
        //    hdct.nguyente = nguyente;
        //    hdct.thanhtien = thanhtien;
        //    hdct.loai = loai;
        //    db.SubmitChanges();
        //}

        public void xoahd(string id)
        {
            hopdong_tp hd = (from c in db.hopdong_tps select c).Single(x => x.id == id);
            db.hopdong_tps.DeleteOnSubmit(hd);
            db.SubmitChanges();
        }
        public void xoact(string id)
        {
            hopdongct_tp ct = (from c in db.hopdongct_tps select c).Single(x => x.id == id);
            db.hopdongct_tps.DeleteOnSubmit(ct);
            db.SubmitChanges();
        }

        public void moitt(string id, string idhd_tp, string diengiai, DateTime ngaytt, int lan, double giatriqt, double giatritt, string ghichu, DateTime ngayxuly, double cantru, string link, string idnv, string linkgoc)
        {
            thanhtoan_tp tt = new thanhtoan_tp();
            tt.id = id;
            tt.idhd_tp = idhd_tp;
            tt.diengiai = diengiai;
            tt.ngaytt = ngaytt;
            tt.lan = lan;
            tt.giatriqt = giatriqt;
            tt.giatritt = giatritt;
            tt.ghichu = ghichu;
            tt.ngayxuly = ngayxuly;
            tt.cantru = cantru;
            tt.link = link;
            tt.idnv = idnv;
            tt.linkgoc = linkgoc;
            db.thanhtoan_tps.InsertOnSubmit(tt);
            db.SubmitChanges();
        }

        public void suatt(string id, string diengiai, DateTime ngaytt, int lan, double giatriqt, double giatritt, string ghichu, double cantru, string link, string linkgoc)
        {
            thanhtoan_tp tt = (from a in db.thanhtoan_tps select a).Single(t => t.id == id);
            tt.id = id;

            tt.diengiai = diengiai;
            tt.ngaytt = ngaytt;
            tt.lan = lan;
            tt.giatriqt = giatriqt;
            tt.giatritt = giatritt;
            tt.ghichu = ghichu;
            tt.linkgoc = linkgoc;
            tt.cantru = cantru;
            tt.link = link;


            db.SubmitChanges();
        }
    }
}
