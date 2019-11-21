using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class t_khuvuc
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void moi(string id, string khuvuc)
        {
            khuvuc dt = new khuvuc();
            dt.id = id;
            dt.khuvuc1 = khuvuc;

            db.khuvucs.InsertOnSubmit(dt);
            db.SubmitChanges();
        }
        public void sua(string id, string khuvuc)
        {
            khuvuc dt = (from d in db.khuvucs select d).Single(t => t.id == id);
            dt.khuvuc1 = khuvuc;

            db.SubmitChanges();
        }
        public void xoa(string id)
        {
            khuvuc dt = (from d in db.khuvucs select d).Single(t => t.id == id);
            db.khuvucs.DeleteOnSubmit(dt);
            db.SubmitChanges();
        }
    }
}