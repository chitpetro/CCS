using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class t_hopdong_cdt
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        public void moihd(string id, DateTime ngaylap, DateTime ngaybd, DateTime ngaykt, string iddt, string idnv, string iddv, string pt, string ghichu, int so, double hantt, double dmcongno, string sohd, string tiente, double tygia, string idct, string noidung, string loaihd, string link)
        {
            hopdong_cdt hd = new hopdong_cdt();
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
            db.hopdong_cdts.InsertOnSubmit(hd);
            db.SubmitChanges();

        }

        public void moihdct(string id, string idhd_tp, string diengiai, double nguyente, double thanhtien, string loai)
        {
            hopdongct_cdt hdct = new hopdongct_cdt();
            hdct.id = id;
            hdct.idhd_cdt = idhd_tp;
            hdct.diengiai = diengiai;
            hdct.nguyente = nguyente;
            hdct.thanhtien = thanhtien;
            hdct.loai = loai;
            db.hopdongct_cdts.InsertOnSubmit(hdct);
            db.SubmitChanges();
        }

        public void suahd(string id, DateTime ngaylap, DateTime ngaybd, DateTime ngaykt, string iddt, string idnv, string iddv, string pt, string ghichu, int so, double hantt, double dmcongno, string sohd, string tiente, double tygia, string noidung, string loaihd, string link)
        {
            hopdong_cdt hd = (from c in db.hopdong_cdts select c).Single(x => x.id == id);


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
            hopdong_cdt hd = (from c in db.hopdong_cdts select c).Single(x => x.id == id);
            db.hopdong_cdts.DeleteOnSubmit(hd);
            db.SubmitChanges();
        }
        public void xoact(string id)
        {
            hopdongct_cdt ct = (from c in db.hopdongct_cdts select c).Single(x => x.id == id);
            db.hopdongct_cdts.DeleteOnSubmit(ct);
            db.SubmitChanges();
        }
    }
}
