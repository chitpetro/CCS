using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class t_lichsu_phuongtien
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void moi(string id, string ten,string madv_ht,string tendv_ht, string madv_dc,string tendv_dc, string madt_ht,string tendt_ht, string madt_dc, string tendt_dc, DateTime thoigian)
        {
            lichsu_phuongtien dt = new lichsu_phuongtien();
            dt.id = id;
            dt.ten = ten;
            dt.madv_ht = madv_ht;
            dt.tendv_ht = tendv_ht;
            dt.madv_dc = madv_dc;
            dt.tendv_dc = tendv_dc;
            dt.madt_ht = madt_ht;
            dt.tendt_ht = tendt_ht;
            dt.madt_dc = madt_dc;
            dt.tendt_dc = tendt_dc;
            dt.thoigian = thoigian;
             
            db.lichsu_phuongtiens.InsertOnSubmit(dt);
            db.SubmitChanges();

        }
        public void sua(string id, string ten, string madv_ht, string tendv_ht, string madv_dc, string tendv_dc, string madt_ht, string tendt_ht, string madt_dc, string tendt_dc, DateTime thoigian)
        {
            lichsu_phuongtien dt = (from d in db.lichsu_phuongtiens select d).Single(t => t.id == id);
            dt.ten = ten;
            dt.madv_ht = madv_ht;
            dt.tendv_ht = tendv_ht;
            dt.madv_dc = madv_dc;
            dt.tendv_dc = tendv_dc;
            dt.madt_ht = madt_ht;
            dt.tendt_ht = tendt_ht;
            dt.madt_dc = madt_dc;
            dt.tendt_dc = tendt_dc;
            dt.thoigian = thoigian;
            db.SubmitChanges();
        }
        public void moi_lsdieuchuyen(string id, string ten, string madv_ht, string tendv_ht, string madv_dc, string tendv_dc, string madt_ht, string tendt_ht, string madt_dc, string tendt_dc, DateTime thoigian,string iddv)
        {
            lichsu_phuongtien dt = new lichsu_phuongtien();
            dt.id = id;
            dt.ten = ten;
            dt.madv_ht = madv_ht;
            dt.tendv_ht = tendv_ht;
            dt.madv_dc = madv_dc;
            dt.tendv_dc = tendv_dc;
            dt.madt_ht = madt_ht;
            dt.tendt_ht = tendt_ht;
            dt.madt_dc = madt_dc;
            dt.tendt_dc = tendt_dc;
            dt.thoigian = thoigian;
            dt.iddv = iddv;
            db.lichsu_phuongtiens.InsertOnSubmit(dt);
            db.SubmitChanges();

        }
        public void sua_lsdieuchuyen(string id, string ten, string madv_ht, string tendv_ht, string madv_dc, string tendv_dc, string madt_ht, string tendt_ht, string madt_dc, string tendt_dc, DateTime thoigian, string iddv)
        {
            lichsu_phuongtien dt = (from d in db.lichsu_phuongtiens select d).Single(t => t.id == id);

            dt.ten = ten;
            dt.madv_ht = madv_ht;
            dt.tendv_ht = tendv_ht;
            dt.madv_dc = madv_dc;
            dt.tendv_dc = tendv_dc;
            dt.madt_ht = madt_ht;
            dt.tendt_ht = tendt_ht;
            dt.madt_dc = madt_dc;
            dt.tendt_dc = tendt_dc;
            dt.thoigian = thoigian;
            dt.iddv = iddv;

            db.SubmitChanges();
        }
        public void xoa(string id)
        {
            lichsu_phuongtien dt = (from d in db.lichsu_phuongtiens select d).Single(t => t.id == id);
            db.lichsu_phuongtiens.DeleteOnSubmit(dt);
            db.SubmitChanges();
        }
    }
}