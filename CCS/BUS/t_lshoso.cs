using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class t_lshoso
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void moi(string id, string idgoc, int buoc, string noiguiden, DateTime ngaynhan, string idnvnhan, string hsgoc, string iddv, string phong, string ngxuly)
        {
            lshoso a = new lshoso();
            a.id = id;
            a.idgoc = idgoc;
            a.buoc = buoc;
            a.noiguiden = noiguiden;
            a.ngaynhan = ngaynhan;
            a.idnvnhan = idnvnhan;
            a.iddv = iddv;
            a.hsgoc = hsgoc;
            a.phong = phong;
            a.ngxulyden = ngxuly;
            db.lshosos.InsertOnSubmit(a);
            db.SubmitChanges();
        }
        public void moidi(string id, string idgoc, int buoc, string noiguidi, DateTime ngaygui, string idnvgui, string idvbdi, string hsgoc, string iddv, string phong, string lydo)
        {
            lshoso a = new lshoso();
            a.id = id;
            a.idgoc = idgoc;
            a.buoc = buoc;
            a.noiguidi = noiguidi;
            a.ngaygui = ngaygui;
            a.idnvgui = idnvgui;
            a.idvbdi = idvbdi;
            a.iddv = iddv;
            a.hsgoc = hsgoc;
            a.phong = phong;
            a.lydo = lydo;
            db.lshosos.InsertOnSubmit(a);
            db.SubmitChanges();
        }
        public void suaden(string idgoc, string noiguiden, DateTime ngaynhan, string idnvnhan, string ngxulyden)
        {
            lshoso a = (from b in db.lshosos select b).Single(t => t.idgoc == idgoc);

            a.noiguiden = noiguiden;
            a.ngaynhan = ngaynhan;
            a.idnvnhan = idnvnhan;
            a.ngxulyden = ngxulyden;
            db.SubmitChanges();
        }


        public void suadithem(string idgoc, string noiguidi, DateTime ngaygui, string idnvgui, string idvbdi, string lydo)
        {
            lshoso a = (from b in db.lshosos select b).Single(t => t.idgoc == idgoc);

            a.noiguidi = noiguidi;
            a.ngaygui = ngaygui;
            a.idnvgui = idnvgui;
            a.idvbdi = idvbdi;
            a.lydo = lydo;
            db.SubmitChanges();
        }
        public void suadi(string noiguidi, DateTime ngaygui, string idnvgui, string idvbdi, string lydo)
        {
            lshoso a = (from b in db.lshosos select b).Single(t => t.idvbdi == idvbdi);

            a.noiguidi = noiguidi;
            a.ngaygui = ngaygui;
            a.idnvgui = idnvgui;
            a.idvbdi = idvbdi;
            a.lydo = lydo;
           
            db.SubmitChanges();
        }

        public void suaden2(string id, string noiguiden, DateTime ngaynhan, string iddv)
        {
            lshoso a = (from b in db.lshosos select b).Single(t => t.id == id);

            a.phong = noiguiden;
            a.ngaynhan = ngaynhan;
            a.iddv = iddv;
            db.SubmitChanges();
        }

        //public void xoa(string id)
        //{
        //    lshoso a = (from b in db.lshosos select b).Single(t => t.id == id);
        //    db.lshosos.DeleteOnSubmit(a);
        //    db.SubmitChanges();
        //}
    }
}