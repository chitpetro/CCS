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
    public partial class f_themkhuvuc : Form
    {
        private readonly KetNoiDBDataContext db = new KetNoiDBDataContext();
        private readonly t_khuvuc ndt = new t_khuvuc();

        public f_themkhuvuc()
        {
            InitializeComponent();
        }

        private void btnLuu_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (txtid.Text == "" || txtten.Text == "")
            {
                MsgBox.ShowWarningDialog("Thông tin chưa đầy đủ - Vui lòng kiểm tra lại!");
            }
            else
            {
                if (Biencucbo.hdkv == 0)
                {
                    //khong cho trung ID va Ten
                    var Lst =
                        (from dt in db.khuvucs where dt.id == txtid.Text || dt.khuvuc1 == txtten.Text select dt).ToList();

                    if (Lst.Count == 1)
                    {
                        MsgBox.ShowErrorDialog("Khu vực này đã tồn tại, Vui Lòng Kiểm tra Lại");
                    }
                    else
                    {
                        ndt.moi(txtid.Text.Trim(), txtten.Text);
                        Close();
                    }
                }
                else
                {
                    var Lst =
                        (from l in db.khuvucs where l.khuvuc1 == txtten.Text && l.id != txtid.Text select l).ToList();

                    if (Lst.Count == 1)
                    {
                        MsgBox.ShowErrorDialog("Khu vực này đã tồn tại, Vui Lòng Kiểm tra Lại");
                    }
                    else
                    {
                        ndt.sua(txtid.Text, txtten.Text);
                        Close();
                    }
                }
            }
        }

        private void btnHuy_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void f_themkhuvuc_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Thêm Khu vực");

            changeFont.Translate(this);
            changeFont.Translate(barManager1);

            if (Biencucbo.hdkv == 1)
            {
                txtid.Enabled = false;
                //var Lst = (from dt in db.nhomdoituongs where dt.id == Biencucbo.ma select dt).ToList();

                //txtid.DataBindings.Clear();
                //txtten.DataBindings.Clear(); 

                //txtid.DataBindings.Add("text", Lst, "id");
                //txtid.Text.Trim();
                //txtten.DataBindings.Add("text", Lst, "ten".Trim()); 
            }
        }
    }
}