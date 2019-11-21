using System;
using System.Windows.Forms;
using BUS;
using ControlLocalizer;
using DAL;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using Lotus;

namespace GUI
{
    public partial class f_tiente : Form
    {
        private readonly t_tiente tt = new t_tiente();

        public f_tiente()
        {
            InitializeComponent();
            gridControl1.DataSource = new KetNoiDBDataContext().tientes;
        }

        // phân quyền 
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            var q = Biencucbo.QuyenDangChon;
            if (q == null) return;

            if ((bool) q.Them)
            {
                btnThem.Visibility = BarItemVisibility.Always;
            }
            else
            {
                btnThem.Visibility = BarItemVisibility.Never;
            }
            if ((bool) q.Sua)
            {
                btnSua.Visibility = BarItemVisibility.Always;
            }
            else
            {
                btnSua.Visibility = BarItemVisibility.Never;
            }
            if ((bool) q.Xoa)
            {
                btnXoa.Visibility = BarItemVisibility.Always;
            }
            else
            {
                btnXoa.Visibility = BarItemVisibility.Never;
            }
        }

        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl1.DataSource = new KetNoiDBDataContext().tientes;
        }

        private void btnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.hdtt = 0;
            var frm = new f_themtiente();
            frm.ShowDialog();
            gridControl1.DataSource = new KetNoiDBDataContext().tientes;
        }

        private void btnSua_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.hdtt = 1;
            Biencucbo.ma = gridView1.GetFocusedRowCellValue("tiente1").ToString();
            var frm = new f_themtiente();
            frm.ShowDialog();
            gridControl1.DataSource = new KetNoiDBDataContext().tientes;
        }

        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MsgBox.ShowYesNoDialog("Bạn có chắc chắn muốn xóa Tiền tệ này không?") == DialogResult.Yes)
            {
                tt.xoa(gridView1.GetFocusedRowCellValue("tiente1").ToString());
            }
            gridControl1.DataSource = new KetNoiDBDataContext().tientes;
        }

        private void f_tiente_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Tiền Tệ");

            changeFont.Translate(this);
            changeFont.Translate(barManager1);
        }

        #region STT

        private bool cal(int _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
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

        #endregion
    }
}