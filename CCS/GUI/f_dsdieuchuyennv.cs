﻿using System;
using System.Linq;
using System.Windows.Forms;
using BUS;
using ControlLocalizer;
using DAL;
using DevExpress.CodeParser;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using Lotus;

namespace GUI
{
    public partial class f_dsdieuchuyennv : Form
    {
        private readonly KetNoiDBDataContext db = new KetNoiDBDataContext();
        private bool doubleclick;
        t_todatatable _tTodatatable = new t_todatatable();
        private readonly t_lichsu_phuongtien ls = new t_lichsu_phuongtien();

        public f_dsdieuchuyennv()
        {
            InitializeComponent();

            rTime.SetTime(thoigian);
            rTime.SetTime2(thoigian);
        }

        public void loaddata(DateTime tungay, DateTime denngay)
        {
            SplashScreenManager.ShowForm(this, typeof(SplashScreen2), true, true, false);
            try
            {
                var lst = from a in db.dieuchuyen_nhanviens
                          join b in db.nhanviens
                              on a.idnv equals b.id
                          join d in db.donvis
                          on a.iddv equals d.id
                          where
                              a.ngaydc.Value >= tungay && a.ngaydc.Value <= denngay
                          select new
                          {
                              a.id,
                              b.ten,
                              b.dienthoai,
                              b.email,
                              ctndc = layct(a.mact_dc),
                              ctnht = layct(a.mact_ht),
                              a.ngaydc,
                              MaTim = LayMaTim(d)
                          };

                var lst2 = lst.ToList().Where(t => t.MaTim.Contains("." + Biencucbo.donvi + "."));
                gridControl1.DataSource = _tTodatatable.addlst(lst2.ToList());
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
        private string layct(string ab)
        {
            string s = "N/A";
            try
            {
                var lst = (from a in new KetNoiDBDataContext().congtrinhs select a).Single(t => t.id == ab);
                s = lst.tencongtrinh;
            }
            catch 
            {
             
            }
            return s;
        }

        private void f_PN_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Danh Sách Điều Chuyển Nhân Sự");

            changeFont.Translate(this);
            changeFont.Translate(barManager1);

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
                e.Info.DisplayText = string.Format("[{0}]", e.RowHandle * -1); //Nhân -1 để đánh lại số thứ tự tăng dần
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

        private void btnIN_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(SplashScreen2), true, true, false);

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

            //
            //gridView1.Columns["iddv"].GroupIndex = 1;
            //gridView1.Columns["cotbom"].GroupIndex = 2;
            //gridView1.Columns["voibom"].GroupIndex = 3;
            //gridView1.Columns["ngay"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            //gridView1.Columns["id"].Visible = false;//.OptionsColumn.AllowShowHide;
            //gridView1.Columns["saiso"].Visible = false; //an cot sai so
            gridView1.ExpandAllGroups();

            gridView1.BestFitColumns();


            //check


            var report = new r_DsDieuChuyennv();
            report.GridControl = gridControl1;

            var printTool = new ReportPrintTool(report);
            //printTool.PrintingSystem.PageMargins.Right = 0;

            printTool.ShowPreviewDialog();
            gridView1.ClearGrouping();
            gridView1.ClearSorting();
            gridView1.Columns["id"].Visible = true;

            SplashScreenManager.CloseForm(false);
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            Biencucbo.dcpt = 1;
            Biencucbo.ma = gridView1.GetFocusedRowCellValue("id").ToString();
            var frm = new f_dieuchuyenphuongtien();
            frm.ShowDialog();

            loaddata(DateTime.Parse(tungay.Text), DateTime.Parse(denngay.Text));
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MsgBox.ShowYesNoCancelDialog("Bạn có chắc chắn muốn xóa DS Điều Chuyển Phương Tiện này không?") ==
                    DialogResult.Yes)
                {
                    ls.xoa(gridView1.GetFocusedRowCellValue("id").ToString());
                }
            }
            catch
            {
            }
            loaddata(DateTime.Parse(tungay.Text), DateTime.Parse(denngay.Text));
        }

        private void btnreload_Click(object sender, EventArgs e)
        {
            gridView1.ClearColumnsFilter();
            loaddata(DateTime.Parse(tungay.Text), DateTime.Parse(denngay.Text));
        }
    }
}