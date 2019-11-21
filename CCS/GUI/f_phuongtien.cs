using System;
using System.Linq;
using System.Windows.Forms;
using BUS;
using ControlLocalizer;
using DAL;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using GUI.HoSoXeMay;
using GUI.Report.PhuongTien;
using Lotus;
using System.Drawing;

namespace GUI
{
    public partial class f_phuongtien : Form
    {
        public static string nhom = "";
        public static string g_tenct = "--Tất cả--";
        public static DateTime g_ngaycapnhat = DateTime.Now;
        private readonly KetNoiDBDataContext db = new KetNoiDBDataContext();
        private readonly t_phuongtien dt = new t_phuongtien();
        t_todatatable _tTodatatable = new t_todatatable();

        public string hide_id = "";

        public f_phuongtien()
        {
            InitializeComponent();
            //gridControl1.DataSource = new KetNoiDBDataContext().phuongtiens;
            gridControl1.DataSource = new KetNoiDBDataContext().DS_PhuongTien();

            WindowState = FormWindowState.Maximized;

            //cboNhom
            cboNhom.EditValue = "--Tất cả--";
            var editor = cboNhom.Edit as RepositoryItemComboBox;
            editor.Properties.Items.Clear();
            var lst = db.nhomphuongtiens.Select(t => t.ten);
            editor.Properties.Items.Add("--Tất cả--");
            editor.Properties.Items.AddRange(lst.ToList());

            //Chọn Công Trình: 

            var editor2 = cboCT.Edit as RepositoryItemSearchLookUpEdit;

            var lst2 = (from a in db.congtrinhs select a).ToList();

            editor2.DataSource = _tTodatatable.addlst(lst2.ToList());
            editor2.ValueMember = "id";
            editor2.DisplayMember = "tencongtrinh";

            //date
            cbongay.EditValue = DateTime.Now;
        }

        private bool _sua = false;
        // phân quyền 
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            var q = Biencucbo.QuyenDangChon;
            if (q == null) return;

            if ((bool)q.Them)
            {
                btnThem.Visibility = BarItemVisibility.Always;
            }
            else
            {
                btnThem.Visibility = BarItemVisibility.Never;
            }
            if ((bool)q.Sua)
            {
                btnSua.Visibility = BarItemVisibility.Always;
                _sua = true;
            }
            else
            {
                btnSua.Visibility = BarItemVisibility.Never;
                _sua = false;
            }
            if ((bool)q.Xoa)
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
            Biencucbo.pt = 0;
            var frm = new f_themphuongtien();
            frm.ShowDialog();
            gridControl1.DataSource = new KetNoiDBDataContext().DS_PhuongTien();
        }

        //btnSua
        private void btnSua_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.pt = 1;
            Biencucbo.ma = gridView1.GetFocusedRowCellValue("id").ToString();
            var frm = new f_themphuongtien();
            frm.ShowDialog();
            gridControl1.DataSource = new KetNoiDBDataContext().DS_PhuongTien();
        }

        private bool dble;
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            dble = true;
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

        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MsgBox.ShowYesNoCancelDialog("Bạn có chắc chắn muốn xóa Phương Tiện này không?") == DialogResult.Yes)
            {
                dt.xoa(gridView1.GetFocusedRowCellValue("id").ToString());
            }
            gridControl1.DataSource = new KetNoiDBDataContext().DS_PhuongTien();
        }

        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl1.DataSource = new KetNoiDBDataContext().DS_PhuongTien();
        }

        private void f_doituong_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Phương Tiện");

            changeFont.Translate(this);
            changeFont.Translate(barManager1);
        }

        private void btndieuchuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_sua)
            {
                try
                {
                    Biencucbo.dcpt = 1;
                    Biencucbo.ma = gridView1.GetFocusedRowCellValue("id").ToString();
                    var frm = new f_dieuchuyenphuongtien();
                    frm.ShowDialog();
                }
                catch
                {
                    Biencucbo.ma = gridView1.GetFocusedRowCellValue("id").ToString();
                    var frm = new f_dieuchuyenphuongtien();
                    frm.ShowDialog();
                }
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.sua = _sua;
            var frm = new f_DsDieuChuyenPT();
            frm.ShowDialog();
        }

        private void btnmo_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new f_DsPhuongTien();
            frm.ShowDialog();
        }

        private void btnIN_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(SplashScreen2), true, true, false);

            if (cbongay.EditValue == "") cbongay.EditValue = DateTime.Now;
            else g_ngaycapnhat = DateTime.Parse(cbongay.EditValue.ToString());
            //var lst = from a in db.phuongtiens select a;

            //check cong trỉnh
            var tenct = "";
            if (cboCT.EditValue == null) // || cboCT.EditValue.ToString() == "[EditValue is null]")
            {
                tenct = "";
                g_tenct = "--Tất cả--";
            }
            else
            {
                tenct = cboCT.EditValue.ToString();

                var lst = (from a in db.congtrinhs select a).SingleOrDefault(t => t.id == tenct);
                g_tenct = lst.id + "-" + lst.tencongtrinh;
            }

            if (cboNhom.EditValue.ToString() == "--Tất cả--")
            {
                nhom = "Tất cả";
                var xtra = new r_DsPhuongTien_all();

                //loc
                if (tenct == "")
                {
                    var lst = from a in db.phuongtiens
                              where a.ngaycapnhat <= DateTime.Parse(cbongay.EditValue.ToString())
                              select new
                              {
                                  a.id,
                                  a.ten,
                                  a.so,
                                  a.tinhtrang,
                                  tendonvi = s_tenct(a.madv), //ten cong trinh
                                  tendt = s_tendt(a.madt),
                                  a.sokhung,
                                  a.somay,
                                  a.ghichu,
                                  a.ngaycapnhat,
                                  a.nhom,
                                  a.sohd
                              };

                    xtra.DataSource = _tTodatatable.addlst(lst.ToList());
                    xtra.ShowPreviewDialog();
                }
                else
                {
                    var lst = from a in db.phuongtiens
                              where
                                  a.madv == cboCT.EditValue.ToString() &&
                                  a.ngaycapnhat <= DateTime.Parse(cbongay.EditValue.ToString())
                              select new
                              {
                                  a.id,
                                  a.ten,
                                  a.so,
                                  a.tinhtrang,
                                  tendonvi = s_tenct(a.madv), //ten cong trinh
                                  tendt = s_tendt(a.madt),
                                  a.sokhung,
                                  a.somay,
                                  a.ghichu,
                                  a.ngaycapnhat,
                                  a.nhom,
                                  a.sohd
                              };

                    xtra.DataSource = _tTodatatable.addlst(lst.ToList());
                    xtra.ShowPreviewDialog();
                }
            }
            else
            {
                nhom = cboNhom.EditValue.ToString();

                //loc
                if (tenct == "")
                {
                    var lst2 = from a in db.phuongtiens
                               where a.nhom == hide_id && a.ngaycapnhat <= DateTime.Parse(cbongay.EditValue.ToString())
                               select new
                               {
                                   a.id,
                                   a.ten,
                                   a.so,
                                   a.tinhtrang,
                                   tendonvi = s_tenct(a.madv), //ten cong trinh
                                   tendt = s_tendt(a.madt),
                                   a.sokhung,
                                   a.somay,
                                   a.ghichu,
                                   a.ngaycapnhat,
                                   a.nhom,
                                   a.sohd
                               };
                    var xtra = new r_DsPhuongTien_all();
                    xtra.DataSource = _tTodatatable.addlst(lst2.ToList());
                    xtra.ShowPreviewDialog();
                }
                else
                {
                    var lst2 = from a in db.phuongtiens
                               where
                                   a.madv == cboCT.EditValue.ToString() && a.nhom == hide_id &&
                                   a.ngaycapnhat <= DateTime.Parse(cbongay.EditValue.ToString())
                               select new
                               {
                                   a.id,
                                   a.ten,
                                   a.so,
                                   a.tinhtrang,
                                   tendonvi = s_tenct(a.madv), //ten cong trinh
                                   tendt = s_tendt(a.madt),
                                   a.sokhung,
                                   a.somay,
                                   a.ghichu,
                                   a.ngaycapnhat,
                                   a.nhom,
                                   a.sohd
                               };
                    var xtra = new r_DsPhuongTien_all();
                    xtra.DataSource = _tTodatatable.addlst(lst2.ToList());
                    xtra.ShowPreviewDialog();
                }
            }

            SplashScreenManager.CloseForm(false);
        }

        private void cboNhom_EditValueChanged(object sender, EventArgs e)
        {
            if (cboNhom.EditValue.ToString() != "--Tất cả--")
            {
                var lst =
                    (from a in db.nhomphuongtiens select a).SingleOrDefault(t => t.ten == cboNhom.EditValue.ToString());
                hide_id = lst.id;
            }
        }

        public string s_tenct(string c)
        {
            var b = "";
            try
            {
                var lst = (from a in db.congtrinhs select a).SingleOrDefault(t => t.id == c);
                b = lst.tencongtrinh;
            }
            catch
            {
            }
            return b;
        }

        public string s_tendt(string c)
        {
            var b = "";
            try
            {
                var lst = (from a in db.nhanviens select a).SingleOrDefault(t => t.id == c);
                b = lst.ten;
            }
            catch
            {
            }
            return b;
        }

        private void btnsodangkiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_sua)
            {
                try
                {
                    sodong = gridView1.FocusedRowHandle;
                    Biencucbo.idpt = gridView1.GetFocusedRowCellValue("id").ToString();
                    f_SoDangKiem frm = new f_SoDangKiem();
                    frm.ShowDialog();
                    gridControl1.DataSource = new KetNoiDBDataContext().DS_PhuongTien();
                    gridView1.FocusedRowHandle = sodong;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnbaohiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_sua)
            {
                try
                {
                    sodong = gridView1.FocusedRowHandle;
                    Biencucbo.idpt = gridView1.GetFocusedRowCellValue("id").ToString();
                    f_baohiem frm = new f_baohiem();
                    frm.ShowDialog();
                    gridControl1.DataSource = new KetNoiDBDataContext().DS_PhuongTien();
                    gridView1.FocusedRowHandle = sodong;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btngiaydiduong_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_sua)
            {
                try
                {
                    sodong = gridView1.FocusedRowHandle;
                    Biencucbo.idpt = gridView1.GetFocusedRowCellValue("id").ToString();
                    f_giaydiduong frm = new f_giaydiduong();
                    frm.ShowDialog();
                    gridControl1.DataSource = new KetNoiDBDataContext().DS_PhuongTien();
                    gridView1.FocusedRowHandle = sodong;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btntamnhaptaixuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_sua)
            {
                try
                {
                    sodong = gridView1.FocusedRowHandle;
                    Biencucbo.idpt = gridView1.GetFocusedRowCellValue("id").ToString();
                    f_tamnhaptaixuat frm = new f_tamnhaptaixuat();
                    frm.ShowDialog();
                    gridControl1.DataSource = new KetNoiDBDataContext().DS_PhuongTien();
                    gridView1.FocusedRowHandle = sodong;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            dble = false;
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (_sua)
            {
                if (dble)
                {
                    try
                    {
                        Biencucbo.pt = 1;
                        Biencucbo.ma = gridView1.GetFocusedRowCellValue("id").ToString();

                        var frm = new f_themphuongtien();
                        frm.ShowDialog();
                        gridControl1.DataSource = new KetNoiDBDataContext().DS_PhuongTien();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        private int sodong;
        private void btnlephididuong_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_sua)
            {
                try
                {
                    sodong = gridView1.FocusedRowHandle;
                    Biencucbo.idpt = gridView1.GetFocusedRowCellValue("id").ToString();
                    f_lephididuong frm = new f_lephididuong();
                    frm.ShowDialog();
                    gridControl1.DataSource = new KetNoiDBDataContext().DS_PhuongTien();
                    gridView1.FocusedRowHandle = sodong;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnCavet_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_sua)
            {
                try
                {
                    sodong = gridView1.FocusedRowHandle;
                    Biencucbo.idpt = gridView1.GetFocusedRowCellValue("id").ToString();
                    f_cavet frm = new f_cavet();
                    frm.ShowDialog();
                    gridControl1.DataSource = new KetNoiDBDataContext().DS_PhuongTien();
                    gridView1.FocusedRowHandle = sodong;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnTransport_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_sua)
            {
                try
                {
                    sodong = gridView1.FocusedRowHandle;
                    Biencucbo.idpt = gridView1.GetFocusedRowCellValue("id").ToString();
                    f_transport frm = new f_transport();
                    frm.ShowDialog();
                    gridControl1.DataSource = new KetNoiDBDataContext().DS_PhuongTien();
                    gridView1.FocusedRowHandle = sodong;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnhopdongmuaxe_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_sua)
            {
                try
                {

                    f_dshopdongmuaxe frm = new f_dshopdongmuaxe();
                    frm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}