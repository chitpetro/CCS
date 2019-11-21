using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DAL;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using GUI.Properties;
using Lotus;

namespace GUI
{
    public partial class f_theodoiphuongtien : Form
    {
        public static string tenpt, dv_ht, tendv_ht, dt_ht, tendt_ht, tendv_dc, tendt_dc;
        private readonly KetNoiDBDataContext db = new KetNoiDBDataContext();

        private readonly t_theodoiphuongtien tdpt = new t_theodoiphuongtien();

        public f_theodoiphuongtien()
        {
            InitializeComponent();

            txtphuongtien.Properties.DataSource = new KetNoiDBDataContext().phuongtiens;
            txtiddt.Properties.DataSource = new KetNoiDBDataContext().nhanviens;
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void f_dieuchuyenphuongtien_Load(object sender, EventArgs e)
        {
            if (Biencucbo.tdpt == 1)
            {
                txtphuongtien.Enabled = false;
                txtthoigian.Enabled = false;
                //try
                //{
                var Lst = (from a in db.theodoi_phuongtiens
                           join b in db.phuongtiens on a.mapt equals b.id
                           select new
                           {
                               a.id,
                               a.mapt,
                               b.ten,
                               a.thoigian,
                               //soluong = a.soluong,
                               a.madv,
                               a.sogiohd,
                               a.sogiodau,
                               a.sogiocuoi,
                               a.socahd,
                               a.sochuyen,
                               a.songay,
                               a.sokm,
                               a.tondk,
                               a.captk,
                               //a.chuyencho,
                               a.tieuhaokhac,
                               a.ghichu,
                               a.tonck,
                               a.tieuhaothuctetk,
                               a.tieuhaodv,
                               a.chenhlech,
                               a.dinhmuc,
                               iddt = a.iddt != "" ? a.iddt : ""
                           }).Single(t => t.id == Biencucbo.ma);
                // (t => t.mapt == Biencucbo.ma); //.Single();// (t => t.mapt == Biencucbo.ma);

                txtphuongtien.Text = Lst.mapt;
                txttenpt.Text = Lst.ten;
                //txtsoluong.Text = Lst.soluong.ToString();
                txtthoigian.DateTime = DateTime.Parse(Lst.thoigian.ToString());
                txtsogio.Text = Lst.sogiohd.Value != 0 ? Lst.sogiohd.ToString() : "0";
                txtSoGioDau.Text = Lst.sogiodau.Value != 0 ? Lst.sogiodau.ToString() : "0";
                txtSoGioCuoi.Text = Lst.sogiocuoi.Value != 0 ? Lst.sogiocuoi.ToString() : "0";
                txtsoca.Text = Lst.socahd.Value != 0 ? Lst.socahd.ToString() : "0";
                txtsochuyen.Text = Lst.sochuyen.Value != 0 ? Lst.sochuyen.ToString() : "0";
                txtsongay.Text = Lst.songay.Value != 0 ? Lst.songay.ToString() : "0";
                txtsokm.Text = Lst.sokm.Value != 0 ? Lst.sokm.ToString() : "0";
                txttondk.Text = Lst.tondk.Value != 0 ? Lst.tondk.ToString() : "0";
                txtcaptk.Text = Lst.captk.Value != 0 ? Lst.captk.ToString() : "0";
                //txtchuyencho.Text = Lst.chuyencho.ToString();
                txtTieuHaoKhac.Text = Lst.tieuhaokhac.Value != 0 ? Lst.tieuhaokhac.ToString() : "0";
                txtGhiChu.Text = Lst.ghichu.ToString() != null  ? Lst.ghichu.ToString() : null;
                txttonck.Text = Lst.tonck.Value != 0 ? Lst.tonck.ToString() : "0";
                txttieuhaotk.Text = Lst.tieuhaothuctetk.Value != 0 ? Lst.tieuhaothuctetk.ToString() : "0";
                txttieuhaodv.Text = Lst.tieuhaodv.Value != 0 ? Lst.tieuhaodv.ToString() : "0";
                txtchenhlech.Text = Lst.chenhlech.Value != 0 ? Lst.chenhlech.ToString() : "0";
                txtiddt.Text = Lst.iddt;
                txtdinhmuc.Text = Lst.dinhmuc.Value != 0 ? Lst.dinhmuc.ToString() : "0";
            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (txtphuongtien.Text == "" || txtthoigian.Text == "")
            {
                MsgBox.ShowWarningDialog("Thông tin chưa đầy đủ - Vui lòng kiểm tra lại!");
            }
            else
            {
                if (Biencucbo.tdpt == 0)
                {
                    //khong cho trung ID va thang
                    var Lst = (from dt in db.theodoi_phuongtiens
                               where
                                   dt.madv == Biencucbo.mact &&
                                   (dt.thoigian.Value.Month.ToString().Length == 1
                                       ? "0" + dt.thoigian.Value.Month + "/" + dt.thoigian.Value.Year
                                       : dt.thoigian.Value.Month + "/" + dt.thoigian.Value.Year) == txtthoigian.Text &&
                                   dt.mapt == txtphuongtien.Text
                               select dt).ToList();

                    if (Lst.Count == 1)
                    {
                        MsgBox.ShowErrorDialog("Phương tiện trong tháng này đã tồn tại, Vui Lòng Kiểm tra Lại");
                    }
                    else
                    {
                        tdpt.moi(txtphuongtien.Text + Biencucbo.mact + DateTime.Now, txtphuongtien.Text,
                            DateTime.Parse(txtthoigian.Text), Biencucbo.mact
                            , double.Parse(txtsogio.Text)
                            , double.Parse(txtSoGioDau.Text)
                            , double.Parse(txtSoGioCuoi.Text),
                            double.Parse(txtsoca.Text), double.Parse(txtsochuyen.Text), double.Parse(txtsongay.Text),
                            double.Parse(txtsokm.Text), double.Parse(txtsoKmDau.Text), double.Parse(txtsoKmCuoi.Text),
                            Biencucbo.donvi, double.Parse(txttondk.Text),
                            double.Parse(txtcaptk.Text)
                            , double.Parse(txtTieuHaoKhac.Text),
                            txtGhiChu.Text,
                            double.Parse(txttonck.Text),
                            double.Parse(txttieuhaotk.Text), double.Parse(txttieuhaodv.Text),
                            double.Parse(txtchenhlech.Text), DateTime.Now, txtiddt.Text, double.Parse(txtdinhmuc.Text));
                        Close();
                    }
                }
                else
                {
                    tdpt.sua(Biencucbo.ma, txtphuongtien.Text, DateTime.Parse(txtthoigian.Text), Biencucbo.mact,
                        double.Parse(txtsogio.Text)
                         , double.Parse(txtSoGioDau.Text)
                            , double.Parse(txtSoGioCuoi.Text),
                        double.Parse(txtsoca.Text), double.Parse(txtsochuyen.Text),
                        double.Parse(txtsongay.Text), double.Parse(txtsokm.Text), double.Parse(txtsoKmDau.Text), double.Parse(txtsoKmCuoi.Text),
                        double.Parse(txttondk.Text),
                        double.Parse(txtcaptk.Text)
                       , double.Parse(txtTieuHaoKhac.Text),
                            txtGhiChu.Text,
                        double.Parse(txttonck.Text),
                        double.Parse(txttieuhaotk.Text), double.Parse(txttieuhaodv.Text),
                        double.Parse(txtchenhlech.Text), DateTime.Now, txtiddt.Text, double.Parse(txtdinhmuc.Text));
                    Close();
                }
            }
        }

        private void txtcaptk_TextChanged(object sender, EventArgs e)
        {
            txttieuhaotk.Text = tinh_tieuhaotk().ToString();
            txttieuhaodv.Text = tinh_tieuhaodonvi().ToString();
            txtchenhlech.Text = tinh_chenhlech().ToString();
        }

        private void txtiddt_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var list = (from a in db.nhanviens
                            select new
                            {
                                a.id,
                                a.ten,
                                a.diachi,
                                a.dienthoai
                            }).Single(t => t.id == txtiddt.Text);
                txttendt.Text = list.ten;
            }
            catch
            {
            }
        }

        private void txtphuongtien_Popup(object sender, EventArgs e)
        {
            var popupControl = sender as IPopupControl;
            var button = new SimpleButton
            {
                Image = Resources.icons8_Add_File_16,
                Text = "Thêm mới",
                BorderStyle = BorderStyles.NoBorder
            };
            button.Click += buttonPhuongTien_Click;
            button.Location = new Point(5, popupControl.PopupWindow.Height - button.Height - 5);
            popupControl.PopupWindow.Controls.Add(button);
            button.BringToFront();
        }

        public void buttonPhuongTien_Click(object sender, EventArgs e)
        {
            var frm = new f_phuongtien();
            frm.ShowDialog();
            txtphuongtien.Properties.DataSource =
                new KetNoiDBDataContext().phuongtiens.Where(t => t.madv == Biencucbo.mact);
        }

        private void txtiddt_Popup(object sender, EventArgs e)
        {
            var popupControl = sender as IPopupControl;
            var button = new SimpleButton
            {
                Image = Resources.icons8_Add_File_16,
                Text = "Thêm mới",
                BorderStyle = BorderStyles.NoBorder
            };
            button.Click += buttonNVLaiXe_Click;
            button.Location = new Point(5, popupControl.PopupWindow.Height - button.Height - 5);
            popupControl.PopupWindow.Controls.Add(button);
            button.BringToFront();
        }

        public void buttonNVLaiXe_Click(object sender, EventArgs e)
        {
            var frm = new f_nhanvienlaixe();
            frm.ShowDialog();
            txtiddt.Properties.DataSource = new KetNoiDBDataContext().nhanviens;
        }

        private void txttondk_TextChanged(object sender, EventArgs e)
        {
            txttieuhaotk.Text = tinh_tieuhaotk().ToString();
            txttieuhaodv.Text = tinh_tieuhaodonvi().ToString();
            txtchenhlech.Text = tinh_chenhlech().ToString();
        }

        private void txtsogio_EditValueChanged(object sender, EventArgs e)
        {
            txttieuhaodv.Text = tinh_tieuhaodonvi().ToString();
            txtchenhlech.Text = tinh_chenhlech().ToString();

            txtsoca.Text = (double.Parse(txtsogio.Text) / 8).ToString();
        }

        private void txtsokm_EditValueChanged(object sender, EventArgs e)
        {
            txttieuhaodv.Text = tinh_tieuhaodonvi().ToString();
            txtchenhlech.Text = tinh_chenhlech().ToString();
        }

        private void txttonck_TextChanged(object sender, EventArgs e)
        {
            txttieuhaotk.Text = tinh_tieuhaotk().ToString();
            txttieuhaodv.Text = tinh_tieuhaodonvi().ToString();
            txtchenhlech.Text = tinh_chenhlech().ToString();

            //txttonck.EditValue=
        }

        private void txtthoigian_EditValueChanged(object sender, EventArgs e)
        {
            lay_tondauki();
        }

        private void txtsoKmDau_EditValueChanged(object sender, EventArgs e)
        {
            txtsokm.Value = txtsoKmCuoi.Value - txtsoKmDau.Value;
            //
            txttieuhaodv.Text = tinh_tieuhaodonvi().ToString();
            txtchenhlech.Text = tinh_chenhlech().ToString();
        }

        private void txtsoKmCuoi_EditValueChanged(object sender, EventArgs e)
        {
            txtsokm.Value = txtsoKmCuoi.Value - txtsoKmDau.Value;
            //
            txttieuhaodv.Text = tinh_tieuhaodonvi().ToString();
            txtchenhlech.Text = tinh_chenhlech().ToString();
        }

        private void txtTieuHaoKhac_TextChanged(object sender, EventArgs e)
        {
            txttieuhaotk.Text = tinh_tieuhaotk().ToString();
            txttieuhaodv.Text = tinh_tieuhaodonvi().ToString();
            txtchenhlech.Text = tinh_chenhlech().ToString();
        }

        private void txtSoGioDau_EditValueChanged(object sender, EventArgs e)
        {
            txtsogio.Value = txtSoGioCuoi.Value - txtSoGioDau.Value;
            //
            txttieuhaodv.Text = tinh_tieuhaodonvi().ToString();
            txtchenhlech.Text = tinh_chenhlech().ToString();
        }

        private void txtSoGioCuoi_EditValueChanged(object sender, EventArgs e)
        {
            txtsogio.Value = txtSoGioCuoi.Value - txtSoGioDau.Value;
            //
            txttieuhaodv.Text = tinh_tieuhaodonvi().ToString();
            txtchenhlech.Text = tinh_chenhlech().ToString();
        }

        private void txtdinhmuc_EditValueChanged(object sender, EventArgs e)
        {
            txttieuhaotk.Text = tinh_tieuhaotk().ToString();
            txttieuhaodv.Text = tinh_tieuhaodonvi().ToString();
            txtchenhlech.Text = tinh_chenhlech().ToString();
        }

        private void txttieuhaotk_TextChanged(object sender, EventArgs e)
        {
            txttieuhaotk.Text = tinh_tieuhaotk().ToString();
            txttieuhaodv.Text = tinh_tieuhaodonvi().ToString();
            txtchenhlech.Text = tinh_chenhlech().ToString();
        }

        private void txtphuongtien_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var list = (from a in db.phuongtiens
                            select new
                            {
                                a.id,
                                a.ten,
                                //dinhmuc = a.dinhmuc != null ? a.dinhmuc.Value : 0,
                                a.dvdinhmuc,
                                a.madv
                            }).Single(t => t.id == txtphuongtien.Text);

                txttenpt.Text = list.ten;
                //txtdinhmuc.Text = list.dinhmuc.ToString();
                txtloaidm.Text = list.dvdinhmuc != "" ? list.dvdinhmuc : "";

                lay_tondauki();
            }
            catch
            {
            }
        }

        public double tinh_tieuhaotk()
        {
            var th = double.Parse(txttondk.Text)
                + double.Parse(txtcaptk.Text)
                //- double.Parse(txtchuyencho.Text)
                - double.Parse(txtTieuHaoKhac.Text)
                - double.Parse(txttonck.Text);
            return th;
        }

        public double tinh_tieuhaodonvi()
        {
            //1 LÍT / KM(XE)
            //1 LÍT / GIỜ(MÁY)
            //xe = tieu hao thuc te / km
            //may = tieu hao thuc te / gio
            double th = 0;
            if (txtloaidm.Text == "1 LÍT / KM(XE)")
            {
                th = double.Parse(txttieuhaotk.Text) / double.Parse(txtsokm.Text);
            }
            else if (txtloaidm.Text == "1 LÍT / GIỜ(MÁY)")
            {
                th = double.Parse(txttieuhaotk.Text) / double.Parse(txtsogio.Text);
            }
            else //chua co dinh muc
            {
                if (double.Parse(txtsokm.Text) > 0)
                {
                    th = double.Parse(txttieuhaotk.Text) / double.Parse(txtsokm.Text);
                }
                else if (double.Parse(txtsogio.Text) > 0)
                {
                    th = double.Parse(txttieuhaotk.Text) / double.Parse(txtsogio.Text);
                }
            }
            return th;
        }

        public double tinh_chenhlech()
        {
            var th = double.Parse(txtdinhmuc.Text) - double.Parse(txttieuhaodv.Text);
            if (th > 0)
                txtchenhlech.BackColor = Color.GreenYellow;
            else txtchenhlech.BackColor = Color.OrangeRed;

            return th;
        }

        public void lay_tondauki()
        {
            if (txtphuongtien.EditValue != null && txtthoigian.EditValue != null)
            {
                //kiem tra cong trinh . mapt. thoigian THANG NAY (THANG DANG CHON) da co chua
                var _check = from a in db.theodoi_phuongtiens
                             where a.madv == Biencucbo.mact
                             && a.mapt == txtphuongtien.EditValue.ToString()
                             && a.thoigian == txtthoigian.DateTime
                             select a;

                //co roi thi thong bao
                if (_check.Count() > 0)
                {
                    MsgBox.ShowWarningDialog("Tháng này đã nhập rồi!");
                    txtthoigian.EditValue = null;
                    return;
                }

                //kiem tra thoi gian THANG TRUOC (TRUOC THANG DANG CHON) da nhap chua
                //var _check2 = from a in db.theodoi_phuongtiens
                //              where a.madv == Biencucbo.mact
                //              && a.mapt == txtphuongtien.EditValue.ToString()
                //              && a.thoigian == txtthoigian.DateTime.AddMonths(-1)
                //              select a;

                var _check2 = (from a in db.theodoi_phuongtiens
                               where a.madv == Biencucbo.mact
                               && a.mapt == txtphuongtien.EditValue.ToString()
                               //&& a.thoigian ==
                               orderby a.thoigian descending
                               select a).Select(i => i.thoigian).Take(1);




                //chua co thi thong bao
                if (_check2.Count() == 0)
                {
                    //MsgBox.ShowWarningDialog("Bạn chưa nhập dữ liệu tháng trước đó! Không thể lấy Tồn Đầu Kì và Số KM Đầu!");
                    //txtthoigian.EditValue = null;
                    txttondk.EditValue = 0;
                    txtsoKmDau.EditValue = 0;
                    txtSoGioDau.EditValue = 0;
                    return;
                }

                //chua co
                //lay ton dau & so KM dau & soGioDau
                var lst = (from q in db.theodoi_phuongtiens
                           where q.madv == Biencucbo.mact
                           && q.mapt == txtphuongtien.EditValue.ToString()
                           //&& q.thoigian == txtthoigian.DateTime.AddMonths(-1)
                           orderby q.thoigian descending
                           select new
                           {
                               mapt = q.mapt,
                               thoigian = q.thoigian,
                               tondau = q.tonck,
                               kmdau = q.sokmcuoi,
                               gioDau = q.sogiocuoi
                           }).Take(1).ToList();

                if (lst == null) return;
                var _row = lst.ElementAt(0);
                txttondk.EditValue = _row.tondau != null ? _row.tondau.Value : 0;
                txtsoKmDau.EditValue = _row.kmdau != null ? _row.kmdau.Value : 0;
                txtSoGioDau.EditValue = _row.gioDau != null ? _row.gioDau.Value : 0;
            }
        }
    }
}