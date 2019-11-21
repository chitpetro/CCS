using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using BUS;
using ControlLocalizer;
using DAL;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using GUI.Properties;
using GUI.report.chiphimay;
using GUI.Report.PhuongTien;
using Lotus;


namespace GUI
{
    public partial class f_main : RibbonForm
    {
        private KetNoiDBDataContext db = new KetNoiDBDataContext();
        t_todatatable _tTodatatable = new t_todatatable();

        private readonly t_chucnang t_cn = new t_chucnang();

        public f_main()
        {
            InitializeComponent();
            defaultLookAndFeel1.LookAndFeel.SetSkinStyle(Biencucbo.skin);
        }


        //moi 15/10
        public void setFontRibbon(RibbonControl ribbonControl)
        {
            foreach (RibbonPage page in ribbonControl.Pages)
            {
                page.Appearance.Font = new Font("Saysettha OT", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);

                foreach (RibbonPageGroup g in page.Groups)
                {
                    //ko co font 

                    foreach (BarItemLink i in g.ItemLinks)
                    {
                        i.Item.ItemAppearance.Normal.Font = new Font("Saysettha OT", 8.25F, FontStyle.Regular,
                            GraphicsUnit.Point, 0);

                        if (i.Item is BarSubItem)
                        {
                            var sub = i.Item as BarSubItem;
                            sub.Enabled = true;
                            foreach (BarItemLink y in sub.ItemLinks)
                            {
                                y.Item.ItemAppearance.Normal.Font = new Font("Saysettha OT", 8.25F, FontStyle.Regular,
                                    GraphicsUnit.Point, 0);
                            }
                        }
                    }
                }
            }
        }


        private void OpenForm<T>()
        {
            var fm = MdiChildren.FirstOrDefault(f => f is T);
            if (fm == null)
            {
                fm = Activator.CreateInstance<T>() as Form; // tao đối tượng T thôi
                fm.MdiParent = this;
                fm.Show();
            }
            else
                fm.Activate();
        }

        private void f_main_Load(object sender, EventArgs e)
        {

            DangNhap();
            try
            {
                Show();

                OpenForm<f_dscongtrinh>();
            }
            catch
            {
                Application.Exit();
            }
        }


        private void DangNhap()
        {
            // dang xuat
            foreach (var form in MdiChildren)
                form.Close();
            db.Dispose();
            db = new KetNoiDBDataContext();

            // dang nhap
            var f = new f_login();

            try
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    WindowState = FormWindowState.Maximized;
                    if (Biencucbo.idnv.Trim() != "AD")
                    {
                        btnskinht.Visibility = BarItemVisibility.Never;
                    }

                    var lst = (from a in db.skins select a).Single(t => t.trangthai == true);
                    Biencucbo.skin = lst.tenskin;
                    defaultLookAndFeel1.LookAndFeel.SetSkinStyle(Biencucbo.skin);

                    //code moi 
                    LanguageHelper.Language = (LanguageEnum)Biencucbo.ngonngu;

                    changeFont.Translate(this);
                    changeFont.Translate(ribbon);

                    LanguageHelper.Active(LanguageHelper.Language);
                    LanguageHelper.Translate(this);
                    LanguageHelper.Translate(ribbon);

                    Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "PetroLao Co.,Ltd");

                    var lst2 = (from a in db.donvis where a.id == Biencucbo.donvi select a.tendonvi).FirstOrDefault();
                    Biencucbo.tendvbc = lst2;

                    btninfo_account.Caption =
                        LanguageHelper.TranslateMsgString("." + Name + "_btn_Wellcome", "Wellcome ") + Biencucbo.ten;
                    btninfo_donvi.Caption = LanguageHelper.TranslateMsgString("." + Name + "_btn_DonVi", "Đơn vị ") +
                                            Biencucbo.donvi + "-" + Biencucbo.tendvbc;
                    btninfo_phong.Caption = LanguageHelper.TranslateMsgString("." + Name + "_btn_BoPhan", "Bộ phận ") +
                                            Biencucbo.phongban;
                    btnDb.Caption = Biencucbo.DbName;
                    btnVersion.Caption = LanguageHelper.TranslateMsgString("." + Name + "_btn_Version", "Version ") +
                                         Assembly.GetExecutingAssembly().GetName().Version;

                    // duyet ribbon
                    duyetRibbon(ribbon);

                    if (Biencucbo.ngonngu.ToString() == "Lao")
                    {
                        Font =
                            btninfo_account.ItemAppearance.Normal.Font =
                                btninfo_account.ItemAppearance.Disabled.Font =
                                    btninfo_account.ItemAppearance.Hovered.Font =
                                        btninfo_account.ItemAppearance.Pressed.Font =
                                            btninfo_donvi.ItemAppearance.Normal.Font =
                                                btninfo_donvi.ItemAppearance.Disabled.Font =
                                                    btninfo_donvi.ItemAppearance.Hovered.Font =
                                                        btninfo_donvi.ItemAppearance.Pressed.Font =
                                                            btninfo_phong.ItemAppearance.Normal.Font =
                                                                btninfo_phong.ItemAppearance.Disabled.Font =
                                                                    btninfo_phong.ItemAppearance.Hovered.Font =
                                                                        btninfo_phong.ItemAppearance.Pressed.Font =
                                                                            btnDb.ItemAppearance.Normal.Font =
                                                                                btnDb.ItemAppearance.Disabled.Font =
                                                                                    btnDb.ItemAppearance.Hovered.Font =
                                                                                        btnDb.ItemAppearance.Pressed
                                                                                            .Font =
                                                                                            btnVersion.ItemAppearance
                                                                                                .Normal.Font =
                                                                                                btnVersion
                                                                                                    .ItemAppearance
                                                                                                    .Disabled.Font =
                                                                                                    btnVersion
                                                                                                        .ItemAppearance
                                                                                                        .Hovered.Font =
                                                                                                        btnVersion
                                                                                                            .ItemAppearance
                                                                                                            .Pressed
                                                                                                            .Font =
                                                                                                            changeFont
                                                                                                                .FontLao;
                    }
                }
                else
                    Application.ExitThread();
            }
            catch (Exception ex)
            {
                MsgBox.ShowErrorDialog(ex.ToString());
            }
        }


        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            //OpenForm<f_account>();
            var frm = new f_account();
            frm.ShowDialog();
        }

        public void duyetRibbon(RibbonControl ribbonControl)
        {
            {
                foreach (RibbonPage page in ribbonControl.Pages)
                {
                    t_cn.moi(page.Name, page.Text, string.Empty);
                    foreach (RibbonPageGroup g in page.Groups)
                    {
                        t_cn.moi(g.Name, g.Text, page.Name);

                        foreach (BarItemLink i in g.ItemLinks)
                        {
                            if (i.Item == btndangxuat) continue;

                            t_cn.moi(i.Item.Name, i.Item.Caption, g.Name);

                            // lay quyen
                            //var quyen = db.PhanQuyen2s
                            //    .FirstOrDefault(p => p.TaiKhoan == Biencucbo.idnv && p.ChucNang == i.Item.Name);

                            var quyen = db.PhanQuyen2s
                                .FirstOrDefault(p => p.TaiKhoan == Biencucbo.phongban && p.ChucNang == i.Item.Name);

                            // cheat tài khoản quan tri
                            //if (Biencucbo.idnv == "AD")

                            if (Biencucbo.phongban == "AD")
                            {
                                if (quyen == null)
                                {
                                    quyen = new PhanQuyen2();
                                    quyen.TaiKhoan = Biencucbo.phongban;
                                    quyen.ChucNang = i.Item.Name;

                                    quyen.duyet = quyen.Xem = quyen.Them = quyen.Sua = quyen.Xoa = true;

                                    db.PhanQuyen2s.InsertOnSubmit(quyen);
                                    db.SubmitChanges();
                                }
                            }

                            i.Item.Enabled = quyen == null ? false : Convert.ToBoolean(quyen.Xem);
                            //if (quyen == null)
                            //{
                            //    i.Item.Visibility = BarItemVisibility.Never;
                            //}
                            //else
                            //{
                            //    if (Convert.ToBoolean(quyen.Xem))
                            //    {
                            //        i.Item.Visibility = BarItemVisibility.Always;
                            //    }
                            //    else
                            //    {
                            //        i.Item.Visibility = BarItemVisibility.Never;
                            //    }
                            //}
                            // luu vào tag của nút tren ribbon de xu ly sau
                            i.Item.Tag = quyen;


                            if (i.Item is BarSubItem)
                            {
                                var sub = i.Item as BarSubItem;
                                sub.Enabled = true;
                                foreach (BarItemLink y in sub.ItemLinks)
                                {
                                    t_cn.moi(y.Item.Name, y.Item.Caption, i.Item.Name);
                                    // lay quyen
                                    //quyen = db.PhanQuyen2s
                                    //    .FirstOrDefault(p => p.TaiKhoan == Biencucbo.idnv && p.ChucNang == y.Item.Name);
                                    quyen = db.PhanQuyen2s
                                        .FirstOrDefault(
                                            p => p.TaiKhoan == Biencucbo.phongban && p.ChucNang == y.Item.Name);

                                    // cheat tài khoản quan tri
                                    //if (Biencucbo.idnv == "AD")
                                    if (Biencucbo.phongban == "AD")
                                    {
                                        if (quyen == null)
                                        {
                                            quyen = new PhanQuyen2();
                                            //quyen.TaiKhoan = Biencucbo.idnv;
                                            quyen.TaiKhoan = Biencucbo.phongban;
                                            quyen.ChucNang = y.Item.Name;

                                            quyen.duyet = quyen.Xem = quyen.Them = quyen.Sua = quyen.Xoa = true;

                                            db.PhanQuyen2s.InsertOnSubmit(quyen);
                                            db.SubmitChanges();
                                        }
                                    }

                                    y.Item.Enabled = quyen == null ? false : Convert.ToBoolean(quyen.Xem);
                                    //if (quyen == null)
                                    //{
                                    //    y.Item.Visibility = BarItemVisibility.Never;
                                    //}
                                    //else
                                    //{
                                    //    if (Convert.ToBoolean(quyen.Xem))
                                    //    {
                                    //        y.Item.Visibility = BarItemVisibility.Always;
                                    //    }
                                    //    else
                                    //    {
                                    //        y.Item.Visibility = BarItemVisibility.Never;
                                    //    }
                                    //}
                                    // luu vào tag của nút tren ribbon de xu ly sau
                                    y.Item.Tag = quyen;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            var a = Biencucbo.ngonngu.ToString();
            var dlg = "";
            if (a == "Vietnam") dlg = "Bạn muốn đăng xuất?";
            if (a == "Lao") dlg = "ທ່ານຕ້ອງການລົງຊື່ອອກບໍ່?";

            if (MsgBox.ShowYesNoDialog(dlg) == DialogResult.Yes)
            {
                Hide();
                DangNhap();
                try
                {
                    Show();
                    OpenForm<f_dscongtrinh>();
                }
                catch
                {
                    Application.Exit();
                }
            }
        }

        private void btndoidv_ItemClick(object sender, ItemClickEventArgs e)
        {
            var ac = (from a in db.accounts select a).Single(t => t.name == Biencucbo.ten);
            Biencucbo.dvTen = ac.madonvi;

            var frm = new f_doidv();
            frm.ShowDialog();
            var lst2 = (from a in db.donvis select a).Single(t => t.id == Biencucbo.donvi);
            btninfo_donvi.Caption = Biencucbo.donvi + " - " + lst2.tendonvi;
        }

        private void btndonvi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            //OpenForm<f_donvi>();
            var frm = new f_donvi();
            frm.ShowDialog();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new f_doituong();
            frm.ShowDialog();
            //OpenForm<f_doituong>();
        }

        private void barButtonItem4_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new f_sanpham();
            frm.ShowDialog();
        }

        private void btnNhomDT_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_nhomdoituong>();
        }


        private void btnskinht_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new f_Skin();
            frm.ShowDialog();
        }


        private void btndoidonvi1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var ac = (from a in db.accounts select a).Single(t => t.name == Biencucbo.ten);
            Biencucbo.dvTen = ac.madonvi;

            var frm = new f_doidv();
            frm.ShowDialog();
            var lst2 = (from a in db.donvis select a).Single(t => t.id == Biencucbo.donvi);
            btninfo_donvi.Caption = Biencucbo.donvi + " - " + lst2.tendonvi;
        }

        private void btnhis_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new f_History();

            frm.ShowDialog();
        }

        private void btnngonngu_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            LanguageHelper.ShowTranslateTool();
        }

        private void btnclose_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MsgBox.ShowYesNoCancelDialog("Bạn muốn thoát phần mềm?") == DialogResult.Yes)
            {
                foreach (var form in MdiChildren)
                    form.Close();
                db.Dispose();
                Application.Exit();
            }
        }

        private void btnmize_ItemClick(object sender, ItemClickEventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void barButtonItem2_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new f_tiente();
            frm.ShowDialog();
            //OpenForm<f_tiente>();
        }

        private void btnTeamviewer_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                Process.Start("tv.exe");
            }
            catch
            {
                XtraMessageBox.Show("Please setup Teamviewer !");
            }
        }

        private void btnHopDong_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;

            var frm = new f_dsHopDong();
            if (Biencucbo.mact != "")
            {
                try
                {
                    var lst = from a in db.congtrinhs
                              join b in db.sxcongtrinhs on a.id equals b.idct
                              where b.idname == Biencucbo.idnv && b.idct == Biencucbo.mact
                              select a;
                    if (lst.Count() != 0)
                    {
                        frm.Show();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bạn chưa được cấp quyền theo dõi công trình này - Vui lòng kiểm tra lại");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn công trình - Vui lòng kiểm tra lại!", "Thông Báo");
            }
        }

        private void btnphanquyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            //OpenForm<FrmPhanQuyen>();
            //OpenForm<frmPhanQuyenChucNang>();
            var frm = new frmPhanQuyenChucNang();
            frm.ShowDialog();
        }

        private void btnnhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;

            var frm = new f_pnhap();
            if (Biencucbo.mact != "")
            {
                try
                {
                    var lst = from a in db.congtrinhs
                              join b in db.sxcongtrinhs on a.id equals b.idct
                              where b.idname == Biencucbo.idnv && b.idct == Biencucbo.mact
                              select a;
                    if (lst.Count() != 0)
                    {
                        frm.Show();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bạn chưa được cấp quyền theo dõi công trình này - Vui lòng kiểm tra lại");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn công trình - Vui lòng kiểm tra lại!", "Thông Báo");
            }
        }

        private void btncpql_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;

            var frm = new f_pchi();
            if (Biencucbo.mact != "")
            {
                try
                {
                    var lst = from a in db.congtrinhs
                              join b in db.sxcongtrinhs on a.id equals b.idct
                              where b.idname == Biencucbo.idnv && b.idct == Biencucbo.mact
                              select a;
                    if (lst.Count() != 0)
                    {
                        frm.Show();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bạn chưa được cấp quyền theo dõi công trình này - Vui lòng kiểm tra lại");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn công trình - Vui lòng kiểm tra lại!", "Thông Báo");
            }
        }

        private void btntinhtrang_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new f_tinhtrang();
            frm.ShowDialog();
        }

        private void btnnhompt_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new f_nhomphuongtien();
            frm.ShowDialog();
        }

        private void btnphuongtien_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new f_phuongtien();
            frm.ShowDialog();
        }

        //private void btndieuchuyen_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
        //    f_dieuchuyenphuongtien frm = new f_dieuchuyenphuongtien();
        //    frm.ShowDialog();
        //}

        private void btntheodoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Biencucbo.mact != "")
            {
                Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
                var frm = new f_ds_theodoipt2();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn công trình - Vui lòng kiểm tra lại!", "Thông Báo");
            }
        }

        private void btncpm_ItemClick(object sender, ItemClickEventArgs e)
        {

            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;

            var frm = new f_cpmay();

            if (Biencucbo.mact != "")
            {
                try
                {
                    var lst = from a in db.congtrinhs
                              join b in db.sxcongtrinhs on a.id equals b.idct
                              where b.idname == Biencucbo.idnv && b.idct == Biencucbo.mact
                              select a;
                    if (lst.Count() != 0)
                    {
                        frm.Show();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bạn chưa được cấp quyền theo dõi công trình này - Vui lòng kiểm tra lại");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn công trình - Vui lòng kiểm tra lại!", "Thông Báo");
            }
        }

        private void btnfilein_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new f_vanbanden();
            frm.Show();
        }

        private void btnfileout_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new f_vanbandi();
            frm.Show();
        }

        private void btnnhapvt_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.form = "f_bccpvt";
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new report.pnhap.f_bccpvt();
            frm.ShowDialog();
        }

        private void btnbchd_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.form = "f_bccphd_tp";
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new f_bchd();
            frm.ShowDialog();
        }

        private void btnbccpk_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            Biencucbo.form = "f_bccpk";
            var frm = new report.chiphikhac.f_bccpk();
            frm.ShowDialog();
        }

        private void btnbccpm_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.form = "f_bccpm";
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new report.chiphimay.f_bccpm();
            frm.ShowDialog();
        }

        private void bccttb_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(SplashScreen2), true, true, false);
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            try
            {
                var lstct = (from a in db.congtrinhs select a).Single(t => t.id == Biencucbo.mact);
                Biencucbo.bcct = "Công trình: " + lstct.tencongtrinh;
                Biencucbo.bcdc = "Địa điểm: " + lstct.diadiem;
                Biencucbo.bccht = "Chỉ huy trưởng: " + lstct.chihuytruong;
                var lstpn = (from a in db.r_pnhaps
                             join b in db.nguoncaps on a.idnc equals b.id into k
                             from nc in k.DefaultIfEmpty()
                             where a.idct == Biencucbo.mact
                             select new
                             {
                                 dv = "I",
                                 chiphi = "Chi phí vật tư",
                                 donvi = "Kip",
                                 loai = nc.tennguoncap,
                                 gtqt = a.thanhtien == null ? 0 : a.thanhtien,
                                 gttt = a.thanhtien == null ? 0 : a.thanhtien,
                                 gtcl = a.thanhtien == null ? 0 : a.thanhtien - a.thanhtien
                             }).ToList();
                var lsthd1 = (from a in db.hopdong_tps
                              join b in db.thanhtoan_tps on a.id equals b.idhd_tp into k
                              from hd in k.DefaultIfEmpty()
                              where a.idct == Biencucbo.mact
                              select new
                              {
                                  a.id,
                                  gttt = hd.giatritt == null ? 0 : (hd.giatritt * a.tygia) + (hd.cantru * a.tygia)
                              }).GroupBy(t => new { t.id }).Select(y => new

                              {
                                  y.Key.id,
                                  gttt = y.Sum(t => t.gttt)
                              });
                var lsthd2 = (from a in db.r_hopdongs
                              where a.idct == Biencucbo.mact
                              select new
                              {
                                  a.id,
                                  gtqt = a.thanhtien == null ? 0 : a.thanhtien
                              }).GroupBy(t => new { t.id }).Select(y => new

                              {
                                  y.Key.id,
                                  gtqt = y.Sum(t => t.gtqt)
                              });


                var lsthd = (from a in db.r_hopdongs
                             join b in lsthd1 on a.id equals b.id
                             join c in lsthd2 on a.id equals c.id
                             //where a.idct == Biencucbo.mact
                             select new
                             {
                                 dv = "II",
                                 chiphi = "Chi phí hợp đồng",
                                 donvi = "Kip",
                                 loai =
                                     "- Số HĐ:" + a.sohd + " - Đối tác: " + a.tendt + "\n- " + a.ngaybd + "/" + a.ngaykt + "\n" +
                                     "- Nội Dung: " + a.noidunghd,
                                 c.gtqt,
                                 b.gttt,
                                 gtcl = c.gtqt - b.gttt
                             }).GroupBy(t => new

                             {
                                 t.dv,
                                 t.chiphi,
                                 t.donvi,
                                 t.loai,
                                 t.gtqt,
                                 t.gttt,
                                 t.gtcl
                             }).Select(y => new
                             {
                                 y.Key.dv,
                                 y.Key.chiphi,
                                 y.Key.donvi,
                                 y.Key.loai,
                                 y.Key.gtqt,
                                 y.Key.gttt,
                                 y.Key.gtcl
                             })
                    ;
                var lstcpm = (from a in db.r_cpmays
                              join b in db.dmcpms on a.loaichi equals b.id
                              where a.idct == Biencucbo.mact
                              select new
                              {
                                  dv = "III",
                                  chiphi = "Chi phí máy",
                                  donvi = "Kip",
                                  loai = b.loaichi,
                                  gtqt = a.sotien == null ? 0 : a.sotien,
                                  gttt = a.sotien == null ? 0 : a.sotien,
                                  gtcl = (a.sotien == null ? 0 : a.sotien) - (a.sotien == null ? 0 : a.sotien)
                              }).ToList();
                var lstcpk = (from a in db.r_pchis
                              join b in db.dmpchis on a.loaichi equals b.danhmuc
                              where a.idct == Biencucbo.mact
                              select new
                              {
                                  dv = "IV",
                                  chiphi = "Chi phí khác",
                                  donvi = "Kip",
                                  loai = b.danhmuc_l,
                                  gtqt = a.sotien == null ? 0 : a.sotien,
                                  gttt = a.sotien == null ? 0 : a.sotien,
                                  gtcl = (a.sotien == null ? 0 : a.sotien) - (a.sotien == null ? 0 : a.sotien)
                              }).ToList();
                var lst =
                    (from a in lstpn select a).Concat(from b in lsthd select b)
                        .Concat(from c in lstcpm select c)
                        .Concat(from d in lstcpk select d)
                        .GroupBy(t => new { t.loai, t.dv, t.chiphi, t.donvi })
                        .Select(y => new
                        {
                            y.Key.dv,
                            y.Key.donvi,
                            y.Key.chiphi,
                            y.Key.loai,
                            gtqt = y.Sum(t => t.gtqt),
                            gttt = y.Sum(t => t.gttt),
                            gtcl = y.Sum(t => t.gtcl)
                        });
                ;
                var xtra = new r_bccttb();
                xtra.DataSource = _tTodatatable.addlst(lst.ToList());
                xtra.ShowPreviewDialog();
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.ToString());
            }
            SplashScreenManager.CloseForm(false);
        }

        private void btnbcthtb_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(SplashScreen2), true, true, false);
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            try
            {
                var lstct = (from a in db.congtrinhs select a).Single(t => t.id == Biencucbo.mact);
                Biencucbo.bcct = "Công trình: " + lstct.tencongtrinh;
                Biencucbo.bcdc = "Địa điểm: " + lstct.diadiem;
                Biencucbo.bccht = "Chỉ huy trưởng: " + lstct.chihuytruong;
                var lstpn = (from a in db.r_pnhaps
                             join b in db.nguoncaps on a.idnc equals b.id into k
                             from nc in k.DefaultIfEmpty()
                             where a.idct == Biencucbo.mact
                             select new
                             {
                                 dv = "I",
                                 chiphi = "Chi phí vật tư",
                                 donvi = "Kip",
                                 loai = nc.tennguoncap,
                                 gtqt = a.thanhtien == null ? 0 : a.thanhtien,
                                 gttt = a.thanhtien == null ? 0 : a.thanhtien,
                                 gtcl = a.thanhtien == null ? 0 : a.thanhtien - a.thanhtien
                             }).ToList();


                var lsthd1 = (from a in db.hopdong_tps
                              join b in db.thanhtoan_tps on a.id equals b.idhd_tp into k
                              from hd in k.DefaultIfEmpty()
                              where a.idct == Biencucbo.mact
                              select new
                              {
                                  a.id,
                                  gttt = hd.giatritt == null ? 0 : (hd.giatritt * a.tygia) + (hd.cantru * a.tygia)
                              }).GroupBy(t => new { t.id }).Select(y => new

                              {
                                  y.Key.id,
                                  gttt = y.Sum(t => t.gttt)
                              });
                var lsthd2 = (from a in db.r_hopdongs
                              where a.idct == Biencucbo.mact
                              select new
                              {
                                  a.id,
                                  gtqt = a.thanhtien == null ? 0 : a.thanhtien
                              }).GroupBy(t => new { t.id }).Select(y => new

                              {
                                  y.Key.id,
                                  gtqt = y.Sum(t => t.gtqt)
                              });


                var lsthd = (from a in db.r_hopdongs
                             join b in lsthd1 on a.id equals b.id
                             join c in lsthd2 on a.id equals c.id
                             //where a.idct == Biencucbo.mact
                             select new
                             {
                                 dv = "II",
                                 chiphi = "Chi phí hợp đồng",
                                 donvi = "Kip",
                                 loai =
                                     "- Số HĐ:" + a.sohd + " - Đối tác: " + a.tendt + "\n- " + a.ngaybd + "/" + a.ngaykt + "\n" +
                                     "- Nội Dung: " + a.noidunghd,
                                 c.gtqt,
                                 b.gttt,
                                 gtcl = c.gtqt - b.gttt
                             }).GroupBy(t => new

                             {
                                 t.dv,
                                 t.chiphi,
                                 t.donvi,
                                 t.loai,
                                 t.gtqt,
                                 t.gttt,
                                 t.gtcl
                             }).Select(y => new
                             {
                                 y.Key.dv,
                                 y.Key.chiphi,
                                 y.Key.donvi,
                                 y.Key.loai,
                                 y.Key.gtqt,
                                 y.Key.gttt,
                                 y.Key.gtcl
                             })
                    ;
                var lstcpm = (from a in db.r_cpmays
                              join b in db.dmcpms on a.loaichi equals b.id
                              where a.idct == Biencucbo.mact
                              select new
                              {
                                  dv = "III",
                                  chiphi = "Chi phí máy",
                                  donvi = "Kip",
                                  loai = b.loaichi,
                                  gtqt = a.sotien == null ? 0 : a.sotien,
                                  gttt = a.sotien == null ? 0 : a.sotien,
                                  gtcl = (a.sotien == null ? 0 : a.sotien) - (a.sotien == null ? 0 : a.sotien)
                              }).ToList();
                var lstcpk = (from a in db.r_pchis
                              join b in db.dmpchis on a.loaichi equals b.danhmuc
                              where a.idct == Biencucbo.mact
                              select new
                              {
                                  dv = "IV",
                                  chiphi = "Chi phí khác",
                                  donvi = "Kip",
                                  loai = b.danhmuc_l,
                                  gtqt = a.sotien == null ? 0 : a.sotien,
                                  gttt = a.sotien == null ? 0 : a.sotien,
                                  gtcl = (a.sotien == null ? 0 : a.sotien) - (a.sotien == null ? 0 : a.sotien)
                              }).ToList();
                var lst =
                    (from a in lstpn select a).Concat(from b in lsthd select b)
                        .Concat(from c in lstcpm select c)
                        .Concat(from d in lstcpk select d)
                        .GroupBy(t => new { t.loai, t.dv, t.chiphi, t.donvi })
                        .Select(y => new
                        {
                            y.Key.dv,
                            y.Key.donvi,
                            y.Key.chiphi,
                            y.Key.loai,
                            gtqt = y.Sum(t => t.gtqt),
                            gttt = y.Sum(t => t.gttt),
                            gtcl = y.Sum(t => t.gtcl)
                        });
                ;
                var xtra = new r_bcthtb();
                xtra.DataSource = _tTodatatable.addlst(lst.ToList());
                xtra.ShowPreviewDialog();
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.ToString());
            }
            SplashScreenManager.CloseForm(false);
        }

        private void btnthcpall_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            try
            {
                var frm = new f_bcthall();
                frm.ShowDialog();
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnthgtall_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            try
            {
                var frm = new f_bcthcpall();
                frm.ShowDialog();
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btndinoibo_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.linkvb = 0;
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new f_vanbandinb();
            frm.Show();
        }

        private void btndennoibo_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new f_vanbandennb();
            frm.Show();
        }

        private void btnbctdtt_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.form = "f_bctdtt";
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new report.theodoitt.f_bctdtt();
            frm.ShowDialog();
        }

        private void btnhd_cdt_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;

            var frm = new f_dsHopDong_cdt();
            if (Biencucbo.mact != "")
            {
                try
                {
                    var lst = from a in db.congtrinhs
                              join b in db.sxcongtrinhs on a.id equals b.idct
                              where b.idname == Biencucbo.idnv && b.idct == Biencucbo.mact
                              select a;
                    if (lst.Count() != 0)
                    {
                        frm.ShowDialog();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bạn chưa được cấp quyền theo dõi công trình này - Vui lòng kiểm tra lại");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn công trình - Vui lòng kiểm tra lại!", "Thông Báo");
            }
        }

        private void btnbchdcdt_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new f_bchd_cdt();
            frm.ShowDialog();
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new f_tiente();
            frm.ShowDialog();
        }

        private void btnnvlx_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new f_dsnhanvienlaixe();
            frm.ShowDialog();
        }

        private void f_main_Activated(object sender, EventArgs e)
        {
            //db = new KetNoiDBDataContext();
            var lst = (from a in db.vanbandens
                       join b in db.donvis on a.iddv equals b.id
                       join c in db.doituongs on a.iddt equals c.id
                       join d in db.accounts on a.idnv equals d.id into k
                       from nv in k.DefaultIfEmpty()
                           //join e in db.loaivanbans on a.loaivb equals e.id
                       where a.noibo == true && a.duyet == false &&
                             a.iddv == Biencucbo.dvTen
                       select new
                       {
                           a.id,
                           a.ngaynhan,
                           a.iddt,
                           tendoituong = c.ten,
                           a.idnv,
                           tennv = nv.name,
                           iddv = nv.id,
                           b.tendonvi,
                           a.loaivb,
                           a.duyet,
                           a.sovb,
                           a.noidung,
                           a.trichyeu
                       }).ToList();
            if (lst.Count() == 0)
            {
                btntb.Glyph = Resources.Apps_Notifications_icon__1_;
            }
            else
            {
                btntb.Glyph = Resources.cotb;
            }

            try
            {
                //var lst1 = (from a in db.skins select a).Single(t => t.trangthai == true);
                //Biencucbo.skin = lst1.tenskin;
                //defaultLookAndFeel1.LookAndFeel.SetSkinStyle(Biencucbo.skin);
            }
            catch
            {
            }
        }

        private void btnlths_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new f_lichtrinh();
            frm.ShowDialog();
        }

        private void btntdthgt_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            try
            {
                var frm = new f_bcthgtall();
                frm.ShowDialog();
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.ToString());
            }
        }

        //private void btnDSTheoDoiPT_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    //Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
        //    //Report.PhuongTien.f_DsTheoDoiPT frm = new Report.PhuongTien.f_DsTheoDoiPT();
        //    //frm.ShowDialog();
        //}

        private void btnPT_TongHop_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new f_tonghop();
            frm.ShowDialog();
        }

        private void btnlinkhs_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            try
            {
                Biencucbo.form = "f_bclink";
                var frm = new report.ktlink.f_bclink();
                frm.ShowDialog();
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ribbon_Click(object sender, EventArgs e)
        {
        }

        private void btnnpxmhomdoituong_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new f_pxm_dsnhomdoituong();
            frm.ShowDialog();
        }

        private void btnpxmdoituong_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new f_pxmdsdoituong();
            frm.ShowDialog();
        }

        private void btnloaisp_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new f_pxmdsloaisp();
            frm.ShowDialog();
        }

        private void btnvattu_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new f_pxmdssanpham();
            frm.ShowDialog();
        }

        private void btnnhapkho_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;

            var frm = new f_pxmnhapkho();
            if (Biencucbo.mact != "")
            {
                try
                {
                    var lst = from a in db.congtrinhs
                              join b in db.sxcongtrinhs on a.id equals b.idct
                              where b.idname == Biencucbo.idnv && b.idct == Biencucbo.mact
                              select a;
                    if (lst.Count() != 0)
                    {
                        frm.Show();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bạn chưa được cấp quyền theo dõi công trình này - Vui lòng kiểm tra lại");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn công trình - Vui lòng kiểm tra lại!", "Thông Báo");
            }

            //var frm = new f_pxmnhapkho();
            //frm.Show();
        }

        private void btnpxuatkho_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;

            var frm = new f_pxmxuatkho();
            if (Biencucbo.mact != "")
            {
                try
                {
                    var lst = from a in db.congtrinhs
                              join b in db.sxcongtrinhs on a.id equals b.idct
                              where b.idname == Biencucbo.idnv && b.idct == Biencucbo.mact
                              select a;
                    if (lst.Count() != 0)
                    {
                        frm.Show();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bạn chưa được cấp quyền theo dõi công trình này - Vui lòng kiểm tra lại");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn công trình - Vui lòng kiểm tra lại!", "Thông Báo");
            }
        }

        private void btnpxmbcnhapkho_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.form = "f_pxmbcnhapkho";
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new report.dk_report.f_pxmbcnhapkho();
            frm.ShowDialog();
        }

        private void btnpxmxuatnb_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;

            var frm = new f_pxmpxuatkhoNB();
            if (Biencucbo.mact != "")
            {
                try
                {
                    var lst = from a in db.congtrinhs
                              join b in db.sxcongtrinhs on a.id equals b.idct
                              where b.idname == Biencucbo.idnv && b.idct == Biencucbo.mact
                              select a;
                    if (lst.Count() != 0)
                    {
                        frm.Show();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bạn chưa được cấp quyền theo dõi công trình này - Vui lòng kiểm tra lại");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn công trình - Vui lòng kiểm tra lại!", "Thông Báo");
            }
        }

        private void btnpxmnhapnb_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;

            var frm = new f_pxmpnhapkhoNB();
            if (Biencucbo.mact != "")
            {
                try
                {
                    var lst = from a in db.congtrinhs
                              join b in db.sxcongtrinhs on a.id equals b.idct
                              where b.idname == Biencucbo.idnv && b.idct == Biencucbo.mact
                              select a;
                    if (lst.Count() != 0)
                    {
                        frm.Show();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bạn chưa được cấp quyền theo dõi công trình này - Vui lòng kiểm tra lại");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn công trình - Vui lòng kiểm tra lại!", "Thông Báo");
            }
        }

        private void btnpxmbcxuatkho_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.form = "f_pxmbcxuatkho";
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new report.dk_report.f_pxmbcxuatkho();
            frm.ShowDialog();
        }

        private void btnpxmbcnxt_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.form = "f_pxmbcNhapXuatTon";
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new report.PXM.f_pxmbcNhapXuatTon();
            frm.ShowDialog();

        }

        private void btnbcchenhlech_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.form = "f_pxmbcchenhlech";
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new report.PXM.f_pxmbcchenhlech();
            frm.ShowDialog();
        }

        private void btndmchiphi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new danhmuc.f_dsmuccp();
            frm.ShowDialog();
        }

        private void btndutoanvattu_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            var frm = new dutoan.chucnang.f_dutoan_pnhap();
            frm.ShowDialog();
        }
    }
}