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

namespace GUI.theodoitt.chiphikhac
{
    public partial class f_themtheodoitt_cpk : frm.frmthemds
    {
        public f_themtheodoitt_cpk()
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
                custom.mes_thongtinchuadaydu();
            }

            if (checknull > 0)
                return false;
            return true;
        }

        private void layttlbltenidnv(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().accounts select a).Single(t => t.id == id);
                lbltenidnv.Text = lst.name;
            }
            catch (Exception ex)
            {
                lbltenidnv.Text = "";
            }
        }

        private void idnvTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            layttlbltenidnv(idnvTextEdit.Text);
        }
        private int _hdong = 0;
        private string _key = "";
        c_theodoitt_cpk cpm = new c_theodoitt_cpk();
        t_history hs = new t_history();

        protected override void load()
        {
            _hdong = Biencucbo.hdong;
            idnvTextEdit.Text = Biencucbo.idnv;
            if (_hdong == 1)
            {
                _key = custom.laykey();
            }
            if (_hdong == 2)
            {
                _key = Biencucbo.key;

                var lst = (from a in new KetNoiDBDataContext().theodoitt_cpks select a).Single(t => t.id == _key);

                dataLayoutControl1.DataSource = lst;
            }


        }

        protected override void luu()
        {
            if (kiemtra())
            {
                if (_hdong == 1)
                {
                    cpm.them(_key, Biencucbo.ma, ngaychuyenDateEdit.DateTime, double.Parse(sotienchuyenSpinEdit.Text), ghichuTextEdit.Text, loaichuyenComboBoxEdit.Text, idnvTextEdit.Text, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));
                    hs.add(Biencucbo.ma + ngaychuyenDateEdit.Text, "Thêm Theoi Dõi Chuyển Tiền Chi Phí Quản Lý");
                    custom.mes_done();
                    DialogResult = DialogResult.OK;
                }
                if (_hdong == 2)
                {
                    cpm.sua(_key, ngaychuyenDateEdit.DateTime, double.Parse(sotienchuyenSpinEdit.Text), ghichuTextEdit.Text, loaichuyenComboBoxEdit.Text);
                    hs.add(Biencucbo.ma + ngaychuyenDateEdit.Text, "Sửa Theoi Dõi Chuyển Tiền Chi Phí Quản Lý");
                    custom.mes_done();
                    DialogResult = DialogResult.OK;
                }
            }
        }

    }
}