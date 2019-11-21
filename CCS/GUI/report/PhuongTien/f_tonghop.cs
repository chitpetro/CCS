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
    public partial class f_tonghop : Form
    {
        private readonly KetNoiDBDataContext db = new KetNoiDBDataContext();
        private bool doubleclick1;
        private bool doubleclick2;
        t_todatatable _tTodatatable = new t_todatatable();
        public f_tonghop()
        {
            InitializeComponent();
            rTime.SetTime(thoigian);
        }

        private void f_chitietnhapkho_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "DANH SÁCH PHƯƠNG TIỆN");
            changeFont.Translate(this);

            tungay.ReadOnly = true;
            denngay.ReadOnly = true;

            danhmuc.Text = "Công trình";

            rTime.SetTime2(thoigian);

            var lst = from a in db.dk_rps where a.user == Biencucbo.idnv select a;
            db.dk_rps.DeleteAllOnSubmit(lst);
            db.SubmitChanges();
            nhan.DataSource = _tTodatatable.addlst(lst.ToList());
        }

        private void thoigian_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeTime.thoigian_change3(thoigian, tungay, denngay);
        }

        private void danhmuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (danhmuc.Text == "Công trình")
            {
                try
                {
                    var list = from a in db.congtrinhs
                        select new
                        {
                            a.id,
                            name = a.tencongtrinh,
                            key = a.id + danhmuc.Text + Biencucbo.idnv
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
            else if (danhmuc.Text == "Nhóm Phương Tiện")
            {
                try
                {
                    var list = from a in db.nhomphuongtiens
                        select new
                        {
                            a.id,
                            name = a.ten,
                            key = a.id + danhmuc.Text + Biencucbo.idnv
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
            else if (danhmuc.Text == "Phương Tiện")
            {
                try
                {
                    var list = from a in db.phuongtiens
                        select new
                        {
                            a.id,
                            name = a.ten,
                            key = a.id + danhmuc.Text + Biencucbo.idnv
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

                if (danhmuc.Text == "Công trình")
                {
                    var list = from a in db.congtrinhs
                        select new
                        {
                            a.id,
                            name = a.tencongtrinh,
                            key = a.id + danhmuc.Text + Biencucbo.idnv
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
                else if (danhmuc.Text == "Nhóm Phương Tiện")
                {
                    var list = from a in db.nhomphuongtiens
                        select new
                        {
                            a.id,
                            name = a.ten,
                            key = a.id + danhmuc.Text + Biencucbo.idnv
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
                else if (danhmuc.Text == "Phương Tiện")
                {
                    var list = from a in db.phuongtiens
                        select new
                        {
                            a.id,
                            name = a.ten,
                            key = a.id + danhmuc.Text + Biencucbo.idnv
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

                    if (danhmuc.Text == "Công trình")
                    {
                        var list = from a in db.congtrinhs
                            select new
                            {
                                a.id,
                                name = a.tencongtrinh,
                                key = a.id + danhmuc.Text + Biencucbo.idnv
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
                    else if (danhmuc.Text == "Nhóm Phương Tiện")
                    {
                        var list = from a in db.nhomphuongtiens
                            select new
                            {
                                a.id,
                                name = a.ten,
                                key = a.id + danhmuc.Text + Biencucbo.idnv
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
                    else if (danhmuc.Text == "Phương Tiện")
                    {
                        var list = from a in db.phuongtiens
                            select new
                            {
                                a.id,
                                name = a.ten,
                                key = a.id + danhmuc.Text + Biencucbo.idnv
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

                if (danhmuc.Text == "Công trình")
                {
                    try
                    {
                        var list = from a in db.congtrinhs
                            select new
                            {
                                a.id,
                                name = a.tencongtrinh,
                                key = a.id + danhmuc.Text + Biencucbo.idnv
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
                else if (danhmuc.Text == "Nhóm Phương Tiện")
                {
                    try
                    {
                        var list = from a in db.nhomphuongtiens
                            select new
                            {
                                a.id,
                                name = a.ten,
                                key = a.id + danhmuc.Text + Biencucbo.idnv
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
                else if (danhmuc.Text == "Phương Tiện")
                {
                    try
                    {
                        var list = from a in db.phuongtiens
                            select new
                            {
                                a.id,
                                name = a.ten,
                                key = a.id + danhmuc.Text + Biencucbo.idnv
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

            if (danhmuc.Text == "Công trình")
            {
                try
                {
                    var list = from a in db.congtrinhs
                        select new
                        {
                            a.id,
                            name = a.tencongtrinh,
                            key = a.id + danhmuc.Text + Biencucbo.idnv
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
            else if (danhmuc.Text == "Nhóm Phương Tiện")
            {
                try
                {
                    var list = from a in db.nhomphuongtiens
                        select new
                        {
                            a.id,
                            name = a.ten,
                            key = a.id + danhmuc.Text + Biencucbo.idnv
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
            else if (danhmuc.Text == "Phương Tiện")
            {
                try
                {
                    var list = from a in db.phuongtiens
                        select new
                        {
                            a.id,
                            name = a.ten,
                            key = a.id + danhmuc.Text + Biencucbo.idnv
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

                if (danhmuc.Text == "Công trình")
                {
                    var list = from a in db.congtrinhs
                        select new
                        {
                            a.id,
                            name = a.tencongtrinh,
                            key = a.id + danhmuc.Text + Biencucbo.idnv
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
                else if (danhmuc.Text == "Nhóm Phương Tiện")
                {
                    var list = from a in db.nhomphuongtiens
                        select new
                        {
                            a.id,
                            name = a.ten,
                            key = a.id + danhmuc.Text + Biencucbo.idnv
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
                else if (danhmuc.Text == "Phương Tiện")
                {
                    var list = from a in db.phuongtiens
                        select new
                        {
                            a.id,
                            name = a.ten,
                            key = a.id + danhmuc.Text + Biencucbo.idnv
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

            if (danhmuc.Text == "Công trình")
            {
                try
                {
                    var list = from a in db.congtrinhs
                        select new
                        {
                            a.id,
                            name = a.tencongtrinh,
                            key = a.id + danhmuc.Text + Biencucbo.idnv
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
            else if (danhmuc.Text == "Nhóm Phương Tiện")
            {
                try
                {
                    var list = from a in db.nhomphuongtiens
                        select new
                        {
                            a.id,
                            name = a.ten,
                            key = a.id + danhmuc.Text + Biencucbo.idnv
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
            else if (danhmuc.Text == "Phương Tiện")
            {
                try
                {
                    var list = from a in db.phuongtiens
                        select new
                        {
                            a.id,
                            name = a.ten,
                            key = a.id + danhmuc.Text + Biencucbo.idnv
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
            try
            {
                Biencucbo.loai = "";
                Biencucbo.doituong = "";
                Biencucbo.kho = "";
                var check = 0;
                var check1 = 0;
                var check2 = 0;

                int c_nhompt = 0, c_pt = 0;

                for (var i = 0; i < gridView2.DataRowCount; i++)
                {
                    if (gridView2.GetRowCellValue(i, "loai").ToString() == "Công trình")
                    {
                        check++;
                        Biencucbo.kho = Biencucbo.kho + gridView2.GetRowCellValue(i, "id") + "-" +
                                        gridView2.GetRowCellValue(i, "name") + ", ";
                    }
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "Nhóm Phương Tiện")
                    {
                        c_nhompt++;
                    }
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "Phương Tiện")
                    {
                        c_pt++;
                    }
                }

                if (check == 0)
                {
                    MsgBox.ShowWarningDialog("Cần phải chọn 1 trường dữ liệu bắt buộc: Công trình");
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
                    if (thoigian.Text == "Tùy ý")
                    {
                        Biencucbo.time = "Từ ngày: " + tungay.Text + " Đến ngày: " + denngay.Text;
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

                //var lst = from a in db.theodoi_phuongtiens
                //          join b in db.doituongs on a.iddt equals b.id into k
                //          join c in db.congtrinhs on a.madv equals c.id into l
                //          join d in db.phuongtiens on a.mapt equals d.id into m
                //          join e2 in db.congtrinhs on a.madv equals e2.id into n
                //          join f2 in db.nhanviens on a.iddt equals f2.id into o
                //          where a.thoigian >= tungay.DateTime && a.thoigian <= denngay.DateTime
                //          from k1 in k.DefaultIfEmpty()
                //          from l1 in l.DefaultIfEmpty()
                //          from m1 in m.DefaultIfEmpty()
                //          from n1 in n.DefaultIfEmpty()
                //          from o1 in o.DefaultIfEmpty()
                //          select new
                //          {
                //              id = a.mapt,
                //              //ten=a.ten,
                //              a.mapt,
                //              m1.ten,
                //              a.thoigian,
                //              a.sogiohd,
                //              a.socahd,
                //              a.sochuyen,
                //              a.songay,
                //              a.tondk,
                //              a.captk,
                //              a.chuyencho,
                //              a.tonck,
                //              a.tieuhaothuctetk,
                //              a.tieuhaodv,
                //              a.chenhlech,
                //              m1.dinhmuc,
                //              m1.dvdinhmuc,
                //              m1.madv,
                //              iddv = m1.madv + "-" + n1.tencongtrinh,
                //              m1.madt,
                //              a.iddt,
                //              //tenlaixe = a.iddt + "-" + o1.ten
                //              tenlaixe = o1.ten
                //          };

                //var lst = from a in db.theodoi_phuongtiens
                //          select a;

                var lst = from a in db.theodoi_phuongtiens
                    join b in db.phuongtiens on a.mapt equals b.id
                    select new
                    {
                        a.mapt,
                        //tenphuongtien = laytenpt(a.mapt),
                        b.ten, //ten pt
                        id_nhompt = b.nhom,
                        nhompt = laynhompt(a.mapt),
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
                        b.dinhmuc,
                        b.dvdinhmuc,
                        a.madv,
                        //iddv = a.madv + "-" + laytenct(a.madv),
                        iddv = laytenct(a.madv),
                        a.iddt,
                        tenlaixe = laytenlaixe(a.iddt)
                    };


                //cong trinh
                var lst2 = lst;
                if (check != 0)
                {
                    lst2 = from a in lst
                        join b in db.dk_rps on a.madv equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "Công trình"
                        select a;
                }

                ////nhom pt
                //lst = lst2;
                //if (c_nhompt != 0)
                //{
                //    lst = from a in lst2
                //          join b in db.dk_rps on a.id_nhompt equals b.id
                //          where b.user == Biencucbo.idnv && b.loai == "Nhóm Phương Tiện"
                //          select a;
                //}


                ////pt
                //lst2 = lst;
                //if (c_pt != 0)
                //{
                //    lst2 = from a in lst
                //           join b in db.dk_rps on a.mapt equals b.id
                //           where b.user == Biencucbo.idnv && b.loai == "Phương Tiện"
                //           select a;
                //}

                //nhom pt
                lst = lst2;

                if (c_nhompt != 0 && c_pt == 0) //nhom
                {
                    lst = from a in lst2
                        join b in db.dk_rps on a.id_nhompt equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "Nhóm Phương Tiện"
                        select a;
                }
                else if (c_nhompt == 0 && c_pt != 0) //pt
                {
                    lst = from a in lst2
                        join b in db.dk_rps on a.mapt equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "Phương Tiện"
                        select a;
                }
                else if (c_nhompt != 0 && c_pt == 0) //pt
                {
                    lst = from a in lst2
                        join b in db.dk_rps on a.id_nhompt equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "Nhóm Phương Tiện"
                        select a;
                }
                else if (c_nhompt != 0 && c_pt != 0) //nhom & pt
                {
                    var lst3a = from a in lst2
                        join b in db.dk_rps on a.id_nhompt equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "Nhóm Phương Tiện"
                        select a;

                    var lst3b = from a in lst2
                        join b in db.dk_rps on a.mapt equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "Phương Tiện"
                        select a;

                    lst = lst3a.Concat(lst3b);
                }

                var xtra = new r_DsTheoDoi_PT_CT();
                xtra.DataSource = _tTodatatable.addlst(lst.ToList());
                xtra.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            SplashScreenManager.CloseForm(false);
        }

        public string laytenpt(string f)
        {
            var b = "";
            try
            {
                var lst = (from a in db.phuongtiens select a).Single(t => t.id == f);
                b = lst.ten;
            }
            catch
            {
            }
            return b;
        }

        public string laynhompt(string f)
        {
            var b = "";
            try
            {
                var lst = (from a in db.phuongtiens select a).Single(t => t.id == f);
                b = lst.ten; //ten pt

                var lst2 = (from a in db.nhomphuongtiens select a).Single(t => t.id == b);
                b = lst2.ten; //ten nhom
            }
            catch
            {
            }
            return b;
        }

        public string laytenct(string f)
        {
            var b = "";
            try
            {
                var lst = (from a in db.congtrinhs select a).Single(t => t.id == f);
                b = lst.id + "-" + lst.tencongtrinh; //ten ct  
            }
            catch
            {
            }
            return b;
        }

        public string laytenlaixe(string f)
        {
            var b = "";
            try
            {
                var lst = (from a in db.nhanviens select a).Single(t => t.id == f);
                b = lst.ten; //ten lai xe
            }
            catch
            {
            }
            return b;
        }
    }
}