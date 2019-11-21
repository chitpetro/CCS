using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS;
using ControlLocalizer;
using DAL;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using Lotus;

namespace GUI
{
    public partial class f_ds_theodoipt2 : Form
    {
        public static string tenct;
        private KetNoiDBDataContext db = new KetNoiDBDataContext();
        private readonly t_theodoiphuongtien ndt = new t_theodoiphuongtien();
        t_todatatable _tTodatatable = new t_todatatable();
        public f_ds_theodoipt2()
        {
            InitializeComponent();

            loaddata(tungay.DateTime, denngay.DateTime);

            Text = "Theo Dõi Phương Tiện - " + Biencucbo.mact;
            WindowState = FormWindowState.Maximized;
            rTime.SetTime(thoigian);
            rTime.SetTime2(thoigian);
        }

        private void btnThemNDT_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.tdpt = 0;
            var frm = new f_theodoiphuongtien();
            frm.ShowDialog();
            db = new KetNoiDBDataContext();

            loaddata(DateTime.Parse(tungay.Text), DateTime.Parse(denngay.Text));
        }

        // phân quyền 
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            var q = Biencucbo.QuyenDangChon;
            if (q == null) return;

            if ((bool) q.Them)
            {
                btnThemNDT.Visibility = BarItemVisibility.Always;
            }
            else
            {
                btnThemNDT.Visibility = BarItemVisibility.Never;
            }
            if ((bool) q.Sua)
            {
                btnSuaNDT.Visibility = BarItemVisibility.Always;
            }
            else
            {
                btnSuaNDT.Visibility = BarItemVisibility.Never;
            }
            if ((bool) q.Xoa)
            {
                btnXoaNDT.Visibility = BarItemVisibility.Always;
            }
            else
            {
                btnXoaNDT.Visibility = BarItemVisibility.Never;
            }
        }

        private void btnSuaNDT_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.tdpt = 1;
            Biencucbo.ma = gridView1.GetFocusedRowCellValue("id").ToString();
            Biencucbo.g_ngaycapnhat = Convert.ToDateTime(gridView1.GetFocusedRowCellValue("thoigian")); //.ToString();
            var frm = new f_theodoiphuongtien();
            frm.ShowDialog();
            db = new KetNoiDBDataContext();

            loaddata(tungay.DateTime, denngay.DateTime);
        }

        private void btnXoaNDT_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MsgBox.ShowYesNoCancelDialog("Bạn có chắc chắn muốn xóa Theo dõi này không?") == DialogResult.Yes)
            {
                ndt.xoa(gridView1.GetFocusedRowCellValue("id").ToString());
            }
            loaddata(tungay.DateTime, denngay.DateTime);
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            loaddata(tungay.DateTime, denngay.DateTime);
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Biencucbo.tdpt = 1;
            Biencucbo.ma = gridView1.GetFocusedRowCellValue("id").ToString();
            Biencucbo.g_ngaycapnhat = Convert.ToDateTime(gridView1.GetFocusedRowCellValue("thoigian"));
            var frm = new f_theodoiphuongtien();
            frm.ShowDialog();

            loaddata(tungay.DateTime, denngay.DateTime);
        }

        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
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

        private void f_nhomdoituong_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Danh Sách Theo Dõi Phương Tiện");

            changeFont.Translate(this);
            changeFont.Translate(barManager1);
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new f_ds_theodoipt();
            frm.ShowDialog();
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

        public void loaddata(DateTime tungay, DateTime denngay)
        {
            SplashScreenManager.ShowForm(this, typeof (SplashScreen2), true, true, false);
            try
            {
                var lst = from a in db.theodoi_phuongtiens
                    join b in db.phuongtiens on a.mapt equals b.id into b1
                    join c in db.donvis on a.iddv equals c.id into c1
                    join d in db.congtrinhs on a.madv equals d.id into d1
                    join e in db.nhanviens on a.iddt equals e.id into e1
                    where
                        a.thoigian >= tungay && a.thoigian <= denngay && a.madv == Biencucbo.mact
                    from b2 in b1.DefaultIfEmpty()
                    from c2 in c1.DefaultIfEmpty()
                    from d2 in d1.DefaultIfEmpty()
                    from e2 in e1.DefaultIfEmpty()
                    select new
                    {
                        a.mapt,
                        b2.ten,
                        a.thoigian,
                        a.ngaycapnhat,
                        a.iddv,
                        d2.tencongtrinh,
                        a.sogiohd,
                        a.sogiodau,
                        a.sogiocuoi,
                        a.socahd,
                        a.sochuyen,
                        a.songay,
                        a.sokm,
                        a.tondk,
                        a.captk,
                        //a.chuyencho,
                        a.tieuhaokhac,
                        a.ghichu,
                        a.tonck,
                        a.tieuhaothuctetk,
                        a.tieuhaodv,
                        b2.dinhmuc,
                        a.id,
                        a.chenhlech,
                        mau = a.chenhlech > 0 ? Color.GreenYellow : Color.OrangeRed,
                        a.iddt,
                        tendt = e2.ten,
                        MaTim = LayMaTim(c2)
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

        private void btnIN_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof (SplashScreen2), true, true, false);

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

            var getten = (from a in db.congtrinhs select a).Single(t => t.id == Biencucbo.mact);
            tenct = getten.tencongtrinh;
            //
            //gridView1.Columns["iddv"].GroupIndex = 1;

            gridView1.Columns["iddv"].Visible = false; //an cot 
            //gridView1.Columns["dinhmuc"].Visible = false; //an cot 
            //gridView1.Columns["chenhlech"].Visible = false; //an cot 
            gridView1.Columns["mau"].Visible = false; //an cot 
            gridView1.Columns["iddt"].Visible = false; //an cot 
            gridView1.Columns["mapt"].Visible = false; //an cot 


            gridView1.ExpandAllGroups();
            gridView1.BestFitColumns();

            //check 
            var report = new r_DsTheoDoi_PT();
            report.GridControl = gridControl1;

            var printTool = new ReportPrintTool(report);
            //printTool.PrintingSystem.PageMargins.Right = 0;

            printTool.ShowPreviewDialog();
            gridView1.ClearGrouping();
            gridView1.ClearSorting();
            gridView1.Columns["iddv"].Visible = true; //an cot 
            //gridView1.Columns["dinhmuc"].Visible = false; //an cot 
            //gridView1.Columns["chenhlech"].Visible = false; //an cot 
            gridView1.Columns["mau"].Visible = true; //an cot 
            gridView1.Columns["iddt"].Visible = true; //an cot 
            gridView1.Columns["mapt"].Visible = true; //an cot 

            SplashScreenManager.CloseForm(false);
        }
    }
}