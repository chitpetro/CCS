using System;
using System.Linq;
using System.Windows.Forms;
using BUS;
using ControlLocalizer;
using DAL;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;

namespace GUI.Report.PhuongTien
{
    public partial class f_lichtrinh : Form
    {
        private readonly KetNoiDBDataContext db = new KetNoiDBDataContext();
        private string hide_id = "";
        t_todatatable _tTodatatable = new t_todatatable();public f_lichtrinh()
        {
            InitializeComponent();
            rTime.SetTime(thoigian);
            rTime.SetTime2(thoigian);

            //cboChon
            loaivb.EditValue = "--Tất cả--";
            //RepositoryItemComboBox editor = cboChon.Edit as RepositoryItemComboBox;
            loaivb.Properties.Items.Clear();
            var lst = db.loaivanbans.Select(t => t.ten);
            loaivb.Properties.Items.Add("--Tất cả--");
            loaivb.Properties.Items.AddRange(lst.ToList());
        }

        private void f_chitietnhapkho_Load(object sender, EventArgs e)
        {
            //LanguageHelper.Translate(this);
            //this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Lịch Trình Theo Dõi Giao Nhận Hồ Sơ").ToString();
            //changeFont.Translate(this);

            tungay.ReadOnly = true;
            denngay.ReadOnly = true;
        }

        private void thoigian_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeTime.thoigian_change3(thoigian, tungay, denngay);
        }

        public string tenloaivb(string c)
        {
            var b = "";
            try
            {
                var lst = (from a in db.loaivanbans select a).SingleOrDefault(t => t.id == c);
                b = lst.ten;
            }
            catch
            {
            }
            return b;
        }

        public string noigui(string c)
        {
            var b = "";
            try
            {
                var lst = (from a in db.doituongs select a).SingleOrDefault(t => t.id == c);
                b = lst.ten;
            }
            catch
            {
            }

            return b;
        }

        public string nguoigui(string c)
        {
            var b = "";
            try
            {
                var lst = (from a in db.accounts select a).SingleOrDefault(t => t.id == c);
                b = lst.name;
            }
            catch
            {
            }
            return b;
        }

        public string phong(string c)
        {
            var b = "";
            try
            {
                var lst = (from a in db.donvis select a).SingleOrDefault(t => t.id == c);
                b = lst.tendonvi;
            }
            catch
            {
            }
            return b;
        }

        public string tinhtrang(string c)
        {
            var f = "Đã Xử Lý";
            try
            {
                var lsttest = from a in db.lshosos
                    where a.id.Contains(c) && a.phong == Biencucbo.donvi
                    select a;
                var lst = from a in db.lshosos
                    where a.id.Contains(c) && (a.noiguidi == null || a.noiguidi == "") && a.phong == Biencucbo.donvi
                    select a;

                if (lst.Count() > 0)
                {
                    f = "Chưa Xử Lý";
                }
            }
            catch
            {
            }

            return f;
        }

        private void btnin_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof (SplashScreen2), true, true, false);
            try
            {
                var lst1 = (from a in db.lshosos
                    join b in db.vanbandens on a.hsgoc equals b.id
                    where
                        (a.ngaygui >= tungay.DateTime && a.ngaygui <= denngay.DateTime) ||
                        (a.ngaynhan >= tungay.DateTime && a.ngaynhan <= denngay.DateTime)
                    select new
                    {
                        a.iddv,
                        id = tinhtrang(b.id),
                        a.buoc,
                        a.lydo,
                        noiguiden = noigui(a.noiguiden),
                        a.ngaynhan,
                        idnvnhan = nguoigui(a.idnvnhan),
                        noiguidi = noigui(a.noiguidi),
                        a.ngaygui,
                        phong = phong(a.phong),
                        idnvgui = nguoigui(a.idnvgui),
                        a.idvbdi,
                        b.sovb,
                        a.ngxulyden,
                        noidung = "Số Hồ Sơ: " + b.id + ", Nội Dung: " + b.noidung,
                        a.hsgoc,
                        idgoc = tenloaivb(b.loaivb),
                        b.loaivb
                    }).Where(t => t.iddv.Contains(Biencucbo.donvi));
                //var lst3 = (from a in db.vanbandens
                //            join b in lst1 on a.id equals b.id
                //            select a);


                //var lst = (from a in db.lshosos
                //           join b in lst3 on a.hsgoc equals b.id
                //           where a.iddv.Contains(Biencucbo.donvi)
                //           //where (a.ngaygui >= tungay.DateTime && a.ngaygui <= denngay.DateTime) || (a.ngaynhan >= tungay.DateTime && a.ngaynhan <= denngay.DateTime)
                //           select new
                //           {
                //               tinhtrang = tinhtrang(b.id),
                //               a.id,
                //               a.idgoc,
                //               a.buoc,
                //               a.lydo,
                //               noiguiden = noigui(a.noiguiden),
                //               a.ngaynhan,
                //               idnvnhan = nguoigui(a.idnvnhan),
                //               noiguidi = noigui(a.noiguidi),
                //               a.ngaygui,
                //               phong = phong(a.phong),
                //               idnvgui = nguoigui(a.idnvgui),
                //               a.idvbdi,
                //               a.iddv,
                //               b.sovb,
                //               a.ngxulyden,
                //               noidung = "Số Hồ Sơ: " + b.id + ", Nội Dung: " + b.noidung,
                //               a.hsgoc,
                //               tenloaivb = tenloaivb(b.loaivb),
                //               b.loaivb
                //           });
                //}).GroupBy(t => new
                //{
                //    t.tinhtrang,
                //    t.id,
                //    t.idgoc,
                //    t.buoc,
                //    t.lydo,
                //    t.noiguiden,
                //    t.ngaynhan,
                //    t.idnvnhan,
                //    t.noiguidi,
                //    t.ngaygui,
                //    t.phong,
                //    t.idnvgui,
                //    t.idvbdi,
                //    t.noidung,
                //    t.iddv,
                //    t.sovb,
                //    t.ngxulyden,
                //    t.hsgoc,
                //    t.tenloaivb,
                //    t.loaivb
                //}).Select(y => new
                //{
                //    y.Key.tinhtrang,
                //    y.Key.id,
                //    y.Key.idgoc,
                //    y.Key.buoc,
                //    y.Key.lydo,
                //    y.Key.noiguiden,
                //    y.Key.ngaynhan,
                //    y.Key.idnvnhan,
                //    y.Key.noiguidi,
                //    y.Key.ngaygui,
                //    y.Key.phong,
                //    y.Key.idnvgui,
                //    y.Key.idvbdi,
                //    y.Key.noidung,
                //    y.Key.iddv,
                //    y.Key.sovb,
                //    y.Key.ngxulyden,
                //    y.Key.hsgoc,
                //    y.Key.tenloaivb,
                //    y.Key.loaivb
                //}).ToList();

                Biencucbo.tungay2 = tungay.DateTime;
                Biencucbo.denngay2 = denngay.DateTime;

                if (loaivb.EditValue.ToString() == "--Tất cả--")
                {
                    var xtra = new r_lichtrinh();
                    xtra.DataSource = _tTodatatable.addlst(lst1.ToList());
                    xtra.ShowPreviewDialog();
                }
                else
                {
                    var lst2 = from a in lst1 where a.loaivb == hide_id select a;
                    var xtra = new r_lichtrinh();
                    xtra.DataSource = _tTodatatable.addlst(lst2.ToList());
                    xtra.ShowPreviewDialog();
                }
            }
            catch
            {
            }
            SplashScreenManager.CloseForm(false);
        }

        private void loaivb_TextChanged(object sender, EventArgs e)
        {
            if (loaivb.EditValue.ToString() != "--Tất cả--")
            {
                var lst = (from a in db.loaivanbans select a).SingleOrDefault(t => t.ten == loaivb.EditValue.ToString());
                hide_id = lst.id;
            }
        }
    }
}