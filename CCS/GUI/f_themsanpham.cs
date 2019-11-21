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
    public partial class f_themsanpham : Form
    {
        private readonly KetNoiDBDataContext db = new KetNoiDBDataContext();
        private readonly t_sanpham sp = new t_sanpham();

        public f_themsanpham()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void btnluu_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (txtid.Text == "" || txtten.Text == "" || txtdvt.Text == "")
            {
                MsgBox.ShowWarningDialog("Thông tin chưa đầy đủ - Vui lòng kiểm tra lại!");
            }
            else
            {
                if (Biencucbo.hdsp == 0)
                {
                    //khong cho trung ID va Ten
                    var Lst =
                        (from dt in db.sanphams where dt.id == txtid.Text || dt.tensp == txtten.Text select dt).ToList();

                    if (Lst.Count == 1)
                    {
                        MsgBox.ShowErrorDialog("Sản phẩm này đã tồn tại, Vui Lòng Kiểm tra Lại");
                    }
                    else
                    {
                        sp.moi(txtid.Text.Trim(), txtten.Text, txtdvt.Text, txtloai.Text, checkQLK.Checked);
                        Close();
                    }
                }
                else
                {
                    var Lst =
                        (from s in db.sanphams where s.tensp == txtten.Text && s.id != txtid.Text select s).ToList();

                    if (Lst.Count == 1)
                    {
                        MsgBox.ShowErrorDialog("Sản phẩm này đã tồn tại, Vui Lòng Kiểm tra Lại");
                    }
                    else
                    {
                        sp.sua(txtid.Text, txtten.Text, txtdvt.Text, txtloai.Text, checkQLK.Checked);
                        Close();
                    }
                }
            }
        }

        private void f_themsanpham_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Thêm Sản Phẩm");

            changeFont.Translate(this);
            changeFont.Translate(barManager1);

            if (Biencucbo.hdsp == 1)
            {
                txtid.Enabled = false;
                var thucthi = (from k in db.sanphams select k).Single(t => t.id == Biencucbo.ma);
                txtid.Text = thucthi.id;
                txtten.Text = thucthi.tensp;

                txtdvt.Text = thucthi.dvt;
                txtloai.Text = thucthi.loai;
                if (thucthi.qlkho == true)
                {
                    checkQLK.Checked = true;
                }
                else
                {
                    checkQLK.Checked = false;
                }
            }
        }
    }
}