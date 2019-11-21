using System;
using System.Linq;
using System.Windows.Forms;
using BUS;
using ControlLocalizer;
using DAL;
using  BUS;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using Lotus;

namespace GUI.Report.PhuongTien
{
    public partial class f_DsPhuongTien : Form
    {
        private readonly KetNoiDBDataContext db = new KetNoiDBDataContext();
        private bool doubleclick1;
        private bool doubleclick2;
        t_todatatable _tTodatatable = new t_todatatable();
        
        public f_DsPhuongTien()
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
        }


        private void simpleButton5_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof (SplashScreen2), true, true, false);
            try
            {
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
                    if (gridView2.GetRowCellValue(i, "loai").ToString() == "Công trình")
                    {
                        check++;
                        Biencucbo.kho = Biencucbo.kho + gridView2.GetRowCellValue(i, "id") + "-" +
                                        gridView2.GetRowCellValue(i, "name") + ", ";
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


                //var lst2 = from a in db.phuongtiens
                //           join b in db.dk_rps on a.madv equals b.id
                //           where b.user == Biencucbo.idnv && b.loai == "Công trình"
                //           select a;

                var lst2 = from a in db.phuongtiens
                    join b in db.dk_rps on a.madv equals b.id
                    where b.id == a.madv
                    select a;

                var lst = from a in lst2
                    join b in db.doituongs on a.madt equals b.id into k
                    join c in db.congtrinhs on a.madv equals c.id into l
                    where a.ngaycapnhat >= DateTime.Parse(tungay.Text) && a.ngaycapnhat <= DateTime.Parse(denngay.Text)
                    from k1 in k.DefaultIfEmpty()
                    from l1 in l.DefaultIfEmpty()
                    select new
                    {
                        a.id,
                        //ten=a.ten,
                        a.ten,
                        a.nhom,
                        a.so,
                        a.tinhtrang,
                        madt = k1.id,
                        tendt = k1.ten,
                        a.somay,
                        madv = l1.id,
                        tendonvi = l1.tencongtrinh,
                        a.sdt,
                        a.sokhung,
                        a.ghichu,
                        a.ngaycapnhat
                    };
                //Biencucbo.title = "BẢNG KÊ PHIẾU CHI TIỀN MẶT";

                var xtra = new r_DsPhuongTien();
                xtra.DataSource = _tTodatatable.addlst(lst.ToList());
                xtra.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            SplashScreenManager.CloseForm(false);
        }
    }
}