using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS;
using ControlLocalizer;
using DAL;
using DevExpress.Utils.Win;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using GUI.Properties;
using Lotus;

namespace GUI
{
    public partial class f_themcongtrinh : Form
    {
        private readonly KetNoiDBDataContext db = new KetNoiDBDataContext();
        private readonly t_themcongtrinh dt = new t_themcongtrinh();
        private readonly t_tudong td = new t_tudong();

        public f_themcongtrinh()
        {
            InitializeComponent();
            txtkhuvuc.Properties.DataSource = new KetNoiDBDataContext().khuvucs;
            txtloaict.Properties.DataSource = new KetNoiDBDataContext().loaicts;

            txtngaybd.Text = "01/01/2010";
            txtngaykt.DateTime = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            txtgthanmuc.Text = "0";
        }


        public void button_Click(object sender, EventArgs e)
        {
            var frm = new f_themkhuvuc();
            frm.ShowDialog();
            txtkhuvuc.Properties.DataSource = new KetNoiDBDataContext().khuvucs;
        }

        public void buttonlct_Click(object sender, EventArgs e)
        {
            var frm = new f_themloaict();
            frm.ShowDialog();
            txtloaict.Properties.DataSource = new KetNoiDBDataContext().loaicts;
        }

        private void btnhuy_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void luu_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (txtid.Text == "" || txttencongtrinh.Text == "" || txtkhuvuc.Text == "")
            {
                MsgBox.ShowWarningDialog("Thông tin chưa đầy đủ - Vui lòng kiểm tra lại!");
            }
            else
            {
                if (Biencucbo.hdct == 0)
                {
                    if (Biencucbo.hdct == 0)
                    {
                        var check = "CT";
                        var lst = (from a in db.tudongs where a.maphieu == check select a).ToList();
                        if (lst.Count == 0)
                        {
                            int so;
                            so = 2;
                            td.themtudong(check, so);
                            txtid.Text = check + "_000001";
                            Biencucbo.soct = 1;
                        }
                        else
                        {
                            int k;
                            Biencucbo.soct = int.Parse(lst.Single(t => t.maphieu == check).so.ToString());
                            var so0 = "";
                            k = Biencucbo.soct;
                            if (k < 10)
                            {
                                so0 = "00000";
                            }
                            else if (k >= 10 & k < 100)
                            {
                                so0 = "0000";
                            }
                            else if (k >= 100 & k < 1000)
                            {
                                so0 = "000";
                            }
                            else if (k >= 1000 & k < 10000)
                            {
                                so0 = "00";
                            }
                            else if (k >= 10000 & k < 100000)
                            {
                                so0 = "0";
                            }
                            else if (k >= 100000)
                            {
                                so0 = "";
                            }
                            txtid.Text = check + "_" + so0 + k;
                            k = k + 1;
                            td.suatudong(check, k);
                        }
                    }
                    //khong cho trung ID va Ten
                    var Lst =
                        (from dt in db.congtrinhs
                            where dt.id == txtid.Text || dt.tencongtrinh == txttencongtrinh.Text
                            select dt).ToList();

                    if (Lst.Count == 1)
                    {
                        MsgBox.ShowErrorDialog("Công Trình này đã tồn tại, Vui Lòng Kiểm tra Lại");
                    }
                    else
                    {
                        dt.moi(txtid.Text, txttencongtrinh.Text, txtkhuvuc.Text, txtdiadiem.Text, txtngaybd.DateTime,
                            txtngaykt.DateTime, txtloaict.Text, txtcht.Text, txtgthanmuc.Text,
                            double.Parse(txtgthanmuc.Text), txtht.Checked, ckkho.Checked);
                        Close();
                    }
                }
                else
                {
                    var Lst =
                        (from l in db.congtrinhs
                            where l.tencongtrinh == txttencongtrinh.Text && l.id != txtid.Text
                            select l).ToList();

                    if (Lst.Count == 1)
                    {
                        MsgBox.ShowErrorDialog("Bị trùng công trình, Vui Lòng Kiểm tra Lại");
                    }
                    else
                    {
                        dt.sua(txtid.Text, txttencongtrinh.Text, txtkhuvuc.Text, txtdiadiem.Text, txtngaybd.DateTime,
                            txtngaykt.DateTime, txtloaict.Text, txtcht.Text, double.Parse(txtgthanmuc.Text),
                            txtht.Checked, ckkho.Checked);
                        Close();
                    }
                }
            }
        }

        private void f_themcongtrinh_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Thêm Công Trình");
            txtid.ReadOnly = true;

            changeFont.Translate(this);
            changeFont.Translate(barManager1);
            if (Biencucbo.hdct == 0)
            {
                txtid.Text = "YYYYY";
            }
            if (Biencucbo.hdct == 1)
            {
                txtid.Enabled = false;
                var Lst = (from dt in db.congtrinhs select dt).Single(t => t.id == Biencucbo.ma);
                txtid.Text = Lst.id;
                txttencongtrinh.Text = Lst.tencongtrinh;
                txtkhuvuc.Text = Lst.khuvuc;
                txtgthanmuc.Text = Lst.gthanmuc.ToString();
                txtdiadiem.Text = Lst.diadiem;
                txtngaybd.DateTime = DateTime.Parse(Lst.ngaybd.ToString());
                txtngaykt.DateTime = DateTime.Parse(Lst.ngaykt.ToString());

                txtcht.Text = Lst.chihuytruong;
                txtcdt.Text = Lst.cdt;
                if (Lst.ht == true)
                {
                    txtht.Checked = true;
                }
                else
                {
                    txtht.Checked = false;
                }

                if (Lst.khopxm == true)
                {
                    ckkho.Checked = true;
                }
                else
                {
                    ckkho.Checked = false;
                }
            }
        }

        private void txtkhuvuc_Popup(object sender, EventArgs e)
        {
            var popupControl = sender as IPopupControl;
            var button = new SimpleButton
            {
                Image = Resources.icons8_Add_File_16,
                Text = "Thêm mới",
                BorderStyle = BorderStyles.NoBorder
            };

            button.Click += button_Click;

            button.Location = new Point(5, popupControl.PopupWindow.Height - button.Height - 5);
            popupControl.PopupWindow.Controls.Add(button);
            button.BringToFront();
        }

        private void txtkhuvuc_EditValueChanged(object sender, EventArgs e)
        {
            var lst = from a in db.khuvucs where a.id == txtkhuvuc.Text select a;
            if (lst.Count() == 1)
            {
                var lst1 = (from a in db.khuvucs select a).Single(t => t.id == txtkhuvuc.Text);
                lblkv.Text = lst1.khuvuc1;
            }
            else
            {
                lblkv.Text = "";
            }
        }

        private void txtloaict_Popup(object sender, EventArgs e)
        {
            var popupControl = sender as IPopupControl;
            var button = new SimpleButton
            {
                Image = Resources.icons8_Add_File_16,
                Text = "Thêm mới",
                BorderStyle = BorderStyles.NoBorder
            };

            button.Click += buttonlct_Click;

            button.Location = new Point(5, popupControl.PopupWindow.Height - button.Height - 5);
            popupControl.PopupWindow.Controls.Add(button);
            button.BringToFront();
        }

        private void txtloaict_EditValueChanged(object sender, EventArgs e)
        {
            var lst = from a in db.loaicts where a.id == txtloaict.Text select a;
            if (lst.Count() == 1)
            {
                var lst1 = (from a in db.loaicts select a).Single(t => t.id == txtloaict.Text);
                lbllct.Text = lst1.loaict1;
            }
            else
            {
                lbllct.Text = "";
            }
        }

        private void txtiduser_EditValueChanged(object sender, EventArgs e)
        {
        }
    }
}