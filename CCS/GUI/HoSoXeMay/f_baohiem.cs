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
using DAL;
using BUS;
using DevExpress.XtraBars;
using DAL;
using BUS;
using DevExpress.DirectX;
using GUI.Properties;

namespace GUI.HoSoXeMay
{
    public partial class f_baohiem : frmp
    {

        c_baohiem bh = new c_baohiem();
        t_history hs = new t_history();
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        private readonly OpenFileDialog openfile = new OpenFileDialog();
        private int _so;
        private int _hdong;
        private string _key = "";
        private string _keytemp = "";
        private string _mapt = "";
        public f_baohiem()
        {
            InitializeComponent();
            btnin.Visibility = BarItemVisibility.Never;
            btnduyet.Visibility = BarItemVisibility.Never;
        }

        private void xoatxt()
        {

            dataLayoutControl1.DataSource = (from a in db.baohiems where a.key == _key select a);
            idTextEdit.Text = "";
            ngaydkDateEdit.Text = "";
            thoihanSpinEdit.Text = "";
            diengiaiTextEdit.Text = "";
            dongedit();
        }

        private void themtxt()
        {
            _keytemp = _key;
            _key = MD5.laykey();
            gd.DataSource = (from a in db.baohiem_files where a.keybh == _key select a);
            xoatxt();
            idTextEdit.Text = "YYYY";
            thoihanSpinEdit.Text = "12";
            _hdong = 0;
            moedit();
        }

        private void moedit()
        {
            ngaydkDateEdit.ReadOnly = false;
            thoihanSpinEdit.ReadOnly = false;
            diengiaiTextEdit.ReadOnly = false;
        }

        private void dongedit()
        {
            ngaydkDateEdit.ReadOnly = true;
            thoihanSpinEdit.ReadOnly = true;
            diengiaiTextEdit.ReadOnly = true;
            _hdong = 2;
        }

        private void loadinfo(string key)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().baohiems select a).Single(t => t.key == key);
                //txtid.Text = lst.id;
                //txtngaydk.DateTime = DateTime.Parse(lst.ngaydk.ToString());
                //txtthoihan.Text = lst.thoihan.ToString();
                //txtdiengiai.Text = lst.diengiai;
                dataLayoutControl1.DataSource = lst;
                gd.DataSource = lst.baohiem_files;
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
            ngaydkDateEdit.Properties.ContextImage = null;

            if (ngaydkDateEdit.Text == string.Empty)
                checknull++;

            if (checknull > 0)
            {
                XtraMessageBox.Show("Thông Tin Chưa Đầy Đủ - Vui Lòng Kiểm Tra Lại", "Thông báo");
                ngaydkDateEdit.Properties.ContextImage = Resources.trong;
            }
            var lst = (from a in new KetNoiDBDataContext().baohiems where a.idpt == _mapt select a);

            try
            {
                if (_hdong == 0)
                {
                    if (ngaydkDateEdit.DateTime <= lst.Single(t => t.so == lst.Max(y => y.so)).ngaydk)
                    {
                        ngaydkDateEdit.Properties.ContextImage = Resources.trung;
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

        SaveFileDialog savefile = new SaveFileDialog();
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

                var ct = gv.GetFocusedRow() as baohiem_file;
                ct.key = MD5.laykey();
                ct.keybh = _key;
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

        private void btntaifile_Click(object sender, EventArgs e)
        {
            if (_hdong == 2)
            {
                try
                {
                    var row = gv.GetFocusedRow() as baohiem_file;
                    if (row == null) return;

                    var a1 = row.key;
                    var lst = (from a in db.baohiem_files select a).Single(x => x.key == a1);
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

                        }


                        Process.Start(file);
                    }
                    
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
                        (from c in db.baohiem_files select c).Single(
                            x => x.key == gv.GetFocusedRowCellValue("key").ToString());
                        db.baohiem_files.DeleteOnSubmit(ct);
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

        #region override


        protected override void load()
        {
            _mapt = Biencucbo.idpt;
            dongedit();
            try
            {
                var so = (from a in db.baohiems where a.idpt == _mapt select a.so).Max();
                if (so == null)
                    return;
                var lst = (from a in db.baohiems where a.idpt == _mapt select a).Single(t => t.so == so);
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
            f_dsbaohiem frm = new f_dsbaohiem();
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
            dataLayoutControl1.Validate();
            gv.CloseEditor();
            gv.PostEditor();
            gv.UpdateCurrentRow();

            try
            {
                var c1 = db.baohiem_files.Context.GetChangeSet();
                db.baohiem_files.Context.SubmitChanges();
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
                        idTextEdit.Text = custom.matutang("SBH" + Biencucbo.donvi);
                        _so = Biencucbo.so;
                        bh.them(_key, idTextEdit.Text, ngaydkDateEdit.DateTime, int.Parse(thoihanSpinEdit.Text), diengiaiTextEdit.Text, _so, _mapt);
                        LuuPhieu();
                        hs.add(idTextEdit.Text, "Thêm Bảo Hiểm");
                        XtraMessageBox.Show("Done");
                        dongedit();
                        _hdong = 2;
                        return true;

                    }
                    if (_hdong == 1)
                    {
                        bh.sua(_key, ngaydkDateEdit.DateTime, int.Parse(thoihanSpinEdit.Text), diengiaiTextEdit.Text, _mapt);
                        LuuPhieu();
                        hs.add(idTextEdit.Text, "Sữa Bảo Hiểm");
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
            if (idTextEdit.Text != string.Empty)
            {
                db = new KetNoiDBDataContext();
                _hdong = 1;
                gd.DataSource = (from a in db.baohiem_files where a.keybh == _key select a);
                moedit();
            }
        }
        protected override bool xoa()
        {

            if (idTextEdit.Text == string.Empty)
            {
                XtraMessageBox.Show("Không có thông tin để xóa");
                return false;
            }
            try
            {
                for (var i = gv.DataRowCount - 1; i >= 0; i--)
                {
                    bh.xoact(gv.GetRowCellValue(i, "key").ToString());
                    gv.DeleteRow(i);
                }
                bh.xoa(_key);
                hs.add(idTextEdit.Text, "Xóa Bảo Hiểm");
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
                var lst = (from a in db.baohiems where a.idpt == _mapt select a.so).Min();
                if (lst == null)
                    return;
                var lst1 = (from a in db.baohiems where a.idpt == _mapt select a).Single(t => t.so == lst);
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
                var lst = (from a in db.baohiems where a.idpt == _mapt && a.so < _so select a.so).Max();
                if (lst == null)
                {
                    XtraMessageBox.Show("Đây là phiếu đầu tiên");
                    return;
                }
                var lst1 = (from a in db.baohiems where a.idpt == _mapt && a.so == lst select a).Single();
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
                var lst = (from a in db.baohiems where a.idpt == _mapt && a.so > _so select a.so).Min();
                if (lst == null)
                {
                    XtraMessageBox.Show("Đây là phiếu cuối cùng");
                    return;
                }
                var lst1 = (from a in db.baohiems where a.idpt == _mapt && a.so == lst select a).Single();
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
                    var row = gv.GetFocusedRow() as baohiem_file;
                    if (row == null) return;

                    var a1 = row.key;
                    var lst = (from a in db.baohiem_files select a).Single(x => x.key == a1);
                    var filedata = lst.formData.ToArray();

                    var tmpPath = Application.StartupPath + "\\tmp";
                    if (!Directory.Exists(tmpPath))
                        Directory.CreateDirectory(tmpPath);

                    var tmpFile = tmpPath + "\\" + "file_temp" + lst.type;
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