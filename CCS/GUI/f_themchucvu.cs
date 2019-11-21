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
    public partial class f_themchucvu : DevExpress.XtraEditors.XtraForm
    {
       KetNoiDBDataContext db = new KetNoiDBDataContext();
        t_dmchucvu _cv = new t_dmchucvu();
        public f_themchucvu()
        {
            InitializeComponent();
        }

        private void f_themchucvu_Load(object sender, EventArgs e)
        {
            if (Biencucbo.hdcv == 0)
            {
                txtchucvu.Text = "";
                txtid.Text = "";
            }
            else if(Biencucbo.hdcv == 1)
            {
                db = new KetNoiDBDataContext();
                var lst = (from a in db.dmchucvus select a).Single(t => t.id == Biencucbo.idcvu);
                txtid.ReadOnly = true;
                txtid.Text = lst.id;
                txtchucvu.Text = lst.chucvu;
            }
            
        }

        private void btnluu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtid.Text != "" || txtchucvu.Text != "")
            {
                if (Biencucbo.hdcv == 0)
                {
                    var lst = (from a in db.dmchucvus where a.id == txtid.Text select a);
                    if (lst.Count() == 0)
                    {
                        _cv.themcv(txtid.Text, txtchucvu.Text);
                    }
                    else
                    {
                        XtraMessageBox.Show("Mã id bị trùng. Vui Lòng kiểm tra lại!", "Thông Báo");
                        return;
                        ;
                    }
                }
                else if (Biencucbo.hdcv == 1)
                {
                    _cv.suacv(txtid.Text,txtchucvu.Text);
                }
                XtraMessageBox.Show("Done!", "Thông Báo");
                Close();
            }
            else
            {
                XtraMessageBox.Show("Thông tin nhập chưa đầy đủ. Vui lòng kiểm tra lại");
                
            }
        }

        private void btndong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}