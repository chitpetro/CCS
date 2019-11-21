using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class c_hopdongmuaxe
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them(string key, string sohd, DateTime ngayky, string noidung, string iddt, string ghichu,
            string tiente, double giatri)
        {
            hopdongmuaxe hd = new hopdongmuaxe();
            hd.key = key;
            hd.sohd = sohd;
            hd.ngayky = ngayky;
            hd.noidung = noidung;
            hd.iddt = iddt;
            hd.ghichu = ghichu;
            hd.tiente = tiente;
            hd.giatri = giatri;
            dbData.hopdongmuaxes.InsertOnSubmit(hd);
            dbData.SubmitChanges();
        }

        public void sua(string key, DateTime ngayky, string noidung, string iddt, string ghichu,
            string tiente, double giatri)
        {
            var hd = (from a in dbData.hopdongmuaxes select a).Single(t => t.key == key);
            hd.ngayky = ngayky;
            hd.noidung = noidung;
            hd.iddt = iddt;
            hd.ghichu = ghichu;
            hd.tiente = tiente;
            hd.giatri = giatri;
            dbData.SubmitChanges();
        }

        public void xoa(string key)
        {
            var hd = (from a in dbData.hopdongmuaxes select a).Single(t => t.key == key);
            dbData.hopdongmuaxes.DeleteOnSubmit(hd);
            dbData.SubmitChanges();
            
        }


        public void xoact(string key)
        {
            var hd = (from a in dbData.hopdongmuaxe_files where a.keythd == key select a);
            dbData.hopdongmuaxe_files.DeleteAllOnSubmit(hd);
            dbData.SubmitChanges();
        }

    }
}
