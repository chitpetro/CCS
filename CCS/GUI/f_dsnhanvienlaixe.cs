using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BUS;
using DAL;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraBars;
using DevExpress.XtraPrinting.Native.LayoutAdjustment;
using DevExpress.XtraReports.UI;
using Lotus;
using GUI.Properties;
using GUI.report.nhanvienlaixe;
using DevExpress.XtraSplashScreen;

namespace GUI
{
    public partial class f_dsnhanvienlaixe : DevExpress.XtraEditors.XtraForm
    {
        t_todatatable todt = new t_todatatable();
        t_nhanvienlaixe dt = new t_nhanvienlaixe();
        KetNoiDBDataContext dbdata = new KetNoiDBDataContext();
        private bool db = false;
        private byte[] file = null;
        private bool _sua = false;
        public f_dsnhanvienlaixe()
        {
            InitializeComponent();
        }
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

        private string layghichu(string id)
        {
            string ab = "";
            try
            {
                var lst = from a in new KetNoiDBDataContext().chamcongnvcongtrinhs
                          where a.idnv == id && a.thoigian == new DateTime(DateTime.Parse(cbothoigian.EditValue.ToString()).Year,
                              DateTime.Parse(cbothoigian.EditValue.ToString()).Month, 1)
                          select a;
                if (lst.Count() == 1)
                {
                    ab =
                        lst.Single(
                            t => t.thoigian == new DateTime(DateTime.Parse(cbothoigian.EditValue.ToString()).Year,
                                DateTime.Parse(cbothoigian.EditValue.ToString()).Month, 1)).ghichu;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return ab;
        }

        private void loaddata()
        {
            SplashScreenManager.ShowForm(this, typeof(SplashScreen2), true, true, false);

            if (txtcongtrinh2.EditValue == null)
            {
                gridControl1.DataSource = dbdata.LayDanhSachNV(new DateTime(DateTime.Parse(cbothoigian.EditValue.ToString()).Year, DateTime.Parse(cbothoigian.EditValue.ToString()).Month, 1));
            }
            else
            {
                gridControl1.DataSource = dbdata.LayDanhSachNV(new DateTime(DateTime.Parse(cbothoigian.EditValue.ToString()).Year, DateTime.Parse(cbothoigian.EditValue.ToString()).Month, 1)).Where(t => t.noicongtac == txtcongtrinh2.EditValue.ToString());
            }
            gridView1.BestFitColumns();


            try
            {
                var lst =
                    (from a in new KetNoiDBDataContext().r_dsnhanviens select a).Single(
                        t => t.id == gridView1.GetFocusedRowCellValue("id").ToString());
                try
                {
                    ImageConverter obfile = new ImageConverter();
                    hinhanh.Image = (Image)obfile.ConvertFrom(lst.hinhanh.ToArray());
                    hinhanh.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch (Exception)
                {

                    hinhanh.Image = Resources.Personnel_icon;
                    hinhanh.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                lblid.Text = "<b>Id: </b>" + lst.id;
                lblnct.Text = "<b>Nơi Công Tác: </b>" + lst.tencongtrinh;
                lblten.Text = "<b>Họ Và Tên: </b>" + lst.ten;
                lblngaysinh.Text = "<b>Ngày Sinh: </b>" + lst.ngaysinh;
                lblgioitinh.Text = "<b>Giới Tính: </b>" + lst.gioitinh;
                lblemail.Text = "<b>Email: </b>" + lst.email;
                lbldienthoai.Text = "<b>SĐT: </b>" + lst.dienthoai;
                lblquoctich.Text = "<b>Quốc Tịch: </b>" + lst.quoctich;
                lbldiachi.Text = "<b>Địa chỉ: </b>" + lst.diachi;
                lblcmnd.Text = "<b>Số CMND/Passport: </b>" + lst.cmnd;
                lblpp.Text = "<b>Chức vụ: </b>" + lst.Chucvu;
                lbltinhtrang.Text = "<b>Tình Trạng: </b>" + lst.tinhtrang;

            }
            catch (Exception)
            {
                hinhanh.Image = Resources.Personnel_icon;
                hinhanh.SizeMode = PictureBoxSizeMode.StretchImage;

                lblid.Text = "<b>Id: </b>";
                lblnct.Text = "<b>Nơi Công Tác: </b>";
                lblten.Text = "<b>Họ Và Tên: </b>";
                lblngaysinh.Text = "<b>Ngày Sinh: </b>";
                lblgioitinh.Text = "<b>Giới Tính: </b>";
                lblemail.Text = "<b>Email: </b>";
                lbldienthoai.Text = "<b>SĐT: </b>";
                lblquoctich.Text = "<b>Quốc Tịch: </b>";
                lbldiachi.Text = "<b>Địa chỉ: </b>";
                lblcmnd.Text = "<b>Số CMND/Passport: </b>";
                lblpp.Text = "<b>Passport: </b>";
                lbltinhtrang.Text = "<b>Tình Trạng: </b>";

            }
            gridView1.ClearGrouping();
            gridView1.Columns["noicongtac"].GroupIndex = 1;
            gridView1.ExpandAllGroups();
            SplashScreenManager.CloseForm(false);
        }

        private void f_dsnhanvienlaixe_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            cbothoigian.EditValue = DateTime.Now;
            loaddata();

            repositoryItemSearchLookUpEdit1.DataSource = dbdata.laydsnoicongtac();
            repositoryItemSearchLookUpEdit1.ValueMember = "tencongtrinh";
            repositoryItemSearchLookUpEdit1.DisplayMember = "tencongtrinh";
            gridView3.BestFitColumns();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            db = false;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            db = true;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (_sua)
            {
                if (db == true)
                {
                    try
                    {
                        Biencucbo.ma = gridView1.GetFocusedRowCellValue("id").ToString();
                        Biencucbo.hddt = 1;
                        f_themnhanvienlaixe frm = new f_themnhanvienlaixe();
                        frm.ShowDialog();
                        loaddata();
                    }
                    catch (Exception)
                    {


                    }

                }
                try
                {
                    var lst =
                        (from a in new KetNoiDBDataContext().r_dsnhanviens select a).Single(
                            t => t.id == gridView1.GetFocusedRowCellValue("id").ToString());
                    try
                    {
                        ImageConverter obfile = new ImageConverter();
                        hinhanh.Image = (Image)obfile.ConvertFrom(lst.hinhanh.ToArray());
                        hinhanh.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    catch (Exception)
                    {

                        hinhanh.Image = Resources.Personnel_icon;
                        hinhanh.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    lblid.Text = "<b>Id: </b>" + lst.id;
                    lblnct.Text = "<b>Nơi Công Tác: </b>" + lst.tencongtrinh;
                    lblten.Text = "<b>Họ Và Tên: </b>" + lst.ten;
                    lblngaysinh.Text = "<b>Ngày Sinh: </b>" + lst.ngaysinh;
                    lblgioitinh.Text = "<b>Giới Tính: </b>" + lst.gioitinh;
                    lblemail.Text = "<b>Email: </b>" + lst.email;
                    lbldienthoai.Text = "<b>SĐT: </b>" + lst.dienthoai;
                    lblquoctich.Text = "<b>Quốc Tịch: </b>" + lst.quoctich;
                    lbldiachi.Text = "<b>Địa chỉ: </b>" + lst.diachi;
                    lblcmnd.Text = "<b>Số CMND/Passport: </b>" + lst.cmnd;
                    lblpp.Text = "<b>Chức Vụ: </b>" + lst.Chucvu;
                    lbltinhtrang.Text = "<b>Tình Trạng: </b>" + lst.tinhtrang;

                }
                catch (Exception)
                {
                    hinhanh.Image = Resources.Personnel_icon;
                    hinhanh.SizeMode = PictureBoxSizeMode.StretchImage;

                    lblid.Text = "<b>Id: </b>";
                    lblnct.Text = "<b>Nơi Công Tác: </b>";
                    lblten.Text = "<b>Họ Và Tên: </b>";
                    lblngaysinh.Text = "<b>Ngày Sinh: </b>";
                    lblgioitinh.Text = "<b>Giới Tính: </b>";
                    lblemail.Text = "<b>Email: </b>";
                    lbldienthoai.Text = "<b>SĐT: </b>";
                    lblquoctich.Text = "<b>Quốc Tịch: </b>";
                    lbldiachi.Text = "<b>Địa chỉ: </b>";
                    lblcmnd.Text = "<b>Số CMND/Passport: </b>";
                    lblpp.Text = "<b>Passport: </b>";
                    lbltinhtrang.Text = "<b>Tình Trạng: </b>";

                }
            }

        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void btnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.hddt = 0;
            var frm = new f_themnhanvienlaixe();
            frm.ShowDialog();
            loaddata();
        }

        private void btnSua_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.hddt = 1;
            Biencucbo.ma = gridView1.GetFocusedRowCellValue("id").ToString();
            var frm = new f_themnhanvienlaixe();
            frm.ShowDialog();
            loaddata();
        }

        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MsgBox.ShowYesNoCancelDialog("Bạn có chắc chắn muốn xóa Đối tượng này không?") == DialogResult.Yes)
            {
                dt.xoa(gridView1.GetFocusedRowCellValue("id").ToString());
            }
            loaddata();
        }

        private void labelControl7_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                var lst =
                    (from a in new KetNoiDBDataContext().r_dsnhanviens select a).Single(
                        t => t.id == gridView1.GetFocusedRowCellValue("id").ToString());
                try
                {
                    ImageConverter obfile = new ImageConverter();
                    hinhanh.Image = (Image)obfile.ConvertFrom(lst.hinhanh.ToArray());
                    hinhanh.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch (Exception)
                {

                    hinhanh.Image = Resources.Personnel_icon;
                    hinhanh.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                lblid.Text = "<b>Id: </b>" + lst.id;
                lblnct.Text = "<b>Nơi Công Tác: </b>" + lst.tencongtrinh;
                lblten.Text = "<b>Họ Và Tên: </b>" + lst.ten;
                lblngaysinh.Text = "<b>Ngày Sinh: </b>" + lst.ngaysinh;
                lblgioitinh.Text = "<b>Giới Tính: </b>" + lst.gioitinh;
                lblemail.Text = "<b>Email: </b>" + lst.email;
                lbldienthoai.Text = "<b>SĐT: </b>" + lst.dienthoai;
                lblquoctich.Text = "<b>Quốc Tịch: </b>" + lst.quoctich;
                lbldiachi.Text = "<b>Địa chỉ: </b>" + lst.diachi;
                lblcmnd.Text = "<b>Số CMND/Passport: </b>" + lst.cmnd;
                lblpp.Text = "<b>Chức vụ: </b>" + lst.Chucvu;
                lbltinhtrang.Text = "<b>Tình Trạng: </b>" + lst.tinhtrang;

            }
            catch (Exception)
            {
                hinhanh.Image = Resources.Personnel_icon;
                hinhanh.SizeMode = PictureBoxSizeMode.StretchImage;

                lblid.Text = "<b>Id: </b>";
                lblnct.Text = "<b>Nơi Công Tác: </b>";
                lblten.Text = "<b>Họ Và Tên: </b>";
                lblngaysinh.Text = "<b>Ngày Sinh: </b>";
                lblgioitinh.Text = "<b>Giới Tính: </b>";
                lblemail.Text = "<b>Email: </b>";
                lbldienthoai.Text = "<b>SĐT: </b>";
                lblquoctich.Text = "<b>Quốc Tịch: </b>";
                lbldiachi.Text = "<b>Địa chỉ: </b>";
                lblcmnd.Text = "<b>Số CMND/Passport: </b>";
                lblpp.Text = "<b>Passport: </b>";
                lbltinhtrang.Text = "<b>Tình Trạng: </b>";

            }
        }

        private void btndc_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_sua)
            {
                try
                {
                    Biencucbo.ma = gridView1.GetFocusedRowCellValue("id").ToString();
                    f_dieuchuyennv frm = new f_dieuchuyennv();
                    frm.ShowDialog();
                    loaddata();
                }
                catch (Exception)
                {

                }
            }
        }

        private void btndsdc_ItemClick(object sender, ItemClickEventArgs e)
        {
            f_dsdieuchuyennv frm = new f_dsdieuchuyennv();
            frm.ShowDialog();

        }

        private void btnin_ItemClick(object sender, ItemClickEventArgs e)
        {
            ////var lst = (from a in dbdata.r_nhanviens select a);
            ////r_dsnhanvienlaixe xtra = new r_dsnhanvienlaixe();
            ////xtra.DataSource = lst;
            ////xtra.ShowPreview();

            //gridView1.Columns["id"].Visible = false;

            //Biencucbo.thang = DateTime.Parse(cbothoigian.EditValue.ToString()).Month;
            //Biencucbo.nam = DateTime.Parse(cbothoigian.EditValue.ToString()).Year;
            ////gridView1.ExpandAllGroups();

            ////gridView1.BestFitColumns();

            //r_dsnhanvienlaixe report = new r_dsnhanvienlaixe();
            //report.GridControl = gridControl1;

            //ReportPrintTool printTool = new ReportPrintTool(report);

            //printTool.ShowPreviewDialog();
            //gridView1.Columns["id"].Visible = true;

            ////gridView1.ClearGrouping();
            ////gridView1.ClearSorting();

            Biencucbo.thang = DateTime.Parse(cbothoigian.EditValue.ToString()).Month;
            Biencucbo.nam = DateTime.Parse(cbothoigian.EditValue.ToString()).Year;

            try
            {
                if (txtcongtrinh2.EditValue == null)
                {
                    r_dsnhanvien r = new r_dsnhanvien();
                    r.DataSource = dbdata.LayDanhSachNV(new DateTime(DateTime.Parse(cbothoigian.EditValue.ToString()).Year, DateTime.Parse(cbothoigian.EditValue.ToString()).Month, 1)).ToList();
                    r.ShowPreview();
                }
                else
                {
                    r_dsnhanvien r = new r_dsnhanvien();
                    r.DataSource = dbdata.LayDanhSachNV(new DateTime(DateTime.Parse(cbothoigian.EditValue.ToString()).Year, DateTime.Parse(cbothoigian.EditValue.ToString()).Month, 1)).Where(t => t.noicongtac == txtcongtrinh2.EditValue.ToString()).ToList();
                    r.ShowPreview();
                }
            }
            catch { }
        }

        private void btnchamcong_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_sua)
            {
                try
                {
                    Biencucbo.ma = gridView1.GetFocusedRowCellValue("id").ToString();
                    f_chamcong frm = new f_chamcong();
                    frm.ShowDialog();
                    loaddata();
                }
                catch
                {

                }
            }
        }


        private void txtthoigian_EditValueChanged(object sender, EventArgs e)
        {


        }

        private void barEditItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void cbothoigian_EditValueChanged(object sender, EventArgs e)
        {

            loaddata();
        }

        //xuat bang cham cong
        private void btnExport_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (txtcongtrinh2.EditValue == null)
            {
                var s = dbdata.ExportChamCong(new DateTime(DateTime.Parse(cbothoigian.EditValue.ToString()).Year, DateTime.Parse(cbothoigian.EditValue.ToString()).Month, 1));
                if (s == null) return;
                gridControl2.DataSource = s;
            }
            else
            {
                //get id cong trinh
                var _idct = (from a in dbdata.congtrinhs
                             where a.tencongtrinh == txtcongtrinh2.EditValue.ToString()
                             select new { id = a.id }).ToList();

                string _getid = _idct.ElementAt(0).id.ToString();

                var s = dbdata.ExportChamCong(new DateTime(DateTime.Parse(cbothoigian.EditValue.ToString()).Year, DateTime.Parse(cbothoigian.EditValue.ToString()).Month, 1)).Where(t => t.noicongtac == _getid);
                if (s == null) return;
                gridControl2.DataSource = s;
            }

            gridView2.BestFitColumns();

            //gridView2.Columns["thoigian"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            //gridView2.Columns["thoigian"].DisplayFormat.FormatString = "yyyy-MM-dd";

            r_Export report = new r_Export();
            report.GridControl = gridControl2;

            ReportPrintTool printTool = new ReportPrintTool(report);

            printTool.ShowPreviewDialog();

        }

        private void btnImport_ItemClick(object sender, ItemClickEventArgs e)
        {
            f_import_dsnhanvien f = new f_import_dsnhanvien();
            f.ShowDialog();

            loaddata();
        }

        private void txtcongtrinh2_EditValueChanged(object sender, EventArgs e)
        {
            loaddata();
        }
    }
}