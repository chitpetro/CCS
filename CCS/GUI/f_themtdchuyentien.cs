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
using DAL;
using BUS;
using GUI.Properties;

namespace GUI
{
    public partial class f_themtdchuyentien : frmthemds
    {

        public f_themtdchuyentien()
        {
            InitializeComponent();
        }

        private bool kiemtra()
        {
            int checknull = 0;
            int checdup = 0;
            ngaychuyenDateEdit.Properties.ContextImage = null;

            if (custom.checknulltext(ngaychuyenDateEdit))
                checknull++;

            loaichuyenComboBoxEdit.Properties.ContextImage = null;

            if (custom.checknulltext(loaichuyenComboBoxEdit))
                checknull++;
            if (checknull > 0)
            {
                XtraMessageBox.Show("Thông tin chưa đầy đủ, vui lòng kiểm tra lại");
            }

            if (checknull > 0)
                return false;
            return true;
        }


        private int _hdong = 0;
        private string _key = "";
        c_tdchuyentien td = new c_tdchuyentien();
        t_history hs = new t_history();

        protected override void load()
        {
            _hdong = Biencucbo.hdong;
            _key = Biencucbo.key;
            idnvTextEdit.Text = Biencucbo.idnv;
            if (_hdong == 2)
            {
                _key = Biencucbo.key;
                idnvTextEdit.ReadOnly = true;
                var lst = (from a in new KetNoiDBDataContext().theodoitts select a).Single(t => t.id == _key);

                dataLayoutControl1.DataSource = lst;
            }
           
        }

        protected override void luu()
        {
            if (kiemtra())
            {
                if (_hdong == 1)
                {
                    td.them(_key, Biencucbo.ma, ngaychuyenDateEdit.DateTime, double.Parse(sotienchuyenSpinEdit.Text), ghichuTextEdit.Text, loaichuyenComboBoxEdit.Text, idnvTextEdit.Text);

                    hs.add(idnvTextEdit.Text, "Thêm Chuyển Tiền Thanh Toán");
                    XtraMessageBox.Show("Done!");
                    DialogResult = DialogResult.OK;
                }
                if (_hdong == 2)
                {
                    td.sua(_key, ngaychuyenDateEdit.DateTime, double.Parse(sotienchuyenSpinEdit.Text), ghichuTextEdit.Text, loaichuyenComboBoxEdit.Text);
                    hs.add(idnvTextEdit.Text, "Sửa Chuyển Tiền Thanh Toán");
                    XtraMessageBox.Show("Done!");
                    DialogResult = DialogResult.OK;
                }
            }
        }



    }
}