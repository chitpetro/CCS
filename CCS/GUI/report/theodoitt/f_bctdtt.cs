using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAL;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;

namespace GUI.report.theodoitt
{
    public partial class f_bctdtt : frm.frmreport2
    {
        public f_bctdtt()
        {
            InitializeComponent();
        }

        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        public string sh2 = "";
        public string sh4 = "";
        t_todatatable _tTodatatable = new t_todatatable();

        public double tongtt;
        public double tongtt2;

        protected override void load()
        {

            txtdanhmuc.Text = "Công Trình";
        }

        private bool layinfo(string tungay, string denngay, bool all)
        {
            Biencucbo.ngaybc = "Từ ngày " + tungay + " Đến ngày " + denngay;
            Biencucbo.info = "";
            if (all)
                Biencucbo.ngaybc = "";
            bool checkdv = true;
            string loai = "";
            gv2.Columns["loai"].SortOrder = ColumnSortOrder.Ascending;
            for (int i = 0; i < gv2.DataRowCount; i++)
            {
                if (gv2.GetRowCellValue(i, "loai").ToString() == "Đơn Vị")
                {
                    checkdv = true;
                }
                if (loai != gv2.GetRowCellValue(i, "loai").ToString())
                {
                    if (Biencucbo.info == "")
                    {
                        Biencucbo.info = gv2.GetRowCellValue(i, "loai") + ": " + gv2.GetRowCellValue(i, "name");
                    }
                    else
                    {
                        Biencucbo.info = Biencucbo.info + "\n" + gv2.GetRowCellValue(i, "loai") + ": " +
                                         gv2.GetRowCellValue(i, "name");
                    }
                }
                else
                {
                    Biencucbo.info = Biencucbo.info + ", " + gv2.GetRowCellValue(i, "name");
                }
                loai = gv2.GetRowCellValue(i, "loai").ToString();
            }
            if (Biencucbo.info == "")
                Biencucbo.info = "Tất cả";
            return checkdv;
        }

        private double tinhtongthanhtien(double a, string b)
        {
            double tt = 0;
            if (sh4 == b)
            {
                tt = 0;
            }
            else
            {
                sh4 = b;
                tt = a;
            }
            return tt;
        }

        private double Tinhgiatricl2(double a, string b, double c, double e)
        {
            double cl = 0;

            if (sh2 == b)
            {
                tongtt2 = tongtt2 + a;
                cl = (c - tongtt2) * e;
            }
            else
            {
                sh2 = b;
                tongtt2 = a;
                cl = (c - tongtt2) * e;
            }
            return cl;
        }

        private void inbc<T>(bool all)
        {
            if (
                layinfo(DateTime.Parse(tungay.EditValue.ToString()).ToShortDateString(),
                    DateTime.Parse(denngay.EditValue.ToString()).ToShortDateString(), all) ==
                false)
            {
                XtraMessageBox.Show("Cần phải chọn một đơn vị bất kỳ để xem báo cáo", "THÔNG BÁO");
                return;
            }
            try
            {
                var rp = Activator.CreateInstance<T>() as XtraReport;
                switch (rdg.SelectedIndex)
                {
                    case 0:
                        try
                        {
                            Biencucbo.loaihd = "";
                            Biencucbo.doituong = "";
                            Biencucbo.khuvuc = "";
                            Biencucbo.loaict = "";
                            Biencucbo.Congtrinh = "";
                            Biencucbo.sohd = "";
                            //moi
                            Biencucbo.linkHS = "";
                            var checkct = 0;
                            var checkkv = 0;
                            var checklct = 0;
                            var checkdt = 0;
                            var checku = 0;
                            var checkdv = 0;
                            //moi
                            var checklinkhs = 0;
                            var checklinkgoc = 0;

                            for (var i = 0; i < gv2.DataRowCount; i++)
                            {
                                if (gv2.GetRowCellValue(i, "loai").ToString() == "Công Trình")
                                {
                                    checkct++;
                                    Biencucbo.Congtrinh = Biencucbo.Congtrinh + gv2.GetRowCellValue(i, "id") + "-" +
                                                          gv2.GetRowCellValue(i, "name") + ", ";
                                }
                                else if (gv2.GetRowCellValue(i, "loai").ToString() == "Hồ Sơ Gốc")
                                {
                                    checklinkgoc++;
                                }
                                else if (gv2.GetRowCellValue(i, "loai").ToString() == "Khu Vực")
                                {
                                    checkkv++;
                                    Biencucbo.khuvuc = Biencucbo.khuvuc + gv2.GetRowCellValue(i, "id") + "-" +
                                                       gv2.GetRowCellValue(i, "name") + ", ";
                                }
                                else if (gv2.GetRowCellValue(i, "loai").ToString() == "Loại Công Trình")
                                {
                                    checklct++;
                                    Biencucbo.loaict = Biencucbo.loaict + gv2.GetRowCellValue(i, "id") + "-" +
                                                       gv2.GetRowCellValue(i, "name") + ", ";
                                }
                                else if (gv2.GetRowCellValue(i, "loai").ToString() == "Đối Tượng")
                                {
                                    checkdt++;
                                    Biencucbo.iddt = Biencucbo.iddt + gv2.GetRowCellValue(i, "id") + "-" +
                                                     gv2.GetRowCellValue(i, "name") + ", ";
                                }
                                else if (gv2.GetRowCellValue(i, "loai").ToString() == "Nhân Viên")
                                {
                                    checku++;
                                }
                                else if (gv2.GetRowCellValue(i, "loai").ToString() == "Đơn Vị")
                                {
                                    checkdv++;
                                }
                                //moi
                                else if (gv2.GetRowCellValue(i, "loai").ToString() == "Link Hồ Sơ")
                                {
                                    checklinkhs++;
                                }
                            }


                            if (checkkv == 0)
                            {
                                Biencucbo.khuvuc = "Tất cả";
                            }
                            if (checklct == 0)
                            {
                                Biencucbo.loaict = "Tất cả";
                            }
                            if (checkct == 0)
                            {
                                Biencucbo.Congtrinh = "Tất cả";
                            }
                            if (checkdt == 0)
                            {
                                Biencucbo.doituong = "Tất cả";
                            }
                            //moi
                            if (checklinkhs == 0)
                            {
                                Biencucbo.linkHS = "Tất cả";
                            }

                            var lst = (from a in dbData.r_hopdongs
                                       join d in dbData.congtrinhs on a.idct equals d.id
                                       where a.loai == "Hợp Đồng"
                                       where d.ht != true
                                       select new
                                       {
                                           a.id,
                                           ttcongtrinh =
                                               "Công trình:" + d.tencongtrinh + "\n" + "Địa điểm: " + d.diadiem +
                                               "\nChỉ huy trưởng: " +
                                               d.chihuytruong,
                                           d.khuvuc,
                                           d.tencongtrinh,
                                           d.loaict,
                                           idct = d.id,
                                           a.idnv,
                                           a.iddv,
                                           a.sohd,
                                           a.ngayky,
                                           a.noidunghd,
                                           a.tygia,
                                           a.loaihd,
                                           a.iddt,
                                           doituong = a.iddt + "-" + a.tendt,

                                           a.tiente,
                                           nguyentehd = a.nguyente == null ? 0 : a.nguyente,
                                           nguyentepl = a.nguyente == null ? 0 : a.nguyente - a.nguyente,
                                           thanhtien = a.thanhtien == null ? 0 : a.thanhtien
                                       }).Concat(from a in dbData.r_hopdongs
                                                 join d in dbData.congtrinhs on a.idct equals d.id
                                                 where a.loai == "Phụ Lục"
                                                 where d.ht != true
                                                 select new
                                                 {
                                                     a.id,
                                                     ttcongtrinh =
                                                         "Công trình:" + d.tencongtrinh + "\n" + "Địa điểm: " + d.diadiem +
                                                         "\nChỉ huy trưởng: " +
                                                         d.chihuytruong,
                                                     d.khuvuc,
                                                     d.tencongtrinh,
                                                     d.loaict,
                                                     idct = d.id,
                                                     a.idnv,
                                                     a.iddv,
                                                     a.sohd,
                                                     a.ngayky,
                                                     a.noidunghd,
                                                     a.tygia,
                                                     a.loaihd,
                                                     a.iddt,
                                                     doituong = a.iddt + "-" + a.tendt,

                                                     a.tiente,
                                                     nguyentehd = a.nguyente == null ? 0 : a.nguyente - a.nguyente,
                                                     nguyentepl = a.nguyente == null ? 0 : a.nguyente,
                                                     thanhtien = a.thanhtien == null ? 0 : a.thanhtien
                                                 }).Concat(from a in dbData.r_hopdongs
                                                           join d in dbData.congtrinhs on a.idct equals d.id
                                                           where a.loai == null
                                                           where d.ht != true
                                                           select new
                                                           {
                                                               a.id,
                                                               ttcongtrinh =
                                                                   "Công trình:" + d.tencongtrinh + "\n" + "Địa điểm: " + d.diadiem +
                                                                   "\nChỉ huy trưởng: " + d.chihuytruong,
                                                               d.khuvuc,
                                                               d.tencongtrinh,
                                                               d.loaict,
                                                               idct = d.id,
                                                               a.idnv,
                                                               a.iddv,
                                                               a.sohd,
                                                               a.ngayky,
                                                               a.noidunghd,
                                                               a.tygia,
                                                               a.loaihd,
                                                               a.iddt,
                                                               doituong = a.iddt + "-" + a.tendt,

                                                               a.tiente,
                                                               nguyentehd = a.nguyente == null ? 0 : a.nguyente - a.nguyente,
                                                               nguyentepl = a.nguyente == null ? 0 : a.nguyente,
                                                               thanhtien = a.thanhtien == null ? 0 : a.thanhtien
                                                           })
                                .ToList()
                                .GroupBy(
                                    t =>
                                        new
                                        {
                                            t.tencongtrinh,
                                            t.id,
                                            t.iddv,
                                            t.sohd,
                                            t.ngayky,
                                            t.noidunghd,
                                            t.loaihd,
                                            t.doituong,

                                            t.tiente,
                                            t.khuvuc,
                                            t.tygia,
                                            t.loaict,
                                            t.idct,
                                            t.iddt,
                                            t.idnv,
                                            t.ttcongtrinh
                                        })
                                .Select(y =>
                                    new
                                    {
                                        y.Key.id,
                                        y.Key.ttcongtrinh,
                                        y.Key.loaict,
                                        y.Key.idnv,
                                        y.Key.tencongtrinh,
                                        y.Key.iddt,
                                        y.Key.idct,
                                        y.Key.iddv,
                                        y.Key.sohd,
                                        y.Key.ngayky,
                                        y.Key.noidunghd,
                                        y.Key.loaihd,
                                        y.Key.doituong,

                                        y.Key.tiente,
                                        y.Key.tygia,
                                        y.Key.khuvuc,
                                        nguyentehd = y.Sum(t => t.nguyentehd),
                                        nguyentepl = y.Sum(t => t.nguyentepl),
                                        thanhtien = y.Sum(t => t.thanhtien)
                                    }).ToList();

                            var lst2 = (from a in dbData.hopdong_tps
                                        join b in dbData.r_theodoitts on a.id equals b.idhd_tp into k
                                        from tt in k.DefaultIfEmpty()
                                        orderby tt.idhd_tp ascending
                                        orderby tt.lan ascending
                                        select new
                                        {
                                            a.id,
                                            tt.idtt,
                                            iddt = tt.id == null ? "" : tt.id,
                                            giatritt = tt.giatritt == null ? 0 : tt.giatritt,
                                            giatriqt = tt.giatriqt == null ? 0 : tt.giatriqt,
                                            tt.ngaytt,
                                            tt.link,
                                            tt.linkgoc,
                                            tt.ghichu,
                                            tt.diengiai,
                                            tt.lan,
                                            tongchuyen = tt.sotienchuyen == null ? 0 : tt.sotienchuyen
                                        }).ToList();

                            var lst3 = lst2.GroupBy(t => new { t.id }).Select(y =>
                                  new
                                  {
                                      y.Key.id,
                                      tongtt = y.Sum(x => x.giatritt)
                                  }).ToList();


                            var lst3b = lst2.GroupBy(t => new { t.id }).Select(y =>
                                  new
                                  {
                                      y.Key.id,
                                      tongchuyen = y.Sum(x => x.tongchuyen)
                                  }).ToList();

                            var lst4 = from a in lst
                                       join b in lst2 on a.id equals b.id into k
                                       join c in lst3 on a.id equals c.id into l
                                       join d in lst3b on a.id equals d.id into m
                                       from tt in k.DefaultIfEmpty()
                                       from tong in l.DefaultIfEmpty()
                                       from tong2 in m.DefaultIfEmpty()
                                       select new
                                       {
                                           a.id,
                                           a.iddv,
                                           a.ttcongtrinh,
                                           a.idct,
                                           a.iddt,
                                           a.idnv,
                                           a.loaict,
                                           a.sohd,
                                           a.ngayky,
                                           noidung =
                                               "- Công trình: " + a.tencongtrinh + "\n" + "- Số HĐ: " + a.sohd + "- Đối tác: " +
                                               a.doituong +
                                               ". \n- GTHĐ: " + string.Format("{0:n2}", a.nguyentehd) + "- GTPL: " +
                                               string.Format("{0:n2}", a.nguyentepl) + " (" + a.tiente + ").\n- Nội Dung HĐ: " +
                                               a.noidunghd,
                                           a.loaihd,
                                           a.khuvuc,
                                           tendoituong = a.doituong,
                                           tt.link,
                                           tt.linkgoc,
                                           tiente = "Tiền tệ: (" + a.tiente + ")",
                                           tt.diengiai,
                                           tt.ngaytt,
                                           tt.lan,
                                           nguyentetp2 = a.nguyentepl * a.tygia,
                                           nguyentetp = a.nguyentepl,
                                           thanhtien2 = a.thanhtien * a.tygia,
                                           thanhtien = a.nguyentehd + a.nguyentepl,
                                           giatrit2t = tt.giatritt * a.tygia,
                                           tt.giatritt,
                                           giatriqt2 = tt.giatriqt * a.tygia,
                                           tt.giatriqt,
                                           tongchuyen2 = tt.tongchuyen * a.tygia,
                                           tt.tongchuyen,
                                           cltt =
                                               Tinhgiatricl2(
                                                   tt.tongchuyen == null ? 0 : double.Parse(tt.tongchuyen.ToString()), tt.idtt,
                                                   tt.giatritt == null ? 0 : double.Parse(tt.giatritt.ToString()), 1),

                                           tongttien =
                                               tinhtongthanhtien(
                                                   (a.nguyentehd == null ? 0 : double.Parse(a.nguyentehd.ToString())) +
                                                   (a.nguyentepl == null ? 0 : double.Parse(a.nguyentepl.ToString())), a.id),
                                           ghichu2 = tt.ghichu
                                       };

                            // nguồn cấp
                            //var lst5 = lst4;

                            //// Khu Vực
                            //lst4 = lst5;
                            if (checkkv != 0)
                            {
                                lst4 = from a in lst4
                                       join b in dbData.dkreports on a.khuvuc equals b.id
                                       where
                                           b.idnv == Biencucbo.idnv && b.loai == "Khu Vực" && b.form == "f_bctdtt" &&
                                           b.PC == Biencucbo.hostname
                                       select a;
                            }


                            //Loại Công Trình

                            if (checklct != 0)
                            {
                                lst4 = from a in lst4
                                       join b in dbData.dkreports on a.loaict equals b.id
                                       where
                                           b.idnv == Biencucbo.idnv && b.loai == "Loại Công Trình" && b.form == "f_bctdtt" &&
                                           b.PC == Biencucbo.hostname
                                       select a;
                            }


                            //Công Trình

                            if (checkct != 0)
                            {
                                lst4 = from a in lst4
                                       join b in dbData.dkreports on a.idct equals b.id
                                       where
                                           b.idnv == Biencucbo.idnv && b.loai == "Công Trình" && b.form == "f_bctdtt" &&
                                           b.PC == Biencucbo.hostname
                                       select a;
                            }


                            //Đối Tượng

                            if (checkdt != 0)
                            {
                                lst4 = from a in lst4
                                       join b in dbData.dkreports on a.iddt equals b.id
                                       where
                                           b.idnv == Biencucbo.idnv && b.loai == "Đối Tượng" && b.form == "f_bctdtt" &&
                                           b.PC == Biencucbo.hostname
                                       select a;
                            }


                            //User

                            if (checku != 0)
                            {
                                lst4 = from a in lst4
                                       join b in dbData.dkreports on a.idnv equals b.id
                                       where
                                           b.idnv == Biencucbo.idnv && b.loai == "Nhân Viên" && b.form == "f_bctdtt" &&
                                           b.PC == Biencucbo.hostname
                                       select a;
                            }

                            //Đơn Vị

                            if (checkdv != 0)
                            {
                                lst4 = from a in lst4
                                       join b in dbData.dkreports on a.iddv equals b.id
                                       where
                                           b.idnv == Biencucbo.idnv && b.loai == "Đơn Vị" && b.form == "f_bctdtt" &&
                                           b.PC == Biencucbo.hostname
                                       select a;
                            }


                            //link hs

                            if (checklinkhs != 0)
                            {
                                lst4 = from a in lst4
                                       join b in dbData.dkreports on a.link equals b.id
                                       where
                                           b.idnv == Biencucbo.idnv && b.loai == "Link Hồ Sơ" && b.form == "f_bctdtt" &&
                                           b.PC == Biencucbo.hostname
                                       select a;
                            }

                            if (checklinkgoc != 0)
                            {
                                lst4 = from a in lst4
                                       join b in dbData.dkreports on a.linkgoc equals b.id
                                       where
                                           b.idnv == Biencucbo.idnv && b.loai == "Hồ Sơ Gốc" && b.form == "f_bctdtt" &&
                                           b.PC == Biencucbo.hostname
                                       select a;
                            }


                            rp.DataSource = _tTodatatable.addlst(lst4.ToList());

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }

                        break;

                    case 1:
                        Biencucbo.title = "BÁO CÁO THEO DÕI CHUYỂN TIỀN THANH TOÁN CHI PHÍ VẬT TƯ";
                        rp.DataSource = dbData.SP_InBCTheoDoiChuyenTienThanhToan(Biencucbo.idnv, "f_bctdtt", Biencucbo.hostname, tungay.DateTime, denngay.DateTime, all, 1);

                        break;
                    case 2:
                        Biencucbo.title = "BÁO CÁO THEO DÕI CHUYỂN TIỀN THANH TOÁN CHI PHÍ MÁY";
                        rp.DataSource = dbData.SP_InBCTheoDoiChuyenTienThanhToan(Biencucbo.idnv, "f_bctdtt", Biencucbo.hostname, tungay.DateTime, denngay.DateTime, all, 2);

                        break;
                    case 3:
                        Biencucbo.title = "BÁO CÁO THEO DÕI CHUYỂN TIỀN THANH TOÁN CHI PHÍ QUẢN LÝ";
                        rp.DataSource = dbData.SP_InBCTheoDoiChuyenTienThanhToan(Biencucbo.idnv, "f_bctdtt", Biencucbo.hostname, tungay.DateTime, denngay.DateTime, all, 3);

                        break;
                }

                rp.ShowPreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        protected override void search()
        {
            SplashScreenManager.ShowForm(typeof(SplashScreen2));
            //if (tgs.IsOn)
            //{
            if (rdg.SelectedIndex != 0)
            {
                switch (rdg.SelectedIndex)
                {
                    case 1:
                        Biencucbo.title = "BÁO CÁO THEO DÕI CHUYỂN TIỀN THANH TOÁN CHI PHÍ VẬT TƯ";

                        break;
                    case 2:
                        Biencucbo.title = "BÁO CÁO THEO DÕI CHUYỂN TIỀN THANH TOÁN CHI PHÍ MÁY";


                        break;
                    case 3:
                        Biencucbo.title = "BÁO CÁO THEO DÕI CHUYỂN TIỀN THANH TOÁN CHI PHÍ QUẢN LÝ";
                        break;
                }
                inbc<r_bctdtt>(false);
            }
            else
            {
                inbc<r_bctheodoitt>(false);
            }
            //}
            //else
            //{
            //    Biencucbo.title = "BÁOCÁOCHITIẾTNHẬPKHO";
            //    //inbc<r_bcnhapkho_ct>();
            //}
            SplashScreenManager.CloseForm();
        }

        protected override void searchall()
        {
            SplashScreenManager.ShowForm(typeof(SplashScreen2));
            //if (tgs.IsOn)
            //{

            if (rdg.SelectedIndex != 0)
            {
                switch (rdg.SelectedIndex)
                {
                    case 1:
                        Biencucbo.title = "BÁO CÁO THEO DÕI CHUYỂN TIỀN THANH TOÁN CHI PHÍ VẬT TƯ";

                        break;
                    case 2:
                        Biencucbo.title = "BÁO CÁO THEO DÕI CHUYỂN TIỀN THANH TOÁN CHI PHÍ MÁY";


                        break;
                    case 3:
                        Biencucbo.title = "BÁO CÁO THEO DÕI CHUYỂN TIỀN THANH TOÁN CHI PHÍ QUẢN LÝ";
                        break;
                }
                inbc<r_bctdtt>(true);
            }
            else
            {
                inbc<r_bctheodoitt>(true);
            }
            //}
            //else
            //{
            //    Biencucbo.title = "BÁOCÁOCHITIẾTNHẬPKHO";
            //    //inbc<r_bcnhapkho_ct>();
            //}
            SplashScreenManager.CloseForm();
        }
    }
}