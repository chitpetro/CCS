using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class t_themcongtrinh
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void moi(string id, string tencongtrinh, string khuvuc, string diadiem, DateTime ngaybd, DateTime ngaykt, string loaict, string iduser, string chihuytruong, double gthanmuc, bool ht, bool khopxm)
        {
            congtrinh dt = new congtrinh();
            dt.id = id;
            dt.tencongtrinh = tencongtrinh;
            dt.khuvuc = khuvuc;
            dt.gthanmuc = gthanmuc;
            dt.diadiem = diadiem;
            dt.ngaybd = ngaybd;
            dt.ngaykt = ngaykt;
            dt.loaict = loaict;
            dt.iduser = iduser;
            dt.ht = ht;
            dt.khopxm = khopxm;
            dt.chihuytruong = chihuytruong;
            db.congtrinhs.InsertOnSubmit(dt);
            db.SubmitChanges();

        }
        public void sua(string id, string tencongtrinh, string khuvuc, string diadiem, DateTime ngaybd, DateTime ngaykt, string loaict, string chihuytruong, double gthanmuc, bool ht, bool khopxm)
        {
            congtrinh dt = (from d in db.congtrinhs select d).Single(t => t.id == id);
           
            dt.tencongtrinh = tencongtrinh;
            dt.khuvuc = khuvuc;
            dt.gthanmuc = gthanmuc;
            dt.diadiem = diadiem;
            dt.ngaybd = ngaybd;
            dt.ngaykt = ngaykt;
            dt.loaict = loaict;
            dt.khopxm = khopxm;
            dt.ht = ht;
            dt.chihuytruong = chihuytruong;
            db.SubmitChanges();
        }
        public void xoa(string id)
        {
            congtrinh dt = (from d in db.congtrinhs select d).Single(t => t.id == id);
            db.congtrinhs.DeleteOnSubmit(dt);
            db.SubmitChanges();
        }
    }
}