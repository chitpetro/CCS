using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BUS;

namespace BUS
{
    public class c_dangkiem
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        public void them(string key, string id, DateTime ngaydk, int thoihan, string diengiai, int so, string idpt)
        {
            dangkiem dk = new dangkiem();
            dk.key = key;
            dk.id = id;
            dk.ngaydk = ngaydk;
            dk.thoihan = thoihan;
            dk.diengiai = diengiai;
            dk.so = so;
            dk.idpt = idpt;
            dbData.dangkiems.InsertOnSubmit(dk);
            dbData.SubmitChanges();
        }
        public void sua(string key, DateTime ngaydk, int thoihan, string diengiai, string idpt)
        {
            var dk = (from a in dbData.dangkiems select a).Single(t => t.key == key);
            dk.ngaydk = ngaydk;
            dk.thoihan = thoihan;
            dk.diengiai = diengiai;
            dk.idpt = idpt;
            dbData.SubmitChanges();
        }

        public void xoa(string key)
        {
            var dk = (from a in dbData.dangkiems select a).Single(t => t.key == key);
            dbData.dangkiems.DeleteOnSubmit(dk);
            dbData.SubmitChanges();
        }

        public void xoact(string key)
        {
            var dk = (from a in dbData.dangkiem_files select a).Single(t => t.key == key);
            dbData.dangkiem_files.DeleteOnSubmit(dk);
            dbData.SubmitChanges();
        }
    }
}
