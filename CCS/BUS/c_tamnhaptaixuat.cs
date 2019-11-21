using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace BUS
{
    public class c_tamnhaptaixuat
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        public void them(string key, string id, DateTime ngaydk, int thoihan, string diengiai, int so, string idpt)
        {
            tamnhaptaixuat bh = new tamnhaptaixuat();
            bh.key = key;
            bh.id = id;
            bh.ngaydk = ngaydk;
            bh.thoihan = thoihan;
            bh.diengiai = diengiai;
            bh.so = so;
            bh.idpt = idpt;
            dbData.tamnhaptaixuats.InsertOnSubmit(bh);
            dbData.SubmitChanges();
        }
        public void sua(string key, DateTime ngaydk, int thoihan, string diengiai, string idpt)
        {
            var bh = (from a in dbData.tamnhaptaixuats select a).Single(t => t.key == key);
            bh.ngaydk = ngaydk;
            bh.thoihan = thoihan;
            bh.diengiai = diengiai;
            dbData.SubmitChanges();
        }

        public void xoa(string key)
        {
            var bh = (from a in dbData.tamnhaptaixuats select a).Single(t => t.key == key);
            dbData.tamnhaptaixuats.DeleteOnSubmit(bh);
            dbData.SubmitChanges();
        }

        public void xoact(string key)
        {
            var bh = (from a in dbData.tamnhaptaixuat_files select a).Single(t => t.key == key);
            dbData.tamnhaptaixuat_files.DeleteOnSubmit(bh);
            dbData.SubmitChanges();
        }
    }
}
