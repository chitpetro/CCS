using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace BUS
{
    public class c_baohiem
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        public void them(string key, string id, DateTime ngaydk, int thoihan, string diengiai, int so, string idpt)
        {
            baohiem bh = new baohiem();
            bh.key = key;
            bh.id = id;
            bh.ngaydk = ngaydk;
            bh.thoihan = thoihan;
            bh.diengiai = diengiai;
            bh.so = so;
            bh.idpt = idpt;
            dbData.baohiems.InsertOnSubmit(bh);
            dbData.SubmitChanges();
        }
        public void sua(string key, DateTime ngaydk, int thoihan, string diengiai, string idpt)
        {
            var bh = (from a in dbData.baohiems select a).Single(t => t.key == key);
            bh.ngaydk = ngaydk;
            bh.thoihan = thoihan;
            bh.diengiai = diengiai;
            dbData.SubmitChanges();
        }

        public void xoa(string key)
        {
            var bh = (from a in dbData.baohiems select a).Single(t => t.key == key);
            dbData.baohiems.DeleteOnSubmit(bh);
            dbData.SubmitChanges();
        }

        public void xoact(string key)
        {
            var bh = (from a in dbData.baohiem_files select a).Single(t => t.key == key);
            dbData.baohiem_files.DeleteOnSubmit(bh);
            dbData.SubmitChanges();
        }
    }
}
