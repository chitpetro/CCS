using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class c_lephididuong
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them(string key, string id, DateTime ngaydk, int thoihan, string diengiai, int so, string idpt)
        {
            lephididuong lp = new lephididuong();
            lp.key = key;
            lp.id = id;
            lp.ngaydk = ngaydk;
            lp.thoihan = thoihan;
            lp.diengiai = diengiai;
            lp.so = so;
            lp.idpt = idpt;
            dbData.lephididuongs.InsertOnSubmit(lp);
            dbData.SubmitChanges();
        }

        public void sua(string key, DateTime ngaydk, int thoihan, string diengiai)
        {
            var lp = (from a in dbData.lephididuongs select a).Single(t => t.key == key);
            lp.ngaydk = ngaydk;
            lp.thoihan = thoihan;
            lp.diengiai = diengiai;

            dbData.SubmitChanges();
        }
        public void xoa(string key)
        {
            var lp = (from a in dbData.lephididuongs select a).Single(t => t.key == key);
            dbData.lephididuongs.DeleteOnSubmit(lp);
            dbData.SubmitChanges();
        }

        public void xoact(string key)
        {
            var lp = (from a in dbData.lephididuong_files select a).Single(t => t.key == key);
            dbData.lephididuong_files.DeleteOnSubmit(lp);
            dbData.SubmitChanges();
        }
    }
}
