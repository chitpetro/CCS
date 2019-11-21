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
using DevExpress.Xpo;

namespace GUI
{
    public partial class f_chamcong : DevExpress.XtraEditors.XtraForm
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        t_chamcongnv cc = new t_chamcongnv();
        t_history hs = new t_history();
        t_tudong td = new t_tudong();
        private int _so = 0;
        private string _id = "";
        public f_chamcong()
        {
            InitializeComponent();
        }

        private void loadbtn()
        {
            btnmo.Enabled = true;
            btnthem.Enabled = true;
            btnluu.Enabled = false;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnreload.Enabled = false;

            txtthoigian.ReadOnly = true;
            txtngaycong.ReadOnly = true;
            txtngayphep.ReadOnly = true;
            txtkhongluong.ReadOnly = true;
            txtngaykhac.ReadOnly = true;
            txtghichu.ReadOnly = true;
        }
        private void thembtn()
        {
            btnmo.Enabled = false;
            btnthem.Enabled = false;
            btnluu.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnreload.Enabled = true;
            txtthoigian.ReadOnly = false;
            txtngaycong.ReadOnly = false;
            txtngayphep.ReadOnly = false;
            txtkhongluong.ReadOnly = false;
            txtngaykhac.ReadOnly = false;
            txtghichu.ReadOnly = false;
        }
        private void f_chamcong_Load(object sender, EventArgs e)
        {
            loadbtn();
            lblnv.Text = "<b> Nhân Viên: </b>" +
                         (from a in db.nhanviens select a).Single((t => t.id == Biencucbo.ma)).ten;

            try
            {
                var lstso = (from a in db.chamcongnvcongtrinhs where a.iddv == Biencucbo.donvi && a.idnv == Biencucbo.ma select a.so).Max();
                var lst = (from a in db.chamcongnvcongtrinhs where a.iddv == Biencucbo.donvi && a.idnv == Biencucbo.ma select a).Single(t => t.so == lstso);
                loadata(lst.id);
            }
            catch (Exception ex)
            {

            }




        }

        private void loadata(string id)
        {
            try
            {
                var lst = (from a in db.chamcongnvcongtrinhs where a.iddv == Biencucbo.donvi && a.idnv == Biencucbo.ma select a).Single(t => t.id == id);
                _id = lst.id;
                txtthoigian.DateTime = DateTime.Parse(lst.thoigian.ToString());
                txtngaycong.Text = lst.ngaycong.ToString();
                txtngayphep.Text = lst.ngayphep.ToString();
                txtkhongluong.Text = lst.khongluong.ToString();
                txtngaykhac.Text = lst.ngaykhac.ToString();
                txtghichu.Text = lst.ghichu;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnthem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                thembtn();
                Biencucbo.hdcc = 0;
                txtthoigian.DateTime = DateTime.Now;
                txtngaycong.Text = "0";
                txtngayphep.Text = "0";
                txtkhongluong.Text = "0";
                txtngaykhac.Text = "0";
                txtghichu.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnsua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_id != "")
            {
                thembtn();
                Biencucbo.hdcc = 1;
            }
        }

        private void btnxoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_id != "")
            {
                cc.xoa(_id);
                _id = "";
                txtthoigian.Text = "";
                txtngaycong.Text = "0";
                txtngayphep.Text = "0";
                txtkhongluong.Text = "0";
                txtngaykhac.Text = "0";
                txtghichu.Text = "";
                Biencucbo.hdcc = 2;
                loadbtn();
                MessageBox.Show("Done!");
            }

        }



        private void btnmo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            f_dschamcong frm = new f_dschamcong();
            frm.ShowDialog();

            try
            {
                if (Biencucbo.id != "")
                    loadata(Biencucbo.id);
            }
            catch (Exception ex)
            {

            }

        }

        private void btnreload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {

                if (Biencucbo.hdcc == 1)
                {
                    loadata(_id);
                    loadbtn();
                    Biencucbo.hdcc = 2;
                }
                else if (Biencucbo.hdcc == 0)
                {
                    try
                    {
                        var lstso = (from a in db.chamcongnvcongtrinhs where a.iddv == Biencucbo.donvi && a.idnv == Biencucbo.ma select a.so).Max();
                        var lst = (from a in db.chamcongnvcongtrinhs where a.iddv == Biencucbo.donvi && a.idnv == Biencucbo.ma select a).Single(t => t.so == lstso);
                        loadata(lst.id);
                        loadbtn();
                        Biencucbo.hdcc = 2;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void luu()
        {
            if (txtthoigian.Text == "")
            {
                MessageBox.Show("Bạn Chưa chọn thời gian - Vui lòng kiểm tra lại");
                return;
            }
            if (Biencucbo.hdcc == 0)
            {
                try
                {
                    var check = "CC" + Biencucbo.donvi;
                    var lst1 = (from a in new KetNoiDBDataContext().tudongs where a.maphieu == check select a);
                    if (lst1.Count() == 0)
                    {
                        td.themtudong(check, 2);
                        _id = check + "_000001";
                        _so = 1;
                    }
                    else
                    {
                        int k = 0;
                        var lst = (from a in new KetNoiDBDataContext().tudongs select a).Single(t => t.maphieu == check);
                        _so = int.Parse(lst.so.ToString());
                        k = _so;
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
                        _id = check + "_" + so0 + k;
                        k = k + 1;
                        td.suatudong(check, k);

                    }
                    cc.moi(_id, Biencucbo.ma, new DateTime(txtthoigian.DateTime.Year, txtthoigian.DateTime.Month, 1), txtngaycong.Text, txtngayphep.Text, txtkhongluong.Text, txtngaykhac.Text, txtghichu.Text, _so);
                    MessageBox.Show("Done!");
                    Biencucbo.hdcc = 2;
                    loadbtn();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            else if (Biencucbo.hdcc == 1)
            {
                try
                {
                    cc.sua(_id, Biencucbo.ma, new DateTime(txtthoigian.DateTime.Year, txtthoigian.DateTime.Month, 1), int.Parse(txtngaycong.Text), int.Parse(txtngayphep.Text), int.Parse(txtkhongluong.Text), int.Parse(txtngaykhac.Text), txtghichu.Text, _so);
                    MessageBox.Show("Done!"); Biencucbo.hdcc = 2;
                    loadbtn();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
        }


        private void btnluu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            db = new KetNoiDBDataContext();
            int ngayphep = 0;
            int np = 0;
            try
            {
                //ngayphep = int.Parse((from a in db.chamcongnvcongtrinhs
                //                      where a.idnv == Biencucbo.ma && DateTime.Parse(a.thoigian.ToString()).Year == txtthoigian.DateTime.Year
                //                      select a.ngayphep).Sum().ToString());
                
                //code moi sua 25/07/2019
                ngayphep = int.Parse((from a in db.chamcongnvcongtrinhs
                                      where a.idnv == Biencucbo.ma
                                      && a.thoigian.Value.Year == txtthoigian.DateTime.Year
                                      select a.ngayphep).Sum().ToString());
            }
            catch (Exception ex)
            {
                ngayphep = 0;
            }

            if (int.Parse(txtngayphep.Text) + ngayphep > 15)
            {
                XtraMessageBox.Show("- Tổng số ngày đã nghỉ phép trong năm nay là : " + ngayphep + "\n- Số ngày nghỉ phép không được vượt quá 15 ngày", "Thông Báo");
                return;
            }
            if (Biencucbo.hdcc == 0)
            {
                var lst = (from a in new KetNoiDBDataContext().chamcongnvcongtrinhs
                           where a.idnv == Biencucbo.ma && a.thoigian == txtthoigian.DateTime
                           select a);
                if (lst.Count() == 0)
                {
                    luu();
                }
                else
                {
                    MessageBox.Show("Thời gian Tháng " + txtthoigian.Text + " của nhân viên " +
                                    (from a in db.nhanviens select a).Single((t => t.id == Biencucbo.ma)).ten +
                                    " đã tồn tại trong bảng chấm công nên không thể lưu - Vui lòng kiểm tra lại");
                }
            }
            if (Biencucbo.hdcc == 1)
            {
                var lst = (from a in new KetNoiDBDataContext().chamcongnvcongtrinhs
                           where a.idnv == Biencucbo.ma && a.thoigian == txtthoigian.DateTime && a.id != _id
                           select a);
                if (lst.Count() == 0)
                {
                    luu();
                }
                else
                {
                    MessageBox.Show("Thời gian Tháng " + txtthoigian.Text + " của nhân viên " +
                        (from a in db.nhanviens select a).Single((t => t.id == Biencucbo.ma)).ten +
                        " đã tồn tại trong bảng chấm công nên không thể lưu - Vui lòng kiểm tra lại");
                }
            }
        }

        private void f_chamcong_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Biencucbo.hdcc != 2)
            {

                if (
                    MessageBox.Show("Thông tin này chưa được lưu, bạn có muốn lưu lại trước khi thoát?", "Thông Báo",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    db = new KetNoiDBDataContext();
                    int ngayphep = 0;

                    try
                    {
                        //ngayphep = int.Parse((from a in db.chamcongnvcongtrinhs where a.idnv == Biencucbo.ma /*&& a.id != Biencucbo.id*/ && DateTime.Parse(a.ngayphep.ToString()).Year == txtthoigian.DateTime.Year select a.ngayphep).Sum().ToString());

                        //code moi sua 25/07/2019
                        ngayphep = int.Parse((from a in db.chamcongnvcongtrinhs
                                              where a.idnv == Biencucbo.ma
                                              && a.thoigian.Value.Year == txtthoigian.DateTime.Year
                                              select a.ngayphep).Sum().ToString());
                    }
                    catch (Exception ex)
                    {
                        ngayphep = 0;
                    }

                    if (int.Parse(txtngayphep.Text) + ngayphep > 15)
                    {
                        XtraMessageBox.Show("- Tổng số ngày đã nghỉ phép trong năm nay là : " + ngayphep + "\n- Số ngày nghỉ phép không được vượt quá 15 ngày", "Thông Báo");
                        return;
                    }
                    if (Biencucbo.hdcc == 0)
                    {
                        var lst = (from a in new KetNoiDBDataContext().chamcongnvcongtrinhs
                                   where a.idnv == Biencucbo.ma && a.thoigian == txtthoigian.DateTime
                                   select a);
                        if (lst.Count() == 0)
                        {
                            luu();
                        }
                        else
                        {
                            MessageBox.Show("Thời gian Tháng " + txtthoigian.Text + " của nhân viên " +
                                            (from a in db.nhanviens select a).Single((t => t.id == Biencucbo.ma)).ten +
                                            " đã tồn tại trong bảng chấm công nên không thể lưu - Vui lòng kiểm tra lại");
                        }
                    }
                    if (Biencucbo.hdcc == 1)
                    {
                        var lst = (from a in new KetNoiDBDataContext().chamcongnvcongtrinhs
                                   where a.idnv == Biencucbo.ma && a.thoigian == txtthoigian.DateTime && a.id != _id
                                   select a);
                        if (lst.Count() == 0)
                        {
                            luu();
                        }
                        else
                        {
                            MessageBox.Show("Thời gian Tháng " + txtthoigian.Text + " của nhân viên " +
                                (from a in db.nhanviens select a).Single((t => t.id == Biencucbo.ma)).ten +
                                " đã tồn tại trong bảng chấm công nên không thể lưu - Vui lòng kiểm tra lại");
                        }
                    }

                }
            }
        }
    }
}