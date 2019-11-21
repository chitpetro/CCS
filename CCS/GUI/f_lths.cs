using System;
using System.Linq;
using System.Windows.Forms;
using BUS;
using ControlLocalizer;
using DAL;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;

namespace GUI
{
    public partial class f_lths : Form
    {
        private readonly KetNoiDBDataContext db = new KetNoiDBDataContext();
        t_todatatable _tTodatatable = new t_todatatable();
        private bool doubleclick;

        public f_lths()
        {
            InitializeComponent();
            //gridControl1.DataSource = new DAL.KetNoiDBDataContext().pnhaps;
            rTime.SetTime(thoigian);
            rTime.SetTime2(thoigian);
        }

        public void loaddata(DateTime tungay, DateTime denngay)
        {
            SplashScreenManager.ShowForm(this, typeof (SplashScreen2), true, true, false);
            try
            {
                var lst = from a in db.r_pnhaps
                    join d in db.donvis on a.iddv equals d.id
                    join b in db.nguoncaps on a.idnc equals b.id into k
                    join c in db.duyeths on a.id equals c.id into l
                    from nc in k.DefaultIfEmpty()
                    from duyet in l.DefaultIfEmpty()
                    where a.ngaynhap >= tungay && a.ngaynhap <= denngay && a.idct == Biencucbo.mact
                    select new
                    {
                        a.id,
                        a.ngaynhap,
                        a.iddt,
                        a.ten,
                        a.idnv,
                        a.iddv,
                        a.sohd,
                        a.idcv,
                        t = duyet.T == null ? false : duyet.T,
                        f = duyet.F == null ? false : duyet.F,
                        a.link,
                        //dv = a.dv,
                        a.tensp,
                        a.ghichu,
                        idnc = nc.tennguoncap,
                        idsanpham = a.idsp,
                        a.soluong,
                        a.thanhtien,
                        noidung = a.diengiai,
                        a.tiente,
                        a.nguyente,
                        MaTim = LayMaTim(d)
                    };
                var lst2 = lst.ToList().Where(t => t.MaTim.Contains("." + Biencucbo.donvi + "."));

                gridControl1.DataSource = _tTodatatable.addlst(lst2.ToList());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
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
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Danh Sách Phiếu Nhập Vật Tư");

            changeFont.Translate(this);
            changeFont.Translate(barManager1);

            tungay.ReadOnly = true;
            denngay.ReadOnly = true;

            Biencucbo.getID = 0;
        }

        private void tungay_EditValueChanged(object sender, EventArgs e)
        {
        }


        private void thoigian_EditValueChanged(object sender, EventArgs e)
        {
            changeTime.thoigian_change3(thoigian, tungay, denngay);
            loaddata(DateTime.Parse(tungay.Text), DateTime.Parse(denngay.Text));
        }

        private void timkiem_Click(object sender, EventArgs e)
        {
            loaddata(DateTime.Parse(tungay.Text), DateTime.Parse(denngay.Text));
        }

        private void gridView1_DoubleClick_1(object sender, EventArgs e)
        {
            doubleclick = true;
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

        private void btnload_Click(object sender, EventArgs e)
        {
            loadall();
        }

        public void loadall()
        {
            SplashScreenManager.ShowForm(this, typeof (SplashScreen2), true, true, false);
            try
            {
                var lst = from a in db.r_pnhaps
                    join d in db.donvis on a.iddv equals d.id
                    join b in db.nguoncaps on a.idnc equals b.id into k
                    join c in db.duyeths on a.id equals c.id into l
                    from nc in k.DefaultIfEmpty()
                    from duyet in l.DefaultIfEmpty()
                    where a.idct == Biencucbo.mact
                    select new
                    {
                        a.id,
                        a.ngaynhap,
                        a.iddt,
                        a.ten,
                        a.idnv,
                        a.iddv,
                        a.idcv,
                        a.sohd,
                        t = duyet.T == null ? false : duyet.T,
                        f = duyet.F == null ? false : duyet.F,
                        a.link,
                        //dv = a.dv,
                        a.tensp,
                        a.ghichu,
                        idnc = nc.tennguoncap,
                        idsanpham = a.idsp,
                        a.soluong,
                        a.thanhtien,
                        noidung = a.diengiai,
                        a.tiente,
                        a.nguyente,
                        MaTim = LayMaTim(d)
                    };
                var lst2 = lst.ToList().Where(t => t.MaTim.Contains("." + Biencucbo.donvi + "."));

                gridControl1.DataSource = _tTodatatable.addlst(lst2.ToList());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
            SplashScreenManager.CloseForm(false);
        }
    }
}