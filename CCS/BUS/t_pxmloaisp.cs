using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class t_pxmloaisp
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them(string id, string tenloai)
        {
            pxm_loaisp sp = new pxm_loaisp();
            sp.id = id;
            sp.tenloai = tenloai;
            dbData.pxm_loaisps.InsertOnSubmit(sp);
            dbData.SubmitChanges();
        }
        public void sua(string id, string tenloai)
        {
            var sp = (from a in dbData.pxm_loaisps select a).Single(t => t.id == id);
            sp.tenloai = tenloai;
           
            dbData.SubmitChanges();
        }
        public void xoa(string id)
        {
            var sp = (from a in dbData.pxm_loaisps select a).Single(t => t.id == id);
            dbData.pxm_loaisps.DeleteOnSubmit(sp);
            dbData.SubmitChanges();
        }
    }
}
