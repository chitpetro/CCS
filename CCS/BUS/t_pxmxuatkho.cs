using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class t_pxmxuatkho
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        public void them(string key, string id, string iddv, DateTime ngayxuat, string idnv, string iddt, string idct,
            string diengiai, int so)
        {
            pxm_xuatkho xk = new pxm_xuatkho();
            xk.key = key;
            xk.id = id;
            xk.iddv = iddv;
            xk.iddt = iddt;
            xk.idnv = idnv;
            xk.ngayxuat = ngayxuat;
            xk.diengiai = diengiai;
            xk.so = so;
            xk.duyet = false;
            xk.idct = idct;
            dbData.pxm_xuatkhos.InsertOnSubmit(xk);
            dbData.SubmitChanges();
        }
        public void sua(string key, string id, string iddv, DateTime ngayxuat, string idnv, string iddt, string idct,
           string diengiai, int so)
        {
            var xk = (from a in dbData.pxm_xuatkhos select a).Single(t => t.key == key);
            xk.id = id;
            xk.iddv = iddv;
            xk.iddt = iddt;
            xk.idnv = idnv;
            xk.ngayxuat = ngayxuat;
            xk.diengiai = diengiai;
            xk.so = so;
            xk.idct = idct;

            dbData.SubmitChanges();
        }
        public void xoa(string key)
        {
            var xk = (from a in dbData.pxm_xuatkhos select a).Single(t => t.key == key);
            dbData.pxm_xuatkhos.DeleteOnSubmit(xk);
            dbData.SubmitChanges();
        }
        public void xoact(string key)
        {
            var xk = (from a in dbData.pxm_xuatkhocts select a).Single(t => t.key == key);
            dbData.pxm_xuatkhocts.DeleteOnSubmit(xk);
            dbData.SubmitChanges();
        }

    }
}
