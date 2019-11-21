using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class c_dmchiphi
            {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void them(string id, string muccp)
        {
            muccp dt = new muccp();
            dt.id = id;
            dt.muccp1 = muccp;
            

            db.muccps.InsertOnSubmit(dt);
            db.SubmitChanges();
        }
        public void sua(string id, string muccp)
        {
            var dt = (from d in db.muccps select d).Single(t => t.id == id);
            dt.muccp1 = muccp;

            db.SubmitChanges();
        }
        public void xoa(string id)
        {
            var dt = (from d in db.muccps select d).Single(t => t.id == id);
            db.muccps.DeleteOnSubmit(dt);
            db.SubmitChanges();
        }
    }
}