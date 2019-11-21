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

namespace GUI
{
    public partial class f_pxmthemloaisp : frmthemds
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        t_pxmloaisp sp = new t_pxmloaisp();
        t_history hs = new t_history();
        private int _hdong;
        private string _ma;
        public f_pxmthemloaisp()
        {
            InitializeComponent();
        }

        protected override void huy()
        {
            Close();
        }

        protected override void load()
        {
            _hdong = Biencucbo.hdong;
            if (_hdong == 1)
            {
                _ma = Biencucbo.ma;
                txtid.ReadOnly = true;

                var lst = (from a in dbData.pxm_loaisps select a).Single(t => t.id == _ma);
                txtid.Text = lst.id;
                txttenloai.Text = lst.tenloai;
            }
        }

        protected override void luu()
        {
            if (txtid.Text == string.Empty || txttenloai.Text == string.Empty)
            {
                XtraMessageBox.Show("Thông tin bị trùng, vui lòng kiểm tra lại", "Thông Báo");
                return;
            }
            try
            {
                if (_hdong == 0)
                {
                    using (dbData = new KetNoiDBDataContext())
                    {
                        var lst = (from a in dbData.pxm_loaisps where a.id == txtid.Text select a);
                        if (lst.Count() > 0)
                        {
                            XtraMessageBox.Show("Thông tin bị trùng, vui lòng kiểm tra lại");

                        }
                    }
                    sp.them(txtid.Text, txttenloai.Text);
                    hs.add(txtid.Text, "Thêm mới loại sản phẩm");
                    MessageBox.Show("Done");
                    DialogResult = DialogResult.OK;
                    huy();

                }
                else
                {
                    sp.sua(txtid.Text,txttenloai.Text);
                    hs.add(txtid.Text,"Sửa loại sản phẩm");
                    XtraMessageBox.Show("Done");
                    DialogResult = DialogResult.OK;
                    huy();
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString());
            }
        }
    }
}