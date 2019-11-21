using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DAL;
using BUS;

namespace BUS
{

    public class t_pxmnhapkhoNB
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them(string key, string id, string iddv, string idnv, DateTime ngaynhap, string iddt, string idct,
            string diengiai, int so, string ctxuat)
        {
            pxm_nhapkho_NB pn = new pxm_nhapkho_NB();
            pn.key = key;
            pn.id = id;
            pn.iddv = iddv;
            pn.idnv = idnv;
            pn.ngaynhap = ngaynhap;
            pn.iddt = iddt;
            pn.idct = idct;
            pn.diengiai = diengiai;
            pn.so = so;
            pn.ctxuat = ctxuat;
            pn.duyet = false;
            dbData.pxm_nhapkho_NBs.InsertOnSubmit(pn);
            dbData.SubmitChanges();
        }
        public void sua(string key,  string iddv, string idnv, DateTime ngaynhap, 
            string diengiai)
        {
          var lst = (from a in dbData.pxm_nhapkho_NBs select a).Single(t => t.key == key);
            lst.duyet = true;
            lst.iddv = iddv;
            lst.idnv = idnv;
            lst.ngaynhap = ngaynhap;
            lst.diengiai = diengiai;
            dbData.SubmitChanges();
       
        }
        public void xoa(string key)
        {
            var pn = (from a in dbData.pxm_nhapkho_NBs select a).Single(t => t.key == key);
            dbData.pxm_nhapkho_NBs.DeleteOnSubmit(pn);
            dbData.SubmitChanges();
        }

        // Chi tiết
        //public void themct(string key, string idpn, string idsp, double soluong, int stt, string ghichu)
        //{
        //    pxm_nhapkhoct ct = new pxm_nhapkhoct();
        //    ct.key = key;
        //    ct.idpn = idpn;
        //    ct.idsp = idsp;
        //    ct.soluong = soluong;
        //    ct.stt = stt;
        //    ct.ghichu = ghichu;
        //    dbData.pxm_nhapkhocts.InsertOnSubmit(ct);
        //    dbData.SubmitChanges();
        //}
        //public void suact(string key, string idpn, string idsp, double soluong, int stt, string ghichu)
        //{
        //    var ct = (from a in dbData.pxm_nhapkhocts select a).Single(t => t.key == key);
        //    ct.idpn = idpn;
        //    ct.idsp = idsp;
        //    ct.soluong = soluong;
        //    ct.stt = stt;
        //    ct.ghichu = ghichu;

        //    dbData.SubmitChanges();
        //}
        public void xoact(string key)
        {
            var ct = (from a in dbData.pxm_nhapkhoct_NBs select a).Single(t => t.key == key);
            dbData.pxm_nhapkhoct_NBs.DeleteOnSubmit(ct);
            dbData.SubmitChanges();
        }
    }
}
