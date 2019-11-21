using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.Linq;

namespace BUS
{
    public class t_dmchucvu
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void themcv(string id, string chucvu)
        {
            dmchucvu cv = new dmchucvu();
            cv.id = id;
            cv.chucvu = chucvu;
            db.dmchucvus.InsertOnSubmit(cv);
            db.SubmitChanges();
        }
        public void suacv(string id, string chucvu)
        {
            dmchucvu cv = (from a in db.dmchucvus select a).Single(t => t.id == id);
            cv.chucvu = chucvu;
            db.SubmitChanges();
        }

        public void xoacv(string id)
        {
            dmchucvu cv = (from a in db.dmchucvus select a).Single(t => t.id == id);
            db.dmchucvus.DeleteOnSubmit(cv);
            db.SubmitChanges();
        }
    }
}
