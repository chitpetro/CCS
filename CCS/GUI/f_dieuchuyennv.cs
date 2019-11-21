using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BUS;
using DAL;

namespace GUI
{
    public partial class f_dieuchuyennv : DevExpress.XtraEditors.XtraForm
    {
        public f_dieuchuyennv()
        {
            InitializeComponent();
        }

        private void f_dieuchuyennv_Load(object sender, EventArgs e)
        {
            txtnct.ReadOnly = true;
            try
            {
                var lst2 = (from a in new KetNoiDBDataContext().r_nhanviens select a).Single(t => t.id == Biencucbo.ma);
                txtnct.Text = lst2.noicongtac;
                lblnct.Text = lst2.tencongtrinh;
                lbltt.Text = "Id: " + lst2.id + " - Họ và Tên: " + lst2.ten;
                txtngay.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            }
            catch (Exception)
            {


            }
            try
            {
                txtndc.Properties.DataSource = (from a in new KetNoiDBDataContext().congtrinhs
                                                select new
                                                {
                                                    a.id,
                                                    tenct = a.tencongtrinh,
                                                    a.khuvuc
                                                });
            }
            catch
            {

            }





        }

        private void txtndc_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().congtrinhs select a).Single((t => t.id == txtndc.Text));
                lblndc.Text = lst.tencongtrinh;
            }
            catch (Exception)
            {


            }
        }
        t_history hs = new t_history();
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        t_tudong td = new t_tudong();
        private int txt1 = 0;
        private string txtid = "";
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtngay.Text == "" || txtndc.Text == "")
                {
                    Lotus.MsgBox.ShowErrorDialog("Thông tin chưa đầy đủ - Vui lòng kiểm tra lại");
                }
                else
                {
                    var check = Biencucbo.ma + Biencucbo.donvi;
                    var lst1 = (from s in new KetNoiDBDataContext().tudongs where s.maphieu == check select new { s.so, s.maphieu }).ToList();

                    if (lst1.Count == 0)
                    {
                        int so;

                        so = 2;
                        td.themtudong(check, so);
                        txtid = check + "_000001";
                        txt1 = 1;
                    }
                    else
                    {
                        int k;
                        txt1 = int.Parse(lst1.Single(t => t.maphieu == check).so.ToString());
                        k = 0;
                        k = txt1;
                        var so0 = "";
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
                        txtid = check + "_" + so0 + k;

                        k = k + 1;

                        td.suatudong(check, k);
                    }
                    KetNoiDBDataContext db = new KetNoiDBDataContext();
                    dieuchuyen_nhanvien pt = new dieuchuyen_nhanvien();
                    pt.id = txtid;
                    pt.idnv = Biencucbo.ma;
                    pt.iddv = Biencucbo.donvi;
                    pt.mact_ht = txtnct.Text;
                    pt.mact_dc = txtndc.Text;
                    pt.ngaydc = txtngay.DateTime;
                    pt.so = txt1;
                    pt.thoigian = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    db.dieuchuyen_nhanviens.InsertOnSubmit(pt);
                    db.dieuchuyen_nhanviens.Context.SubmitChanges();

                    nhanvien nv = (from a in db.nhanviens select a).Single(t => t.id == Biencucbo.ma);
                    nv.noicongtac = txtndc.Text;
                    db.nhanviens.Context.SubmitChanges();
                    hs.add(txtid, "Thêm Điều Chuyển Nhân Sự");
                    this.Close();

                }
            }
            catch (Exception)
            {


            }
        }
    }
}