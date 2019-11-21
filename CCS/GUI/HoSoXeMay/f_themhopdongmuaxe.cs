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
using DAL;
using BUS;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using GUI.Properties;
using System.IO;
using System.Data.Linq;
using System.Diagnostics;

namespace GUI.HoSoXeMay
{
    public partial class f_themhopdongmuaxe : frm.frmthemds
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        public f_themhopdongmuaxe()
        {
            InitializeComponent();
        }

        private void gv_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            custom.sttgv(gv, e);
            BeginInvoke(new MethodInvoker(delegate
            {
                custom.cal(gd, gv);
            }));
        }

        #region SearchLookEdit

        private void layttlblteniddt(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().pxm_doituongs select a).Single(t => t.id == id);
                lblteniddt.Text = lst.ten;
            }
            catch (Exception ex)
            {
                lblteniddt.Text = "";
            }
        }

        private void iddtSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            layttlblteniddt(iddtSearchLookUpEdit.Text);
        }

        private void iddtSearchLookUpEdit_Popup(object sender, EventArgs e)
        {
            var form = (sender as IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            var pop = form.Controls.OfType<SearchEditLookUpPopup>().FirstOrDefault();
            LayoutControl popupControl = pop.Controls.OfType<LayoutControl>().FirstOrDefault();
            Control clearBtn =
                popupControl.Controls.OfType<Control>().Where(ct => ct.Name == "btClear").FirstOrDefault();
            LayoutControlItem clearLCI = (LayoutControlItem)popupControl.GetItemByControl(clearBtn);
            LayoutControlItem myLCI = (LayoutControlItem)clearLCI.Owner.CreateLayoutItem(clearLCI.Parent);
            LayoutControlItem myrefresh = (LayoutControlItem)clearLCI.Owner.CreateLayoutItem(clearLCI.Parent);

            //btn edit
            var btnadd = new SimpleButton
            {
                Image = Resources.edit_16x16,
                Text = "Add/Edit",
                BorderStyle = BorderStyles.Default
            };
            btnadd.Click += btnadd_Click;

            // BTN load
            var btnreload = new SimpleButton
            {
                Image = Resources.refresh_16x16,
                Text = "Refresh",
                BorderStyle = BorderStyles.Default
            };
            btnreload.Click += btnreload_Click;
            var edit = sender as SearchLookUpEdit;
            var popupForm = edit.GetPopupEditForm();
            popupForm.KeyPreview = true;
            popupForm.KeyUp -= txt_KeyUp;
            popupForm.KeyUp += txt_KeyUp;
            if (checkbtn)
            {
                myLCI.Control = btnadd;
                myLCI.Move(clearLCI, InsertType.Left);
                myrefresh.Control = btnreload;
                myrefresh.Move(myLCI, InsertType.Left);

                checkbtn = false;
            }
        }

        private bool checkbtn = true;

        private void loadsluiddtSearchLookUpEdit()
        {
            iddtSearchLookUpEdit.Properties.DataSource = (from a in new KetNoiDBDataContext().pxm_doituongs where a.nhom == "BX" select a);
        }

        public void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                Biencucbo.QuyenDangChon =
                    (from a in new KetNoiDBDataContext().PhanQuyen2s select a).Single(
                        t => t.TaiKhoan == Biencucbo.phongban && t.ChucNang == "btnpxmdoituong");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            var frm = new f_pxmdsdoituong();
            frm.ShowDialog();
            loadsluiddtSearchLookUpEdit();
            iddtSearchLookUpEdit.ShowPopup();
        }

        public void btnreload_Click(object sender, EventArgs e)
        {
            loadsluiddtSearchLookUpEdit();
            iddtSearchLookUpEdit.ShowPopup();
        }

        private static void txt_KeyUp(object sender, KeyEventArgs e)
        {
            PopupSearchLookUpEditForm popupForm = sender as PopupSearchLookUpEditForm;
            if (e.KeyData == Keys.Enter)
            {
                GridView view = popupForm.OwnerEdit.Properties.View;
                view.FocusedRowHandle = 0;
                popupForm.OwnerEdit.ClosePopup();
            }
        }

        private void tienteSearchLookUpEdit_Popup(object sender, EventArgs e)
        {

            var form = (sender as IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            var pop = form.Controls.OfType<SearchEditLookUpPopup>().FirstOrDefault();
            LayoutControl popupControl = pop.Controls.OfType<LayoutControl>().FirstOrDefault();
            Control clearBtn =
                popupControl.Controls.OfType<Control>().Where(ct => ct.Name == "btClear").FirstOrDefault();
            LayoutControlItem clearLCI = (LayoutControlItem)popupControl.GetItemByControl(clearBtn);
            LayoutControlItem myLCI = (LayoutControlItem)clearLCI.Owner.CreateLayoutItem(clearLCI.Parent);
            LayoutControlItem myrefresh = (LayoutControlItem)clearLCI.Owner.CreateLayoutItem(clearLCI.Parent);

            //btn edit
            var btnaddtienteSearchLookUpEdit = new SimpleButton
            {
                Image = Resources.edit_16x16,
                Text = "Add/Edit",
                BorderStyle = BorderStyles.Default
            };
            btnaddtienteSearchLookUpEdit.Click += btnaddtienteSearchLookUpEdit_Click;

            // BTN load
            var btnreloadtienteSearchLookUpEdit = new SimpleButton
            {
                Image = Resources.refresh_16x16,
                Text = "Refresh",
                BorderStyle = BorderStyles.Default
            };
            btnreloadtienteSearchLookUpEdit.Click += btnreloadtienteSearchLookUpEdit_Click;
            var edit = sender as SearchLookUpEdit;
            var popupForm = edit.GetPopupEditForm();
            popupForm.KeyPreview = true;
            popupForm.KeyUp -= txt_KeyUp;
            popupForm.KeyUp += txt_KeyUp;


            if (checkbtntienteSearchLookUpEdit)
            {
                myLCI.Control = btnaddtienteSearchLookUpEdit;
                myLCI.Move(clearLCI, InsertType.Left);
                myrefresh.Control = btnreloadtienteSearchLookUpEdit;
                myrefresh.Move(myLCI, InsertType.Left);

                checkbtntienteSearchLookUpEdit = false;
            }
        }

        private bool checkbtntienteSearchLookUpEdit = true;

        private void loadslutienteSearchLookUpEdit()
        {
            tienteSearchLookUpEdit.Properties.DataSource = (from a in new KetNoiDBDataContext().tientes select a);
        }

        public void btnaddtienteSearchLookUpEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Biencucbo.QuyenDangChon =
                    (from a in new KetNoiDBDataContext().PhanQuyen2s select a).Single(
                        t => t.TaiKhoan == Biencucbo.phongban && t.ChucNang == "barButtonItem11");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            var frm = new f_tiente();
            frm.ShowDialog();
            loadslutienteSearchLookUpEdit();
            tienteSearchLookUpEdit.ShowPopup();
        }

        public void btnreloadtienteSearchLookUpEdit_Click(object sender, EventArgs e)
        {
            loadslutienteSearchLookUpEdit();
            tienteSearchLookUpEdit.ShowPopup();

        }

        #endregion


        private int _hdong = 0;
        private string _key = "";
        c_hopdongmuaxe hd = new c_hopdongmuaxe();
        t_history hs = new t_history();
        protected override void load()
        {
            loadsluiddtSearchLookUpEdit();
            loadslutienteSearchLookUpEdit();
            _hdong = Biencucbo.hdong;
            if (_hdong == 1)
            {
                _key = custom.laykey();
                gd.DataSource = (from a in db.hopdongmuaxe_files where a.keythd == _key select a);
            }

            if (_hdong == 2)
            {
                _key = Biencucbo.key;
                sohdTextEdit.ReadOnly = true;
                var lst = (from a in new KetNoiDBDataContext().hopdongmuaxes select a).Single(t => t.key == _key);

                dataLayoutControl1.DataSource = lst;
                gd.DataSource = (from a in db.hopdongmuaxe_files where a.keythd == _key select a);


            }
            if (_hdong == 3)
            {
                _key = Biencucbo.key;
                var lst = (from a in new KetNoiDBDataContext().hopdongmuaxes select a).Single(t => t.key == _key);
                dataLayoutControl1.DataSource = lst;
                gd.DataSource = (from a in db.hopdongmuaxe_files where a.keythd == _key select a);
                sohdTextEdit.Text = string.Empty;
                _hdong = 1;

            }

        }

        private bool LuuPhieu()
        {
            dataLayoutControl1.Validate();
            gv.CloseEditor();
            gv.PostEditor();
            gv.UpdateCurrentRow();

            try
            {
                var c1 = db.hopdongmuaxe_files.Context.GetChangeSet();
                db.hopdongmuaxe_files.Context.SubmitChanges();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }
        protected override void luu()
        {
            if (kiemtra())
            {
                if (_hdong == 1)
                {
                    hd.them(_key, sohdTextEdit.Text, ngaykyDateEdit.DateTime, noidungTextEdit.Text, iddtSearchLookUpEdit.Text, ghichuTextEdit.Text, tienteSearchLookUpEdit.Text, double.Parse(giatriSpinEdit.Text));
                    LuuPhieu();
                    hs.add(sohdTextEdit.Text, "Thêm Hợp Đồng Mua Xe");
                    custom.mes_done();
                    DialogResult = DialogResult.OK;
                }
                if (_hdong == 2)
                {
                    hd.sua(_key, ngaykyDateEdit.DateTime, noidungTextEdit.Text, iddtSearchLookUpEdit.Text, ghichuTextEdit.Text, tienteSearchLookUpEdit.Text, double.Parse(giatriSpinEdit.Text));
                    LuuPhieu();
                    hs.add(sohdTextEdit.Text, "Sửa Hợp Đồng Mua Xe");
                    custom.mes_done();
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private bool kiemtra()
        {
            int checknull = 0;
            int checdup = 0;
            sohdTextEdit.Properties.ContextImage = null;

            if (custom.checknulltext(sohdTextEdit))
                checknull++;

            ngaykyDateEdit.Properties.ContextImage = null;

            if (custom.checknulltext(ngaykyDateEdit))
                checknull++;
            if (checknull > 0)
            {
                custom.mes_thongtinchuadaydu();
            }
            var lst = (from a in new KetNoiDBDataContext().hopdongmuaxes select a);
            if (_hdong == 1)
            {
                if (lst.Where(t => t.sohd == sohdTextEdit.Text).Count() > 0)
                {
                    sohdTextEdit.Properties.ContextImage = Resources.trung;
                    checdup++;
                }
            }
            
            if (checdup > 0)
                XtraMessageBox.Show("Số Hợp Đồng bị trùng. Vui lòng kiểm tra lại","THÔNG BÁO");
            if (checdup > 0 || checknull > 0)
                return false;
            return true;
        }
        //private bool kiemtra()
        //{
        //    int checknull = 0;
        //    int checdup = 0;
        //    sohdTextEdit.Properties.ContextImage = null;

        //    if (custom.checknulltext(sohdTextEdit))
        //        checknull++;

        //    ngaykyDateEdit.Properties.ContextImage = null;

        //    if (custom.checknulltext(ngaykyDateEdit))
        //        checknull++;
        //    if (checknull > 0)
        //    {
        //        custom.mes_thongtinchuadaydu();
        //    }

        //    if (checknull > 0)
        //        return false;
        //    return true;
        //}

        private void btnluufile_Click(object sender, EventArgs e)
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

            var ct = gv.GetFocusedRow() as hopdongmuaxe_file;
            ct.key = MD5.laykey();
            ct.keythd = _key;
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
        SaveFileDialog savefile = new SaveFileDialog();
        private void btntaifile_Click(object sender, EventArgs e)
        {

            try
            {
                var row = gv.GetFocusedRow() as hopdongmuaxe_file;
                if (row == null) return;

                var a1 = row.key;
                var lst = (from a in db.hopdongmuaxe_files select a).Single(x => x.key == a1);
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

            }
            catch
            {
            }

        }

        private void btnxoafile_Click(object sender, EventArgs e)
        {

            try
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa file này không?", "THÔNG BÁO", MessageBoxButtons.YesNo) ==
                    DialogResult.Yes)
                {
                    var ct =
                    (from c in db.hopdongmuaxe_files select c).Single(
                        x => x.key == gv.GetFocusedRowCellValue("key").ToString());
                    db.hopdongmuaxe_files.DeleteOnSubmit(ct);
                    gv.DeleteRow(gv.FocusedRowHandle);
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn File chi tiết cần xóa", "Thông Báo!");
                return;
            }

        }
        private OpenFileDialog openfile = new OpenFileDialog();
        private void txtduongdan_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool dble = false;
        private void gv_Click(object sender, EventArgs e)
        {
            dble = false;
        }

        private void gv_DoubleClick(object sender, EventArgs e)
        {
            dble = true;
        }

        private void gv_RowClick(object sender, RowClickEventArgs e)
        {
            if (dble)
            {
                try
                {
                    var row = gv.GetFocusedRow() as hopdongmuaxe_file;
                    if (row == null) return;

                    var a1 = row.key;
                    var lst = (from a in db.hopdongmuaxe_files select a).Single(x => x.key == a1);
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