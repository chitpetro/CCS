using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class t_loaicpm
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void moi(string id, string loai)
        {
            loaicpm dt = new loaicpm();
            dt.id = id;
            dt.loaicpm1 = loai;

            db.loaicpms.InsertOnSubmit(dt);
            db.SubmitChanges();
        }
        public void sua(string id, string nguonvon)
        {
            loaicpm dt = (from d in db.loaicpms select d).Single(t => t.id == id);
            dt.loaicpm1 = nguonvon;

            db.SubmitChanges();
        }
        public void xoa(string id)
        {
            loaicpm dt = (from d in db.loaicpms select d).Single(t => t.id == id);
            db.loaicpms.DeleteOnSubmit(dt);
            db.SubmitChanges();
        }
    }
}