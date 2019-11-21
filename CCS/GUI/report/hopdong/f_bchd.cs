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
using GUI.report;
using System.Data;
using System.Collections.Generic;
using System.Reflection;

namespace GUI.Report.PhuongTien
{
    public partial class f_bchd : Form
    {
        private readonly KetNoiDBDataContext db = new KetNoiDBDataContext();
        private bool doubleclick1;
        private bool doubleclick2;
        public string sh = "";
        public string sh2 = "";

        public string sh3 = "";
        public string sh4 = "";
        public double tongtt;
        public double tongtt2;


        public f_bchd()
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
            nhan.DataSource = _todatatable.addlst(lst.ToList());
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
            Biencucbo.ngay = "Từ ngày: " + tungay.Text + " Đến ngày: " + denngay.Text;
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
                    nguon.DataSource = _todatatable.addlst(lst.ToList());

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
                    nguon.DataSource = _todatatable.addlst(lst.ToList());

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
                    nguon.DataSource = _todatatable.addlst(lst.ToList());

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
                    nguon.DataSource = _todatatable.addlst(lst.ToList());

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
                    nguon.DataSource = _todatatable.addlst(lst.ToList());

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
                    nguon.DataSource = _todatatable.addlst(lst2.ToList());
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
                    nguon.DataSource = _todatatable.addlst(lst2.ToList());
                }
                catch (Exception ex)

                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
            else if (danhmuc.Text == "Số Hợp Đồng")
            {
                try
                {
                    var lst1 = from a in db.hopdong_tps
                        select new {id = a.sohd , name = a.sohd, key = a.sohd.Substring(0,300) + danhmuc.Text + Biencucbo.idnv};
                    var lst = (from a in lst1 select a).GroupBy(t => new {t.id, t.name, t.key}).Select(c=>c.Key);

                    nguon.DataSource = _todatatable.addlst(lst.ToList());

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
                    //var lst = (from a in db.filevbdens select new { id = a.id, name = a.idvbden, key = a.id + danhmuc.Text + Biencucbo.idnv });
                    var lst = from a in db.vanbandens
                        select new {a.id, name = a.noidung, key = a.id + danhmuc.Text + Biencucbo.idnv};
                    nguon.DataSource = _todatatable.addlst(lst.ToList());

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

            else if (danhmuc.Text == "Hồ Sơ Gốc")
            {
                try
                {
                    //var lst = (from a in db.filevbdens select new { id = a.id, name = a.idvbden, key = a.id + danhmuc.Text + Biencucbo.idnv });
                    var lst = from a in db.vanbandens
                              select new { a.id, name = a.noidung, key = a.id + danhmuc.Text + Biencucbo.idnv };
                    nguon.DataSource = _todatatable.addlst(lst.ToList());

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
                nhan.DataSource = _todatatable.addlst(lst.ToList());
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
                    nguon.DataSource = _todatatable.addlst(lst2.ToList());
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
                    nguon.DataSource = _todatatable.addlst(lst2.ToList());
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
                nhan.DataSource = _todatatable.addlst(lst2.ToList());
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
                    nguon.DataSource = _todatatable.addlst(lst.ToList());

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
                    nguon.DataSource = _todatatable.addlst(lst2.ToList());
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
                    nguon.DataSource = _todatatable.addlst(lst.ToList());

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
            else if (danhmuc.Text == "Số Hợp Đồng")
            {
                try
                {
                    var lst1 = from a in db.hopdong_tps
                               select new { id = a.sohd, name = a.sohd, key = a.sohd.Substring(0,300) + danhmuc.Text + Biencucbo.idnv };
                    var lst = (from a in lst1 select a).GroupBy(t => new { t.id, t.name, t.key }).Select(c => c.Key);
                    nguon.DataSource = _todatatable.addlst(lst.ToList());

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
                    nguon.DataSource = _todatatable.addlst(lst.ToList());

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
                    nguon.DataSource = _todatatable.addlst(lst.ToList());

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
                    nguon.DataSource = _todatatable.addlst(lst2.ToList());
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
                    nguon.DataSource = _todatatable.addlst(lst.ToList());

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
                    nguon.DataSource = _todatatable.addlst(lst.ToList());

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
                    nguon.DataSource = _todatatable.addlst(lst.ToList());

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

            else if (danhmuc.Text == "Hồ Sơ Gốc")
            {
                try
                {
                    var lst = from a in db.vanbandens
                              select new { a.id, name = a.noidung, key = a.id + danhmuc.Text + Biencucbo.idnv };
                    nguon.DataSource = _todatatable.addlst(lst.ToList());

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
                    nhan.DataSource = _todatatable.addlst(lst.ToList());
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
                    nguon.DataSource = _todatatable.addlst(lst2.ToList());
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
                    nguon.DataSource = _todatatable.addlst(lst2.ToList());
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
                nhan.DataSource = _todatatable.addlst(lst.ToList());
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
                    nguon.DataSource = _todatatable.addlst(lst.ToList());

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
            if (danhmuc.Text == "Số Hợp Đồng")
            {
                try
                {
                    var lst1 = from a in db.hopdong_tps
                               select new { id = a.sohd, name = a.sohd, key = a.sohd.Substring(0,300) + danhmuc.Text + Biencucbo.idnv };
                    var lst = (from a in lst1 select a).GroupBy(t => new { t.id, t.name, t.key }).Select(c => c.Key);
                    nguon.DataSource = _todatatable.addlst(lst.ToList());

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
                    nguon.DataSource = _todatatable.addlst(lst2.ToList());
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
                    nguon.DataSource = _todatatable.addlst(lst2.ToList());
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
                    nguon.DataSource = _todatatable.addlst(lst.ToList());

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
                    nguon.DataSource = _todatatable.addlst(lst.ToList());

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
                    nguon.DataSource = _todatatable.addlst(lst.ToList());

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
                    nguon.DataSource = _todatatable.addlst(lst.ToList());

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
                    nguon.DataSource = _todatatable.addlst(lst.ToList());

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
                    nguon.DataSource = _todatatable.addlst(lst.ToList());

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

            if (danhmuc.Text == "Hồ Sơ Gốc")
            {
                try
                {
                    var lst = from a in db.vanbandens
                              select new { a.id, name = a.noidung, key = a.id + danhmuc.Text + Biencucbo.idnv };
                    nguon.DataSource = _todatatable.addlst(lst.ToList());

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
                Biencucbo.loaihd = "";
                Biencucbo.doituong = "";
                Biencucbo.khuvuc = "";
                Biencucbo.loaict = "";
                Biencucbo.Congtrinh = "";
                Biencucbo.sohd = "";
                //moi
                Biencucbo.linkHS = "";
                var checkct = 0;
                var checklhd = 0;
                var checkkv = 0;
                var checklct = 0;
                var checkdt = 0;
                var checku = 0;
                var checkdv = 0;
                var checksohd = 0;
                //moi
                var checklinkhs = 0;
                var checklinkgoc = 0;

                for (var i = 0; i < gridView2.DataRowCount; i++)
                {
                    if (gridView2.GetRowCellValue(i, "loai").ToString() == "Công Trình")
                    {
                        checkct++;
                        Biencucbo.Congtrinh = Biencucbo.Congtrinh + gridView2.GetRowCellValue(i, "id") + "-" +
                                              gridView2.GetRowCellValue(i, "name") + ", ";
                    }
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "Loại Hợp Đồng")
                    {
                        checklhd++;
                        Biencucbo.loaihd = Biencucbo.loaihd + gridView2.GetRowCellValue(i, "id") + "-" +
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
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "Số Hợp Đồng")
                    {
                        checksohd++;
                    }
                    //moi
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "Link Hồ Sơ")
                    {
                        checklinkhs++;
                    }
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "Hồ Sơ Gốc")
                    {
                        checklinkgoc++;
                    }
                }

                if (checklhd == 0)
                {
                    Biencucbo.loaihd = "Tất cả";
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
                if (checksohd == 0)
                {
                    Biencucbo.sohd = "Tất cả";
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

                var lst = (from a in db.r_hopdongs
                    join d in db.congtrinhs on a.idct equals d.id
                    where a.loai == "Hợp Đồng"
                    where d.ht != true
                    select new
                    {
                        a.id,
                        ttcongtrinh =
                            "Công trình:" + d.tencongtrinh + "\n" + "Địa điểm: " + d.diadiem + "\nChỉ huy trưởng: " +
                            d.chihuytruong,
                        d.khuvuc,
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
                    }).Concat(from a in db.r_hopdongs
                        join d in db.congtrinhs on a.idct equals d.id
                        where a.loai == "Phụ Lục"
                        where d.ht != true
                        select new
                        {
                            a.id,
                            ttcongtrinh =
                                "Công trình:" + d.tencongtrinh + "\n" + "Địa điểm: " + d.diadiem + "\nChỉ huy trưởng: " +
                                d.chihuytruong,
                            d.khuvuc,
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
                        }).Concat(from a in db.r_hopdongs
                            join d in db.congtrinhs on a.idct equals d.id
                            where a.loai == null
                            where d.ht != true
                            select new
                            {
                                a.id,
                                ttcongtrinh =
                                    "Công trình:" + d.tencongtrinh + "\n" + "Địa điểm: " + d.diadiem +
                                    "\nChỉ huy trưởng: " + d.chihuytruong,
                                d.khuvuc,
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


                var lst2 = (from a in db.hopdong_tps
                    join b in db.thanhtoan_tps on a.id equals b.idhd_tp into k
                    from tt in k.DefaultIfEmpty()
                    orderby tt.idhd_tp ascending
                    orderby tt.lan ascending
                    where tt.ngayxuly >= tungay.DateTime && tt.ngayxuly <= denngay.DateTime
                    select new
                    {
                        a.id,
                        tt.linkgoc,
                        tt.link,
                        giatritt = (tt.giatritt == null ? 0 : tt.giatritt) + (tt.cantru == null ? 0 : tt.cantru),
                        giatriqt = tt.giatriqt == null ? 0 : tt.giatriqt,
                        tt.ngaytt,
                        tt.ghichu,
                        tt.diengiai,
                        tt.lan
                    }).ToList();
                if (tgsngay.IsOn)
                {
                    lst2 = (from a in db.hopdong_tps
                        join b in db.thanhtoan_tps on a.id equals b.idhd_tp into k
                        from tt in k.DefaultIfEmpty()
                        orderby tt.idhd_tp ascending
                        orderby tt.lan ascending
                        where tt.ngaytt >= tungay.DateTime && tt.ngaytt <= denngay.DateTime
                        select new
                        {
                            a.id,
                            tt.linkgoc,
                            tt.link,
                            giatritt = (tt.giatritt == null ? 0 : tt.giatritt) + (tt.cantru == null ? 0 : tt.cantru),
                            giatriqt = tt.giatriqt == null ? 0 : tt.giatriqt,
                            tt.ngaytt,
                            tt.ghichu,
                            tt.diengiai,
                            tt.lan
                        }).ToList();
                }
                var lst3 = lst2.GroupBy(t => new {t.id}).Select(y =>
                    new
                    {
                        y.Key.id,
                        tongtt = y.Sum(x => x.giatritt)
                    }).ToList();


                var lst4 = (from a in lst
                           join b in lst2 on a.id equals b.id into k
                           join c in lst3 on a.id equals c.id into l
                           from tt in k
                           from tong in l
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
                               noidunghd =
                                   "- Số HĐ: " + a.sohd + ".\n- Đối tác: " + a.doituong + ". \n- GTHĐ: " +
                                   string.Format("{0:n2}", a.nguyentehd) + ". \n- GTPL: " +
                                   string.Format("{0:n2}", a.nguyentepl) + " (" + a.tiente + ")",
                               a.loaihd,
                               a.khuvuc,
                               tendoituong = a.doituong,
                               a.tiente,
                               tt.diengiai,
                               tt.ngaytt,
                               tt.lan,
                               tt.link,
                               tt.linkgoc,
                               nguyentetp = a.nguyentepl,
                               a.thanhtien,
                               tt.giatritt,
                               tt.giatriqt,
                               thanhtoan = tt.giatritt * a.tygia,
                               quyettoan = tt.giatriqt * a.tygia,
                               ghichu2 = tt.ghichu
                           });
               

                //var lst4 = from a in lst
                //    join b in lst2 on a.id equals b.id into k
                //    join c in lst3 on a.id equals c.id into l
                //    from tt in k
                //    from tong in l
                //    select new
                //    {
                //        a.id,
                //        a.iddv,
                //        a.ttcongtrinh,
                //        a.idct,
                //        a.iddt,
                //        a.idnv,
                //        a.loaict,
                //        a.sohd,
                //        a.ngayky,
                //        noidunghd =
                //            "- Số HĐ: " + a.sohd + ".\n- Đối tác: " + a.doituong + ". \n- GTHĐ: " +
                //            string.Format("{0:n2}", a.nguyentehd) + ". \n- GTPL: " +
                //            string.Format("{0:n2}", a.nguyentepl) + " (" + a.tiente + ")",
                //        a.loaihd,
                //        a.khuvuc,
                //        tendoituong = a.doituong,
                //        a.tiente,
                //        tt.diengiai,
                //        tt.ngaytt,
                //        tt.lan,
                //        a.link,
                //        nguyentetp = a.nguyentepl,
                //        a.thanhtien,
                //        tt.giatritt,
                //        tt.giatriqt,
                //        thanhtoan = tt.giatritt*a.tygia,
                //        quyettoan = tt.giatriqt*a.tygia,
                //        ghichu2 = tt.ghichu
                //    };


                // nguồn cấp
               
                if (checklhd != 0)
                {
                    lst4 = from a in lst4
                        join b in db.dk_rps on a.loaihd equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "Loại Hợp Đồng"
                        select a;
                }


                // Khu Vực

                if (checkkv != 0)
                {
                    lst4 = from a in lst4
                        join b in db.dk_rps on a.khuvuc equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "Khu Vực"
                        select a;
                }


                //Loại Công Trình

                if (checklct != 0)
                {
                    lst4 = from a in lst4
                        join b in db.dk_rps on a.loaict equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "Loại Công Trình"
                        select a;
                }


                //Công Trình

                if (checkct != 0)
                {
                    lst4 = from a in lst4
                        join b in db.dk_rps on a.idct equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "Công Trình"
                        select a;
                }


                //Đối Tượng

                if (checkdt != 0)
                {
                    lst4 = from a in lst4
                        join b in db.dk_rps on a.iddt equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "Đối Tượng"
                        select a;
                }


                //User

                if (checku != 0)
                {
                    lst4 = from a in lst4
                        join b in db.dk_rps on a.idnv equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "User"
                        select a;
                }

                //Đơn Vị

                if (checkdv != 0)
                {
                    lst4 = from a in lst4
                        join b in db.dk_rps on a.iddv equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "Đơn Vị"
                        select a;
                }

                //Vật Tư

                if (checksohd != 0)
                {
                    lst4 = from a in lst4
                        join b in db.dk_rps on a.sohd equals b.name
                        where b.user == Biencucbo.idnv && b.loai == "Số Hợp Đồng"
                        select a;
                }

                //moi
                //link

                if (checklinkhs != 0)
                {
                    lst4 = from a in lst4
                        join b in db.dk_rps on a.link equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "Link Hồ Sơ"
                        select a;
                }

                if (checklinkgoc != 0)
                {
                    lst4 = from a in lst4
                           join b in db.dk_rps on a.linkgoc equals b.id
                           where b.user == Biencucbo.idnv && b.loai == "Hồ Sơ Gốc"
                           select a;
                }

                var xtra = new r_bdhdcps();
                xtra.DataSource = _todatatable.addlst(lst4.ToList());
                xtra.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            SplashScreenManager.CloseForm(false);
        }
        t_todatatable _todatatable = new t_todatatable();
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
            try
            {
                cl = 0;

                if (sh3 == b)
                {
                    cl = 0;
                }
                else
                {
                    sh3 = b;
                    cl = (c + d - a)*e;
                }
            }
            catch
            {
                cl = 1;
            }

            return cl;
        }

        private void btnall_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof (SplashScreen2), true, true, false);
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
                var checklhd = 0;
                var checkkv = 0;
                var checklct = 0;
                var checkdt = 0;
                var checku = 0;
                var checkdv = 0;
                var checksohd = 0;
                //moi
                var checklinkhs = 0;
                var checklinkgoc = 0;

                for (var i = 0; i < gridView2.DataRowCount; i++)
                {
                    if (gridView2.GetRowCellValue(i, "loai").ToString() == "Công Trình")
                    {
                        checkct++;
                        Biencucbo.Congtrinh = Biencucbo.Congtrinh + gridView2.GetRowCellValue(i, "id") + "-" +
                                              gridView2.GetRowCellValue(i, "name") + ", ";
                    }
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "Loại Hợp Đồng")
                    {
                        checklhd++;
                        Biencucbo.loaihd = Biencucbo.loaihd + gridView2.GetRowCellValue(i, "id") + "-" +
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
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "Số Hợp Đồng")
                    {
                        checksohd++;
                    }
                    //moi
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "Link Hồ Sơ")
                    {
                        checklinkhs++;
                    }
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "Hồ Sơ Gốc")
                    {
                        checklinkgoc++;
                    }
                }

                if (checklhd == 0)
                {
                    Biencucbo.loaihd = "Tất cả";
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
                if (checksohd == 0)
                {
                    Biencucbo.sohd = "Tất cả";
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


                if (ts.IsOn)
                {
                    var lst = (from a in db.r_hopdongs
                        join d in db.congtrinhs on a.idct equals d.id
                        where a.loai == "Hợp Đồng"
                        where d.ht != true
                        select new
                        {
                            a.id,
                            ttcongtrinh =
                                "Công trình:" + d.tencongtrinh + "\n" + "Địa điểm: " + d.diadiem + "\nChỉ huy trưởng: " +
                                d.chihuytruong,
                            d.khuvuc,
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
                        }).Concat(from a in db.r_hopdongs
                            join d in db.congtrinhs on a.idct equals d.id
                            where a.loai == "Phụ Lục"
                            where d.ht != true
                            select new
                            {
                                a.id,
                                ttcongtrinh =
                                    "Công trình:" + d.tencongtrinh + "\n" + "Địa điểm: " + d.diadiem +
                                    "\nChỉ huy trưởng: " + d.chihuytruong,
                                d.khuvuc,
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
                            }).Concat(from a in db.r_hopdongs
                                join d in db.congtrinhs on a.idct equals d.id
                                where a.loai == null
                                where d.ht != true
                                select new
                                {
                                    a.id,
                                    ttcongtrinh =
                                        "Công trình:" + d.tencongtrinh + "\n" + "Địa điểm: " + d.diadiem +
                                        "\nChỉ huy trưởng: " + d.chihuytruong,
                                    d.khuvuc,
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
                                    t.iddt,
                                    t.idnv,
                                    t.idct,
                                    t.ttcongtrinh
                                })
                        .Select(y =>
                            new
                            {
                                y.Key.id,
                                y.Key.ttcongtrinh,
                                y.Key.loaict,
                                y.Key.idnv,
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

                    var lst2 = (from a in db.hopdong_tps
                        join b in db.thanhtoan_tps on a.id equals b.idhd_tp into k
                        from tt in k.DefaultIfEmpty()
                        orderby tt.idhd_tp ascending
                        orderby tt.lan ascending
                        select new
                        {
                            a.id,
                            tt.linkgoc,
                            tt.link,
                            giatritt = (tt.giatritt == null ? 0 : tt.giatritt) + (tt.cantru == null ? 0 : tt.cantru),
                            giatriqt = tt.giatriqt == null ? 0 : tt.giatriqt,
                            tt.ngaytt,
                            tt.ghichu,
                            tt.diengiai,
                            tt.lan
                        }).ToList();
                    var lst3 = lst2.GroupBy(t => new {t.id}).Select(y =>
                        new
                        {
                            y.Key.id,
                            tongtt = y.Sum(x => x.giatritt)
                        }).ToList();


                    var lst4 = from a in lst
                        join b in lst2 on a.id equals b.id into k
                        join c in lst3 on a.id equals c.id into l
                        from tt in k
                        from tong in l
                        select new
                        {
                            a.id,
                            a.iddv,
                            a.idct,
                            a.ttcongtrinh,
                            a.iddt,
                            a.idnv,
                            a.loaict,
                            a.sohd,
                            a.ngayky,
                            noidung =
                                "- Số HĐ: " + a.sohd + "- Đối tác: " + a.doituong + ". \n- GTHĐ: " +
                                string.Format("{0:n2}", a.nguyentehd) + "- GTPL: " +
                                string.Format("{0:n2}", a.nguyentepl) + " (" + a.tiente + ").\n- Nội Dung HĐ: " +
                                a.noidunghd,
                            a.loaihd,
                            a.khuvuc,
                            tendoituong = a.doituong,
                            a.tiente,
                            tt.diengiai,
                            tt.ngaytt,
                            tt.lan,
                            nguyentetp = a.nguyentepl,
                            a.thanhtien,
                            tt.linkgoc,
                            tt.link,
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


                    // nguồn cấp
                    var lst5 = lst4;
                    if (checklhd != 0)
                    {
                        lst5 = from a in lst4
                            join b in db.dk_rps on a.loaihd equals b.id
                            where b.user == Biencucbo.idnv && b.loai == "Loại Hợp Đồng"
                            select a;
                    }


                    // Khu Vực
                    lst4 = lst5;
                    if (checkkv != 0)
                    {
                        lst4 = from a in lst5
                            join b in db.dk_rps on a.khuvuc equals b.id
                            where b.user == Biencucbo.idnv && b.loai == "Khu Vực"
                            select a;
                    }


                    //Loại Công Trình
                    lst5 = lst4;
                    if (checklct != 0)
                    {
                        lst5 = from a in lst4
                            join b in db.dk_rps on a.loaict equals b.id
                            where b.user == Biencucbo.idnv && b.loai == "Loại Công Trình"
                            select a;
                    }


                    //Công Trình
                    lst4 = lst5;
                    if (checkct != 0)
                    {
                        lst4 = from a in lst5
                            join b in db.dk_rps on a.idct equals b.id
                            where b.user == Biencucbo.idnv && b.loai == "Công Trình"
                            select a;
                    }


                    //Đối Tượng
                    lst5 = lst4;
                    if (checkdt != 0)
                    {
                        lst5 = from a in lst4
                            join b in db.dk_rps on a.iddt equals b.id
                            where b.user == Biencucbo.idnv && b.loai == "Đối Tượng"
                            select a;
                    }


                    //User
                    lst4 = lst5;
                    if (checku != 0)
                    {
                        lst4 = from a in lst5
                            join b in db.dk_rps on a.idnv equals b.id
                            where b.user == Biencucbo.idnv && b.loai == "User"
                            select a;
                    }

                    //Đơn Vị
                    lst5 = lst4;
                    if (checkdv != 0)
                    {
                        lst5 = from a in lst4
                            join b in db.dk_rps on a.iddv equals b.id
                            where b.user == Biencucbo.idnv && b.loai == "Đơn Vị"
                            select a;
                    }

                    //Vật Tư
                    lst4 = lst5;
                    if (checksohd != 0)
                    {
                        lst4 = from a in lst5
                            join b in db.dk_rps on a.sohd equals b.name
                            where b.user == Biencucbo.idnv && b.loai == "Số Hợp Đồng"
                            select a;
                    }

                    //moi
                    //link
                    lst5 = lst4;
                    if (checklinkhs != 0)
                    {
                        lst5 = from a in lst4
                            join b in db.dk_rps on a.link equals b.id
                            where b.user == Biencucbo.idnv && b.loai == "Link Hồ Sơ"
                            select a;
                    }
                    lst4 = lst5;
                    if (checklinkgoc != 0)
                    {
                        lst4 = from a in lst5
                               join b in db.dk_rps on a.linkgoc equals b.id
                               where b.user == Biencucbo.idnv && b.loai == "Hồ Sơ Gốc"
                               select a;
                    }


                    var xtra = new hdtp_ct();
                    xtra.DataSource = _todatatable.addlst(lst5.ToList()); 
                    xtra.ShowPreviewDialog();
                }
                else
                {
                    var lst = (from a in db.r_hopdongs
                        join d in db.congtrinhs on a.idct equals d.id
                        where a.loai == "Hợp Đồng"
                        where d.ht != true
                        select new
                        {
                            a.id,
                            ttcongtrinh =
                                "Công trình:" + d.tencongtrinh + "\n" + "Địa điểm: " + d.diadiem + "\nChỉ huy trưởng: " +
                                d.chihuytruong,
                            a.idnv,
                            a.idct,
                            d.loaict,
                            a.iddt,
                            d.khuvuc,
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
                            thanhtien = a.thanhtien == null ? 0 : a.thanhtien
                        }).Concat(from a in db.r_hopdongs
                            join d in db.congtrinhs on a.idct equals d.id
                            where a.loai == "Phụ Lục"
                            where d.ht != true
                            select new
                            {
                                a.id,
                                ttcongtrinh =
                                    "Công trình:" + d.tencongtrinh + "\n" + "Địa điểm: " + d.diadiem +
                                    "\nChỉ huy trưởng: " + d.chihuytruong,
                                a.idnv,
                                a.idct,
                                d.loaict,
                                a.iddt,
                                d.khuvuc,
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
                                thanhtien = a.thanhtien == null ? 0 : a.thanhtien
                            }).Concat(from a in db.r_hopdongs
                                join d in db.congtrinhs on a.idct equals d.id
                                where a.loai == null
                                where d.ht != true
                                select new
                                {
                                    a.id,
                                    ttcongtrinh =
                                        "Công trình:" + d.tencongtrinh + "\n" + "Địa điểm: " + d.diadiem +
                                        "\nChỉ huy trưởng: " + d.chihuytruong,
                                    a.idnv,
                                    a.idct,
                                    d.loaict,
                                    a.iddt,
                                    d.khuvuc,
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
                                    thanhtien = a.thanhtien == null ? 0 : a.thanhtien
                                })
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
                           
                                    t.tygia,
                                    t.ghichu,
                                    t.khuvuc,
                                    t.loaict,
                                    t.idct,
                                    t.ttcongtrinh,
                                    t.iddt,
                                    t.idnv
                                })
                        .Select(y =>
                            new
                            {
                                y.Key.id,
                                y.Key.idct,
                                y.Key.idnv,
                                y.Key.loaict,
                                y.Key.ttcongtrinh,
                                y.Key.iddt,
                                y.Key.khuvuc,
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
                    var lst2 = (from a in db.hopdong_tps
                        join b in db.thanhtoan_tps on a.id equals b.idhd_tp into k
                        from tt in k.DefaultIfEmpty()
                        select new
                        {
                            a.id,
                            giatri =
                                ((tt.giatritt == null ? 0 : tt.giatritt) + (tt.cantru == null ? 0 : tt.cantru))*
                                (a.tygia == null ? 1 : a.tygia),
                            giatritt2 = (tt.giatritt == null ? 0 : tt.giatritt) + (tt.cantru == null ? 0 : tt.cantru),
                            giatriqt = tt.giatriqt == null ? 0 : tt.giatriqt*a.tygia
                        }).GroupBy(t => new {t.id}).Select(y =>
                            new
                            {
                                y.Key.id,
                                giatritt = y.Sum(x => x.giatri),
                                giatritt2 = y.Sum(x => x.giatritt2),
                                giatriqt = y.Sum(x => x.giatriqt)
                            });

                    var lst4 = from a in lst
                        join b in lst2 on a.id equals b.id into k
                        from tt in k.DefaultIfEmpty()
                        select new
                        {
                            a.id,
                            a.idct,
                            a.idnv,
                            a.ttcongtrinh,
                            a.loaict,
                            a.iddt,
                            a.iddv,
                            a.khuvuc,
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

                    // nguồn cấp


                    if (checklhd != 0)
                    {
                        lst4 = from a in lst4
                            join b in db.dk_rps on a.loaihd equals b.id
                            where b.user == Biencucbo.idnv && b.loai == "Loại Hợp Đồng"
                            select a;
                    }


                    // Khu Vực

                    if (checkkv != 0)
                    {
                        lst4 = from a in lst4
                            join b in db.dk_rps on a.khuvuc equals b.id
                            where b.user == Biencucbo.idnv && b.loai == "Khu Vực"
                            select a;
                    }


                    //Loại Công Trình

                    if (checklct != 0)
                    {
                        lst4 = from a in lst4
                            join b in db.dk_rps on a.loaict equals b.id
                            where b.user == Biencucbo.idnv && b.loai == "Loại Công Trình"
                            select a;
                    }


                    //Công Trình

                    if (checkct != 0)
                    {
                        lst4 = from a in lst4
                            join b in db.dk_rps on a.idct equals b.id
                            where b.user == Biencucbo.idnv && b.loai == "Công Trình"
                            select a;
                    }


                    //Đối Tượng

                    if (checkdt != 0)
                    {
                        lst4 = from a in lst4
                            join b in db.dk_rps on a.iddt equals b.id
                            where b.user == Biencucbo.idnv && b.loai == "Đối Tượng"
                            select a;
                    }


                    //User

                    if (checku != 0)
                    {
                        lst4 = from a in lst4
                            join b in db.dk_rps on a.idnv equals b.id
                            where b.user == Biencucbo.idnv && b.loai == "User"
                            select a;
                    }

                    //Đơn Vị

                    if (checkdv != 0)
                    {
                        lst4 = from a in lst4
                            join b in db.dk_rps on a.iddv equals b.id
                            where b.user == Biencucbo.idnv && b.loai == "Đơn Vị"
                            select a;
                    }

                    //Vật Tư

                    if (checksohd != 0)
                    {
                        lst4 = from a in lst4
                            join b in db.dk_rps on a.sohd equals b.name
                            where b.user == Biencucbo.idnv && b.loai == "Số Hợp Đồng"
                            select a;
                    }

                    //moi
                    //link

                    //if (checklinkhs != 0)
                    //{
                    //    lst4 = from a in lst4
                    //        join b in db.dk_rps on a.link equals b.id
                    //        where b.user == Biencucbo.idnv && b.loai == "Link Hồ Sơ"
                    //        select a;
                    //}

                    var frm = new hdth_th();
                    frm.DataSource = _todatatable.addlst(lst4.ToList());
                    frm.ShowPreviewDialog();
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