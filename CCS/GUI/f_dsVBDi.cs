﻿using System;
using System.Linq;
using System.Windows.Forms;
using BUS;
using ControlLocalizer;
using DAL;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using Lotus;

namespace GUI
{
    public partial class f_dsVBDi : Form
    {
        private readonly KetNoiDBDataContext db = new KetNoiDBDataContext();
        t_todatatable _tTodatatable = new t_todatatable();
        private bool doubleclick;

        public f_dsVBDi()
        {
            InitializeComponent();

            rTime.SetTime(thoigian);
            rTime.SetTime2(thoigian);
            // This line of code is generated by Data Source Configuration Wizard

            // This line of code is generated by Data Source Configuration Wizard
            txtnxl.Properties.DataSource = from a in db.accounts where a.madonvi == Biencucbo.donvi select a;
        }

        public void loaddata(DateTime tungay, DateTime denngay)
        {
            SplashScreenManager.ShowForm(this, typeof (SplashScreen2), true, true, false);
            try
            {
                if (Biencucbo.nb == 1)
                {
                    var lst = from a in db.vanbandis
                        join b in db.donvis on a.iddv equals b.id
                        join c in db.doituongs on a.iddt equals c.id
                        join d in db.accounts on a.idnv equals d.id
                        join e in db.loaivanbans on a.loaivb equals e.id
                        where a.noibo == true
                        where
                            a.ngaygui >= tungay && a.ngaygui <= denngay && a.iddv == Biencucbo.donvi
                        select new
                        {
                            a.id,
                            a.ngaygui,
                            a.iddt,
                            tendoituong = c.ten,
                            a.idnv,
                            tennv = d.name,
                            a.iddv,
                            b.tendonvi,
                            a.loaivb,
                            tenloaivb = e.ten,
                            a.ghichu,
                            a.sovb,
                            a.noidung,
                            a.trichyeu,
                            MaTim = LayMaTim(b)
                        };
                    var lst2 = lst.ToList();

                    Biencucbo.title = "THỐNG KÊ HỒ SƠ ĐI NỘI BỘ";
                    gridControl1.DataSource = _tTodatatable.addlst(lst2.ToList());
                }
                else
                {
                    var lst = from a in db.vanbandis
                        join b in db.donvis on a.iddv equals b.id
                        join c in db.doituongs on a.iddt equals c.id
                        join d in db.accounts on a.idnv equals d.id
                        join e in db.loaivanbans on a.loaivb equals e.id
                        where a.noibo != true && a.iddv == Biencucbo.donvi
                        where
                            a.ngaygui >= tungay && a.ngaygui <= denngay
                        select new
                        {
                            a.id,
                            a.ngaygui,
                            a.iddt,
                            tendoituong = c.ten,
                            a.idnv,
                            tennv = d.name,
                            a.iddv,
                            tenloaivb = e.ten,
                            b.tendonvi,
                            a.loaivb,
                            a.sovb,
                            a.ghichu,
                            a.noidung,
                            a.trichyeu,
                            MaTim = LayMaTim(b)
                        };
                    var lst2 = lst.ToList();

                    Biencucbo.title = "THỐNG KÊ HỒ SƠ ĐI";
                    gridControl1.DataSource = _tTodatatable.addlst(lst2.ToList());
                }
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
            //LanguageHelper.Translate(this);
            //LanguageHelper.Translate(barManager1);
            //this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Danh Sách Văn Bản Đến").ToString();

            //changeFont.Translate(this);
            //changeFont.Translate(barManager1);

            tungay.ReadOnly = true;
            denngay.ReadOnly = true;

            Biencucbo.getID = 0;
        }

        private void thoigian_EditValueChanged(object sender, EventArgs e)
        {
            changeTime.thoigian_change3(thoigian, tungay, denngay);
            if (changeTime.gtime == 1)
            {
                loaddata(DateTime.Parse(tungay.Text), DateTime.Parse(denngay.Text));
            }
        }

        private void timkiem_Click(object sender, EventArgs e)
        {
            loaddata(DateTime.Parse(tungay.Text), DateTime.Parse(denngay.Text));
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
                Close();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            doubleclick = true;
        }

        private void btnin_Click(object sender, EventArgs e)
        {
            if (Biencucbo.nb == 1)
            {
                var lst = from a in db.vanbandis
                    join b in db.donvis on a.iddv equals b.id
                    join c in db.doituongs on a.iddt equals c.id
                    join d in db.accounts on a.idnv equals d.id
                    join f in db.loaivanbans on a.loaivb equals f.id
                    where a.noibo == true
                    where
                        a.ngaygui >= tungay.DateTime && a.ngaygui <= denngay.DateTime && a.iddv == Biencucbo.donvi &&
                        a.ghichu == txtnxl.Text
                    select new
                    {
                        a.id,
                        a.ngaygui,
                        a.iddt,
                        tendoituong = c.ten,
                        a.idnv,
                        tennv = d.name,
                        a.iddv,
                        b.tendonvi,
                        a.loaivb,
                        tenloaivb = f.ten,
                        a.ghichu,
                        a.sovb,
                        a.noidung,
                        a.trichyeu,
                        MaTim = LayMaTim(b)
                    };

                Biencucbo.title = "THỐNG KÊ HỒ SƠ ĐI NỘI BỘ";
                Biencucbo.tungay2 = tungay.DateTime;
                Biencucbo.denngay2 = denngay.DateTime;
                var ra = new r_dsVbDi();
                ra.DataSource = _tTodatatable.addlst(lst.ToList());
                ra.ShowPreviewDialog();
            }
            else
            {
                var lst = from a in db.vanbandis
                    join b in db.donvis on a.iddv equals b.id
                    join c in db.doituongs on a.iddt equals c.id
                    join d in db.accounts on a.idnv equals d.id
                    join f in db.loaivanbans on a.loaivb equals f.id
                    where a.noibo != true && a.iddv == Biencucbo.donvi
                    where
                        a.ngaygui >= tungay.DateTime && a.ngaygui <= denngay.DateTime && a.ghichu == txtnxl.Text
                    select new
                    {
                        a.id,
                        a.ngaygui,
                        a.iddt,
                        tendoituong = c.ten,
                        a.idnv,
                        tennv = d.name,
                        a.iddv,
                        tenloaivb = f.ten,
                        b.tendonvi,
                        a.loaivb,
                        a.sovb,
                        a.ghichu,
                        a.noidung,
                        a.trichyeu,
                        MaTim = LayMaTim(b)
                    };


                Biencucbo.title = "THỐNG KÊ HỒ SƠ ĐI";
                Biencucbo.tungay2 = tungay.DateTime;
                Biencucbo.denngay2 = denngay.DateTime;
                var r = new r_dsVbDi();
                r.DataSource = _tTodatatable.addlst(lst.ToList());
                r.ShowPreviewDialog();
            }
        }

        private void btnall_Click(object sender, EventArgs e)
        {
            if (txtnxl.Text != "")
            {
                var lst = from a in db.vanbandis
                    join b in db.donvis on a.iddv equals b.id
                    join c in db.doituongs on a.iddt equals c.id
                    join d in db.accounts on a.idnv equals d.id
                    join f in db.loaivanbans on a.loaivb equals f.id
                    where a.iddv == Biencucbo.donvi
                    where
                        a.ngaygui >= tungay.DateTime && a.ngaygui <= denngay.DateTime && a.ghichu == txtnxl.Text
                    select new
                    {
                        a.id,
                        a.ngaygui,
                        a.iddt,
                        tendoituong = c.ten,
                        a.idnv,
                        tennv = d.name,
                        a.iddv,
                        tenloaivb = f.ten,
                        b.tendonvi,
                        a.loaivb,
                        a.sovb,
                        a.ghichu,
                        a.noidung,
                        a.trichyeu,
                        MaTim = LayMaTim(b)
                    };


                Biencucbo.title = "THỐNG KÊ HỒ SƠ ĐI";
                Biencucbo.tungay2 = tungay.DateTime;
                Biencucbo.denngay2 = denngay.DateTime;
                var r = new r_dsVbDi();
                r.DataSource = _tTodatatable.addlst(lst.ToList());
                r.ShowPreviewDialog();
            }
            else
            {
                var lst = from a in db.vanbandis
                    join b in db.donvis on a.iddv equals b.id
                    join c in db.doituongs on a.iddt equals c.id
                    join d in db.accounts on a.idnv equals d.id
                    join f in db.loaivanbans on a.loaivb equals f.id
                    where a.iddv == Biencucbo.donvi
                    where
                        a.ngaygui >= tungay.DateTime && a.ngaygui <= denngay.DateTime
                    select new
                    {
                        a.id,
                        a.ngaygui,
                        a.iddt,
                        tendoituong = c.ten,
                        a.idnv,
                        tennv = d.name,
                        a.iddv,
                        tenloaivb = f.ten,
                        b.tendonvi,
                        a.loaivb,
                        a.sovb,
                        a.ghichu,
                        a.noidung,
                        a.trichyeu,
                        MaTim = LayMaTim(b)
                    };


                Biencucbo.title = "THỐNG KÊ HỒ SƠ ĐI";
                Biencucbo.tungay2 = tungay.DateTime;
                Biencucbo.denngay2 = denngay.DateTime;
                var r = new r_dsVbDi();
                r.DataSource = _tTodatatable.addlst(lst.ToList());
                r.ShowPreviewDialog();
            }
        }
    }
}