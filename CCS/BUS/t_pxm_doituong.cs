using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{

    public class t_pxm_doituong
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them(string id, string ten, string nhom, string diachi, string msthue, string dienthoai,
            string email, string fax, string taikhoan, string nganhang)
        {
            pxm_doituong dt = new pxm_doituong();
            dt.id = id;
            dt.ten = ten;
            dt.nhom = nhom;
            dt.diachi = diachi;
            dt.msthue = msthue;
            dt.dienthoai = dienthoai;
            dt.email = email;
            dt.fax = fax;
            dt.taikhoan = taikhoan;
            dt.nganhang = nganhang;
            dbData.pxm_doituongs.InsertOnSubmit(dt);
            dbData.SubmitChanges();
        }

        public void sua(string id, string ten, string nhom, string diachi, string msthue, string dienthoai,
            string email, string fax, string taikhoan, string nganhang)
        {
            pxm_doituong dt = (from a in dbData.pxm_doituongs select a).Single(t => t.id == id);

            dt.ten = ten;
            dt.nhom = nhom;
            dt.diachi = diachi;
            dt.msthue = msthue;
            dt.dienthoai = dienthoai;
            dt.email = email;
            dt.fax = fax;
            dt.taikhoan = taikhoan;
            dt.nganhang = nganhang;
            dbData.SubmitChanges();
        }

        public void xoa(string id)
        {
            pxm_doituong dt = (from a in dbData.pxm_doituongs select a).Single(t => t.id == id);
            dbData.pxm_doituongs.DeleteOnSubmit(dt);
            dbData.SubmitChanges();
        }

    }
}
