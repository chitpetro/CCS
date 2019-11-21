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
using GUI.report.pnhap;

namespace GUI.Report.PhuongTien
{
    public partial class f_bcpnhapkho : Form
    {
        private readonly KetNoiDBDataContext db = new KetNoiDBDataContext();
        private bool doubleclick1;
        private bool doubleclick2;
        t_todatatable _tTodatatable = new t_todatatable();

        public f_bcpnhapkho()
        {
            InitializeComponent();

            rTime.SetTime(thoigian);
        }


        private void f_chitietnhapkho_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);

            changeFont.Translate(this);

            tungay.ReadOnly = true;
            denngay.ReadOnly = true;

            danhmuc.Text = "Công Trình";

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
            if (danhmuc.Text == "Công Trình")
            {
                try
                {
                    var lst = from a in db.congtrinhs
                        where a.ht != true
                        select new {a.id, name = a.tencongtrinh, key = a.id + danhmuc.Text + Biencucbo.idnv};
                    nguon.DataSource = _tTodatatable.addlst(lst.ToList());

                    for (var i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        for (var j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView1.GetRowCellValue(i, "key").ToString() ==
                                gridView2.GetRowCellValue(j, "key").ToString())
                            {
                                gridView1.DeleteRow(i);
                                break;
                            }
                        }
                    }
                    ;
                }
                catch

                {
                }
            }
            else if (danhmuc.Text == "Đối Tượng")
            {
                try
                {
                    var lst = from a in db.doituongs
                        select new {a.id, name = a.ten, key = a.id + danhmuc.Text + Biencucbo.idnv};
                    nguon.DataSource = _tTodatatable.addlst(lst.ToList());

                    for (var i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        for (var j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView1.GetRowCellValue(i, "key").ToString() ==
                                gridView2.GetRowCellValue(j, "key").ToString())
                            {
                                gridView1.DeleteRow(i);
                                break;
                            }
                        }
                    }
                    ;
                }
                catch

                {
                }
            }

            else if (danhmuc.Text == "Vật Tư")
            {
                try
                {
                    var lst = from a in db.sanphams
                        select new {a.id, name = a.tensp, key = a.id + danhmuc.Text + Biencucbo.idnv};
                    nguon.DataSource = _tTodatatable.addlst(lst.ToList());

                    for (var i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        for (var j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView1.GetRowCellValue(i, "key").ToString() ==
                                gridView2.GetRowCellValue(j, "key").ToString())
                            {
                                gridView1.DeleteRow(i);
                                break;
                            }
                        }
                    }
                    ;
                }
                catch

                {
                }
            }
            else if (danhmuc.Text == "Hợp Đồng")
            {
                try
                {
                    var lst = from a in db.pnhaps
                        select new {id = a.sohd, name = a.sohd, key = a.id + danhmuc.Text + Biencucbo.idnv};
                    nguon.DataSource = _tTodatatable.addlst(lst.ToList());

                    for (var i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        for (var j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView1.GetRowCellValue(i, "key").ToString() ==
                                gridView2.GetRowCellValue(j, "key").ToString())
                            {
                                gridView1.DeleteRow(i);
                                break;
                            }
                        }
                    }
                    ;
                }
                catch

                {
                }
            }
            else if (danhmuc.Text == "Khu Vực")
            {
                try
                {
                    var lst = from a in db.khuvucs
                        select new {a.id, name = a.khuvuc1, key = a.id + danhmuc.Text + Biencucbo.idnv};
                    nguon.DataSource = _tTodatatable.addlst(lst.ToList());

                    for (var i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        for (var j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView1.GetRowCellValue(i, "key").ToString() ==
                                gridView2.GetRowCellValue(j, "key").ToString())
                            {
                                gridView1.DeleteRow(i);
                                break;
                            }
                        }
                    }
                    ;
                }
                catch

                {
                }
            }
            else if (danhmuc.Text == "Loại Công Trình")
            {
                try
                {
                    var lst = from a in db.loaicts
                        select new {a.id, name = a.loaict1, key = a.id + danhmuc.Text + Biencucbo.idnv};
                    nguon.DataSource = _tTodatatable.addlst(lst.ToList());

                    for (var i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        for (var j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView1.GetRowCellValue(i, "key").ToString() ==
                                gridView2.GetRowCellValue(j, "key").ToString())
                            {
                                gridView1.DeleteRow(i);
                                break;
                            }
                        }
                    }
                    ;
                }
                catch

                {
                }
            }
            else if (danhmuc.Text == "Nguồn Cấp")
            {
                try
                {
                    var lst = from a in db.nguoncaps
                        select new {a.id, name = a.tennguoncap, key = a.id + danhmuc.Text + Biencucbo.idnv};
                    nguon.DataSource = _tTodatatable.addlst(lst.ToList());

                    for (var i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        for (var j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView1.GetRowCellValue(i, "key").ToString() ==
                                gridView2.GetRowCellValue(j, "key").ToString())
                            {
                                gridView1.DeleteRow(i);
                                break;
                            }
                        }
                    }
                    ;
                }
                catch

                {
                }
            }
            else if (danhmuc.Text == "Đơn Vị")
            {
                try
                {
                    var list = from a in db.donvis
                        select new
                        {
                            a.id,
                            name = a.tendonvi,
                            key = a.id + danhmuc.Text + Biencucbo.idnv,
                            MaTim = LayMaTim(a)
                        };
                    var lst2 = list.ToList().Where(t => t.MaTim.Contains("." + Biencucbo.donvi + "."));

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
            else if (danhmuc.Text == "User")
            {
                try
                {
                    var list = from a in db.accounts
                        join d in db.donvis on a.madonvi equals d.id
                        select new
                        {
                            a.id,
                            a.name,
                            key = a.id + danhmuc.Text + Biencucbo.idnv,
                            MaTim = LayMaTim(d)
                        };
                    var lst2 = list.ToList().Where(t => t.MaTim.Contains("." + Biencucbo.donvi + "."));

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

            //moi
            else if (danhmuc.Text == "Link Hồ Sơ")
            {
                try
                {
                    var lst = from a in db.vanbandens
                        select new {a.id, name = a.noidung, key = a.id + danhmuc.Text + Biencucbo.idnv};
                    nguon.DataSource = _tTodatatable.addlst(lst.ToList());

                    for (var i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        for (var j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView1.GetRowCellValue(i, "key").ToString() ==
                                gridView2.GetRowCellValue(j, "key").ToString())
                            {
                                gridView1.DeleteRow(i);
                                break;
                            }
                        }
                    }
                    ;
                }
                catch
                {
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
                if (danhmuc.Text == "Đơn Vị")
                {
                    var list = from a in db.donvis
                        select new
                        {
                            a.id,
                            name = a.tendonvi,
                            key = a.id + danhmuc.Text + Biencucbo.idnv,
                            MaTim = LayMaTim(a)
                        };
                    var lst2 = list.ToList().Where(t => t.MaTim.Contains("." + Biencucbo.donvi + "."));

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
                else if (danhmuc.Text == "User")
                {
                    var list = from a in db.accounts
                        join d in db.donvis on a.madonvi equals d.id
                        select new
                        {
                            a.id,
                            a.name,
                            key = a.id + danhmuc.Text + Biencucbo.idnv,
                            MaTim = LayMaTim(d)
                        };
                    var lst2 = list.ToList().Where(t => t.MaTim.Contains("." + Biencucbo.donvi + "."));

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                simpleButton1_Click(sender, e);
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
                simpleButton3_Click(sender, e);
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
            if (danhmuc.Text == "Công Trình")
            {
                try
                {
                    var lst = from a in db.congtrinhs
                        where a.ht != true
                        select new {a.id, name = a.tencongtrinh, key = a.id + danhmuc.Text + Biencucbo.idnv};
                    nguon.DataSource = _tTodatatable.addlst(lst.ToList());

                    for (var i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        for (var j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView1.GetRowCellValue(i, "key").ToString() ==
                                gridView2.GetRowCellValue(j, "key").ToString())
                            {
                                gridView1.DeleteRow(i);
                                break;
                            }
                        }
                    }
                    ;
                }
                catch

                {
                }
            }
            else if (danhmuc.Text == "Đơn vị")
            {
                try
                {
                    var list = from a in db.donvis
                        select new
                        {
                            a.id,
                            name = a.tendonvi,
                            key = a.id + danhmuc.Text + Biencucbo.idnv,
                            MaTim = LayMaTim(a)
                        };
                    var lst2 = list.ToList().Where(t => t.MaTim.Contains("." + Biencucbo.donvi + "."));

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
            else if (danhmuc.Text == "Đối Tượng")
            {
                try
                {
                    var lst = from a in db.doituongs
                        select new {a.id, name = a.ten, key = a.id + danhmuc.Text + Biencucbo.idnv};
                    nguon.DataSource = _tTodatatable.addlst(lst.ToList());

                    for (var i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        for (var j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView1.GetRowCellValue(i, "key").ToString() ==
                                gridView2.GetRowCellValue(j, "key").ToString())
                            {
                                gridView1.DeleteRow(i);
                                break;
                            }
                        }
                    }
                    ;
                }
                catch

                {
                }
            }
            else if (danhmuc.Text == "Vật Tư")
            {
                try
                {
                    var lst = from a in db.sanphams
                        select new {a.id, name = a.tensp, key = a.id + danhmuc.Text + Biencucbo.idnv};
                    nguon.DataSource = _tTodatatable.addlst(lst.ToList());

                    for (var i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        for (var j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView1.GetRowCellValue(i, "key").ToString() ==
                                gridView2.GetRowCellValue(j, "key").ToString())
                            {
                                gridView1.DeleteRow(i);
                                break;
                            }
                        }
                    }
                    ;
                }
                catch

                {
                }
            }
            else if (danhmuc.Text == "Hợp Đồng")
            {
                try
                {
                    var lst = from a in db.pnhaps
                        select new {id = a.sohd, name = a.sohd, key = a.id + danhmuc.Text + Biencucbo.idnv};
                    nguon.DataSource = _tTodatatable.addlst(lst.ToList());

                    for (var i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        for (var j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView1.GetRowCellValue(i, "key").ToString() ==
                                gridView2.GetRowCellValue(j, "key").ToString())
                            {
                                gridView1.DeleteRow(i);
                                break;
                            }
                        }
                    }
                    ;
                }
                catch

                {
                }
            }
            else if (danhmuc.Text == "Nguồn Cấp")
            {
                try
                {
                    var lst = from a in db.nguoncaps
                        select new {a.id, name = a.tennguoncap, key = a.id + danhmuc.Text + Biencucbo.idnv};
                    nguon.DataSource = _tTodatatable.addlst(lst.ToList());

                    for (var i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        for (var j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView1.GetRowCellValue(i, "key").ToString() ==
                                gridView2.GetRowCellValue(j, "key").ToString())
                            {
                                gridView1.DeleteRow(i);
                                break;
                            }
                        }
                    }
                    ;
                }
                catch

                {
                }
            }
            else if (danhmuc.Text == "User")
            {
                try
                {
                    var list = from a in db.accounts
                        join d in db.donvis on a.madonvi equals d.id
                        select new
                        {
                            a.id,
                            a.name,
                            key = a.id + danhmuc.Text + Biencucbo.idnv,
                            MaTim = LayMaTim(d)
                        };
                    var lst2 = list.ToList().Where(t => t.MaTim.Contains("." + Biencucbo.donvi + "."));

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
            else if (danhmuc.Text == "Khu Vực")
            {
                try
                {
                    var lst = from a in db.khuvucs
                        select new {a.id, name = a.khuvuc1, key = a.id + danhmuc.Text + Biencucbo.idnv};
                    nguon.DataSource = _tTodatatable.addlst(lst.ToList());

                    for (var i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        for (var j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView1.GetRowCellValue(i, "key").ToString() ==
                                gridView2.GetRowCellValue(j, "key").ToString())
                            {
                                gridView1.DeleteRow(i);
                                break;
                            }
                        }
                    }
                    ;
                }
                catch

                {
                }
            }
            else if (danhmuc.Text == "Loại Công Trình")
            {
                try
                {
                    var lst = from a in db.loaicts
                        select new {a.id, name = a.loaict1, key = a.id + danhmuc.Text + Biencucbo.idnv};
                    nguon.DataSource = _tTodatatable.addlst(lst.ToList());

                    for (var i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        for (var j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView1.GetRowCellValue(i, "key").ToString() ==
                                gridView2.GetRowCellValue(j, "key").ToString())
                            {
                                gridView1.DeleteRow(i);
                                break;
                            }
                        }
                    }
                    ;
                }
                catch

                {
                }
            }

            //moi
            else if (danhmuc.Text == "Link Hồ Sơ")
            {
                try
                {
                    var lst = from a in db.vanbandens
                        select new {a.id, name = a.noidung, key = a.id + danhmuc.Text + Biencucbo.idnv};
                    nguon.DataSource = _tTodatatable.addlst(lst.ToList());

                    for (var i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        for (var j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView1.GetRowCellValue(i, "key").ToString() ==
                                gridView2.GetRowCellValue(j, "key").ToString())
                            {
                                gridView1.DeleteRow(i);
                                break;
                            }
                        }
                    }
                    ;
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
                if (danhmuc.Text == "Đơn vị")
                {
                    var list = from a in db.donvis
                        select new
                        {
                            a.id,
                            name = a.tendonvi,
                            key = a.id + danhmuc.Text + Biencucbo.idnv,
                            MaTim = LayMaTim(a)
                        };
                    var lst2 = list.ToList().Where(t => t.MaTim.Contains("." + Biencucbo.donvi + "."));

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
                else if (danhmuc.Text == "User")
                {
                    var list = from a in db.accounts
                        join d in db.donvis on a.madonvi equals d.id
                        select new
                        {
                            a.id,
                            a.name,
                            key = a.id + danhmuc.Text + Biencucbo.idnv,
                            MaTim = LayMaTim(d)
                        };
                    var lst2 = list.ToList().Where(t => t.MaTim.Contains("." + Biencucbo.donvi + "."));

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
            if (danhmuc.Text == "Công Trình")
            {
                try
                {
                    var lst = from a in db.congtrinhs
                        where a.ht != true
                        select new {a.id, name = a.tencongtrinh, key = a.id + danhmuc.Text + Biencucbo.idnv};
                    nguon.DataSource = _tTodatatable.addlst(lst.ToList());

                    for (var i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        for (var j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView1.GetRowCellValue(i, "key").ToString() ==
                                gridView2.GetRowCellValue(j, "key").ToString())
                            {
                                gridView1.DeleteRow(i);
                                break;
                            }
                        }
                    }
                    ;
                }
                catch

                {
                }
            }
            else if (danhmuc.Text == "Đơn Vị")
            {
                try
                {
                    var list = from a in db.donvis
                        select new
                        {
                            a.id,
                            name = a.tendonvi,
                            key = a.id + danhmuc.Text + Biencucbo.idnv,
                            MaTim = LayMaTim(a)
                        };
                    var lst2 = list.ToList().Where(t => t.MaTim.Contains("." + Biencucbo.donvi + "."));

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
            else if (danhmuc.Text == "User")
            {
                try
                {
                    var list = from a in db.accounts
                        join d in db.donvis on a.madonvi equals d.id
                        select new
                        {
                            a.id,
                            a.name,
                            key = a.id + danhmuc.Text + Biencucbo.idnv,
                            MaTim = LayMaTim(d)
                        };
                    var lst2 = list.ToList().Where(t => t.MaTim.Contains("." + Biencucbo.donvi + "."));

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
            else if (danhmuc.Text == "Đối Tượng")
            {
                try
                {
                    var lst = from a in db.doituongs
                        select new {a.id, name = a.ten, key = a.id + danhmuc.Text + Biencucbo.idnv};
                    nguon.DataSource = _tTodatatable.addlst(lst.ToList());

                    for (var i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        for (var j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView1.GetRowCellValue(i, "key").ToString() ==
                                gridView2.GetRowCellValue(j, "key").ToString())
                            {
                                gridView1.DeleteRow(i);
                                break;
                            }
                        }
                    }
                    ;
                }
                catch

                {
                }
            }
            else if (danhmuc.Text == "Vật Tư")
            {
                try
                {
                    var lst = from a in db.sanphams
                        select new {a.id, name = a.tensp, key = a.id + danhmuc.Text + Biencucbo.idnv};
                    nguon.DataSource = _tTodatatable.addlst(lst.ToList());

                    for (var i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        for (var j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView1.GetRowCellValue(i, "key").ToString() ==
                                gridView2.GetRowCellValue(j, "key").ToString())
                            {
                                gridView1.DeleteRow(i);
                                break;
                            }
                        }
                    }
                    ;
                }
                catch

                {
                }
            }
            else if (danhmuc.Text == "Hợp Đồng")
            {
                try
                {
                    var lst = from a in db.pnhaps
                        select new {id = a.sohd, name = a.sohd, key = a.id + danhmuc.Text + Biencucbo.idnv};
                    nguon.DataSource = _tTodatatable.addlst(lst.ToList());

                    for (var i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        for (var j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView1.GetRowCellValue(i, "key").ToString() ==
                                gridView2.GetRowCellValue(j, "key").ToString())
                            {
                                gridView1.DeleteRow(i);
                                break;
                            }
                        }
                    }
                    ;
                }
                catch

                {
                }
            }
            else if (danhmuc.Text == "Nguồn Cấp")
            {
                try
                {
                    var lst = from a in db.nguoncaps
                        select new {a.id, name = a.tennguoncap, key = a.id + danhmuc.Text + Biencucbo.idnv};
                    nguon.DataSource = _tTodatatable.addlst(lst.ToList());

                    for (var i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        for (var j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView1.GetRowCellValue(i, "key").ToString() ==
                                gridView2.GetRowCellValue(j, "key").ToString())
                            {
                                gridView1.DeleteRow(i);
                                break;
                            }
                        }
                    }
                    ;
                }
                catch

                {
                }
            }
            if (danhmuc.Text == "Khu Vực")
            {
                try
                {
                    var lst = from a in db.khuvucs
                        select new {a.id, name = a.khuvuc1, key = a.id + danhmuc.Text + Biencucbo.idnv};
                    nguon.DataSource = _tTodatatable.addlst(lst.ToList());

                    for (var i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        for (var j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView1.GetRowCellValue(i, "key").ToString() ==
                                gridView2.GetRowCellValue(j, "key").ToString())
                            {
                                gridView1.DeleteRow(i);
                                break;
                            }
                        }
                    }
                    ;
                }
                catch

                {
                }
            }
            if (danhmuc.Text == "Loại Công Trình")
            {
                try
                {
                    var lst = from a in db.loaicts
                        select new {a.id, name = a.loaict1, key = a.id + danhmuc.Text + Biencucbo.idnv};
                    nguon.DataSource = _tTodatatable.addlst(lst.ToList());

                    for (var i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        for (var j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView1.GetRowCellValue(i, "key").ToString() ==
                                gridView2.GetRowCellValue(j, "key").ToString())
                            {
                                gridView1.DeleteRow(i);
                                break;
                            }
                        }
                    }
                    ;
                }
                catch

                {
                }
            }

            //moi
            if (danhmuc.Text == "Link Hồ Sơ")
            {
                try
                {
                    var lst = from a in db.vanbandens
                        select new {a.id, name = a.noidung, key = a.id + danhmuc.Text + Biencucbo.idnv};
                    nguon.DataSource = _tTodatatable.addlst(lst.ToList());

                    for (var i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        for (var j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView1.GetRowCellValue(i, "key").ToString() ==
                                gridView2.GetRowCellValue(j, "key").ToString())
                            {
                                gridView1.DeleteRow(i);
                                break;
                            }
                        }
                    }
                    ;
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
                Biencucbo.nguoncap = "";
                Biencucbo.doituong = "";
                Biencucbo.khuvuc = "";
                Biencucbo.loaict = "";
                Biencucbo.Congtrinh = "";
                Biencucbo.sp = "";
                //moi
                Biencucbo.linkHS = "";

                var checkct = 0;
                var checknc = 0;
                var checkkv = 0;
                var checklct = 0;
                var checkdt = 0;
                var checku = 0;
                var checkdv = 0;
                var checksp = 0;
                //moi
                var checklinkhs = 0;

                for (var i = 0; i < gridView2.DataRowCount; i++)
                {
                    if (gridView2.GetRowCellValue(i, "loai").ToString() == "Công Trình")
                    {
                        checkct++;
                        Biencucbo.Congtrinh = Biencucbo.Congtrinh + gridView2.GetRowCellValue(i, "id") + "-" +
                                              gridView2.GetRowCellValue(i, "name") + ", ";
                    }
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "Nguồn Cấp")
                    {
                        checknc++;
                        Biencucbo.nguoncap = Biencucbo.nguoncap + gridView2.GetRowCellValue(i, "id") + "-" +
                                             gridView2.GetRowCellValue(i, "name") + ", ";
                    }
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "Khu Vực")
                    {
                        checkkv++;
                        Biencucbo.khuvuc = Biencucbo.khuvuc + gridView2.GetRowCellValue(i, "id") + "-" +
                                           gridView2.GetRowCellValue(i, "name") + ", ";
                    }
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "Loại Công Trình")
                    {
                        checklct++;
                        Biencucbo.loaict = Biencucbo.loaict + gridView2.GetRowCellValue(i, "id") + "-" +
                                           gridView2.GetRowCellValue(i, "name") + ", ";
                    }
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "Đối Tượng")
                    {
                        checkdt++;
                        Biencucbo.iddt = Biencucbo.iddt + gridView2.GetRowCellValue(i, "id") + "-" +
                                         gridView2.GetRowCellValue(i, "name") + ", ";
                    }
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "User")
                    {
                        checku++;
                    }
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "Đơn Vị")
                    {
                        checkdv++;
                    }
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "Vật Tư")
                    {
                        checksp++;
                    }
                    //moi
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "Link Hồ Sơ")
                    {
                        checklinkhs++;
                    }
                }

                if (checknc == 0)
                {
                    Biencucbo.nguoncap = "Tất cả";
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
                if (checksp == 0)
                {
                    Biencucbo.sp = "Tất cả";
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

                var lst1 = from a in db.r_pnhaps
                    join b in db.congtrinhs on a.idct equals b.id
                    where a.idsp != null && a.ngaynhap >= tungay.DateTime && a.ngaynhap <= denngay.DateTime
                    where b.ht != true
                    orderby a.ngaynhap
                    select new
                    {
                        congtrinh =
                            "Công trình:" + b.tencongtrinh + "\n" + "Địa điểm: " + b.diadiem + "\nChỉ huy trưởng: " +
                            b.chihuytruong,
                        a.idct,
                        a.ghichu,
                        a.ngaynhap,
                        a.soluong,
                        a.dongia,
                        a.tiente,
                        a.dvt,
                        a.tygia,
                        a.nguyente,
                        a.thanhtien,
                        a.tensp,
                        a.diengiai,
                        a.idsp,
                        a.idnv,
                        a.idnc,
                        b.khuvuc,
                        b.loaict,
                        a.iddt,
                        a.iddv,
                        a.tennguoncap,
                        a.link
                    };
                var lst2 = lst1;

                // nguồn cấp
                if (checknc != 0)
                {
                    lst2 = from a in lst1
                        join b in db.dk_rps on a.idnc equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "Nguồn Cấp"
                        select a;
                }


                // Khu Vực
                lst1 = lst2;
                if (checkkv != 0)
                {
                    lst1 = from a in lst2
                        join b in db.dk_rps on a.khuvuc equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "Khu Vực"
                        select a;
                }


                //Loại Công Trình
                lst2 = lst1;
                if (checklct != 0)
                {
                    lst2 = from a in lst1
                        join b in db.dk_rps on a.loaict equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "Loại Công Trình"
                        select a;
                }


                //Công Trình
                lst1 = lst2;
                if (checkct != 0)
                {
                    lst1 = from a in lst2
                        join b in db.dk_rps on a.idct equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "Công Trình"
                        select a;
                }


                //Đối Tượng
                lst2 = lst1;
                if (checkdt != 0)
                {
                    lst2 = from a in lst1
                        join b in db.dk_rps on a.iddt equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "Đối Tượng"
                        select a;
                }


                //User
                lst1 = lst2;
                if (checku != 0)
                {
                    lst1 = from a in lst2
                        join b in db.dk_rps on a.idnv equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "User"
                        select a;
                }

                //Đơn Vị
                lst2 = lst1;
                if (checkdv != 0)
                {
                    lst2 = from a in lst1
                        join b in db.dk_rps on a.iddv equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "Đơn Vị"
                        select a;
                }

                //Vật Tư
                lst1 = lst2;
                if (checksp != 0)
                {
                    lst1 = from a in lst2
                        join b in db.dk_rps on a.idsp equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "Vật Tư"
                        select a;
                }

                //moi
                //link hồ sơ
                lst2 = lst1;
                if (checklinkhs != 0)
                {
                    lst2 = from a in lst1
                        join b in db.dk_rps on a.link equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "Link Hồ Sơ"
                        select a;
                }

                //Biencucbo.title = "BẢNG KÊ PHIẾU CHI TIỀN MẶT";
                if (ts.IsOn)
                {
                    var lst =
                        (from a in lst1 select a).GroupBy(t => new {t.idct, t.tensp, t.dvt, t.congtrinh})
                            .Select(y => new
                            {
                                y.Key.idct,
                                y.Key.tensp,
                                y.Key.dvt,
                                y.Key.congtrinh,
                                soluong = y.Sum(c => c.soluong),
                                thanhtien = y.Sum(t => t.thanhtien),
                                dongia = y.Sum(t => t.thanhtien)/y.Sum(c => c.soluong)
                            });

                    var xtra = new r_thpnhap();
                    xtra.DataSource = _tTodatatable.addlst(lst.ToList());
                    xtra.ShowPreviewDialog();
                }
                else
                {
                    var xtra = new r_ctpnhap();
                    xtra.DataSource = _tTodatatable.addlst(lst1.ToList());
                    xtra.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            SplashScreenManager.CloseForm(false);
        }

        private void btnall_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof (SplashScreen2), true, true, false);
            try
            {
                Biencucbo.nguoncap = "";
                Biencucbo.doituong = "";
                Biencucbo.khuvuc = "";
                Biencucbo.loaict = "";
                Biencucbo.Congtrinh = "";
                Biencucbo.sp = "";
                //moi
                Biencucbo.linkHS = "";

                var checkct = 0;
                var checknc = 0;
                var checkkv = 0;
                var checklct = 0;
                var checkdt = 0;
                var checku = 0;
                var checkdv = 0;
                var checksp = 0;
                var checkhd = 0;
                //moi
                var checklinkhs = 0;

                for (var i = 0; i < gridView2.DataRowCount; i++)
                {
                    if (gridView2.GetRowCellValue(i, "loai").ToString() == "Công Trình")
                    {
                        checkct++;
                        Biencucbo.Congtrinh = Biencucbo.Congtrinh + gridView2.GetRowCellValue(i, "id") + "-" +
                                              gridView2.GetRowCellValue(i, "name") + ", ";
                    }
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "Nguồn Cấp")
                    {
                        checknc++;
                        Biencucbo.nguoncap = Biencucbo.nguoncap + gridView2.GetRowCellValue(i, "id") + "-" +
                                             gridView2.GetRowCellValue(i, "name") + ", ";
                    }
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "Khu Vực")
                    {
                        checkkv++;
                        Biencucbo.khuvuc = Biencucbo.khuvuc + gridView2.GetRowCellValue(i, "id") + "-" +
                                           gridView2.GetRowCellValue(i, "name") + ", ";
                    }
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "Loại Công Trình")
                    {
                        checklct++;
                        Biencucbo.loaict = Biencucbo.loaict + gridView2.GetRowCellValue(i, "id") + "-" +
                                           gridView2.GetRowCellValue(i, "name") + ", ";
                    }
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "Đối Tượng")
                    {
                        checkdt++;
                        Biencucbo.iddt = Biencucbo.iddt + gridView2.GetRowCellValue(i, "id") + "-" +
                                         gridView2.GetRowCellValue(i, "name") + ", ";
                    }
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "User")
                    {
                        checku++;
                    }
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "Đơn Vị")
                    {
                        checkdv++;
                    }
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "Vật Tư")
                    {
                        checksp++;
                    }
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "Hợp Đồng")
                    {
                        checkhd++;
                    }
                    //moi
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "Link Hồ Sơ")
                    {
                        checklinkhs++;
                    }
                }

                if (checknc == 0)
                {
                    Biencucbo.nguoncap = "Tất cả";
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
                if (checksp == 0)
                {
                    Biencucbo.sp = "Tất cả";
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

                var lst1 = from a in db.r_pnhaps
                    join b in db.congtrinhs on a.idct equals b.id
                    where a.idsp != null
                    where b.ht != true
                    orderby a.ngaynhap
                    select new
                    {
                        congtrinh =
                            "Công trình:" + b.tencongtrinh + "\n" + "Địa điểm: " + b.diadiem + "\nChỉ huy trưởng: " +
                            b.chihuytruong,
                        a.idct,
                        a.ghichu,
                        a.ngaynhap,
                        soluong = a.soluong == null ? 0 : a.soluong,
                        a.dongia,
                        a.tiente,
                        a.tygia,
                        a.nguyente,
                        thanhtien = a.thanhtien == null ? 0 : a.thanhtien,
                        tensp = a.tensp + " (DVT: " + a.dvt + ")",
                        a.dvt,
                        a.diengiai,
                        a.idsp,
                        a.idnv,
                        a.sohd,
                        a.idnc,
                        b.khuvuc,
                        b.loaict,
                        a.iddt,
                        a.iddv,
                        a.tennguoncap,
                        a.link
                    };
                var lst2 = lst1;

                // nguồn cấp
                if (checknc != 0)
                {
                    lst2 = from a in lst1
                        join b in db.dk_rps on a.idnc equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "Nguồn Cấp"
                        select a;
                }


                // Khu Vực
                lst1 = lst2;
                if (checkkv != 0)
                {
                    lst1 = from a in lst2
                        join b in db.dk_rps on a.khuvuc equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "Khu Vực"
                        select a;
                }


                //Loại Công Trình
                lst2 = lst1;
                if (checklct != 0)
                {
                    lst2 = from a in lst1
                        join b in db.dk_rps on a.loaict equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "Loại Công Trình"
                        select a;
                }


                //Công Trình
                lst1 = lst2;
                if (checkct != 0)
                {
                    lst1 = from a in lst2
                        join b in db.dk_rps on a.idct equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "Công Trình"
                        select new
                        {
                            a.congtrinh,
                            a.idct,
                            a.ghichu,
                            a.ngaynhap,
                            soluong = a.soluong == null ? 0 : a.soluong,
                            a.dongia,
                            a.tiente,
                            a.tygia,
                            a.nguyente,
                            thanhtien = a.thanhtien == null ? 0 : a.thanhtien,
                            a.tensp,
                            a.dvt,
                            a.diengiai,
                            a.idsp,
                            a.idnv,
                            a.sohd,
                            a.idnc,
                            a.khuvuc,
                            a.loaict,
                            a.iddt,
                            a.iddv,
                            a.tennguoncap,
                            a.link
                        };
                }

                //Đối Tượng
                lst2 = lst1;
                if (checkdt != 0)
                {
                    lst2 = from a in lst1
                        join b in db.dk_rps on a.iddt equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "Đối Tượng"
                        select a;
                }


                //User
                lst1 = lst2;
                if (checku != 0)
                {
                    lst1 = from a in lst2
                        join b in db.dk_rps on a.idnv equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "User"
                        select a;
                }

                //Đơn Vị
                lst2 = lst1;
                if (checkdv != 0)
                {
                    lst2 = from a in lst1
                        join b in db.dk_rps on a.iddv equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "Đơn Vị"
                        select a;
                }

                //Vật Tư
                lst1 = lst2;
                if (checksp != 0)
                {
                    lst1 = from a in lst2
                        join b in db.dk_rps on a.idsp equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "Vật Tư"
                        select a;
                }

                lst2 = lst1;
                if (checkhd != 0)
                {
                    lst2 = from a in lst1
                        join b in db.dk_rps on a.sohd equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "Hợp Đồng"
                        select a;
                }

                //moi
                //link hồ sơ
                lst1 = lst2;
                if (checklinkhs != 0)
                {
                    lst1 = from a in lst2
                        join b in db.dk_rps on a.link equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "Link Hồ Sơ"
                        select a;
                }

                //Biencucbo.title = "BẢNG KÊ PHIẾU CHI TIỀN MẶT";
                if (ts.IsOn)
                {
                    var lst =
                        (from a in lst1 select a).GroupBy(t => new {t.idct, t.congtrinh, t.tensp, t.dvt})
                            .Select(y => new
                            {
                                y.Key.idct,
                                y.Key.tensp,
                                y.Key.dvt,
                                y.Key.congtrinh,
                                soluong = y.Sum(c => c.soluong),
                                thanhtien = y.Sum(t => t.thanhtien),
                                dongia =
                                    y.Sum(t => t.thanhtien) == 0 || y.Sum(c => c.soluong) == 0
                                        ? 0
                                        : y.Sum(t => t.thanhtien)/y.Sum(c => c.soluong)
                            }).ToList();
                    var xtra = new r_thpnhap();
                    xtra.DataSource = _tTodatatable.addlst(lst.ToList());
                    xtra.ShowPreviewDialog();
                }
                else
                {
                    var xtra = new r_ctpnhap();
                    xtra.DataSource = _tTodatatable.addlst(lst1.ToList());
                    xtra.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            SplashScreenManager.CloseForm(false);
        }
    }
}