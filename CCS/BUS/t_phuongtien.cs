using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class t_phuongtien
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void moi(string id, string ten, string nhom, string so, string tinhtrang, string donvihoatdong, string sokhung, DateTime ngay, string ghichu, string somay, string nuocsx, string tinhtrangmua, string iddv, double dinhmuc, string dvdinhmuc, string sohd, string tiente, double giatri, string linkhopdong)//, string cavet, DateTime ngaydkcavet)
        {
            phuongtien dt = new phuongtien();
            dt.id = id;
            dt.ten = ten;
            dt.nhom = nhom;
            dt.so = so;
            dt.tinhtrang = tinhtrang;
            dt.madv = donvihoatdong;
            dt.sokhung = sokhung;
            dt.sohd = sohd;
            //dt.cavet = cavet;
            //dt.ngaydkcavet = ngaydkcavet;
            dt.ngaycapnhat = ngay;
            dt.ghichu = ghichu;
            dt.somay = somay;
            dt.nuocsx = nuocsx;
            dt.tinhtrangmua = tinhtrangmua;
            dt.iddv = iddv;
            dt.dinhmuc = dinhmuc;
            dt.dvdinhmuc = dvdinhmuc;
            dt.tiente = tiente;
            dt.giatri = giatri;
            dt.linkhopdong = linkhopdong;
            db.phuongtiens.InsertOnSubmit(dt);
            db.SubmitChanges();

        }
        public void sua(string id, string ten, string nhom, string so, string tinhtrang, string donvihoatdong, string sokhung, DateTime ngay, string ghichu, string somay, string nuocsx, string tinhtrangmua, double dinhmuc, string dvdinhmuc, string sohd, string tiente, double giatri, string linkhopdong)//, string cavet, DateTime ngaydkcavet)
        {
            phuongtien dt = (from d in db.phuongtiens select d).Single(t => t.id == id);
            dt.ten = ten;
            dt.nhom = nhom;
            dt.so = so;
            dt.tinhtrang = tinhtrang;
            dt.madv = donvihoatdong;
            dt.sokhung = sokhung;
            dt.ngaycapnhat = ngay;
            dt.ghichu = ghichu;
            dt.somay = somay;
            dt.nuocsx = nuocsx;
            dt.tinhtrangmua = tinhtrangmua;
            dt.sohd = sohd;
            //dt.cavet = cavet;
            //dt.ngaydkcavet = ngaydkcavet;
            dt.dinhmuc = dinhmuc;
            dt.dvdinhmuc = dvdinhmuc;
            dt.tiente = tiente;
            dt.giatri = giatri;
            dt.linkhopdong = linkhopdong;
            db.SubmitChanges();
        }
        public void sua_dieuchuyen(string id, string donvihoatdong, string iddt)
        {
            phuongtien dt = (from d in db.phuongtiens select d).Single(t => t.id == id);

            dt.madv = donvihoatdong;
            dt.madt = iddt;

            db.SubmitChanges();
        }
        public void xoa(string id)
        {
            phuongtien dt = (from d in db.phuongtiens select d).Single(t => t.id == id);
            db.phuongtiens.DeleteOnSubmit(dt);
            db.SubmitChanges();
        }
    }
}