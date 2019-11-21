using System;
using System.Linq;
using System.Windows.Forms;
using BUS;
using ControlLocalizer;
using DAL;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;

namespace GUI
{
    public partial class f_History : Form
    {
        private readonly KetNoiDBDataContext db = new KetNoiDBDataContext();
        t_todatatable _tTodatatable = new t_todatatable();
        public f_History()
        {
            InitializeComponent();

            rTime.SetTime(thoigian);
            rTime.SetTime2(thoigian);
        }

        public void loaddata(DateTime tungay, DateTime denngay)
        {
            SplashScreenManager.ShowForm(this, typeof (SplashScreen2), true, true, false);
            var lst = from a in db.histories
                join d in db.donvis on a.donvi equals d.id
                where
                    a.thoigian >= tungay && a.thoigian <= denngay
                select new
                {
                    a.ma,
                    a.hoatdong,
                    a.nguoi,
                    a.may,
                    a.thoigian,
                    a.donvi,
                    MaTim = LayMaTim(d)
                };
            var lst2 = lst.ToList().Where(t => t.MaTim.Contains("." + Biencucbo.donvi + "."));

            gridControl1.DataSource = _tTodatatable.addlst(lst2.ToList());

            SplashScreenManager.CloseForm(false);
        }

        #region code cu

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

        #endregion

        private void f_PN_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);

            changeFont.Translate(this);
            changeFont.Translate(barManager1);

            tungay.ReadOnly = true;
            denngay.ReadOnly = true;
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
    }
}