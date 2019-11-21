using System;
using System.Linq;
using System.Windows.Forms;
using BUS;
using ControlLocalizer;
using DAL;
using DevExpress.XtraBars;
using Lotus;
using System.IO;
using System.Drawing;

using GUI.Properties;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors;

namespace GUI
{
    public partial class f_themnhanvienlaixe : Form
    {
        private readonly KetNoiDBDataContext db = new KetNoiDBDataContext();
        private readonly t_nhanvienlaixe dt = new t_nhanvienlaixe();

        public f_themnhanvienlaixe()
        {
            InitializeComponent();
        }

        private void f_themdoituong_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Thêm Nhân Viên");
            txtpp.Properties.DataSource = new KetNoiDBDataContext().dmchucvus;
            changeFont.Translate(this);
            changeFont.Translate(barManager1);
            hinhanh.SizeMode = PictureBoxSizeMode.StretchImage;
            if (Biencucbo.hddt == 1)
            {
                txtid.Enabled = false;
                var Lst = (from dt in db.nhanviens  select dt).Single(t=>t.id == Biencucbo.ma);
            
                txtid.Text= Lst.id;
                txtten.Text = Lst.ten;
                txtdc.Text = Lst.diachi;
                txtdt.Text= Lst.dienthoai;
                txtemail.Text = Lst.email;
                txtghichu.Text = Lst.ghichu;
                try
                {
                    txtngaysinh.DateTime = DateTime.Parse(Lst.ngaysinh.ToString());
                }
                catch (Exception)
                { 
                }
                try
                {
                    txtNgayNghiViec.DateTime = DateTime.Parse(Lst.ngaynghiviec.ToString());
                }
                catch (Exception)
                {
                }

                txtquoctich.Text = Lst.quoctich;
                txtcmnd.Text = Lst.cmnd;
                txtpp.Text = Lst.Chucvu;try
                {
                    txtngayvaolam.DateTime = DateTime.Parse(Lst.ngayvaolam.ToString());
                }
                catch (Exception)
                {
                    
                   
                }
                txtgioitinh.Text = Lst.gioitinh;
                txttinhtrang.Text = Lst.tinhtrang;
                try
                {
                    ImageConverter objfile = new ImageConverter();
                    hinhanh.Image = (Image)objfile.ConvertFrom(Lst.hinhanh.ToArray());
                    hinhanh.SizeMode = PictureBoxSizeMode.StretchImage;
                    file = Lst.hinhanh.ToArray();
                }
                catch
                {

                }
            }
        }


        private void btnhuy_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void luu_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (txtid.Text == "" || txtten.Text == "")
            {
                MsgBox.ShowWarningDialog("Thông tin chưa đầy đủ - Vui lòng kiểm tra lại!");
            }
            else
            {
                if (Biencucbo.hddt == 0)
                {
                    //khong cho trung ID va Ten
                    var Lst =
                        (from dt in db.nhanviens where dt.id == txtid.Text || dt.ten == txtten.Text select dt).ToList();

                    if (Lst.Count == 1)
                    {
                        MsgBox.ShowErrorDialog("Đối tượng này đã tồn tại, Vui Lòng Kiểm tra Lại");
                    }
                    else
                    {
                        dt.moi(txtid.Text.Trim(), txtten.Text, txtdc.Text, txtdt.Text, txtemail.Text, txtghichu.Text, txtngaysinh.DateTime, txtquoctich.Text, txtcmnd.Text, txtpp.Text, txtngayvaolam.DateTime, txtgioitinh.Text, txttinhtrang.Text, file, txtNgayNghiViec.DateTime);
                        Close();
                    }
                }
                else
                {
                    var Lst =
                        (from l in db.nhanviens where l.ten == txtten.Text && l.id != txtid.Text select l).ToList();

                    if (Lst.Count == 1)
                    {
                        MsgBox.ShowErrorDialog("Đối tượng này đã tồn tại, Vui Lòng Kiểm tra Lại");
                    }
                    else
                    {
                        dt.sua(txtid.Text.Trim(), txtten.Text, txtdc.Text, txtdt.Text, txtemail.Text, txtghichu.Text, txtngaysinh.DateTime, txtquoctich.Text, txtcmnd.Text, txtpp.Text, txtngayvaolam.DateTime, txtgioitinh.Text, txttinhtrang.Text, file, txtNgayNghiViec.DateTime);
                        Close();
                    }
                }
            }
        }
        public byte[] file = null;
        private void btnimg_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Title = "Chọn ảnh nhân viên";
            openfile.Filter = "jpg Files|*.jpg";
            openfile.FilterIndex = 1;
            openfile.RestoreDirectory = true;
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                using (var stream = new FileStream(openfile.FileName, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = new BinaryReader(stream))
                    {
                        file = reader.ReadBytes((int)stream.Length);
                        ImageConverter objfile = new ImageConverter();
                        hinhanh.Image = (Image)objfile.ConvertFrom(file);
                        hinhanh.SizeMode = PictureBoxSizeMode.StretchImage;


                    }
                }

            }
        }

        private void txtpp_Popup(object sender, EventArgs e)
        {
            var popupControl = sender as IPopupControl;
            var button = new SimpleButton
            {
                Image = Resources.icons8_Add_File_16,
                Text = "Edit",
                BorderStyle = BorderStyles.NoBorder
            };

            button.Click += button_Click;

            button.Location = new Point(5, popupControl.PopupWindow.Height - button.Height - 5);
            popupControl.PopupWindow.Controls.Add(button);
            button.BringToFront();

        }
        public void button_Click(object sender, EventArgs e)
        {
            var frm = new f_dmchucvu();
            frm.ShowDialog();
            txtpp.Properties.DataSource = new KetNoiDBDataContext().dmchucvus;
        }
    }
}