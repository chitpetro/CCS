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
    public partial class f_bclinkhs : Form
    {
        private readonly KetNoiDBDataContext db = new KetNoiDBDataContext();
        private bool doubleclick1;
        private bool doubleclick2;
        t_todatatable _tTodatatable = new t_todatatable();

        public f_bclinkhs()
        {
            InitializeComponent();
        }


        private void f_chitietnhapkho_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Báo Cáo Theo Hồ Sơ");

            changeFont.Translate(this);


            try
            {
                var lst = from a in db.vanbandens
                    select new {a.id, name = a.noidung, key = a.id + "VBD" + Biencucbo.idnv};
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

            var lst2 = from a in db.dk_rps where a.user == Biencucbo.idnv select a;
            db.dk_rps.DeleteAllOnSubmit(lst2);
            db.SubmitChanges();
            nhan.DataSource = _tTodatatable.addlst(lst2.ToList());
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


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var dk = new dk_rp();
                dk.id = gridView1.GetFocusedRowCellValue("id").ToString();
                dk.name = gridView1.GetFocusedRowCellValue("name").ToString();
                dk.key = gridView1.GetFocusedRowCellValue("key").ToString();
                dk.loai = "VBD";
                dk.user = Biencucbo.idnv;
                db.dk_rps.InsertOnSubmit(dk);
                db.SubmitChanges();
                var lst = from a in db.dk_rps where a.user == Biencucbo.idnv select a;
                nhan.DataSource = _tTodatatable.addlst(lst.ToList());


                gridView1.DeleteSelectedRows();
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

            try
            {
                var lst = from a in db.vanbandens
                    select new {a.id, name = a.noidung, key = a.id + "VBD" + Biencucbo.idnv};
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
                    dk.loai = "VBD";
                    dk.user = Biencucbo.idnv;
                    db.dk_rps.InsertOnSubmit(dk);
                    db.SubmitChanges();
                    var lst = from a in db.dk_rps where a.user == Biencucbo.idnv select a;
                    nhan.DataSource = _tTodatatable.addlst(lst.ToList());
                }


                for (var i = gridView1.RowCount; i > 0; i--)
                {
                    gridView1.DeleteSelectedRows();
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

            try
            {
                var lst = from a in db.vanbandens
                    select new {a.id, name = a.noidung, key = a.id + "VBD" + Biencucbo.idnv};
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


        private void btnall_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof (SplashScreen2), true, true, false);
            try
            {
                //if (checksohd != 0)
                //{
                //    lst4 = from a in lst5
                //           join b in db.dk_rps on a.sohd equals b.name
                //           where b.user == Biencucbo.idnv && b.loai == "Số Hợp Đồng"
                //           select a;
                //}


                var lsthd = (from tt in db.r_linktts
                    join a in db.dk_rps on tt.link equals a.id
                    where a.user == Biencucbo.idnv && a.loai == "VBD"
                    select new
                    {
                        a.id,
                        idct = tt.idct + " - " + tt.tencongtrinh,
                        ngay = tt.ngaytt,
                        dt = tt.iddt + " - " + tt.ten,
                        tt.tiente,
                        giatrint = tt.giatritt == null ? 0 : tt.giatritt,
                        giatri = (tt.giatritt == null ? 0 : tt.giatritt)*(tt.tygia == null ? 1 : tt.tygia),
                        noidung = tt.diengiai + " (Số HĐ: " + tt.sohd + ")",
                        loai = "Chi Phí Hợp Đồng"
                    }
                    ).Concat(from pn in db.r_linkpnhaps
                        join a in db.dk_rps on pn.link equals a.id
                        where a.user == Biencucbo.idnv && a.loai == "VBD"
                        select new
                        {
                            a.id,
                            idct = pn.idct + " - " + pn.tencongtrinh,
                            ngay = pn.ngaynhap,
                            dt = pn.iddt + " - " + pn.ten,
                            pn.tiente,
                            giatrint = pn.nguyente == null ? 0 : pn.nguyente,
                            giatri = (pn.nguyente == null ? 0 : pn.nguyente)*(pn.tygia == null ? 1 : pn.tygia),
                            noidung = pn.ghichu,
                            loai = "Chi Phí Nhập Vật Tư"
                        }
                    ).Concat(from pn in db.r_linkpchis
                        join a in db.dk_rps on pn.link equals a.id
                        where a.user == Biencucbo.idnv && a.loai == "VBD"
                        select new
                        {
                            a.id,
                            idct = pn.idct + " - " + pn.tencongtrinh,
                            ngay = pn.ngaychi,
                            dt = pn.iddt + " - " + pn.ten,
                            pn.tiente,
                            giatrint =
                                (pn.nguyentebch == null ? 0 : pn.nguyentebch) +
                                (pn.nguyentecn == null ? 0 : pn.nguyentecn) +
                                (pn.nguyentect == null ? 0 : pn.nguyentect),
                            giatri =
                                ((pn.nguyentebch == null ? 0 : pn.nguyentebch) +
                                 (pn.nguyentecn == null ? 0 : pn.nguyentecn) +
                                 (pn.nguyentect == null ? 0 : pn.nguyentect))*(pn.tygia == null ? 1 : pn.tygia),
                            noidung = pn.ghichu,
                            loai = "Chi Phí Quản Lý"
                        }).Concat(from pn in db.r_linkcpms
                            join a in db.dk_rps on pn.link equals a.id
                            where a.user == Biencucbo.idnv && a.loai == "VBD"
                            select new
                            {
                                a.id,
                                idct = pn.idct + " - " + pn.tencongtrinh,
                                ngay = pn.ngaychi,
                                dt = pn.iddt + " - " + pn.ten,
                                tiente = "Kip",
                                giatrint = pn.sotien == null ? 0 : pn.sotien,
                                giatri = (pn.sotien == null ? 0 : pn.sotien)*1,
                                noidung = pn.ghichu,
                                loai = "Chi Phí Máy"
                            });

              

                var frm = new r_ktlink();
                frm.DataSource = _tTodatatable.addlst(lsthd.Where(t => t.idct != null).ToList());
                frm.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            SplashScreenManager.CloseForm(false);
        }
    }
}