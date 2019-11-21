using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class t_pxmsanpham
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them(string id, string tensp, string dvt, string loai)
        {
            pxm_sanpham sp = new pxm_sanpham();
            sp.id = id;
            sp.tensp = tensp;
            sp.dvt = dvt;
            sp.loai = loai;
            dbData.pxm_sanphams.InsertOnSubmit(sp);
            dbData.SubmitChanges();
        }
        public void sua(string id, string tensp, string dvt, string loai)
        {
            var sp = (from a in dbData.pxm_sanphams select a).Single(t => t.id == id);
            sp.tensp = tensp;
            sp.dvt = dvt;
            sp.loai = loai;

            dbData.SubmitChanges();
        }
        public void xoa(string id)
        {
            var sp = (from a in dbData.pxm_sanphams select a).Single(t => t.id == id);
            dbData.pxm_sanphams.DeleteOnSubmit(sp);
            dbData.SubmitChanges();
        }
    }
}
