using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class t_pxmxuatkhoNB
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        public void them(string key, string id, string iddv, DateTime ngayxuat, string idnv, string iddt, string idct,
            string diengiai, int so, string ctnhap)
        {
            pxm_xuatkho_NB xk = new pxm_xuatkho_NB();
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
            xk.ctnhap = ctnhap;
            dbData.pxm_xuatkho_NBs.InsertOnSubmit(xk);
            dbData.SubmitChanges();
        }
        public void themnhap(string key, string id, string iddv, DateTime ngayxuat, string iddt, string idct,
           string diengiai, int so, string ctxuat)
        {
            pxm_nhapkho_NB xk = new pxm_nhapkho_NB();
            xk.key = key;
            xk.id = id;
            xk.iddv = iddv;
            xk.iddt = iddt;
            xk.ngaynhap = ngayxuat;
            xk.diengiai = diengiai;
            xk.so = so;
            xk.duyet = false;
            xk.idct = idct;
            xk.ctxuat = ctxuat;
            dbData.pxm_nhapkho_NBs.InsertOnSubmit(xk);
            dbData.SubmitChanges();
        }

        public void themnhapct(string key, string keypn, string idsp, string ghichu, double soluong, double soluongtn,
            double chenhlech, int stt)
        {
            pxm_nhapkhoct_NB np = new pxm_nhapkhoct_NB();
            np.key = key;
            np.keypn = keypn;
            np.idsp = idsp;
            np.ghichu = ghichu;
            np.soluong = soluong;
            np.soluongtn = soluongtn;
            np.chenhlech = chenhlech;
            np.stt = stt;
            dbData.pxm_nhapkhoct_NBs.InsertOnSubmit(np);
            dbData.SubmitChanges();
        }
        //public void sua(string key, string id, string iddv, DateTime ngayxuat, string idnv, string iddt, string idct,
        //   string diengiai, int so, string ctnhap)
        //{
        //    var xk = (from a in dbData.pxm_xuatkho_NBs select a).Single(t => t.key == key);
        //    xk.id = id;
        //    xk.iddv = iddv;
        //    xk.iddt = iddt;
        //    xk.idnv = idnv;
        //    xk.ngayxuat = ngayxuat;
        //    xk.diengiai = diengiai;
        //    xk.so = so;
        //    xk.idct = idct;
        //    xk.ctnhap = ctnhap;
        //    dbData.SubmitChanges();
        //}
        public void xoa(string key)
        {
            var xk = (from a in dbData.pxm_xuatkho_NBs select a).Single(t => t.key == key);
            dbData.pxm_xuatkho_NBs.DeleteOnSubmit(xk);
            dbData.SubmitChanges();
        }
        public void xoanhap(string key)
        {
            var xk = (from a in dbData.pxm_nhapkho_NBs select a).Single(t => t.key == key);
            dbData.pxm_nhapkho_NBs.DeleteOnSubmit(xk);
            dbData.SubmitChanges();
        }
        public void xoact(string key)
        {
            var xk = (from a in dbData.pxm_xuatkhoct_NBs select a).Single(t => t.key == key);
            dbData.pxm_xuatkhoct_NBs.DeleteOnSubmit(xk);
            dbData.SubmitChanges();
        }
        public void xoanhapct(string key)
        {
            var xk = (from a in dbData.pxm_nhapkhoct_NBs where a.keypn == key select a);
            dbData.pxm_nhapkhoct_NBs.DeleteAllOnSubmit(xk);
            dbData.SubmitChanges();
        }

    }
}
