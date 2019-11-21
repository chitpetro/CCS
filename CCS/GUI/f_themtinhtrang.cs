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
    public partial class f_themtinhtrang : Form
    {
        private readonly KetNoiDBDataContext db = new KetNoiDBDataContext();
        private readonly t_tinhtrang dt = new t_tinhtrang();

        public f_themtinhtrang()
        {
            InitializeComponent();
        }

        private void f_themdoituong_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Thêm Tình Trạng");

            changeFont.Translate(this);
            changeFont.Translate(barManager1);

            if (Biencucbo.tthd == 1)
            {
                var Lst = (from dt in db.tinhtrangs where dt.id == Biencucbo.ma select dt).ToList();

                txtten.Enabled = false;
                txtten.DataBindings.Clear();
                txtghichu.DataBindings.Clear();

                txtten.DataBindings.Add("text", Lst, "ten".Trim());
                txtghichu.DataBindings.Add("text", Lst, "ghichu".Trim());
            }
        }

        private void btnhuy_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void luu_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (txtten.Text == "")
            {
                MsgBox.ShowWarningDialog("Thông tin chưa đầy đủ - Vui lòng kiểm tra lại!");
            }
            else
            {
                if (Biencucbo.tthd == 0)
                {
                    //khong cho trung ID va Ten
                    var Lst = (from dt in db.tinhtrangs where dt.ten == txtten.Text select dt).ToList();

                    if (Lst.Count == 1)
                    {
                        MsgBox.ShowErrorDialog("Tình trạng này đã tồn tại, Vui Lòng Kiểm tra Lại");
                    }
                    else
                    {
                        if (txtten.Text != "")
                        {
                            var lst2 = from a in db.tinhtrangs where a.ten == txtten.Text select a;
                            if (lst2.Count() != 0)
                            {
                                MsgBox.ShowErrorDialog("Tên không được phép trùng, Vui Lòng Kiểm tra Lại");
                                return;
                            }
                        }

                        dt.moi(txtten.Text, txtten.Text, txtghichu.Text);
                        Close();
                    }
                }
                else
                {
                    //var Lst = (from l in db.tinhtrangs where l.ten == txtten.Text select l).ToList();

                    //if (Lst.Count == 1)
                    //{

                    //    Lotus.MsgBox.ShowErrorDialog("Tình trạng này đã tồn tại, Vui Lòng Kiểm tra Lại");
                    //}
                    //else
                    {
                        dt.sua(txtten.Text, txtten.Text, txtghichu.Text);
                        Close();
                    }
                }
            }
        }
    }
}