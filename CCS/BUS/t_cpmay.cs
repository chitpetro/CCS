using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class t_cpmay
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void moiphieu(string id, DateTime ngaychi, string iddt, string iddv, string idnv, string ghichu, int so, string loaichi, string idct, string link, string donvi, string linkgoc)
        {
            cpmay pt = new cpmay();
            pt.id = id;
            pt.ngaychi = ngaychi;
            pt.iddt = iddt;
            pt.iddv = iddv;
            pt.idnv = idnv;
            pt.loaichi = loaichi;
            pt.ghichu = ghichu;
            pt.so = so;
            pt.tiente = donvi;
            pt.idct = idct;
            pt.link = link;
            pt.linkgoc = linkgoc;
            db.cpmays.InsertOnSubmit(pt);
            db.cpmays.Context.SubmitChanges();

        }
        public void moict(string diengiai, string idcv, string idmuccp, string idchi, string id, double nguyente, string idpt, double dongia, double sotien, string donvi, int stt, double catgiam, string lydocg)
        {
            cpmayct ct = new cpmayct();
            ct.diengiai = diengiai;
            ct.idcv = idcv;
            ct.stt = stt;
            ct.dongia = dongia;
            ct.sotien = sotien;
            ct.donvi = donvi;
            ct.idmuccp = idmuccp;
            ct.idchi = idchi;
            ct.id = id;
            ct.idpt = idpt;
            ct.catgiam = catgiam;
            ct.lydocg = lydocg;
            ct.nguyente = nguyente;
            db.cpmaycts.InsertOnSubmit(ct);
            db.cpmaycts.Context.SubmitChanges();

        }

        public void suaphieu(string id, DateTime ngaychi, string iddt, string ghichu, int so, string loaichi, string link, string donvi, string linkgoc)
        {
            cpmay pn = (from c in db.cpmays select c).Single(x => x.id == id);

            pn.ngaychi = ngaychi;
            pn.iddt = iddt;
            pn.ghichu = ghichu;
            pn.so = so;
            pn.tiente = donvi;
            pn.linkgoc = linkgoc;
            pn.loaichi = loaichi;
            pn.link = link;
            db.cpmays.Context.SubmitChanges();

        }

        public void xoapphieu(string id)
        {
            cpmay pt = (from c in db.cpmays select c).Single(x => x.id == id);
            db.cpmays.DeleteOnSubmit(pt);
            db.cpmays.Context.SubmitChanges();
        }
        public void xoact(string id)
        {

            cpmayct ct = (from c in db.cpmaycts select c).Single(x => x.id == id);
            db.cpmaycts.DeleteOnSubmit(ct);
            db.cpmaycts.Context.SubmitChanges();
        }
    }
}
