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
using GUI.report.chiphimay;

namespace GUI.Report.PhuongTien
{
    public partial class f_bcthgtall : Form
    {
        private readonly KetNoiDBDataContext db = new KetNoiDBDataContext();
        private bool doubleclick1;
        private bool doubleclick2;
        public string sh = "";
        public string sh2 = "";
        t_todatatable _tTodatatable = new t_todatatable();
        public string sh3 = "";
        public string sh4 = "";


        public double tongtt;
        public double tongtt2;


        public f_bcthgtall()
        {
            InitializeComponent();
        }


        private void f_chitietnhapkho_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);


            changeFont.Translate(this);


            danhmuc.Text = "Công Trình";


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
            else if (danhmuc.Text == "Loại Chi")
            {
                try
                {
                    var lst = from a in db.dmcpms
                        select new {a.id, name = a.loaichi, key = a.id + danhmuc.Text + Biencucbo.idnv};
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
            //else if (danhmuc.Text == "Số Hợp Đồng")
            //{
            //    try
            //    {
            //        var lst = (from a in db.hopdong_tps select new { id = a.id, name = a.sohd, key = a.id + danhmuc.Text + Biencucbo.idnv });
            //        nguon.DataSource = _tTodatatable.addlst(lst.ToList());

            //        for (int i = gridView1.RowCount - 1; i >= 0; i--)
            //        {
            //            for (int j = 0; j < gridView2.DataRowCount; j++)
            //            {
            //                if (gridView1.GetRowCellValue(i, "key").ToString() == gridView2.GetRowCellValue(j, "key").ToString())
            //                {
            //                    gridView1.DeleteRow(i);
            //                    break;
            //                }
            //            }
            //        };
            //    }
            //    catch

            //    {

            //    }
            //}
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
            else if (danhmuc.Text == "Loại Chi")
            {
                try
                {
                    var lst = from a in db.dmcpms
                        select new {a.id, name = a.loaichi, key = a.id + danhmuc.Text + Biencucbo.idnv};
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
            //else if (danhmuc.Text == "Số Hợp Đồng")
            //{
            //    try
            //    {
            //        var lst = (from a in db.hopdong_tps select new { id = a.id, name = a.sohd, key = a.id + danhmuc.Text + Biencucbo.idnv });
            //        nguon.DataSource = _tTodatatable.addlst(lst.ToList());

            //        for (int i = gridView1.RowCount - 1; i >= 0; i--)
            //        {
            //            for (int j = 0; j < gridView2.DataRowCount; j++)
            //            {
            //                if (gridView1.GetRowCellValue(i, "key").ToString() == gridView2.GetRowCellValue(j, "key").ToString())
            //                {
            //                    gridView1.DeleteRow(i);
            //                    break;
            //                }
            //            }
            //        };
            //    }
            //    catch

            //    {

            //    }
            //}
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
            else if (danhmuc.Text == "Loại Chi")
            {
                try
                {
                    var lst = from a in db.dmcpms
                        select new {a.id, name = a.loaichi, key = a.id + danhmuc.Text + Biencucbo.idnv};
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
            //if (danhmuc.Text == "Số Hợp Đồng")
            //{
            //    try
            //    {
            //        var lst = (from a in db.hopdong_tps select new { id = a.id, name = a.sohd, key = a.id + danhmuc.Text + Biencucbo.idnv });
            //        nguon.DataSource = _tTodatatable.addlst(lst.ToList());

            //        for (int i = gridView1.RowCount - 1; i >= 0; i--)
            //        {
            //            for (int j = 0; j < gridView2.DataRowCount; j++)
            //            {
            //                if (gridView1.GetRowCellValue(i, "key").ToString() == gridView2.GetRowCellValue(j, "key").ToString())
            //                {
            //                    gridView1.DeleteRow(i);
            //                    break;

            //                }

            //            }
            //        };


            //    }
            //    catch

            //    {

            //    }
            //}
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
            if (b != "HD00_000035")
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
            if (b == "HD00_000035")
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
                var checkct = 0;
                var checkloai = 0;
                var checkkv = 0;
                var checklct = 0;


                for (var i = 0; i < gridView2.DataRowCount; i++)
                {
                    if (gridView2.GetRowCellValue(i, "loai").ToString() == "Công Trình")
                    {
                        checkct++;
                        Biencucbo.Congtrinh = Biencucbo.Congtrinh + gridView2.GetRowCellValue(i, "id") + "-" +
                                              gridView2.GetRowCellValue(i, "name") + ", ";
                    }
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "Loại Chi")
                    {
                        checkloai++;
                        //Biencucbo.loaihd = Biencucbo.loaihd + gridView2.GetRowCellValue(i, "id").ToString() + "-" + gridView2.GetRowCellValue(i, "name").ToString() + ", ";
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


                var lstpn = (from a in db.congtrinhs
                    join b in db.r_bcpns on a.id equals b.idct into k
                    from pn in k.DefaultIfEmpty()
                    where a.ht != true
                    select new
                    {
                        dv = a.khuvuc,
                        a.tencongtrinh,
                        loai = a.loaict,
                        a.gthanmuc,
                        pn.idct,
                        gtqt = pn.gtqt == null ? 0 : pn.gtqt,
                        gttt = pn.gttt == null ? 0 : pn.gttt,
                        gtcl = (pn.gtqt == null ? 0 : pn.gtqt) - (pn.gttt == null ? 0 : pn.gttt)
                    }).ToList();
                var lsthd = (from a in db.congtrinhs
                    join b in db.r_thanhtoans on a.id equals b.idct into k
                    from pn in k.DefaultIfEmpty()
                    where a.ht != true
                    select new
                    {
                        dv = a.khuvuc,
                        a.tencongtrinh,
                        loai = a.loaict,
                        a.gthanmuc,
                        pn.idct,
                        gtqt = pn.giatriqt == null ? 0 : pn.giatriqt,
                        gttt = pn.giatritt == null ? 0 : pn.giatritt,
                        gtcl = (pn.giatriqt == null ? 0 : pn.giatriqt) - (pn.giatritt == null ? 0 : pn.giatritt)
                    }).ToList();
                var lstcpm = (from a in db.congtrinhs
                    join b in db.r_bccpms on a.id equals b.idct into k
                    from pn in k.DefaultIfEmpty()
                    where a.ht != true
                    select new
                    {
                        dv = a.khuvuc,
                        a.tencongtrinh,
                        loai = a.loaict,
                        a.gthanmuc,
                        pn.idct,
                        gtqt = pn.gtqt == null ? 0 : pn.gtqt,
                        gttt = pn.gttt == null ? 0 : pn.gttt,
                        gtcl = (pn.gtqt == null ? 0 : pn.gtqt) - (pn.gttt == null ? 0 : pn.gttt)
                    }).ToList();
                var lstcpk = (from a in db.congtrinhs
                    join b in db.r_bccpks on a.id equals b.idct into k
                    from pn in k.DefaultIfEmpty()
                    where a.ht != true
                    select new
                    {
                        dv = a.khuvuc,
                        a.tencongtrinh,
                        loai = a.loaict,
                        a.gthanmuc,
                        pn.idct,
                        gtqt = pn.gtqt == null ? 0 : pn.gtqt,
                        gttt = pn.gttt == null ? 0 : pn.gttt,
                        gtcl = (pn.gtqt == null ? 0 : pn.gtqt) - (pn.gttt == null ? 0 : pn.gttt)
                    }).ToList();


                var lst1 =
                    (from a in lstpn select a).Concat(from b in lsthd select b)
                        .Concat(from c in lstcpm select c)
                        .Concat(from d in lstcpk select d)
                        .GroupBy(t => new {t.idct, t.dv, t.tencongtrinh, t.loai, t.gthanmuc})
                        .Select(y => new

                        {
                            y.Key.idct,
                            y.Key.dv,
                            y.Key.loai,
                            y.Key.tencongtrinh,
                            y.Key.gthanmuc,
                            gtqt = y.Sum(t => t.gtqt),
                            gttt = y.Sum(t => t.gttt),
                            gtcl = y.Sum(t => t.gtcl)
                        }
                        ).Where(c => c.idct != null).ToList();
                var lsthdcdt = (from a in db.congtrinhs
                    join b in db.r_hopdong_cdts on a.id equals b.idct into k
                    from cdt in k.DefaultIfEmpty()
                    where a.ht != true
                    select new
                    {
                        idct = a.id,
                        giatrihd = cdt.thanhtien == null ? 0 : cdt.thanhtien
                    }).GroupBy(t => t.idct).Select(y => new
                    {
                        idcdt = y.Key,
                        giatrihd = y.Sum(t => t.giatrihd)
                    }).ToList();

                var lst = from a in lst1
                    join c in lsthdcdt on a.idct equals c.idcdt
                    select new
                    {
                        a.idct,
                        a.dv,
                        a.tencongtrinh,
                        a.loai,
                        a.gthanmuc,
                        a.gtqt,
                        a.gttt,
                        a.gtcl,
                        gthd = c.giatrihd /*== null ? 0 : cdt.giatrihd*/
                    };
                // nguồn cấp
                var lst2 = lst;

                // Khu Vực
                lst = lst2;
                if (checkkv != 0)
                {
                    lst = from a in lst2
                        join b in db.dk_rps on a.dv equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "Khu Vực"
                        select a;
                }


                //Loại Công Trình
                lst2 = lst;
                if (checklct != 0)
                {
                    lst2 = from a in lst
                        join b in db.dk_rps on a.loai equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "Loại Công Trình"
                        select a;
                }


                //Công Trình
                lst = lst2;
                if (checkct != 0)
                {
                    lst = from a in lst2
                        join b in db.dk_rps on a.idct equals b.id
                        where b.user == Biencucbo.idnv && b.loai == "Công Trình"
                        select a;
                }


                var xtra = new r_bcthgtall();
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