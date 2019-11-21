using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Microsoft.SqlServer.Server;

namespace BUS
{
    public class t_pxm_nhomdt
    {

        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
       
        public void them(string id, string ten)
        {
            pxm_nhomdoituong nhom = new pxm_nhomdoituong();
            nhom.id = id;
            nhom.ten = ten;
            dbData.pxm_nhomdoituongs.InsertOnSubmit(nhom);
            dbData.SubmitChanges();
        }
        public void sua(string id, string ten)
        {
            pxm_nhomdoituong nhom = (from a in dbData.pxm_nhomdoituongs select a).Single(t => t.id == id);
            nhom.ten = ten;
            dbData.SubmitChanges();
        }
        public void xoa(string id)
        {
            pxm_nhomdoituong nhom = (from a in dbData.pxm_nhomdoituongs select a).Single(t => t.id == id);
            dbData.pxm_nhomdoituongs.DeleteOnSubmit(nhom);
            dbData.SubmitChanges();
        }
      

       


    }
}
