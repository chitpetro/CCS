using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class t_duyeths
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void moi(string id, string iduser, string loai, string ghichu,bool t, bool f, string link)
        {
            duyeth dt = new duyeth();
            dt.id = id;
            dt.iduser = iduser;
            dt.loai = loai;
            dt.ghichu = ghichu;
            dt.T = t;
            dt.F = f;
            dt.link = link;
            db.duyeths.InsertOnSubmit(dt);
            db.SubmitChanges();

        }
        public void sua(string id, string iduser, string loai, string ghichu,bool t, bool f, string link)
        {
            duyeth dt = (from d in db.duyeths select d).Single(c => c.id == id);
            dt.loai = loai;
            dt.ghichu = ghichu;
            dt.T = t;
            dt.F = f;
            dt.link = link;
            db.SubmitChanges();
        }
        public void xoa(string id)
        {
            duyeth dt = (from d in db.duyeths select d).Single(t => t.id == id);
            db.duyeths.DeleteOnSubmit(dt);
            db.SubmitChanges();
        }
    }
}