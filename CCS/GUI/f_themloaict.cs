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
    public partial class f_themloaict : Form
    {
        private readonly KetNoiDBDataContext db = new KetNoiDBDataContext();
        private readonly t_loaict ndt = new t_loaict();

        public f_themloaict()
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
                if (Biencucbo.hdlct == 0)
                {
                    //khong cho trung ID va Ten
                    var Lst =
                        (from dt in db.loaicts where dt.id == txtid.Text || dt.loaict1 == txtten.Text select dt).ToList();

                    if (Lst.Count == 1)
                    {
                        MsgBox.ShowErrorDialog("Loại công trình này đã tồn tại, Vui Lòng Kiểm tra Lại");
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
                        (from l in db.loaicts where l.loaict1 == txtten.Text && l.id != txtid.Text select l).ToList();

                    if (Lst.Count == 1)
                    {
                        MsgBox.ShowErrorDialog("Loại công trình này đã tồn tại, Vui Lòng Kiểm tra Lại");
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
            Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Thêm Loại Công Trình");

            changeFont.Translate(this);
            changeFont.Translate(barManager1);

            if (Biencucbo.hdlct == 1)
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