using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class t_loainc
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void moi(string id, string nguonvon)
        {
            nguoncap dt = new nguoncap();
            dt.id = id;
            dt.tennguoncap = nguonvon;

            db.nguoncaps.InsertOnSubmit(dt);
            db.SubmitChanges();
        }
        public void sua(string id, string nguonvon)
        {
            nguoncap dt = (from d in db.nguoncaps select d).Single(t => t.id == id);
            dt.tennguoncap = nguonvon;

            db.SubmitChanges();
        }
        public void xoa(string id)
        {
            nguoncap dt = (from d in db.nguoncaps select d).Single(t => t.id == id);
            db.nguoncaps.DeleteOnSubmit(dt);
            db.SubmitChanges();
        }
    }
}