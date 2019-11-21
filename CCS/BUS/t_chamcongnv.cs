using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class t_chamcongnv
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void moi(string id, string idnv, DateTime thoigian, string ngaycong, string ngayphep, string khongluong,
            string ngaykhac, string ghichu, int so)
        {
            chamcongnvcongtrinh cc = new chamcongnvcongtrinh();
           
            cc.id = id;
            cc.idnv = idnv;
            cc.thoigian = thoigian;
            cc.ngaycong = Convert.ToInt32(ngaycong);
            cc.ngayphep = Convert.ToInt32(ngayphep);
            cc.khongluong = Convert.ToInt32(khongluong);
            cc.ngaykhac = Convert.ToInt32(ngaykhac);
            cc.ghichu = ghichu;
            cc.iddv = Biencucbo.donvi;
            cc.so = so;
            db.chamcongnvcongtrinhs.InsertOnSubmit(cc);
            db.SubmitChanges();
        }

        public void sua(string id, string idnv, DateTime thoigian, int ngaycong, int ngayphep, int khongluong,
            int ngaykhac, string ghichu, int so)
        {
            chamcongnvcongtrinh cc = (from a in db.chamcongnvcongtrinhs where a.idnv == idnv select a).Single(t => t.id == id);
            cc.thoigian = thoigian;
            cc.ngaycong = ngaycong;
            cc.ngayphep = ngayphep;
            cc.khongluong = khongluong;
            cc.ngaykhac = ngaykhac;
            cc.ghichu = ghichu;
            db.SubmitChanges();
        }
        public void xoa(string id)
        {
            chamcongnvcongtrinh cc = (from a in db.chamcongnvcongtrinhs select a).Single(t => t.id == id);
            db.chamcongnvcongtrinhs.DeleteOnSubmit(cc);
            db.SubmitChanges();
        }

    }
}