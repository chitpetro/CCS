using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class t_congviec
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void moi(string id, string ten, string ghichu)
        {
            congviec dt = new congviec();
            dt.id = id;
            dt.tencongviec = ten;
            dt.nhomcongviec = ghichu; 
            db.congviecs.InsertOnSubmit(dt);
            db.SubmitChanges();

        }
        public void sua(string id, string ten, string ghichu)
        {
            congviec dt = (from d in db.congviecs select d).Single(t => t.id == id);
            dt.tencongviec = ten;
            dt.nhomcongviec = ghichu;
            db.SubmitChanges();
        }
        public void xoa(string id)
        {
            congviec dt = (from d in db.congviecs select d).Single(t => t.id == id);
            db.congviecs.DeleteOnSubmit(dt);
            db.SubmitChanges();
        }
    }
}