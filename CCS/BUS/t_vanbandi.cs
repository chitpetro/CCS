using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class t_vanbandi
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        public void moivbdi(string id, string iddv, string loaivb, DateTime ngaygui, string idnv, string sovb, string iddt, string noidung, string trichyeu, int so, string mavb, bool nb, string ghichu, string lydo, string tenct, string tendoitac)
        {
            vanbandi vb = new vanbandi();

            vb.id = id;
            vb.iddv = iddv;
            vb.ghichu = ghichu;
            vb.loaivb = loaivb;
            vb.ngaygui = ngaygui;
            vb.idnv = idnv;
            vb.sovb = sovb;
            vb.noibo = nb;
            vb.iddt = iddt;
            vb.noidung = noidung;
            vb.trichyeu = trichyeu;
            vb.so = so;
            vb.mavb = mavb;
            vb.lydo = lydo;
            vb.tenct = tenct;
            vb.tendoitac = tendoitac;
            db.vanbandis.InsertOnSubmit(vb);
            db.SubmitChanges();
        }

        public void luuct(string id, string formname, System.Data.Linq.Binary data, string size, string diengiai, string idvbdi)
        {
            filevbdi ct = new filevbdi();
            {

                ct.id = id;
                ct.formName = formname;
                ct.formData = data;
                ct.formSize = size;
               
                ct.diengiai = diengiai;
                ct.idvbdi = idvbdi;
            };
            db.filevbdis.InsertOnSubmit(ct);
            db.SubmitChanges();
        }


        public void suavbdi(string id, string iddv, string loaivb, DateTime ngaygui, string idnv, string sovb, string iddt, string noidung, string trichyeu, int so, string ghichu,string  lydo, string tenct, string tendoitac)
        {
            vanbandi vb = (from c in db.vanbandis select c).Single(x => x.id == id);

            vb.iddv = iddv;

            vb.loaivb = loaivb;
            vb.ngaygui = ngaygui;
            vb.idnv = idnv;
            vb.sovb = sovb;
            vb.iddt = iddt;
            vb.noidung = noidung;
            vb.trichyeu = trichyeu;
            vb.so = so;
            vb.ghichu = ghichu;
            vb.lydo = lydo;
            vb.tenct = tenct;
            vb.tendoitac = tendoitac;
            db.SubmitChanges();
        }

        public void xoavbdi(string id)
        {
            vanbandi vb = (from c in db.vanbandis select c).SingleOrDefault(x => x.id == id);
            db.vanbandis.DeleteOnSubmit(vb);
            db.SubmitChanges();
        }
        public void xoafile(string id)
        {
            filevbdi vb = (from c in db.filevbdis select c).Single(x => x.id == id.Trim());

            db.filevbdis.DeleteOnSubmit(vb);
            db.SubmitChanges();
        }
    }
}
