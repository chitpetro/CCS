using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class t_nhomphuongtien
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void moi(string id, string ten)
        {
            nhomphuongtien dt = new nhomphuongtien();
            dt.id = id;
            dt.ten = ten;

            db.nhomphuongtiens.InsertOnSubmit(dt);
            db.SubmitChanges();
        }
        public void sua(string id, string ten)
        {
            nhomphuongtien dt = (from d in db.nhomphuongtiens select d).Single(t => t.id == id);
            dt.ten = ten;

            db.SubmitChanges();
        }
        public void xoa(string id)
        {
            nhomphuongtien dt = (from d in db.nhomphuongtiens select d).Single(t => t.id == id);
            db.nhomphuongtiens.DeleteOnSubmit(dt);
            db.SubmitChanges();
        }
    }
}