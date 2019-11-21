using System;
using System.Linq;
using System.Windows.Forms;
using BUS;
using ControlLocalizer;
using DAL;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using Lotus;

namespace GUI
{
    
    public partial class f_account : Form
    {
        private readonly t_account ac = new t_account();
        private readonly KetNoiDBDataContext db = new KetNoiDBDataContext();

        private readonly t_tudong td = new t_tudong();

        public f_account()
        {
            InitializeComponent();
            loadData();
        }
        t_todatatable _tTodatatable = new t_todatatable();
        private void loadData()
        {
            var load = from a in db.accounts
                join d in db.donvis on a.madonvi equals d.id
                where a.madonvi == Biencucbo.donvi || d.iddv == Biencucbo.donvi
                select new
                {
                    loadid = a.id,
                    loaduname = a.uname,
                    loadname = a.name,
                    loadpass = a.pass,
                    loadphongban = a.phongban,
                    loadmadonvi = a.madonvi,
                    loaddonvi = d.tendonvi,
                    a.IsActived
                };
            dataaccount.DataSource = _tTodatatable.addlst(load.ToList());
            
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.hdaccount = 0;
            string check;
            check = "NV" + Biencucbo.donvi.Trim();
            var Lst = (from s in db.tudongs where s.maphieu == check select new {s.so}).ToList();

            if (Lst.Count() == 0)
            {
                int so;
                Biencucbo.soaccount = 1;
                so = Biencucbo.soaccount + 1;
                td.themtudong(check, so);
            }
            else
            {
                int k;
                txt1.DataBindings.Clear();
                txt1.DataBindings.Add("text", Lst, "so");
                k = Convert.ToInt32(txt1.Text);

                Biencucbo.soaccount = k;
                k = k + 1;

                td.suatudong(check, k);
            }

            var fr = new f_themaccount();
            fr.ShowDialog();

            loadData();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            var q = Biencucbo.QuyenDangChon;
            if (q == null) return;
            dataaccount.Enabled = (bool) q.Xem;

            if ((bool) q.Them)
            {
                barButtonItem4.Visibility = BarItemVisibility.Always;
            }
            else
            {
                barButtonItem4.Visibility = BarItemVisibility.Never;
            }
            if ((bool) q.Sua)
            {
                barButtonItem5.Visibility = BarItemVisibility.Always;
            }
            else
            {
                barButtonItem5.Visibility = BarItemVisibility.Never;
            }
            if ((bool) q.Xoa)
            {
                barButtonItem6.Visibility = BarItemVisibility.Always;
            }
            else
            {
                barButtonItem6.Visibility = BarItemVisibility.Never;
            }
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Biencucbo.ten == gridView2.GetFocusedRowCellValue("loadname").ToString() || Biencucbo.ten == "Admin")
            {
                Biencucbo.hdaccount = 1;
                Biencucbo.account = gridView2.GetFocusedRowCellValue("loadid").ToString();
                var frm = new f_themaccount();
                frm.ShowDialog();

                loadData();
            }
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            var q = Biencucbo.QuyenDangChon;
            if (q == null) return;
            if (q.Sua == true)
            {
                if (Biencucbo.ten == gridView2.GetFocusedRowCellValue("loadname").ToString() || Biencucbo.ten == "Admin")
                {
                    Biencucbo.hdaccount = 1;
                    Biencucbo.account = gridView2.GetFocusedRowCellValue("loadid").ToString();

                    var frm = new f_themaccount();
                    frm.ShowDialog();

                    loadData();
                }
            }
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            loadData();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MsgBox.ShowYesNoCancelDialog("Bạn có chắc chắn muốn xóa tài khoản này khỏi hệ thống?") ==
                DialogResult.Yes)
            {
                ac.xoa(gridView2.GetFocusedRowCellValue("loadid").ToString());
                loadData();
            }
        }

        private void gridView2_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!gridView2.IsGroupRow(e.RowHandle))
            {
                if (e.Info.IsRowIndicator)
                {
                    if (e.RowHandle < 0)
                    {
                        e.Info.ImageIndex = 0;
                        e.Info.DisplayText = string.Empty;
                    }
                    else
                    {
                        e.Info.ImageIndex = -1;
                        e.Info.DisplayText = (e.RowHandle + 1).ToString();
                    }
                    var _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                    var _Width = Convert.ToInt32(_Size.Width) + 20;
                    BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView2); }));
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", e.RowHandle*-1);
                var _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                var _Width = Convert.ToInt32(_Size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView2); }));
            }
        }

        private bool cal(int _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }


        private void f_account_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Tài Khoản Đăng Nhập");

            changeFont.Translate(this);
            changeFont.Translate(barManager1);
        }
    }
}