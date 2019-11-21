using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAL;
using DevExpress.XtraEditors;
using GUI.Properties;

namespace GUI.danhmuc
{
    public partial class f_themmuccp : frm.frmthemds
    {
        
        public f_themmuccp()
        {
            InitializeComponent();
        }

        private int _hdong = 0;
        private string _key = "";
        c_dmchiphi muccp = new c_dmchiphi();
        t_history hs = new t_history();

        protected override void load()
        {
            _hdong = Biencucbo.hdong;
            if (_hdong == 2)
            {
                _key = Biencucbo.key;
                idTextEdit.ReadOnly = true;
                var lst = (from a in new KetNoiDBDataContext().muccps select a).Single(t => t.id == _key);

                dataLayoutControl1.DataSource = lst;
            }
            if (_hdong == 3)
            {
                _key = Biencucbo.key;
                var lst = (from a in new KetNoiDBDataContext().muccps select a).Single(t => t.id == _key);
                dataLayoutControl1.DataSource = lst;
                idTextEdit.Text = string.Empty;
                _hdong = 1;

            }

        }

        protected override void luu()
        {
            if (kiemtra())
            {
                if (_hdong == 1)
                {
                    muccp.them(idTextEdit.Text,muccp1TextEdit.Text);
                    hs.add(idTextEdit.Text, "Thêm Mục Chi Phí");
                    custom.mes_done();
                    DialogResult = DialogResult.OK;
                }
                if (_hdong == 2)
                {
                    muccp.sua(idTextEdit.Text,muccp1TextEdit.Text);
                    hs.add(idTextEdit.Text, "Sửa Mục Chi Phí");
                    custom.mes_done();
                    DialogResult = DialogResult.OK;
                }
            }
        }           
        

        private bool kiemtra()
        {
            int checknull = 0;
            int checdup = 0;
            idTextEdit.Properties.ContextImage = null;

            if (custom.checknulltext(idTextEdit))
                checknull++;

            muccp1TextEdit.Properties.ContextImage = null;

            if (custom.checknulltext(muccp1TextEdit))
                checknull++;
            if (checknull > 0)
            {
                custom.mes_thongtinchuadaydu();
            }
            var lst = (from a in new KetNoiDBDataContext().muccps select a);
            if (_hdong == 1)
            {
                if (lst.Where(t => t.id == idTextEdit.Text).Count() > 0)
                {
                    idTextEdit.Properties.ContextImage = Resources.trung;
                    checdup++;
                }
                if (lst.Where(t => t.muccp1 == muccp1TextEdit.Text).Count() > 0)
                {
                    muccp1TextEdit.Properties.ContextImage = Resources.trung;
                    checdup++;
                }

            }
            if (_hdong == 2)
            {
                if (lst.Where(t => t.id != idTextEdit.Text && t.muccp1 == muccp1TextEdit.Text).Count() > 0)
                {
                    muccp1TextEdit.Properties.ContextImage = Resources.trung;
                    checdup++;
                }
            }
            if (checdup > 0)
                XtraMessageBox.Show("Mục chi phí này đã tồn tại. Vui lòng kiểm tra lại","THÔNG BÁO");
            if (checdup > 0 || checknull > 0)
                return false;
            return true;
        }                   
    }
}