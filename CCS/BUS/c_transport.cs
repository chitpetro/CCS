using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace BUS
{
    public class c_transport
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        public void them(string key, string id, DateTime ngaydk, int thoihan, string diengiai, int so, string idpt)
        {
            transport bh = new transport();
            bh.key = key;
            bh.id = id;
            bh.ngaydk = ngaydk;
            bh.thoihan = thoihan;
            bh.diengiai = diengiai;
            bh.so = so;
            bh.idpt = idpt;
            dbData.transports .InsertOnSubmit(bh);
            dbData.SubmitChanges();
        }
        public void sua(string key, DateTime ngaydk, int thoihan, string diengiai, string idpt)
        {
            var bh = (from a in dbData.transports select a).Single(t => t.key == key);
            bh.ngaydk = ngaydk;
            bh.thoihan = thoihan;
            bh.diengiai = diengiai;
            dbData.SubmitChanges();
        }

        public void xoa(string key)
        {
            var bh = (from a in dbData.transports select a).Single(t => t.key == key);
            dbData.transports.DeleteOnSubmit(bh);
            dbData.SubmitChanges();
        }

        public void xoact(string key)
        {
            var bh = (from a in dbData.transport_files select a).Single(t => t.key == key);
            dbData.transport_files.DeleteOnSubmit(bh);
            dbData.SubmitChanges();
        }
    }
}
