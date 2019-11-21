using System;
using System.Linq;
using System.Windows.Forms;
using BUS;
using ControlLocalizer;
using DAL;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;

namespace GUI
{
    public partial class f_duyettt : Form
    {
        private readonly KetNoiDBDataContext db = new KetNoiDBDataContext();
        private bool doubleclick;
        private t_doituong dt = new t_doituong();
        t_todatatable _tTodatatable = new t_todatatable();

        public f_duyettt()
        {
            InitializeComponent();
            var lst = from a in db.thanhtoan_tps
                where a.idhd_tp == Biencucbo.ma
                select new
                {
                    a.id,
                    a.ngaytt,
                    a.giatriqt,
                    a.giatritt,
                    a.diengiai,
                    a.lan,
                    a.ghichu,
                    duyet = checkduyet(a.id)
                };
            gridControl1.DataSource = _tTodatatable.addlst(lst.ToList());
            WindowState = FormWindowState.Maximized;
        }

        public bool checkduyet(string id)
        {
            var b = false;
            var lst = (from a in db.duyeths where a.id == id select a).ToList();
            if (lst.Count() == 0)
                b = false;
            else
                b = true;
            return b;
        }

        // phân quyền 
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            var q = Biencucbo.QuyenDangChon;
            if (q == null) return;

            btnduyet.Enabled = (bool) q.Them;
        }

        //btnThem


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


        private void f_doituong_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Duyệt Thanh Toán");

            changeFont.Translate(this);
            changeFont.Translate(barManager1);
        }

        private void btnduyet_ItemClick(object sender, ItemClickEventArgs e)
        {
            var hs = new t_history();

            Biencucbo.idduyet = gridView1.GetFocusedRowCellValue("id").ToString();
            Biencucbo.loaiduyet = "Thanh Toán HĐ Thầu Phụ";
            var frm = new f_duyeths();
            frm.ShowDialog();
            var lst = from a in db.thanhtoan_tps
                where a.idhd_tp == Biencucbo.ma
                select new
                {
                    a.id,
                    a.ngaytt,
                    a.giatriqt,
                    a.giatritt,
                    a.diengiai,
                    a.lan,
                    a.ghichu,
                    duyet = checkduyet(a.id)
                };
            gridControl1.DataSource = _tTodatatable.addlst(lst.ToList());
            hs.add(Biencucbo.ma, "Duyệt Thanh Toán");
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            doubleclick = false;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            doubleclick = true;
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (doubleclick)
            {
                Biencucbo.idduyet = gridView1.GetFocusedRowCellValue("id").ToString();
                Biencucbo.loaiduyet = "Thanh Toán HĐ Thầu Phụ";
                var frm = new f_duyeths();
                frm.ShowDialog();
                var lst = from a in db.thanhtoan_tps
                    where a.idhd_tp == Biencucbo.ma
                    select new
                    {
                        a.id,
                        a.ngaytt,
                        a.giatriqt,
                        a.giatritt,
                        a.diengiai,
                        a.lan,
                        a.ghichu,
                        duyet = checkduyet(a.id)
                    };
                gridControl1.DataSource = _tTodatatable.addlst(lst.ToList());
            }
        }
    }
}