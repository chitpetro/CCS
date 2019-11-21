using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class c_dutoan_pnhap
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them(string key, string id, DateTime ngaylap, string iddv, string idnv, string idct, string tiente,
            double tygia, string diengiai, int so)
        {
            var pn = new dutoan_pnhap();

            pn.key = key;
            pn.id = id;
            pn.ngaylap = ngaylap;
            pn.iddv = iddv;
            pn.idnv = idnv;
            pn.idct = idct;
            pn.tiente = tiente;
            pn.tygia = tygia;
            pn.diengiai = diengiai;
            pn.so = so;
            dbData.dutoan_pnhaps.InsertOnSubmit(pn);
            dbData.SubmitChanges();
        }

        public void sua(string key, DateTime ngaylap, string tiente,
           double tygia, string diengiai)
        {
            var pn = (from a in dbData.dutoan_pnhaps select a).Single(t => t.key == key);
            pn.ngaylap = ngaylap;
            pn.tiente = tiente;
            pn.tygia = tygia;
            pn.diengiai = diengiai;
            dbData.SubmitChanges();
        }

        public void xoa(string key)
        {
            var pn = (from a in dbData.dutoan_pnhaps select a).Single(t => t.key == key);
            dbData.dutoan_pnhaps.DeleteOnSubmit(pn);
            dbData.SubmitChanges();
        }

        public void xoact(string key)
        {
            var pn = (from a in dbData.dutoan_pnhapcts select a).Single(t => t.key == key);
            dbData.dutoan_pnhapcts.DeleteOnSubmit(pn);
            dbData.SubmitChanges();
        }
    }
}
