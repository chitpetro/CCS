using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace BUS
{
    public class c_cavet
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        public void them(string key, string id, DateTime ngaydk, int thoihan, string diengiai, int so, string idpt, string loai)
        {
            cavet bh = new cavet();
            bh.key = key;
            bh.id = id;
            bh.ngaydk = ngaydk;
            bh.thoihan = thoihan;
            bh.diengiai = diengiai;
            bh.so = so;
            bh.idpt = idpt;

            if (loai == string.Empty) loai = "Không Có";
            bh.loai = loai;
            dbData.cavets.InsertOnSubmit(bh);
            dbData.SubmitChanges();
        }
        public void sua(string key, DateTime ngaydk, int thoihan, string diengiai, string idpt, string loai)
        {
            var bh = (from a in dbData.cavets select a).Single(t => t.key == key);
            bh.ngaydk = ngaydk;
            bh.thoihan = thoihan;
            bh.diengiai = diengiai;

            if (loai == string.Empty) loai = "Không Có";
            bh.loai = loai;
            dbData.SubmitChanges();
        }

        public void xoa(string key)
        {
            var bh = (from a in dbData.cavets select a).Single(t => t.key == key);
            dbData.cavets.DeleteOnSubmit(bh);
            dbData.SubmitChanges();
        }

        public void xoact(string key)
        {
            var bh = (from a in dbData.cavet_files select a).Single(t => t.key == key);
            dbData.cavet_files.DeleteOnSubmit(bh);
            dbData.SubmitChanges();
        }
    }
}