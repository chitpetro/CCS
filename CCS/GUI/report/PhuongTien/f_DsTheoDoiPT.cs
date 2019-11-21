using System;
using System.Linq;
using System.Windows.Forms;
using BUS;
using ControlLocalizer;
using DAL;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using Lotus;

namespace GUI.Report.PhuongTien
{
    public partial class f_DsTheoDoiPT : Form
    {
        public static string loaixemay = "";
        public static string tenxe = "";
        public static string ct = "";
        private readonly KetNoiDBDataContext db = new KetNoiDBDataContext();
        private bool doubleclick1;
        private bool doubleclick2;
        t_todatatable _tTodatatable = new t_todatatable();
        public int test;

        public f_DsTheoDoiPT()
        {
            InitializeComponent();
            rTime.SetTime(thoigian);
        }

        private void f_chitietnhapkho_Load(object sender, EventArgs e)
        {
            //LanguageHelper.Translate(this);
            //this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "DANH SÁCH THEO DÕI PHƯƠNG TIỆN").ToString();

            //changeFont.Translate(this);
            rTime.SetTime2(thoigian);
            tungay.ReadOnly = true;
            denngay.ReadOnly = true;

            danhmuc.Text = "Phương Tiện";

            var lst = from a in db.dk_rps where a.user == Biencucbo.idnv select a;
            db.dk_rps.DeleteAllOnSubmit(lst);
            db.SubmitChanges();
            nhan.DataSource = _tTodatatable.addlst(lst.ToList());
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

        private void thoigian_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeTime.thoigian_change3(thoigian, tungay, denngay);
            changeTime.thoigian_change3(thoigian, dateEdit1, dateEdit2);
            try
            {
                var list = from a in db.theodoi_phuongtiens
                    join b in db.phuongtiens on a.mapt equals b.id
                    where a.thoigian >= dateEdit1.DateTime && a.thoigian <= dateEdit2.DateTime
                    select new
                    {
                        id = a.mapt,
                        name = b.ten,
                        key = a.mapt + danhmuc.Text + Biencucbo.idnv
                    };
                var lst2 = list.ToList();

                for (var j = 0; j < gridView2.DataRowCount; j++)
                {
                    var lst3 = from a in lst2
                        where a.key != gridView2.GetRowCellValue(j, "key").ToString()
                        select a;
                    lst2 = lst3.ToList();
                }
                ;
                nguon.DataSource = _tTodatatable.addlst(lst2.ToList());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void danhmuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (danhmuc.Text == "Phương Tiện")
            {
                try
                {
                    var list = from a in db.theodoi_phuongtiens
                        join b in db.phuongtiens on a.mapt equals b.id
                        where a.thoigian >= dateEdit1.DateTime && a.thoigian <= dateEdit2.DateTime
                        select new
                        {
                            id = a.mapt,
                            name = b.ten,
                            key = a.mapt + danhmuc.Text + Biencucbo.idnv
                        };
                    var lst2 = list.ToList();

                    for (var j = 0; j < gridView2.DataRowCount; j++)
                    {
                        var lst3 = from a in lst2
                            where a.key != gridView2.GetRowCellValue(j, "key").ToString()
                            select a;
                        lst2 = lst3.ToList();
                    }
                    ;
                    nguon.DataSource = _tTodatatable.addlst(lst2.ToList());
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            test = 0;
            for (var i = 0; i < gridView2.DataRowCount; i++)
            {
                if (gridView2.GetRowCellValue(i, "loai").ToString() == "Phương Tiện")
                {
                    test++;
                    if (test >= 1)
                    {
                        MsgBox.ShowWarningDialog("Chỉ được chọn 1 Phương Tiện duy nhất");
                        return;
                    }
                }
            }

            try
            {
                var dk = new dk_rp();
                dk.id = gridView1.GetFocusedRowCellValue("id").ToString();
                dk.name = gridView1.GetFocusedRowCellValue("name").ToString();
                dk.key = gridView1.GetFocusedRowCellValue("key").ToString();
                dk.loai = danhmuc.Text;

                dk.user = Biencucbo.idnv;
                db.dk_rps.InsertOnSubmit(dk);
                db.SubmitChanges();
                var lst = from a in db.dk_rps where a.user == Biencucbo.idnv select a;
                nhan.DataSource = _tTodatatable.addlst(lst.ToList());

                if (danhmuc.Text == "Phương Tiện")
                {
                    var list = from a in db.theodoi_phuongtiens
                        join b in db.phuongtiens on a.mapt equals b.id
                        where a.thoigian >= dateEdit1.DateTime && a.thoigian <= dateEdit2.DateTime
                        select new
                        {
                            id = a.mapt,
                            name = b.ten,
                            key = a.mapt + danhmuc.Text + Biencucbo.idnv
                        };

                    var lst2 = list.ToList();

                    for (var j = 0; j < gridView2.DataRowCount; j++)
                    {
                        var lst3 = from a in lst2
                            where a.key != gridView2.GetRowCellValue(j, "key").ToString()
                            select a;
                        lst2 = lst3.ToList();
                    }
                    ;
                    nguon.DataSource = _tTodatatable.addlst(lst2.ToList());
                }
                else
                {
                    gridView1.DeleteSelectedRows();
                }
            }
            catch
            {
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            doubleclick1 = false;
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (doubleclick1)
            {
                test = 0;
                for (var i = 0; i < gridView2.DataRowCount; i++)
                {
                    if (gridView2.GetRowCellValue(i, "loai").ToString() == "Phương Tiện")
                    {
                        test++;
                        if (test >= 1)
                        {
                            MsgBox.ShowWarningDialog("Chỉ được chọn 1 Phương Tiện duy nhất");
                            return;
                        }
                    }
                }

                try
                {
                    var dk = new dk_rp();
                    dk.id = gridView1.GetFocusedRowCellValue("id").ToString();
                    dk.name = gridView1.GetFocusedRowCellValue("name").ToString();
                    dk.key = gridView1.GetFocusedRowCellValue("key").ToString();
                    dk.loai = danhmuc.Text;
                    dk.user = Biencucbo.idnv;
                    db.dk_rps.InsertOnSubmit(dk);
                    db.SubmitChanges();
                    var lst = from a in db.dk_rps where a.user == Biencucbo.idnv select a;
                    nhan.DataSource = _tTodatatable.addlst(lst.ToList());

                    if (danhmuc.Text == "Phương Tiện")
                    {
                        var list = from a in db.theodoi_phuongtiens
                            join b in db.phuongtiens on a.mapt equals b.id
                            where a.thoigian >= dateEdit1.DateTime && a.thoigian <= dateEdit2.DateTime
                            select new
                            {
                                id = a.mapt,
                                name = b.ten,
                                key = a.mapt + danhmuc.Text + Biencucbo.idnv
                            };

                        var lst2 = list.ToList();

                        for (var j = 0; j < gridView2.DataRowCount; j++)
                        {
                            var lst3 = from a in lst2
                                where a.key != gridView2.GetRowCellValue(j, "key").ToString()
                                select a;
                            lst2 = lst3.ToList();
                        }
                        ;
                        nguon.DataSource = _tTodatatable.addlst(lst2.ToList());
                    }
                    else
                    {
                        gridView1.DeleteSelectedRows();
                    }
                }
                catch
                {
                }
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            doubleclick1 = true;
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            doubleclick2 = true;
        }

        private void gridView2_Click(object sender, EventArgs e)
        {
            doubleclick2 = false;
        }

        private void gridView2_RowClick(object sender, RowClickEventArgs e)
        {
            if (doubleclick2)
            {
                try
                {
                    var dk = new dk_rp();
                    var lst =
                        (from a in db.dk_rps where a.user == Biencucbo.idnv select a).Single(
                            t => t.key == gridView2.GetFocusedRowCellValue("key").ToString());
                    db.dk_rps.DeleteOnSubmit(lst);
                    db.SubmitChanges();
                    var lst2 = from a in db.dk_rps where a.user == Biencucbo.idnv select a;
                    nhan.DataSource = _tTodatatable.addlst(lst2.ToList());
                }
                catch
                {
                }
                if (danhmuc.Text == "Phương Tiện")
                {
                    try
                    {
                        var list = from a in db.theodoi_phuongtiens
                            join b in db.phuongtiens on a.mapt equals b.id
                            where a.thoigian >= dateEdit1.DateTime && a.thoigian <= dateEdit2.DateTime
                            select new
                            {
                                id = a.mapt,
                                name = b.ten,
                                key = a.mapt + danhmuc.Text + Biencucbo.idnv
                            };

                        var lst2 = list.ToList();

                        for (var j = 0; j < gridView2.DataRowCount; j++)
                        {
                            var lst3 = from a in lst2
                                where a.key != gridView2.GetRowCellValue(j, "key").ToString()
                                select a;
                            lst2 = lst3.ToList();
                        }
                        ;
                        nguon.DataSource = _tTodatatable.addlst(lst2.ToList());
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                var dk = new dk_rp();
                var lst =
                    (from a in db.dk_rps where a.user == Biencucbo.idnv select a).Single(
                        t => t.key == gridView2.GetFocusedRowCellValue("key").ToString());
                db.dk_rps.DeleteOnSubmit(lst);
                db.SubmitChanges();
                var lst2 = from a in db.dk_rps where a.user == Biencucbo.idnv select a;
                nhan.DataSource = _tTodatatable.addlst(lst2.ToList());
            }
            catch
            {
            }
            if (danhmuc.Text == "Phương Tiện")
            {
                try
                {
                    var list = from a in db.theodoi_phuongtiens
                        join b in db.phuongtiens on a.mapt equals b.id
                        where a.thoigian >= dateEdit1.DateTime && a.thoigian <= dateEdit2.DateTime
                        select new
                        {
                            id = a.mapt,
                            name = b.ten,
                            key = a.mapt + danhmuc.Text + Biencucbo.idnv
                        };

                    var lst2 = list.ToList();

                    for (var j = 0; j < gridView2.DataRowCount; j++)
                    {
                        var lst3 = from a in lst2
                            where a.key != gridView2.GetRowCellValue(j, "key").ToString()
                            select a;
                        lst2 = lst3.ToList();
                    }
                    ;
                    nguon.DataSource = _tTodatatable.addlst(lst2.ToList());
                }
                catch
                {
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            test = 0;
            if (test == 0)
            {
                MsgBox.ShowWarningDialog("Chỉ được chọn 1 Phương Tiện duy nhất");
                return;
            }
            for (var i = 0; i < gridView2.DataRowCount; i++)
            {
                if (gridView2.GetRowCellValue(i, "loai").ToString() == "Phương Tiện")
                {
                    test++;
                    if (test >= 1)
                    {
                        MsgBox.ShowWarningDialog("Chỉ được chọn 1 Phương Tiện duy nhất");
                        return;
                    }
                }
            }

            try
            {
                for (var i = 0; i < gridView1.RowCount; i++)
                {
                    var dk = new dk_rp();
                    dk.id = gridView1.GetRowCellValue(i, "id").ToString();
                    dk.name = gridView1.GetRowCellValue(i, "name").ToString();
                    dk.key = gridView1.GetRowCellValue(i, "key").ToString();
                    dk.loai = danhmuc.Text;
                    dk.user = Biencucbo.idnv;
                    db.dk_rps.InsertOnSubmit(dk);
                    db.SubmitChanges();
                    var lst = from a in db.dk_rps where a.user == Biencucbo.idnv select a;
                    nhan.DataSource = _tTodatatable.addlst(lst.ToList());
                }
                if (danhmuc.Text == "Phương Tiện")
                {
                    var list = from a in db.theodoi_phuongtiens
                        join b in db.phuongtiens on a.mapt equals b.id
                        where a.thoigian >= dateEdit1.DateTime && a.thoigian <= dateEdit2.DateTime
                        select new
                        {
                            id = a.mapt,
                            name = b.ten,
                            key = a.mapt + danhmuc.Text + Biencucbo.idnv
                        };

                    var lst2 = list.ToList();

                    for (var j = 0; j < gridView2.DataRowCount; j++)
                    {
                        var lst3 = from a in lst2
                            where a.key != gridView2.GetRowCellValue(j, "key").ToString()
                            select a;
                        lst2 = lst3.ToList();
                    }
                    ;
                    nguon.DataSource = _tTodatatable.addlst(lst2.ToList());
                }
                else
                {
                    for (var i = gridView1.RowCount; i > 0; i--)
                    {
                        gridView1.DeleteSelectedRows();
                    }
                }
            }
            catch
            {
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                var lst = from a in db.dk_rps where a.user == Biencucbo.idnv select a;
                db.dk_rps.DeleteAllOnSubmit(lst);
                db.SubmitChanges();
                nhan.DataSource = _tTodatatable.addlst(lst.ToList());
            }
            catch
            {
            }
            if (danhmuc.Text == "Phương Tiện")
            {
                try
                {
                    var list = from a in db.theodoi_phuongtiens
                        join b in db.phuongtiens on a.mapt equals b.id
                        where a.thoigian >= dateEdit1.DateTime && a.thoigian <= dateEdit2.DateTime
                        select new
                        {
                            id = a.mapt,
                            name = b.ten,
                            key = a.mapt + danhmuc.Text + Biencucbo.idnv
                        };

                    var lst2 = list.ToList();

                    for (var j = 0; j < gridView2.DataRowCount; j++)
                    {
                        var lst3 = from a in lst2
                            where a.key != gridView2.GetRowCellValue(j, "key").ToString()
                            select a;
                        lst2 = lst3.ToList();
                    }
                    ;
                    nguon.DataSource = _tTodatatable.addlst(lst2.ToList());
                }
                catch
                {
                }
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof (SplashScreen2), true, true, false);
            //try
            //{

            Biencucbo.loai = "";
            Biencucbo.doituong = "";
            Biencucbo.congviec = "";
            Biencucbo.taikhoan = "";
            Biencucbo.muccp = "";
            Biencucbo.kho = "";
            var check = 0;
            var check1 = 0;
            var check2 = 0;
            var check3 = 0;
            var check4 = 0;
            var check5 = 0;

            for (var i = 0; i < gridView2.DataRowCount; i++)
            {
                if (gridView2.GetRowCellValue(i, "loai").ToString() == "Phương Tiện")
                {
                    check++;
                    Biencucbo.kho = Biencucbo.kho + gridView2.GetRowCellValue(i, "id") + "-" +
                                    gridView2.GetRowCellValue(i, "name") + ", ";
                }
            }

            if (check == 0)
            {
                MsgBox.ShowWarningDialog("Cần phải chọn 1 trường dữ liệu bắt buộc: Phương Tiện");
                return;
            }

            if (Biencucbo.ngonngu.ToString() == "Vietnam")
            {
                if (check1 == 0)
                {
                    Biencucbo.loai = "Tất cả";
                }
                if (check2 == 0)
                {
                    Biencucbo.doituong = "Tất cả";
                }
                if (check3 == 0)
                {
                    Biencucbo.congviec = "Tất cả";
                }
                if (check4 == 0)
                {
                    Biencucbo.muccp = "Tất cả";
                }
                if (check5 == 0)
                {
                    Biencucbo.taikhoan = "Tất cả";
                }
                if (thoigian.Text == "Tùy ý")
                {
                    Biencucbo.time = "Từ tháng: " + tungay.Text + " Đến tháng: " + denngay.Text;
                }
                else if (thoigian.Text == "Cả Năm")
                {
                    Biencucbo.time = thoigian.Text + " " + DateTime.Now.Year;
                }
                else
                {
                    Biencucbo.time = thoigian.Text + ", năm " + DateTime.Now.Year;
                }
            }

            var lst2 = from a in db.theodoi_phuongtiens
                join b in db.dk_rps on a.mapt equals b.id
                where a.mapt == b.id
                      && b.user == Biencucbo.idnv
                //&& a.thoigian >= dateEdit1.DateTime && a.thoigian <= dateEdit2.DateTime
                select a;

            var lst = from a in lst2
                join b in db.phuongtiens on a.mapt equals b.id
                where a.thoigian >= dateEdit1.DateTime && a.thoigian <= dateEdit2.DateTime
                //&& b.madv == Biencucbo.mact
                select new
                {
                    id = a.mapt,
                    //ten=a.ten,
                    b.ten,
                    a.thoigian,
                    a.sogiohd,
                    a.socahd,
                    a.sochuyen,
                    a.songay,
                    a.tondk,
                    a.captk,
                    a.chuyencho,
                    a.tonck,
                    a.tieuhaothuctetk,
                    a.tieuhaodv,
                    a.chenhlech,
                    b.dvdinhmuc,
                    b.madv
                };

            var lst3 = (from a in lst select new {a.dvdinhmuc, a.id, a.ten}).Single();
            loaixemay = lst3.dvdinhmuc;
            tenxe = lst3.id + " - " + lst3.ten;
            var lst4 =
                (from a in lst join b in db.congtrinhs on a.madv equals b.id select new {a.madv, b.tencongtrinh}).Single
                    ();
            ct = lst4.madv + " - " + lst4.tencongtrinh;

            var xtra = new r_DsTheoDoi_PT2();
            xtra.DataSource = _tTodatatable.addlst(lst.ToList());
            xtra.ShowPreviewDialog();
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message);
            //}
            SplashScreenManager.CloseForm(false);
        }
    }
}