using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
  public  class c_theodoitt_cpvt
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them(string id, string idpn, DateTime ngaychuyen, double sotienchuyen, string ghichu,
           string loaichuyen, string idnv, DateTime ngaylap)
        {
            theodoitt_cpvt td = new theodoitt_cpvt();
            td.id = id;
            td.idpn = idpn;
            td.ngaychuyen = ngaychuyen;
            td.sotienchuyen = sotienchuyen;
            td.ghichu = ghichu;
            td.loaichuyen = loaichuyen;
            td.idnv = idnv;
            td.ngaylap = ngaylap;
            dbData.theodoitt_cpvts.InsertOnSubmit(td);
            dbData.SubmitChanges();
        }

        public void sua(string id, DateTime ngaychuyen, double sotienchuyen, string ghichu,
            string loaichuyen)
        {
            var td = (from a in dbData.theodoitt_cpvts select a).Single(t => t.id == id);
            td.ngaychuyen = ngaychuyen;
            td.sotienchuyen = sotienchuyen;
            td.ghichu = ghichu;
            td.loaichuyen = loaichuyen;
            dbData.SubmitChanges();
        }

        public void xoa(string id)
        {
            var td = (from a in dbData.theodoitt_cpvts select a).Single(t => t.id == id);
            dbData.theodoitt_cpvts.DeleteOnSubmit(td);
            dbData.SubmitChanges();
        }
    }
}
