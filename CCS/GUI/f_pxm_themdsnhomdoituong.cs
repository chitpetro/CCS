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
    public partial class f_pxm_themdsnhomdoituong : frmthemds
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        t_pxm_nhomdt nhom = new t_pxm_nhomdt();
        t_history hs = new t_history();
        private int _hdong;
        private string _ma;

        public f_pxm_themdsnhomdoituong()
        {
            InitializeComponent();
        }

        protected override void load()
        {
            _hdong = Biencucbo.hdong;

            if (_hdong == 1)
            {
                _ma = Biencucbo.ma;
                txtid.ReadOnly = true;
                var lst = (from a in dbData.pxm_nhomdoituongs select a).Single(t => t.id == _ma);
                txtid.Text = lst.id;
                txtten.Text = lst.ten;
            }
        }

        protected override void huy()
        {
            Close();
        }
        protected override void luu()
        {
            try
            {
                if (txtid.Text == string.Empty || txtten.Text == string.Empty)
                {
                    XtraMessageBox.Show("Thông tin chưa đầy đủ vui lòng kiểm tra lại!", "Thông Báo");
                    return;
                }

                if (_hdong == 0)
                {
                    var lst = (from a in dbData.pxm_nhomdoituongs where a.id == txtid.Text || a.ten == txtten.Text select a);
                    if (lst.Count() > 0)
                    {
                        XtraMessageBox.Show("Nhóm đối tượng này đã tồn tại, vui lòng kiêm tra lại", "Thông Báo");
                        return;
                    }

                    nhom.them(txtid.Text, txtten.Text);
                    hs.add(txtid.Text, "Thêm mới nhóm đối tượng (PXM)");
                    XtraMessageBox.Show("Done!");

                }
                else if (_hdong == 1)
                {
                    nhom.sua(txtid.Text, txtten.Text);
                    hs.add(txtid.Text, "Sửa nhóm đối tượng (PXM)");
                    XtraMessageBox.Show("Done!");
                }

                DialogResult = DialogResult.OK;
                huy();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }

}