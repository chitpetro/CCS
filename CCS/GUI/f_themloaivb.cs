using System;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DAL;
using DevExpress.XtraBars;
using Lotus;

namespace GUI
{
    public partial class f_themloaivb : Form
    {
        private readonly KetNoiDBDataContext db = new KetNoiDBDataContext();
        private readonly t_loaivb lvb = new t_loaivb();

        public f_themloaivb()
        {
            InitializeComponent();
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (txtid.Text == "" || txtten.Text == "")
            {
                MsgBox.ShowWarningDialog("Thông tin chưa đầy đủ - Vui lòng kiểm tra lại!");
            }
            else
            {
                if (Biencucbo.lvb == 0)
                {
                    var Lst = (from l in db.loaivanbans where l.id == txtid.Text select l).ToList();

                    if (Lst.Count == 1)
                    {
                        MsgBox.ShowWarningDialog("Loại Văn Bản này đã tồn tại, Vui Lòng Kiểm tra Lại");
                    }
                    else
                    {
                        lvb.moi(txtid.Text.Trim(), txtten.Text, txtghichu.Text);
                        Close();
                    }
                }
                //sua
                else
                {
                    lvb.sua(txtid.Text.Trim(), txtten.Text, txtghichu.Text);
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
            //LanguageHelper.Translate(this);
            //LanguageHelper.Translate(barManager1);
            //this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Thêm Loại Văn Bản").ToString();

            //changeFont.Translate(this);
            //changeFont.Translate(barManager1);

            if (Biencucbo.lvb == 1)
            {
                txtid.Enabled = false;
                var Lst = (from tt in db.loaivanbans where tt.id == Biencucbo.ma select tt).ToList();

                txtid.DataBindings.Clear();
                txtten.DataBindings.Clear();
                txtghichu.DataBindings.Clear();

                txtid.DataBindings.Add("text", Lst, "id");
                txtid.Text.Trim();
                txtten.DataBindings.Add("text", Lst, "ten".Trim());
                txtghichu.DataBindings.Add("text", Lst, "ghichu".Trim());
            }
        }
    }
}