using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class t_loaihd
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void moi(string id, string loai)
        {
            cloaihd dt = new cloaihd();
            dt.id = id;
            dt.loai = loai;

            db.cloaihds.InsertOnSubmit(dt);
            db.SubmitChanges();
        }
        public void sua(string id, string loai)
        {
            cloaihd dt = (from d in db.cloaihds select d).Single(t => t.id == id);
            dt.loai = loai;

            db.SubmitChanges();
        }
        public void xoa(string id)
        {
            cloaihd dt = (from d in db.cloaihds select d).Single(t => t.id == id);
            db.cloaihds.DeleteOnSubmit(dt);
            db.SubmitChanges();
        }
    }
}