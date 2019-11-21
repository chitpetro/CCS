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
    public partial class f_themnguoncap : Form
    {
        private readonly KetNoiDBDataContext db = new KetNoiDBDataContext();
        private readonly t_loainc ndt = new t_loainc();

        public f_themnguoncap()
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
                if (Biencucbo.hdlnc == 0)
                {
                    //khong cho trung ID va Ten
                    var Lst =
                        (from dt in db.nguoncaps where dt.id == txtid.Text || dt.tennguoncap == txtten.Text select dt)
                            .ToList();

                    if (Lst.Count == 1)
                    {
                        MsgBox.ShowErrorDialog("Nguồn cấp này đã tồn tại, Vui Lòng Kiểm tra Lại");
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
                        (from l in db.nguoncaps where l.tennguoncap == txtten.Text && l.id != txtid.Text select l)
                            .ToList();

                    if (Lst.Count == 1)
                    {
                        MsgBox.ShowErrorDialog("Nguồn cấp này đã tồn tại, Vui Lòng Kiểm tra Lại");
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
            Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Thêm Loại Nguồn Cấp");

            changeFont.Translate(this);
            changeFont.Translate(barManager1);

            if (Biencucbo.hdlnc == 1)
            {
                txtid.Enabled = false;
            }
        }
    }
}