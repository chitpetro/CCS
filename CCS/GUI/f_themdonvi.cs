using System;
using System.Linq;
using System.Windows.Forms;
using BUS;
using ControlLocalizer;
using DAL;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using Lotus;

namespace GUI
{
    public partial class f_themdonvi : Form
    {
        private readonly KetNoiDBDataContext db = new KetNoiDBDataContext();
        private readonly t_donvi dv = new t_donvi();

        public f_themdonvi()
        {
            InitializeComponent();
        }

        private void buttonEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            var frm = new f_dvql();
            frm.ShowDialog();
            txtdvql.Text = Biencucbo.ma;
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (txtid.Text == "" || txtnhom.Text == "" || txtdvql.Text == "" || txtten.Text == "")
            {
                MsgBox.ShowWarningDialog("Thông tin chưa đầy đủ - Vui lòng kiểm tra lại!");
            }
            else
            {
                if (Biencucbo.hddv == 0)
                {
                    var Lst =
                        (from l in db.donvis where l.id == txtid.Text || l.tendonvi == txtten.Text select l).ToList();

                    if (Lst.Count == 1)
                    {
                        MsgBox.ShowErrorDialog("Đơn vị này đã tồn tại, Vui Lòng Kiểm tra Lại");
                    }
                    else
                    {
                        dv.moi(txtid.Text.Trim(), txtten.Text, txtnhom.Text, txtdvql.Text);
                        Close();
                    }
                }
                else
                {
                    var Lst =
                        (from l in db.donvis where l.tendonvi == txtten.Text && l.id != txtid.Text select l).ToList();

                    if (Lst.Count == 1)
                    {
                        MsgBox.ShowErrorDialog("Đơn vị này đã tồn tại, Vui Lòng Kiểm tra Lại");
                    }
                    else
                    {
                        dv.sua(txtid.Text, txtten.Text, txtnhom.Text, txtdvql.Text);
                        Close();
                    }
                }
            }
        }

        private void f_themdonvi_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Thêm Đơn Vị");

            changeFont.Translate(this);
            changeFont.Translate(barManager1);

            if (Biencucbo.hddv == 1)
            {
                txtid.Enabled = false;
                var Lst = (from dv in db.donvis where dv.id == Biencucbo.ma select dv).ToList();

                txtid.DataBindings.Clear();
                txtten.DataBindings.Clear();
                txtnhom.DataBindings.Clear();
                txtdvql.DataBindings.Clear();

                txtid.DataBindings.Add("text", Lst, "id");
                txtid.Text.Trim();
                txtten.DataBindings.Add("text", Lst, "tendonvi".Trim());
                txtnhom.DataBindings.Add("text", Lst, "nhomdonvi".Trim());
                txtdvql.DataBindings.Add("text", Lst, "iddv".Trim());
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}