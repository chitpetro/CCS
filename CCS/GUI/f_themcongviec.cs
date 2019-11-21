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
    public partial class f_themcongviec : Form
    {
        private readonly KetNoiDBDataContext db = new KetNoiDBDataContext();
        private readonly t_congviec dt = new t_congviec();

        public f_themcongviec()
        {
            InitializeComponent();
        }

        private void f_themdoituong_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Thêm Công Việc");

            changeFont.Translate(this);
            changeFont.Translate(barManager1);

            if (Biencucbo.cv == 1)
            {
                txtid.Enabled = false;
                var Lst = (from dt in db.congviecs where dt.id == Biencucbo.ma select dt).ToList();

                txtid.DataBindings.Clear();
                txtten.DataBindings.Clear();
                txtghichu.DataBindings.Clear();

                txtid.DataBindings.Add("text", Lst, "id".Trim());
                txtten.DataBindings.Add("text", Lst, "tencongviec".Trim());
                txtghichu.DataBindings.Add("text", Lst, "nhomcongviec".Trim());
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
                if (Biencucbo.cv == 0)
                {
                    //khong cho trung ID va Ten
                    var Lst =
                        (from dt in db.congviecs where dt.id == txtid.Text || dt.tencongviec == txtten.Text select dt)
                            .ToList();

                    if (Lst.Count == 1)
                    {
                        MsgBox.ShowErrorDialog("Công Việc này đã tồn tại, Vui Lòng Kiểm tra Lại");
                    }
                    else
                    {
                        dt.moi(txtid.Text.Trim(), txtten.Text, txtghichu.Text);
                        Close();
                    }
                }
                else
                {
                    var Lst =
                        (from l in db.congviecs where l.tencongviec == txtten.Text && l.id != txtid.Text select l)
                            .ToList();

                    if (Lst.Count == 1)
                    {
                        MsgBox.ShowErrorDialog("Công Việc này đã tồn tại, Vui Lòng Kiểm tra Lại");
                    }
                    else
                    {
                        dt.sua(txtid.Text, txtten.Text, txtghichu.Text);
                        Close();
                    }
                }
            }
        }
    }
}