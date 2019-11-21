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
    public partial class f_nhanvienlaixe : Form
    {
        private KetNoiDBDataContext db = new KetNoiDBDataContext();
        private readonly t_nhanvienlaixe dt = new t_nhanvienlaixe();

        public f_nhanvienlaixe()
        {
            InitializeComponent();
            gridControl1.DataSource = new KetNoiDBDataContext().nhanviens;
            WindowState = FormWindowState.Maximized;
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

        //btnThem
        private void btnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.hddt = 0;
            var frm = new f_themnhanvienlaixe();
            frm.ShowDialog();
            gridControl1.DataSource = new KetNoiDBDataContext().nhanviens;
        }

        //btnSua
        private void btnSua_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.hddt = 1;
            Biencucbo.ma = gridView1.GetFocusedRowCellValue("id").ToString();
            var frm = new f_themnhanvienlaixe();
            frm.ShowDialog();
            gridControl1.DataSource = new KetNoiDBDataContext().nhanviens;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Biencucbo.hddt = 1;
            Biencucbo.ma = gridView1.GetFocusedRowCellValue("id").ToString();

            var frm = new f_themnhanvienlaixe();
            frm.ShowDialog();
            gridControl1.DataSource = new KetNoiDBDataContext().nhanviens;
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

        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MsgBox.ShowYesNoCancelDialog("Bạn có chắc chắn muốn xóa Đối tượng này không?") == DialogResult.Yes)
            {
                dt.xoa(gridView1.GetFocusedRowCellValue("id").ToString());
            }
            gridControl1.DataSource = new KetNoiDBDataContext().nhanviens;
        }

        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl1.DataSource = new KetNoiDBDataContext().nhanviens;
        }

        private void f_doituong_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Nhân Viên Lái Xe");

            changeFont.Translate(this);
            changeFont.Translate(barManager1);
        }
    }
}