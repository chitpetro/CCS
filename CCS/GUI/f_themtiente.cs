using System;
using System.Linq;
using System.Windows.Forms;
using BUS;
using ControlLocalizer;
using DAL;
using DevExpress.XtraBars;
using Lotus;

namespace GUI
{
    public partial class f_themtiente : Form
    {
        private readonly KetNoiDBDataContext db = new KetNoiDBDataContext();
        private readonly t_tiente tt = new t_tiente();

        public f_themtiente()
        {
            InitializeComponent();
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (txtTienTe.Text == "" || txtTyGia.Text == "")
            {
                MsgBox.ShowWarningDialog("Thông tin chưa đầy đủ - Vui lòng kiểm tra lại!");
            }
            else
            {
                if (Biencucbo.hdtt == 0)
                {
                    var Lst = (from l in db.tientes where l.tiente1 == txtTienTe.Text select l).ToList();

                    if (Lst.Count == 1)
                    {
                        MsgBox.ShowWarningDialog("Đơn vị Tiền tệ này đã tồn tại, Vui Lòng Kiểm tra Lại");
                    }
                    else
                    {
                        tt.moi(txtTienTe.Text.Trim(), float.Parse(txtTyGia.Text), txtGhiChu.Text);
                        Close();
                    }
                }
                //sua
                else
                {
                    tt.sua(txtTienTe.Text, float.Parse(txtTyGia.Text), txtGhiChu.Text);
                    Close();
                }
            }
        }

        private void btnCancel_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void f_themtiente_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Thêm Tiền Tệ");

            changeFont.Translate(this);
            changeFont.Translate(barManager1);

            if (Biencucbo.hdtt == 1)
            {
                txtTienTe.Enabled = false;
                var Lst = (from tt in db.tientes where tt.tiente1 == Biencucbo.ma select tt).ToList();

                txtTienTe.DataBindings.Clear();
                txtTyGia.DataBindings.Clear();
                txtGhiChu.DataBindings.Clear();

                txtTienTe.DataBindings.Add("text", Lst, "tiente1");
                txtTienTe.Text.Trim();
                txtTyGia.DataBindings.Add("text", Lst, "tygia".Trim());
                txtGhiChu.DataBindings.Add("text", Lst, "ghichu".Trim());
            }
        }
    }
}