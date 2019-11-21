using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class t_loaivb
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void moi(string id, string ten, string ghichu)
        {
            loaivanban tt = new loaivanban();
            tt.id = id;
            tt.ten = ten;
            tt.ghichu = ghichu;

            db.loaivanbans.InsertOnSubmit(tt);
            db.SubmitChanges();
        }
        public void sua(string id, string ten, string ghichu)
        {
            loaivanban tt = (from t in db.loaivanbans select t).Single(a => a.id == id);
            tt.ten = ten;
            tt.ghichu = ghichu;
            db.SubmitChanges();
        }

        public void xoa(string id)
        {
            loaivanban tt = (from t in db.loaivanbans select t).Single(a => a.id == id);
            db.loaivanbans.DeleteOnSubmit(tt);
            db.SubmitChanges();
        }
    }
}
