using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class t_tinhtrang
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void moi(string id, string ten, string ghichu)
        {
            tinhtrang dt = new tinhtrang();
            dt.id = id;
            dt.ten = ten;
            dt.ghichu = ghichu; 
            db.tinhtrangs.InsertOnSubmit(dt);
            db.SubmitChanges();

        }
        public void sua(string id, string ten, string ghichu)
        {
            tinhtrang dt = (from d in db.tinhtrangs select d).Single(t => t.id == id);
            dt.ten = ten;
            dt.ghichu = ghichu;
            db.SubmitChanges();
        }
        public void xoa(string id)
        {
            tinhtrang dt = (from d in db.tinhtrangs select d).Single(t => t.id == id);
            db.tinhtrangs.DeleteOnSubmit(dt);
            db.SubmitChanges();
        }
    }
}