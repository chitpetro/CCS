using System;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DAL;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;

namespace GUI
{
    public partial class f_suathanhtoan : XtraForm
    {
        private  KetNoiDBDataContext db = new KetNoiDBDataContext();
        private  t_history hs = new t_history();
        private  t_hopdong tt = new t_hopdong();
        t_todatatable _tTodatatable = new t_todatatable();

        public f_suathanhtoan()
        {
            InitializeComponent();
            var lst2 = (from a in db.vanbandens
                        join d in db.donvis on a.iddv equals d.id
                        //where a.iddv == Biencucbo.donvi
                        select new
                        {
                            a.id,
                            a.ngaynhan,
                            a.sovb,
                            a.noidung
                        }).ToList();
            txtlinkhs.Properties.DataSource = _tTodatatable.addlst(lst2.ToList());
            loadslutxtlinkgoc();
            txtnhanvien.ReadOnly = true;
        }

        public void loaddata()
        {
            if (Biencucbo.hdtthdtp == 0)
            {
                txtngaythanhtoan.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                try
                {
                    var lst = (from a in db.thanhtoan_tps where a.idhd_tp == Biencucbo.hopdong select a.lan).Max();
                    txtlan.Text = (lst + 1).ToString();
                }
                catch
                {
                    txtlan.Text = "1";
                }
                txtnhanvien.Text = Biencucbo.idnv;
            }
            else if (Biencucbo.hdtthdtp == 1)
            {
                var lst = (from a in db.thanhtoan_tps select a).Single(t => t.id == Biencucbo.matthdtp);
                txtdiengiai.Text = lst.diengiai;
                txtlan.Text = lst.lan.ToString();
                txtngaythanhtoan.DateTime = DateTime.Parse(lst.ngaytt.ToString());
                txtgtth.Text = lst.giatriqt.ToString();
                txtcantru.Text = lst.cantru.ToString();
                txtgttt.Text = lst.giatritt.ToString();
                txtghichu.Text = lst.ghichu;
                txtlinkhs.Text = lst.link;
                txtlinkgoc.Text = lst.linkgoc;
                txtnhanvien.Text = lst.idnv;
            }
        }

        private void f_suathanhtoan_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void btnluu_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (Biencucbo.hdtthdtp == 0)
                {
                    tt.moitt(Biencucbo.matthdtp, Biencucbo.hopdong, txtdiengiai.Text, txtngaythanhtoan.DateTime,
                        int.Parse(txtlan.Text), double.Parse(txtgtth.Text), double.Parse(txtgttt.Text), txtghichu.Text,
                        new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                        double.Parse(txtcantru.Text), txtlinkhs.Text, Biencucbo.idnv,txtlinkgoc.Text);
                    hs.add(Biencucbo.matthdtp, "Thêm mới Thanh Toán TP: " + Biencucbo.matthdtp);
                }
                else if (Biencucbo.hdtthdtp == 1)
                {
                    tt.suatt(Biencucbo.matthdtp, txtdiengiai.Text, txtngaythanhtoan.DateTime, int.Parse(txtlan.Text),
                        double.Parse(txtgtth.Text), double.Parse(txtgttt.Text), txtghichu.Text,
                        double.Parse(txtcantru.Text), txtlinkhs.Text,txtlinkgoc.Text);
                    hs.add(Biencucbo.matthdtp, "Sửa Thanh Toán TP: " + Biencucbo.matthdtp);
                }
                MessageBox.Show("Done!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnhuy_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void layttlbllink(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().vanbandens select a).Single(t => t.id == id);
                lbllink.Text = lst.noidung;
            }
            catch (Exception ex)
            {
                lbllink.Text = "";
            }
        }
        private void txtlinkhs_EditValueChanged(object sender, EventArgs e)
        {
            layttlbllink(txtlinkhs.Text);
        }

        private void layttlbllinkgoc(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().vanbandens select a).Single(t => t.id == id);
                lbllinkgoc.Text = lst.noidung;
            }
            catch (Exception ex)
            {
                lbllinkgoc.Text = "";
            }
        }
        private void txtlinkgoc_EditValueChanged(object sender, EventArgs e)
        {
            layttlbllinkgoc(txtlinkgoc.Text);
        }

        private void loadslutxtlinkgoc()
        {
            txtlinkgoc.Properties.DataSource = (from a in new KetNoiDBDataContext().vanbandens select a);
        }
    }
}