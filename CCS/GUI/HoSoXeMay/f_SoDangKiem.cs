using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BUS;
using DAL;
using DevExpress.XtraBars;
using GUI.Properties;


namespace GUI.HoSoXeMay
{
    public partial class f_SoDangKiem : frmp
    {
        c_dangkiem dk = new c_dangkiem();
        t_history hs = new t_history();
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        private readonly OpenFileDialog openfile = new OpenFileDialog();
        private int _so;
        private int _hdong;
        private string _key = "";
        private string _mapt = "";

        public f_SoDangKiem()
        {
            InitializeComponent();
            btnin.Visibility = BarItemVisibility.Never;
            btnduyet.Visibility = BarItemVisibility.Never;
        }
        private void xoatxt()
        {
            txtid.Text = "";
            txtngaydk.Text = "";
            txtthoihan.Text = "1";
            txtdiengiai.Text = "";
            txttenfile.Text = "";
            txttype.Text = "";
            txtduongdan.Text = "";
            dongedit();
        }

        private string _keytemp = "";
        private void themtxt()
        {
            _keytemp = _key;
            _key = MD5.laykey();
            gd.DataSource = (from a in db.dangkiem_files where a.keydk == _key select a);
            xoatxt();
            txtid.Text = "YYYY";
            txtthoihan.Text = "12";
            _hdong = 0;
            moedit();
        }

        private void moedit()
        {
            txtngaydk.ReadOnly = false;
            txtthoihan.ReadOnly = false;
            txtdiengiai.ReadOnly = false;

        }

        private void dongedit()
        {
            txtngaydk.ReadOnly = true;
            txtthoihan.ReadOnly = true;
            txtdiengiai.ReadOnly = true;
            _hdong = 2;
        }

        private void loadinfo(string key)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().dangkiems select a).Single(t => t.key == key);
                txtid.Text = lst.id;
                txtngaydk.DateTime = DateTime.Parse(lst.ngaydk.ToString());
                txtthoihan.Text = lst.thoihan.ToString();
                txtdiengiai.Text = lst.diengiai;
                gd.DataSource = lst.dangkiem_files;
                _key = lst.key;
                _so = Convert.ToInt32(lst.so);
                dongedit();
                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private bool kiemtra()
        {
            int checknull = 0;
            int checdup = 0;
            txtngaydk.Properties.ContextImage = null;

            if (txtngaydk.Text == string.Empty)
                checknull++;

            if (checknull > 0)
            {
                XtraMessageBox.Show("Thông Tin Chưa Đầy Đủ - Vui Lòng Kiểm Tra Lại", "Thông báo");
                txtngaydk.Properties.ContextImage = Resources.trong;
            }
            var lst = (from a in new KetNoiDBDataContext().dangkiems where a.idpt == _mapt select a);

            try
            {
                if (_hdong == 0)
                {
                    if (txtngaydk.DateTime <= lst.Single(t => t.so == lst.Max(y => y.so)).ngaydk)
                    {
                        txtngaydk.Properties.ContextImage = Resources.trung;
                        checdup++;
                    }
                }
            }
            catch (Exception ex)
            {

            }

            if (checdup > 0)
                XtraMessageBox.Show("Ngày đăng ký bị trùng hoặc sai");
            if (checdup > 0 || checknull > 0)
                return false;
            return true;
        }

        #region override


        protected override void load()
        {
            _mapt = Biencucbo.idpt;
            dongedit();
            try
            {
                var so = (from a in db.dangkiems where a.idpt == _mapt select a.so).Max();
                if (so == null)
                    return;
                var lst = (from a in db.dangkiems where a.idpt == _mapt select a).Single(t => t.so == so);
                loadinfo(lst.key);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        protected override void mo()
        {
            Biencucbo.idpt = _mapt;
            f_dssodangkiem frm = new f_dssodangkiem();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                loadinfo(Biencucbo.ma);
            }
        }
        protected override void reload()
        {
            if (_hdong == 0)
            {
                _key = _keytemp;

            }
            loadinfo(_key);
            dongedit();

        }

        protected override void them()
        {
      
            _hdong = 0;
            themtxt();
        }

        private bool LuuPhieu()
        {
            layoutControl1.Validate();
            gv.CloseEditor();
            gv.PostEditor();
            gv.UpdateCurrentRow();

            try
            {
                var c1 = db.dangkiem_files.Context.GetChangeSet();
                db.dangkiem_files.Context.SubmitChanges();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }
        protected override bool luu()
        {
            try
            {
                gv.PostEditor();
                gv.UpdateCurrentRow();
                if (kiemtra())
                {
                    if (_hdong == 0)
                    {
                        txtid.Text = custom.matutang("SDK" + Biencucbo.donvi);
                        _so = Biencucbo.so;
                        dk.them(_key, txtid.Text, txtngaydk.DateTime, int.Parse(txtthoihan.Text), txtdiengiai.Text, _so, _mapt);
                        LuuPhieu();
                        hs.add(txtid.Text, "Thêm Sổ Đăng kiểm");
                        XtraMessageBox.Show("Done");
                        dongedit();
                        _hdong = 2;
                        return true;

                    }
                    if (_hdong == 1)
                    {
                        dk.sua(_key, txtngaydk.DateTime, int.Parse(txtthoihan.Text), txtdiengiai.Text, _mapt);
                        LuuPhieu();
                        hs.add(txtid.Text, "Sữa Sổ Đăng Kiểm");
                        XtraMessageBox.Show("Done");
                        dongedit();
                        _hdong = 2;
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        protected override void sua()
        {
            if (txtid.Text != string.Empty)
            {
                db = new KetNoiDBDataContext();
                _hdong = 1;
                gd.DataSource = (from a in db.dangkiem_files where a.keydk == _key select a);
                moedit();
            }
        }
        protected override bool xoa()
        {

            if (txtid.Text == string.Empty)
            {
                XtraMessageBox.Show("Không có thông tin để xóa");
                return false;
            }
            try
            {
                for (var i = gv.DataRowCount - 1; i >= 0; i--)
                {
                    dk.xoact(gv.GetRowCellValue(i, "key").ToString());
                    gv.DeleteRow(i);
                }
                dk.xoa(_key);
                hs.add(txtid.Text, "Xóa Sổ Đăng Kiểm");
                _hdong = 2;
                XtraMessageBox.Show("Done");
                dongedit();
                xoatxt();
                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        protected override void top()
        {
            try
            {
                var lst = (from a in db.dangkiems where a.idpt == _mapt select a.so).Min();
                if (lst == null)
                    return;
                var lst1 = (from a in db.dangkiems where a.idpt == _mapt select a).Single(t => t.so == lst);
                loadinfo(lst1.key);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        protected override void prev()
        {
            try
            {
                var lst = (from a in db.dangkiems where a.idpt == _mapt && a.so < _so select a.so).Max();
                if (lst == null)
                {
                    XtraMessageBox.Show("Đây là phiếu đầu tiên");
                    return;
                }
                var lst1 = (from a in db.dangkiems where a.idpt == _mapt && a.so == lst select a).Single();
                loadinfo(lst1.key);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        protected override void next()
        {
            try
            {
                var lst = (from a in db.dangkiems where a.idpt == _mapt && a.so > _so select a.so).Min();
                if (lst == null)
                {
                    XtraMessageBox.Show("Đây là phiếu cuối cùng");
                    return;
                }
                var lst1 = (from a in db.dangkiems where a.idpt == _mapt && a.so == lst select a).Single();
                loadinfo(lst1.key);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        protected override void end()
        {
            load();
        }




        #endregion

        private void txtduongdan_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (_hdong == 2)
                return;
            openfile.Title = "Chọn File";
            //openfile.InitialDirectory = @"c:\Program Files";//Thư mục mặc định khi mở
            //openfile.Filter = "Pdf Files|*.pdf";

            openfile.FilterIndex = 1; //chúng ta có All files là 1,exe là 2
            openfile.RestoreDirectory = true;

            if (openfile.ShowDialog() == DialogResult.OK)
            {
                txtduongdan.Text = openfile.FileName;
                txttenfile.Text = openfile.FileName.Substring(openfile.FileName.LastIndexOf('\\') + 1);
                var ext = Path.GetExtension(txttenfile.Text); // getting the file extension of uploaded file         
                txttype.Text = ext;
            }
        }

        private void btnluufile_Click(object sender, EventArgs e)
        {
            if (_hdong != 2)
            {
                if (txtduongdan.Text == "")
                {
                    txtduongdan.ErrorText = "Null";
                    return;
                }

                byte[] file = null;

                if (!string.IsNullOrEmpty(txtduongdan.Text))
                {
                    using (var stream = new FileStream(txtduongdan.Text, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = new BinaryReader(stream))
                        {
                            file = reader.ReadBytes((int)stream.Length);
                        }
                    }
                }

                Binary file2 = file;
                var size = file.Length / 1024; //kb
                gv.AddNewRow();

                var ct = gv.GetFocusedRow() as dangkiem_file;
                ct.key = MD5.laykey();
                ct.keydk = _key;
                ct.formName = txttenfile.Text;
                ct.formData = file;
                ct.type = txttype.Text;
                ct.formSize = size.ToString();
                ct.ghichu = txtduongdan.Text;
                gv.UpdateCurrentRow();
                gv.PostEditor();

                txtduongdan.Text = "";
                txttenfile.Text = "";
                txttype.Text = "";
            }
        }

        SaveFileDialog savefile = new SaveFileDialog();
        private void btntaifile_Click(object sender, EventArgs e)
        {
            if (_hdong == 2)
            {
                try
                {
                    var row = gv.GetFocusedRow() as dangkiem_file;
                    if (row == null) return;

                    var a1 = row.key;
                    var lst = (from a in db.dangkiem_files select a).Single(x => x.key == a1);
                    var filedata = lst.formData.ToArray();

                    //savefile.Title = lst.formName;
                    savefile.FileName = lst.formName;
                    var tmpPath = savefile.InitialDirectory;
                    savefile.FilterIndex = 1;
                    savefile.RestoreDirectory = true;
                    var file = "";
                    if (savefile.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(savefile.FileName + lst.type, filedata);
                        file = savefile.FileName;
                        if (
                       MessageBox.Show("Tải về Thành Công- Bạn có muốn mở file lên không?", "Thông Báo",
                           MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Process.Start(file);
                        }
                   

                    }
                    //var row2 = gv.GetFocusedRow() as dangkiem_file;
                    //if (row2 == null) return;

                    //var a2 = row2.key;
                    //var lst2 = (from a in db.dangkiem_files select a).Single(x => x.key == a2);
                    //var filedata2 = lst2.formData.ToArray();

                    //var tmpPath2 = Application.StartupPath + "\\tmp";
                    //if (!Directory.Exists(tmpPath2))
                    //    Directory.CreateDirectory(tmpPath2);

                    //var tmpFile = tmpPath2 + "\\" + a2 + lst2.type;
                    //File.WriteAllBytes(tmpFile, filedata);

                    
                }
                catch
                {
                }
            }
        }

        private void btnxoafile_Click(object sender, EventArgs e)
        {

            if (_hdong != 2)
            {
                try
                {
                    if (XtraMessageBox.Show("Bạn có muốn xóa file này không?", "THÔNG BÁO", MessageBoxButtons.YesNo) ==
                        DialogResult.Yes)
                    {
                        var ct =
                        (from c in db.dangkiem_files select c).Single(
                            x => x.key == gv.GetFocusedRowCellValue("key").ToString());
                        db.dangkiem_files.DeleteOnSubmit(ct);
                        gv.DeleteRow(gv.FocusedRowHandle);
                    }
                }
                catch
                {
                    MessageBox.Show("Vui lòng chọn File chi tiết cần xóa", "Thông Báo!");
                    return;
                }
            }
            
        }

        private bool dble;
        private void gv_Click(object sender, EventArgs e)
        {
            dble = false;
        }

        private void gv_DoubleClick(object sender, EventArgs e)
        {
            dble = true;
        }

        private void gv_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (dble)
            {
                try
                {
                    var row = gv.GetFocusedRow() as dangkiem_file;
                    if (row == null) return;

                    var a1 = row.key;
                    var lst = (from a in db.dangkiem_files select a).Single(x => x.key == a1);
                    var filedata = lst.formData.ToArray();

                    var tmpPath = Application.StartupPath + "\\tmp";
                    if (!Directory.Exists(tmpPath))
                        Directory.CreateDirectory(tmpPath);

                    var tmpFile = tmpPath + "\\" +"file_temp" + lst.type;
                    File.WriteAllBytes(tmpFile, filedata);

                    Process.Start(tmpFile);
                }
                catch
                {
                }
            }
        }
    }
}