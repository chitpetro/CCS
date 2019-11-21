using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class t_vanbanden
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        public void moivbd(string id, string iddv, string loaivb, DateTime ngaynhan, string idnv, string sovb, string iddt, string noidung, string trichyeu, int so, bool noibo, bool duyet, string ghichu, string lydo, string tenct, string tendoitac)
        {
            vanbanden vb = new vanbanden();

            vb.id = id;
            vb.iddv = iddv;
            vb.ghichu = ghichu;
            vb.loaivb = loaivb;
            vb.ngaynhan = ngaynhan;
            vb.idnv = idnv;
            vb.sovb = sovb;
            vb.iddt = iddt;
            vb.noidung = noidung;
            vb.trichyeu = trichyeu;
            vb.so = so;
            vb.noibo = noibo;
            vb.duyet = duyet;
            vb.lydo = lydo;
            vb.tenct = tenct;
            vb.tendoitac = tendoitac;
            db.vanbandens.InsertOnSubmit(vb);
            db.SubmitChanges();
        }

        public void luuct(string id, string formname, System.Data.Linq.Binary data, string size, string diengiai, string idvbdi)
        {
            filevbden ct = new filevbden();
            {

                ct.id = id;
                ct.formName = formname;
                ct.formData = data;
                ct.formSize = size;

                ct.diengiai = diengiai;
                ct.idvbden = idvbdi;
            };
            db.filevbdens.InsertOnSubmit(ct);
            db.SubmitChanges();
        }

         public void suavbd2(string id, string iddv, string loaivb, DateTime ngaynhan, string idnv, string sovb, string iddt, string noidung, string trichyeu, int so, string ghichu, string lydo, string tenct, string tendoitac)
        {
            vanbanden vb = (from c in db.vanbandens select c).Single(x => x.id == id);

            vb.iddv = iddv;

            vb.loaivb = loaivb;
            vb.ngaynhan = ngaynhan;
            vb.idnv = idnv;
            vb.sovb = sovb;
            vb.ghichu = ghichu;
            vb.iddt = iddt;
            vb.noidung = noidung;
            vb.trichyeu = trichyeu;
            vb.so = so;
            vb.lydo = lydo;
            vb.tenct = tenct;
            vb.tendoitac = tendoitac;
            db.SubmitChanges();
        }
        public void suavbd(string id, string iddv, string loaivb, DateTime ngaynhan, string idnv, string sovb, string iddt, string noidung, string trichyeu, int so, string ghichu, string lydo, string tenct, string tendoitac)
        {
            vanbanden vb = (from c in db.vanbandens select c).Single(x => x.id == id);

            vb.iddv = iddv;

            vb.loaivb = loaivb;
            vb.ngaynhan = ngaynhan;
            vb.idnv = idnv;
            vb.sovb = sovb;
            vb.ghichu = ghichu;
            vb.iddt = iddt;
            vb.noidung = noidung;
            vb.trichyeu = trichyeu;
            vb.so = so;
            vb.lydo = lydo;
            vb.tenct = tenct;
            vb.tendoitac = tendoitac;
            db.SubmitChanges();
        }

        public void xoavbd(string id)
        {
            vanbanden vb = (from c in db.vanbandens select c).Single(x => x.id == id);
            db.vanbandens.DeleteOnSubmit(vb);
            db.SubmitChanges();
        }
        public void xoafile(string id)
        {
            filevbden vb = (from c in db.filevbdens select c).Single(x => x.id == id.Trim());

            db.filevbdens.DeleteOnSubmit(vb);
            db.SubmitChanges();
        }
    }
}
