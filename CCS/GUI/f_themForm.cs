using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using BUS;
using ControlLocalizer;
using DAL;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using Lotus;

namespace GUI
{
    public partial class f_themForm : Form
    {
        private string a = "";

        private KetNoiDBDataContext db = new KetNoiDBDataContext();

        //nút upload file
        private readonly OpenFileDialog openfile = new OpenFileDialog();
        private readonly t_tudong td = new t_tudong();
        t_todatatable _tTodatatable = new t_todatatable();
        public f_themForm()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();

            txtid.ReadOnly = true;
            txtname.ReadOnly = true;
            txtlink.ReadOnly = true;
            txtdiengiai.ReadOnly = true;

            btnluu.Enabled = false;
        }

        private void f_themaccount_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Thêm File");

            changeFont.Translate(this);
            changeFont.Translate(barManager1);

            load();
        }

        private void load()
        {
            var lst = from a in db.filehds
                join b in db.hopdong_tps
                    on a.idhopdong equals b.id
                where a.idhopdong == Biencucbo.hopdong
                select new
                {
                    b.sohd,
                    a.formName,
                    a.diengiai,
                    a.id
                };
            gridControl1.DataSource = _tTodatatable.addlst(lst.ToList());
        }

        //nut chon file
        private void buttonEdit1_Click(object sender, EventArgs e)
        {
            openfile.Title = "Chọn File";
            //openfile.InitialDirectory = @"c:\Program Files";//Thư mục mặc định khi mở
            openfile.Filter = "Pdf Files|*.pdf";

            openfile.FilterIndex = 1; //chúng ta có All files là 1,exe là 2
            openfile.RestoreDirectory = true;

            if (openfile.ShowDialog() == DialogResult.OK)
            {
                txtlink.Text = openfile.FileName;
                txtname.Text = openfile.FileName.Substring(openfile.FileName.LastIndexOf('\\') + 1);
            }
        }


        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof (SplashScreen2), true, true, false);

            Thread.Sleep(TimeSpan.FromSeconds(5));

            pdfViewer1.CloseDocument();

            var a1 = gridView1.GetFocusedRowCellValue("id").ToString();
            var lst = (from a in db.filehds select a).Single(x => x.id == a1);
            var filedata = lst.formData.ToArray();
            var str = new MemoryStream(filedata, true);

            pdfViewer1.HandTool = true;
            pdfViewer1.LoadDocument(str);

            SplashScreenManager.CloseForm(false);
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


        private void btnluu_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Biencucbo.fhd == 0)
            {
                if (txtlink.Text == "")
                    return;
                db = new KetNoiDBDataContext();

                try
                {
                    var check = "FHD" + Biencucbo.donvi.Trim();
                    var lst1 = (from s in db.tudongs where s.maphieu == check select new {s.so, s.maphieu}).ToList();

                    if (lst1.Count == 0)
                    {
                        int so;

                        so = 2;
                        td.themtudong(check, so);
                        txtid.Text = check + "_000001";
                        a = "1";
                    }
                    else
                    {
                        var lst = (from b in lst1 select b).Single(t => t.maphieu == check);
                        int k;
                        //txt1.DataBindings.Clear();
                        //txt1.DataBindings.Add("text", lst1, "so");
                        a = lst.so.ToString();
                        k = 0;

                        k = Convert.ToInt32(a);
                        var so0 = "";
                        if (k < 10)
                        {
                            so0 = "00000";
                        }
                        else if (k >= 10 & k < 100)
                        {
                            so0 = "0000";
                        }
                        else if (k >= 100 & k < 1000)
                        {
                            so0 = "000";
                        }
                        else if (k >= 1000 & k < 10000)
                        {
                            so0 = "00";
                        }
                        else if (k >= 10000 & k < 100000)
                        {
                            so0 = "0";
                        }
                        else if (k >= 100000)
                        {
                            so0 = "";
                        }
                        txtid.Text = check + "_" + so0 + k;

                        k = k + 1;

                        td.suatudong(check, k);
                    }


                    byte[] file = null;

                    if (!string.IsNullOrEmpty(txtname.Text))
                    {
                        using (var stream = new FileStream(txtlink.Text, FileMode.Open, FileAccess.Read))
                        {
                            using (var reader = new BinaryReader(stream))
                            {
                                file = reader.ReadBytes((int) stream.Length);
                            }
                        }
                    }

                    var filehd = new filehd
                    {
                        id = txtid.Text,
                        formName = txtname.Text,
                        formData = file,
                        //diengiai = txtlink.Text,
                        diengiai = txtdiengiai.Text,
                        idhopdong = Biencucbo.hopdong
                    };

                    db.filehds.InsertOnSubmit(filehd);
                    db.SubmitChanges();
                    txtlink.Text = "";
                    txtname.Text = "";
                    txtdiengiai.Text = "";
                    txtid.Text = "";
                    load();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                btnthem.Enabled = true;
                btnsua.Enabled = true;
                btnxoa.Enabled = true;
                btnluu.Enabled = false;
                btnreload.Enabled = true;
            }

            // else //nut sua
            if (Biencucbo.fhd == 1)
            {
                byte[] file = null;


                if (!string.IsNullOrEmpty(txtlink.Text))
                {
                    using (var stream = new FileStream(txtlink.Text, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = new BinaryReader(stream))
                        {
                            file = reader.ReadBytes((int) stream.Length);
                        }
                    }
                }

                var a1 = gridView1.GetFocusedRowCellValue("id").ToString();

                var filehd = db.filehds.FirstOrDefault(x => x.id == a1);
                if (filehd != null)
                {
                    filehd.formName = txtname.Text;
                    //filehd.formData = file;
                    filehd.diengiai = txtdiengiai.Text;
                    filehd.idhopdong = Biencucbo.hopdong;

                    if (file != null)
                        filehd.formData = file;

                    db.SubmitChanges();
                    XtraMessageBox.Show("Sửa thành công!", "Thông báo!", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    load();
                }
            }
        }

        private void btnsua_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.fhd = 1;
            btnthem.Enabled = false;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = true;
            btnreload.Enabled = true;

            txtid.ReadOnly = false;
            txtname.ReadOnly = false;
            txtlink.ReadOnly = false;
            txtdiengiai.ReadOnly = false;

            var id = gridView1.GetFocusedRowCellValue("id").ToString();

            var Lst = (from dt in db.filehds where dt.id == id select dt).ToList();

            txtid.DataBindings.Clear();
            txtname.DataBindings.Clear();
            txtlink.DataBindings.Clear();
            txtdiengiai.DataBindings.Clear();

            txtid.DataBindings.Add("text", Lst, "id");
            txtid.Text.Trim();

            txtname.DataBindings.Add("text", Lst, "formName".Trim());
            //txtlink.DataBindings.Add("text", Lst, "idhopdong".Trim());
            txtdiengiai.DataBindings.Add("text", Lst, "diengiai".Trim());
        }

        private void btnxoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MsgBox.ShowYesNoCancelDialog("Bạn có chắc chắn muốn xóa File này không?") == DialogResult.Yes)
            {
                var a1 = gridView1.GetFocusedRowCellValue("id").ToString();
                var fhd = (from tb in db.filehds select tb).Single(t => t.id == a1);
                db.filehds.DeleteOnSubmit(fhd);
                db.SubmitChanges();
                load();
            }
        }

        //nút thêm
        private void btnthem_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.fhd = 0;
            txtid.ReadOnly = true;
            txtname.ReadOnly = false;
            txtlink.ReadOnly = false;
            txtdiengiai.ReadOnly = false;

            btnthem.Enabled = false;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = true;
            btnreload.Enabled = true;
        }


        //nut reload
        private void btnreload_ItemClick(object sender, ItemClickEventArgs e)
        {
            db = new KetNoiDBDataContext();

            txtid.Text = "";
            txtname.Text = "";
            txtlink.Text = "";
            txtdiengiai.Text = "";

            txtid.ReadOnly = true;
            txtname.ReadOnly = true;
            txtlink.ReadOnly = true;
            txtdiengiai.ReadOnly = true;

            //btn
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnluu.Enabled = false;
            btnmo.Enabled = true;
            btnxoa.Enabled = true;
            btnreload.Enabled = false;
            Biencucbo.fhd = 2;
        }

        private void btnmo_ItemClick(object sender, ItemClickEventArgs e)
        {
        }
    }
}