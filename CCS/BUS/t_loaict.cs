using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class t_loaict
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void moi(string id, string loaict)
        {
            loaict dt = new loaict();
            dt.id = id;
            dt.loaict1 = loaict;

            db.loaicts.InsertOnSubmit(dt);
            db.SubmitChanges();
        }
        public void sua(string id, string loaict)
        {
            loaict dt = (from d in db.loaicts select d).Single(t => t.id == id);
            dt.loaict1 = loaict;

            db.SubmitChanges();
        }
        public void xoa(string id)
        {
            loaict dt = (from d in db.loaicts select d).Single(t => t.id == id);
            db.loaicts.DeleteOnSubmit(dt);
            db.SubmitChanges();
        }
    }
}