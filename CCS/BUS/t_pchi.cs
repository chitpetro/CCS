using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class t_pchi
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void moiphieu(string id, DateTime ngaychi, string iddt, string iddv, string idnv, string ghichu, int so, string tiente, double tygia, string idct, string link, string linkgoc)
        {
            pchi pt = new pchi();
      
            pt.id = id;
            pt.ngaychi = ngaychi;
            pt.iddt = iddt;
            pt.iddv = iddv;
            pt.idnv = idnv;
            pt.link = link;
         
            pt.ghichu = ghichu;
            pt.so = so;
            pt.tiente = tiente;
            pt.tygia = tygia;
            pt.idct = idct;
            pt.linkgoc = linkgoc; 
            db.pchis.InsertOnSubmit(pt);
            db.pchis.Context.SubmitChanges();

        }
        public void moict(string diengiai, string idcv, string idmuccp, double thanhtien, string idchi, string id, double nguyentebch, double nguyentecn, double nguyentect, int stt, double catgiam)
        {
            pchict ct = new pchict();
            ct.diengiai = diengiai;
            ct.idcv = idcv;
            ct.stt = stt;
            ct.idmuccp = idmuccp;
            ct.sotien = thanhtien;
            ct.idchi = idchi;
            ct.catgiam = catgiam;
            ct.id = id;
            ct.nguyentebch = nguyentebch;
            ct.nguyentecn = nguyentecn;
            ct.nguyentect = nguyentect;
            db.pchicts.InsertOnSubmit(ct);
            db.SubmitChanges();

        }

        public void suaphieu(string id, DateTime ngaychi, string iddt, string ghichu, int so, string tiente, double tygia, string link, string linkgoc)
        {
            pchi pn = (from c in db.pchis select c).Single(x => x.id == id );
            pn.ngaychi = ngaychi;
            pn.iddt = iddt;
            pn.ghichu = ghichu;
            pn.so = so;
            pn.tiente = tiente;
            pn.link = link;
            pn.tygia = tygia;
           
            pn.linkgoc = linkgoc;
            db.pchis.Context.SubmitChanges();

        }

        public void xoapphieu(string id)
        {
            pchi pt = (from c in db.pchis select c).Single(x => x.id == id);
            db.pchis.DeleteOnSubmit(pt);
            db.pchis.Context.SubmitChanges();
        }
        public void xoact(string id)
        {

            pchict ct = (from c in db.pchicts select c).Single(x => x.id == id);
            db.pchicts.DeleteOnSubmit(ct);
            db.pchicts.Context.SubmitChanges();
        }
    }
}
