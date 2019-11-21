using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class t_nhanvienlaixe
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void moi(string id, string ten, string diachi, string dienthoai, string email, string ghichu, DateTime ngaysinh, string quoctich, string cmnd, string chucvu, DateTime ngayvaolam, string gioitinh, string tinhtrang, byte[] hinhanh, DateTime ngaynghiviec)
        {
            nhanvien dt = new nhanvien();
            dt.id = id;
            dt.ten = ten;
            dt.diachi = diachi;
            dt.dienthoai = dienthoai;
            dt.email = email;
            dt.ghichu = ghichu;
            dt.ngaysinh = ngaysinh;
            dt.ngayvaolam = ngayvaolam;
            dt.quoctich = quoctich;
            dt.cmnd = cmnd;
            dt.Chucvu = chucvu;
            dt.hinhanh = hinhanh;
            dt.gioitinh = gioitinh;
            dt.tinhtrang = tinhtrang;
            dt.ngaynghiviec = ngaynghiviec;
            db.nhanviens.InsertOnSubmit(dt);
            db.SubmitChanges();

        }
        public void sua(string id, string ten, string diachi, string dienthoai, string email, string ghichu, DateTime ngaysinh, string quoctich, string cmnd, string chucvu, DateTime ngayvaolam, string gioitinh, string tinhtrang, byte[] hinhanh, DateTime ngaynghiviec)
        {
            nhanvien dt = (from d in db.nhanviens select d).Single(t => t.id == id);
            dt.ten = ten;
            dt.diachi = diachi;
            dt.dienthoai = dienthoai;
            dt.email = email;
            dt.ghichu = ghichu;
            dt.ngaysinh = ngaysinh;
            dt.ngayvaolam = ngayvaolam;
            dt.quoctich = quoctich;
            dt.cmnd = cmnd;
            dt.Chucvu = chucvu;
            dt.hinhanh = hinhanh;
            dt.gioitinh = gioitinh;
            dt.tinhtrang = tinhtrang;
            dt.ngaynghiviec = ngaynghiviec;
            db.SubmitChanges();
        }
        public void xoa(string id)
        {
            nhanvien dt = (from d in db.nhanviens select d).Single(t => t.id == id);
            db.nhanviens.DeleteOnSubmit(dt);
            db.SubmitChanges();
        }
    }
}