using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS;
using ControlLocalizer;
using DAL;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using GUI.Report.Nhap;
using Lotus;
using DevExpress.XtraEditors;

namespace GUI
{
    public partial class f_dscongtrinh : RibbonForm
    {
        private readonly KetNoiDBDataContext db = new KetNoiDBDataContext();
        private bool doubleclick;
        private bool khopxm = false;
        private readonly t_themcongtrinh dt = new t_themcongtrinh();
        t_todatatable _tTodatatable = new t_todatatable();
        public f_dscongtrinh()
        {
            InitializeComponent();

            var lst = from a in db.congtrinhs
                //join d in db.accounts on a.iduser equals d.id 
                select new
                {
                    a.id,
                    a.tencongtrinh,
                    a.khuvuc,
                    a.diadiem,
                    a.ngaybd,
                    a.ngaykt,
                    a.loaict,
                    a.khopxm,
                    //d.name,
                    a.chihuytruong,
                    a.cdt,
                    ht = a.ht == null ? false : a.ht
                };
            if (khopxm)
            {
                lst = lst.Where(t => t.khopxm == true);
            }
            gridControl1.DataSource = _tTodatatable.addlst(lst.ToList());
            gridView1.BestFitColumns();
            gridView1.Columns[0].Width = 30;
            gridView1.Columns[1].Width = 70;
            gridView1.Columns[3].Width = 100;
            gridView1.Columns[8].Width = 25;
        }

        public void loaddata()
        {
            if (khopxm)
            {
                btscongtrinhql.Checked = false;
                btscongtrinhql.Visibility = BarItemVisibility.Never;
            }
            try
            {
                //var lst = from a in db.congtrinhs
                //    //join d in db.accounts on a.iduser equals d.id
                //    select new
                //    {
                //        a.id,
                //        a.tencongtrinh,
                //        a.khuvuc,
                //        a.diadiem,
                //        a.ngaybd,
                //        a.ngaykt,
                //        a.loaict,
                //        a.khopxm,
                //        //d.name,
                //        a.chihuytruong,
                //        a.cdt,
                //        a.gthanmuc
                //    };

                //if (khopxm)
                //{
                //    lst.Where(t => t.khopxm == true);
                //}
                //gridControl1.DataSource = _tTodatatable.addlst(lst.ToList());

                if (btscongtrinhql.Checked == false)
                {
                  var lst = from a in db.congtrinhs
                              join b in db.sxcongtrinhs on a.id equals b.idct
                              where b.idname == Biencucbo.idnv
                              select a;
                    if (khopxm)
                    {
                        lst = lst.Where(t => t.khopxm == true);
                    }

                    gridControl1.DataSource = _tTodatatable.addlst(lst.ToList());
                }
                else
                {
                    var lst = from a in db.congtrinhs
                              select a;
                    if (khopxm)
                    {
                        lst = (from a in lst where a.khopxm == true select a);
                    }
                    gridControl1.DataSource = _tTodatatable.addlst(lst.ToList());
                }
                Biencucbo.mact = gridView1.GetFocusedRowCellValue("id").ToString();
                lblcongtrinh.Caption = "Công Trình: " + gridView1.GetFocusedRowCellValue("id") + "-" +
                                       gridView1.GetFocusedRowCellValue("tencongtrinh");
            }
            catch (Exception ex)
            {
                MsgBox.ShowErrorDialog(ex.ToString());
            }
          
        }


        private void f_PN_Load(object sender, EventArgs e)
        {
            try
            {
                khopxm = Convert.ToBoolean((from a in db.accounts select a).Single(t => t.id == Biencucbo.idnv).khopxm);
            }
            catch (Exception ex)
            {
                khopxm = false;
            }
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Danh Sách Công Trình");

            changeFont.Translate(this);
            changeFont.Translate(barManager1);

            btscongtrinhql.Appearance.BackColor = Color.LightYellow;
            btscongtrinhql.Checked = true;
            //var lst = (from a in db.congtrinhs
            //           join b in db.sxcongtrinhs on a.id equals b.idct
            //           where b.idname == Biencucbo.idnv
            //           select a);
            //gridControl1.DataSource = _tTodatatable.addlst(lst.ToList());


            loaddata();

            //if (khopxm)
            //{
            //    gridControl1.DataSource =(from a in new KetNoiDBDataContext().congtrinhs where a.khopxm == true select a);
            //}
            //else
            //{
            //    gridControl1.DataSource = new KetNoiDBDataContext().congtrinhs;
            //}

            Biencucbo.getID = 0;
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
            try
            {
                Biencucbo.mact = gridView1.GetFocusedRowCellValue("id").ToString();
                lblcongtrinh.Caption = "Công Trình: " + gridView1.GetFocusedRowCellValue("id") + "-" +
                                       gridView1.GetFocusedRowCellValue("tencongtrinh");
                if (doubleclick)
                {
                    if (Biencucbo.idnv != "AD")
                    {
                        return;
                    }
                    Biencucbo.hdct = 1;
                    Biencucbo.ma = gridView1.GetFocusedRowCellValue("id").ToString();
                    ;

                    var frm = new f_themcongtrinh();
                    frm.ShowDialog();
                    SplashScreenManager.ShowForm(typeof(SplashScreen1));
                 
                    loaddata();
                    
                    SplashScreenManager.CloseForm(false);
                }
            }
            catch
            {
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            doubleclick = true;
        }


        private void btnthem_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Biencucbo.idnv != "AD")
            {
                MessageBox.Show(
                    "Bạn không có quyền tham gia chức năng này - Vui lòng liên hệ Admin để được hướng dẫn xử lý!",
                    "THÔNG BÁO");
                return;
            }
            Biencucbo.hdct = 0;
            var frm = new f_themcongtrinh();
            frm.ShowDialog();
            SplashScreenManager.ShowForm(typeof(SplashScreen1));
            
            loaddata();
            
            SplashScreenManager.CloseForm(false);
        }

        private void btnsua_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Biencucbo.idnv != "AD")
            {
                MessageBox.Show(
                    "Bạn không có quyền tham gia chức năng này - Vui lòng liên hệ Admin để được hướng dẫn xử lý!",
                    "THÔNG BÁO");
                return;
            }
            Biencucbo.hdct = 1;
            Biencucbo.ma = gridView1.GetFocusedRowCellValue("id").ToString();
            var frm = new f_themcongtrinh();
            frm.ShowDialog();
            if (khopxm)
            {
                gridControl1.DataSource = (from a in new KetNoiDBDataContext().congtrinhs where a.khopxm == true select a);
            }
            else
            {
                gridControl1.DataSource = new KetNoiDBDataContext().congtrinhs;
            }
        }

        private void btnxoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Biencucbo.idnv != "AD")
            {
                MessageBox.Show(
                    "Bạn không có quyền tham gia chức năng này - Vui lòng liên hệ Admin để được hướng dẫn xử lý!",
                    "THÔNG BÁO");
                return;
            }
            if (MsgBox.ShowYesNoCancelDialog("Bạn có chắc chắn muốn xóa Đối tượng này không?") == DialogResult.Yes)
            {
                dt.xoa(gridView1.GetFocusedRowCellValue("id").ToString());
            }
            if (khopxm)
            {
                gridControl1.DataSource = (from a in new KetNoiDBDataContext().congtrinhs where a.khopxm == true select a);
            }
            else
            {
                gridControl1.DataSource = new KetNoiDBDataContext().congtrinhs;
            }
        }

       

        private void btscongtrinhql_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (btscongtrinhql.Checked == false)
            {
                e.Item.Appearance.BackColor = Color.LightYellow;
                var lst = from a in db.congtrinhs
                    join b in db.sxcongtrinhs on a.id equals b.idct
                    where b.idname == Biencucbo.idnv
                    select a;
                if (khopxm)
                {
                  lst =  lst.Where(t => t.khopxm == true);
                }
               
                gridControl1.DataSource = _tTodatatable.addlst(lst.ToList());
            }
            else
            {
                e.Item.Appearance.BackColor = Color.Transparent;
                var lst = from a in db.congtrinhs
                    select a;
                if (khopxm)
                {
                    lst = lst.Where(t => t.khopxm == true);
                }
                gridControl1.DataSource = _tTodatatable.addlst(lst.ToList());
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                Biencucbo.mact = gridView1.GetFocusedRowCellValue("id").ToString();
                lblcongtrinh.Caption = "Công Trình: " + gridView1.GetFocusedRowCellValue("id") + "-" +
                                       gridView1.GetFocusedRowCellValue("tencongtrinh");
              
            }
            catch
            {
            }
        }

        private void btnsx_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (Biencucbo.idnv == "AD")
                {
                    var frm = new f_sxcongtrinh();
                    frm.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show("Bạn không có quyền truy cập chức năng này", "THÔNG BÁO");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}