using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class c_tdchuyentien
    {

        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them(string id, string idtt, DateTime ngaychuyen, double sotienchuyen, string ghichu,
            string loaichuyen, string idnv)
        {
            theodoitt td = new theodoitt();
            td.id = id;
            td.idtt = idtt;
            td.ngaychuyen = ngaychuyen;
            td.sotienchuyen = sotienchuyen;
            td.ghichu = ghichu;
            td.loaichuyen = loaichuyen;
            td.idnv = idnv;
            dbData.theodoitts.InsertOnSubmit(td);
            dbData.SubmitChanges();
        }

        public void sua(string id, DateTime ngaychuyen, double sotienchuyen, string ghichu,
            string loaichuyen)
        {
            var td = (from a in dbData.theodoitts select a).Single(t => t.id == id);

            td.ngaychuyen = ngaychuyen;
            td.sotienchuyen = sotienchuyen;
            td.ghichu = ghichu;
            td.loaichuyen = loaichuyen;
            dbData.SubmitChanges();
        }

        public void xoa(string id)
        {
            var td = (from a in dbData.theodoitts select a).Single(t => t.id == id);
            dbData.theodoitts.DeleteOnSubmit(td);
            dbData.SubmitChanges();
        }

    }
}
