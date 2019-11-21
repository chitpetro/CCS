using System;
using System.Linq;
using System.Windows.Forms;
using BUS;
using ControlLocalizer;
using DAL;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using GUI.report;
using Lotus;

namespace GUI
{
    public partial class f_dsHopDong_cdt : Form
    {
        private readonly KetNoiDBDataContext db = new KetNoiDBDataContext();
        private bool doubleclick;
        public string sh = "";
        public string sh2 = "";

        public string sh3 = "";
        public string sh4 = "";
        t_todatatable _tTodatatable = new t_todatatable();
        public double tongtt;
        public double tongtt2;

        public f_dsHopDong_cdt()
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;
        }

        public void loaddata()
        {
            SplashScreenManager.ShowForm(this, typeof (SplashScreen2), true, true, false);
            try
            {
                var lst = (from a in db.r_hopdong_cdts
                    join d in db.donvis on a.iddv equals d.id
                    where a.idct == Biencucbo.mact
                    select new
                    {
                        a.id,
                        a.iddv,
                        a.sohd,
                        a.ngayky,
                        a.noidunghd,
                        a.loaihd,
                        doituong = a.iddt + "-" + a.tendt,
                        a.tiente,
                        nguyente = a.nguyente == null ? 0 : a.nguyente,
                        thanhtien = a.thanhtien == null ? 0 : a.thanhtien,
                        a.ghichu,
                        MaTim = LayMaTim(d)
                    }).ToList()
                    .Where(t => t.MaTim.Contains("." + Biencucbo.donvi + "."))
                    .GroupBy(
                        t =>
                            new
                            {
                                t.id,
                                t.iddv,
                                t.sohd,
                                t.ngayky,
                                t.noidunghd,
                                t.loaihd,
                                t.doituong,
                                t.tiente,
                                t.ghichu,
                                t.MaTim
                            })
                    .Select(y =>
                        new
                        {
                            y.Key.id,
                            y.Key.iddv,
                            y.Key.sohd,
                            y.Key.ngayky,
                            y.Key.noidunghd,
                            y.Key.loaihd,
                            y.Key.doituong,
                            y.Key.tiente,
                            nguyente = y.Sum(t => t.nguyente),
                            thanhtien = y.Sum(t => t.thanhtien),
                            y.Key.ghichu
                        });

                var lst2 = (from a in db.hopdong_cdts
                    join b in db.thanhtoan_cdts on a.id equals b.idhd_cdt into k
                    join d in db.donvis on a.iddv equals d.id
                    where a.idct == Biencucbo.mact
                    from tt in k.DefaultIfEmpty()
                    select new
                    {
                        a.id,
                        giatritt = tt.giatritt == null ? 0 : tt.giatritt,
                        giatriqt = tt.giatriqt == null ? 0 : tt.giatriqt,
                        Matim = LayMaTim(d)
                    }).ToList()
                    .Where(t => t.Matim.Contains("." + Biencucbo.donvi + "."))
                    .GroupBy(t => new {t.id, t.Matim})
                    .Select(y => new
                    {
                        y.Key.id,
                        giatritt = y.Sum(t => t.giatritt),
                        giatriqt = y.Sum(t => t.giatriqt)
                    });
                var lst3 = from a in lst
                    join b in lst2 on a.id equals b.id into k
                    from tt in k.DefaultIfEmpty()
                    select new
                    {
                        a.id,
                        a.iddv,
                        a.sohd,
                        a.ngayky,
                        a.noidunghd,
                        a.loaihd,
                        a.doituong,
                        a.tiente,
                        a.nguyente,
                        a.thanhtien,
                        tt.giatritt,
                        tt.giatriqt,
                        cl = a.nguyente - tt.giatritt,
                        a.ghichu
                    };


                gridControl1.DataSource = _tTodatatable.addlst(lst3.ToList());
            }
            catch (Exception ex)
            {
                MsgBox.ShowErrorDialog(ex.ToString());
            }
            SplashScreenManager.CloseForm(false);
        }

        private string LayMaTim(donvi d)
        {
            var s = "." + d.id + "." + d.iddv + ".";
            var find = db.donvis.FirstOrDefault(t => t.id == d.iddv);
            if (find != null)
            {
                var iddv = find.iddv;
                if (d.id != find.iddv)
                {
                    if (!s.Contains(iddv))
                        s += iddv + ".";
                }
                while (iddv != find.id)
                {
                    if (!s.Contains(find.id))
                        s += find.id + ".";
                    find = db.donvis.FirstOrDefault(t => t.id == find.iddv);
                }
            }
            return s;
        }

        private void f_PN_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Danh Sách Hợp Đồng");

            changeFont.Translate(this);
            changeFont.Translate(barManager1);

            loaddata();

            Biencucbo.getID = 0;
        }

        private void thoigian_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void timkiem_Click(object sender, EventArgs e)
        {
        }

        private void gridView1_CustomDrawRowIndicator_1(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!gridView1.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
            {
                if (e.Info.IsRowIndicator) //Nếu là dòng Indicator
                {
                    if (e.RowHandle < 0)
                    {
                        e.Info.ImageIndex = 0;
                        e.Info.DisplayText = string.Empty;
                    }
                    else
                    {
                        e.Info.ImageIndex = -1; //Không hiển thị hình
                        e.Info.DisplayText = (e.RowHandle + 1).ToString(); //Số thứ tự tăng dần
                    }
                    var _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                        //Lấy kích thước của vùng hiển thị Text
                    var _Width = Convert.ToInt32(_Size.Width) + 20;
                    BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView1); }));
                        //Tăng kích thước nếu Text vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", e.RowHandle*-1); //Nhân -1 để đánh lại số thứ tự tăng dần
                var _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                var _Width = Convert.ToInt32(_Size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView1); }));
            }
        }

        private bool cal(int _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            doubleclick = false;
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (doubleclick)
            {
                Biencucbo.getID = 1;
                Biencucbo.ma = gridView1.GetFocusedRowCellValue("id").ToString();
                var frm = new f_hopdong_cdt();
                frm.ShowDialog();
                loaddata();
                //this.Close();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            doubleclick = true;
        }


        private void btnin_Click(object sender, EventArgs e)
        {
            var lstct = (from a in db.congtrinhs select a).Single(t => t.id == Biencucbo.mact);
            Biencucbo.bcct = "Công trình: " + lstct.tencongtrinh;
            Biencucbo.bcdc = "Địa điểm: " + lstct.diadiem;
            Biencucbo.bccht = "Chỉ huy trưởng: " + lstct.chihuytruong;
            if (tgsin.IsOn)
            {
                var lst = (from a in db.r_hopdong_cdts
                    join d in db.donvis on a.iddv equals d.id
                    where a.idct == Biencucbo.mact && a.loai == "Hợp Đồng"
                    select new
                    {
                        a.id,
                        a.iddv,
                        a.sohd,
                        a.ngayky,
                        a.noidunghd,
                        a.tygia,
                        a.loaihd,
                        doituong = a.iddt + "-" + a.tendt,
                        a.tiente,
                        nguyentehd = a.nguyente == null ? 0 : a.nguyente,
                        nguyentepl = a.nguyente == null ? 0 : a.nguyente - a.nguyente,
                        thanhtien = a.thanhtien == null ? 0 : a.thanhtien,
                        MaTim = LayMaTim(d)
                    }).Concat(from a in db.r_hopdong_cdts
                        join d in db.donvis on a.iddv equals d.id
                        where a.idct == Biencucbo.mact && a.loai == "Phụ Lục"
                        select new
                        {
                            a.id,
                            a.iddv,
                            a.sohd,
                            a.ngayky,
                            a.noidunghd,
                            a.tygia,
                            a.loaihd,
                            doituong = a.iddt + "-" + a.tendt,
                            a.tiente,
                            nguyentehd = a.nguyente == null ? 0 : a.nguyente - a.nguyente,
                            nguyentepl = a.nguyente == null ? 0 : a.nguyente,
                            thanhtien = a.thanhtien == null ? 0 : a.thanhtien,
                            MaTim = LayMaTim(d)
                        }).Concat(from a in db.r_hopdong_cdts
                            join d in db.donvis on a.iddv equals d.id
                            where a.idct == Biencucbo.mact && a.loai == null
                            select new
                            {
                                a.id,
                                a.iddv,
                                a.sohd,
                                a.ngayky,
                                a.noidunghd,
                                a.tygia,
                                a.loaihd,
                                doituong = a.iddt + "-" + a.tendt,
                                a.tiente,
                                nguyentehd = a.nguyente == null ? 0 : a.nguyente - a.nguyente,
                                nguyentepl = a.nguyente == null ? 0 : a.nguyente,
                                thanhtien = a.thanhtien == null ? 0 : a.thanhtien,
                                MaTim = LayMaTim(d)
                            })
                    .ToList()
                    .Where(t => t.MaTim.Contains("." + Biencucbo.donvi + "."))
                    .GroupBy(
                        t =>
                            new
                            {
                                t.id,
                                t.iddv,
                                t.sohd,
                                t.ngayky,
                                t.noidunghd,
                                t.loaihd,
                                t.doituong,
                                t.tiente,
                                t.MaTim,
                                t.tygia
                            })
                    .Select(y =>
                        new
                        {
                            y.Key.id,
                            y.Key.iddv,
                            y.Key.sohd,
                            y.Key.ngayky,
                            y.Key.noidunghd,
                            y.Key.loaihd,
                            y.Key.doituong,
                            y.Key.tiente,
                            y.Key.tygia,
                            nguyentehd = y.Sum(t => t.nguyentehd),
                            nguyentepl = y.Sum(t => t.nguyentepl),
                            thanhtien = y.Sum(t => t.thanhtien)
                        });

                var lst2 = (from a in db.hopdong_cdts
                    join b in db.thanhtoan_cdts on a.id equals b.idhd_cdt into k
                    join d in db.donvis on a.iddv equals d.id
                    where a.idct == Biencucbo.mact
                    from tt in k.DefaultIfEmpty()
                    orderby tt.idhd_cdt ascending
                    orderby tt.lan ascending
                    select new
                    {
                        a.id,
                        giatritt = tt.giatritt == null ? 0 : tt.giatritt,
                        giatriqt = tt.giatriqt == null ? 0 : tt.giatriqt,
                        tt.ngaytt,
                        tt.ghichu,
                        tt.diengiai,
                        tt.lan,
                        Matim = LayMaTim(d)
                    }).ToList().Where(t => t.Matim.Contains("." + Biencucbo.donvi + "."));
                var lst4 = lst2.GroupBy(t => new {t.id}).Select(y =>
                    new
                    {
                        y.Key.id,
                        tongtt = y.Sum(x => x.giatritt)
                    });


                var lst3 = from a in lst
                    join b in lst2 on a.id equals b.id into k
                    join c in lst4 on a.id equals c.id into l
                    from tt in k.DefaultIfEmpty()
                    from tong in l.DefaultIfEmpty()
                    select new
                    {
                        a.id,
                        a.iddv,
                        a.sohd,
                        a.ngayky,
                        noidung =
                            "- Số HĐ: " + a.sohd + "- Chủ Đầu Tư: " + a.doituong + ". \n- GTHĐ: " +
                            string.Format("{0:n2}", a.nguyentehd) + "- GTPL: " + string.Format("{0:n2}", a.nguyentepl) +
                            " (" + a.tiente + ").\n- Nội Dung HĐ: " + a.noidunghd,
                        a.loaihd,
                        tendoituong = a.doituong,
                        a.tiente,
                        tt.diengiai,
                        tt.ngaytt,
                        tt.lan,
                        nguyentetp = a.nguyentepl,
                        a.thanhtien,
                        tt.giatritt,
                        tt.giatriqt,
                        cl =
                            Tinhgiatricl(tt.giatritt == null ? 0 : double.Parse(tt.giatritt.ToString()), a.id,
                                a.nguyentehd == null ? 0 : double.Parse(a.nguyentehd.ToString()),
                                a.nguyentepl == null ? 0 : double.Parse(a.nguyentepl.ToString())),
                        cltt =
                            Tinhgiatricl2(tt.giatritt == null ? 0 : double.Parse(tt.giatritt.ToString()), a.id,
                                a.nguyentehd == null ? 0 : double.Parse(a.nguyentehd.ToString()),
                                a.nguyentepl == null ? 0 : double.Parse(a.nguyentepl.ToString()),
                                double.Parse(a.tygia.ToString())),
                        tongcl =
                            Tinhgiatricl3(tong.tongtt == null ? 0 : double.Parse(tong.tongtt.ToString()), a.id,
                                a.nguyentehd == null ? 0 : double.Parse(a.nguyentehd.ToString()),
                                a.nguyentepl == null ? 0 : double.Parse(a.nguyentepl.ToString()),
                                double.Parse(a.tygia.ToString())),
                        tongttien =
                            tinhtongthanhtien(a.thanhtien == null ? 0 : double.Parse(a.thanhtien.ToString()), a.id),
                        ghichu2 = tt.ghichu
                    };
                var frm = new hdtp1cdt_ct();
                frm.DataSource = _tTodatatable.addlst(lst3.ToList());
                frm.ShowPreviewDialog();
            }
            else
            {
                var lst = (from a in db.r_hopdong_cdts
                    join d in db.donvis on a.iddv equals d.id
                    where a.idct == Biencucbo.mact && a.loai == "Hợp Đồng"
                    select new
                    {
                        a.id,
                        a.iddv,
                        a.sohd,
                        a.ngayky,
                        a.noidunghd,
                        a.tygia,
                        a.loaihd,
                        doituong = a.iddt + "-" + a.tendt,
                        a.ghichu,
                        a.tiente,
                        nguyentehd = a.nguyente == null ? 0 : a.nguyente,
                        nguyentepl = a.nguyente == null ? 0 : a.nguyente - a.nguyente,
                        thanhtien = a.thanhtien == null ? 0 : a.thanhtien,
                        MaTim = LayMaTim(d)
                    }).Concat(from a in db.r_hopdong_cdts
                        join d in db.donvis on a.iddv equals d.id
                        where a.idct == Biencucbo.mact && a.loai == "Phụ Lục"
                        select new
                        {
                            a.id,
                            a.iddv,
                            a.sohd,
                            a.ngayky,
                            a.noidunghd,
                            a.tygia,
                            a.loaihd,
                            doituong = a.iddt + "-" + a.tendt,
                            a.ghichu,
                            a.tiente,
                            nguyentehd = a.nguyente == null ? 0 : a.nguyente - a.nguyente,
                            nguyentepl = a.nguyente == null ? 0 : a.nguyente,
                            thanhtien = a.thanhtien == null ? 0 : a.thanhtien,
                            MaTim = LayMaTim(d)
                        }).Concat(from a in db.r_hopdong_cdts
                            join d in db.donvis on a.iddv equals d.id
                            where a.idct == Biencucbo.mact && a.loai == null
                            select new
                            {
                                a.id,
                                a.iddv,
                                a.sohd,
                                a.ngayky,
                                a.noidunghd,
                                a.tygia,
                                a.loaihd,
                                doituong = a.iddt + "-" + a.tendt,
                                a.ghichu,
                                a.tiente,
                                nguyentehd = a.nguyente == null ? 0 : a.nguyente - a.nguyente,
                                nguyentepl = a.nguyente == null ? 0 : a.nguyente,
                                thanhtien = a.thanhtien == null ? 0 : a.thanhtien,
                                MaTim = LayMaTim(d)
                            })
                    .ToList()
                    .Where(t => t.MaTim.Contains("." + Biencucbo.donvi + "."))
                    .GroupBy(
                        t =>
                            new
                            {
                                t.id,
                                t.iddv,
                                t.sohd,
                                t.ngayky,
                                t.noidunghd,
                                t.loaihd,
                                t.doituong,
                                t.tiente,
                                t.MaTim,
                                t.tygia,
                                t.ghichu
                            })
                    .Select(y =>
                        new
                        {
                            y.Key.id,
                            y.Key.iddv,
                            y.Key.sohd,
                            y.Key.ngayky,
                            y.Key.noidunghd,
                            y.Key.loaihd,
                            y.Key.doituong,
                            y.Key.tiente,
                            y.Key.ghichu,
                            y.Key.tygia,
                            nguyentehd = y.Sum(t => t.nguyentehd),
                            nguyentepl = y.Sum(t => t.nguyentepl),
                            thanhtien = y.Sum(t => t.thanhtien)
                        });
                var lst2 = (from a in db.hopdong_cdts
                    join b in db.thanhtoan_cdts on a.id equals b.idhd_cdt into k
                    join d in db.donvis on a.iddv equals d.id
                    where a.idct == Biencucbo.mact
                    from tt in k.DefaultIfEmpty()
                    select new
                    {
                        a.id,
                        giatritt = tt.giatritt == null ? 0 : tt.giatritt*a.tygia,
                        giatritt2 = tt.giatritt == null ? 0 : tt.giatritt,
                        giatriqt = tt.giatriqt == null ? 0 : tt.giatriqt*a.tygia,
                        Matim = LayMaTim(d)
                    }).ToList()
                    .Where(t => t.Matim.Contains("." + Biencucbo.donvi + "."))
                    .GroupBy(t => new {t.id})
                    .Select(y =>
                        new
                        {
                            y.Key.id,
                            giatritt = y.Sum(x => x.giatritt),
                            giatritt2 = y.Sum(x => x.giatritt2),
                            giatriqt = y.Sum(x => x.giatriqt)
                        });


                var lst3 = from a in lst
                    join b in lst2 on a.id equals b.id into k
                    from tt in k.DefaultIfEmpty()
                    select new
                    {
                        a.id,
                        a.iddv,
                        a.sohd,
                        a.ngayky,
                        a.noidunghd,
                        a.loaihd,
                        tendoituong = a.doituong,
                        a.tiente,
                        gthd = a.nguyentehd == null ? 0 : a.nguyentehd*a.tygia,
                        gtpl = a.nguyentepl == null ? 0 : a.nguyentepl*a.tygia,
                        tt.giatritt,
                        tt.giatriqt,
                        tongcl =
                            Tinhgiatricl3(tt.giatritt2 == null ? 0 : double.Parse(tt.giatritt2.ToString()), a.id,
                                a.nguyentehd == null ? 0 : double.Parse(a.nguyentehd.ToString()),
                                a.nguyentepl == null ? 0 : double.Parse(a.nguyentepl.ToString()),
                                double.Parse(a.tygia.ToString())),
                        a.ghichu
                    };
                var frm = new hdtp1_th();
                frm.DataSource = _tTodatatable.addlst(lst3.ToList());
                frm.ShowPreviewDialog();
            }
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

        private double Tinhgiatricl(double a, string b, double c, double d)
        {
            double cl = 0;
            if (sh == b)
            {
                tongtt = tongtt + a;
                cl = c + d - tongtt;
            }
            else
            {
                sh = b;
                tongtt = a;
                cl = c + d - tongtt;
            }
            return cl;
        }

        private double Tinhgiatricl2(double a, string b, double c, double d, double e)
        {
            double cl = 0;

            if (sh2 == b)
            {
                tongtt2 = tongtt2 + a;
                cl = (c + d - tongtt2)*e;
            }
            else
            {
                sh2 = b;
                tongtt2 = a;
                cl = (c + d - tongtt2)*e;
            }
            return cl;
        }

        private double Tinhgiatricl3(double a, string b, double c, double d, double e)
        {
            double cl = 0;

            if (sh3 == b)
            {
                cl = 0;
            }
            else
            {
                sh3 = b;
                cl = (c + d - a)*e;
            }
            return cl;
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            Biencucbo.getID = 2;
            var frm = new f_hopdong_cdt();
            frm.ShowDialog();
            loaddata();
        }
    }
}