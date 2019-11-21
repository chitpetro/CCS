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
    public partial class f_dmchucvu : DevExpress.XtraEditors.XtraForm
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        t_todatatable _tTodatatable = new t_todatatable();
        t_dmchucvu cv = new t_dmchucvu();
        private bool dbl = false;
        
        public f_dmchucvu()
        {
            InitializeComponent();
        }

        private void load()
        {
            db = new KetNoiDBDataContext();
            var lst = from a in db.dmchucvus select a;
            gd.DataSource = _tTodatatable.addlst(lst.ToList());

        }
        private void f_dmchucvu_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnthem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            f_themchucvu frm  = new f_themchucvu();
            Biencucbo.hdcv = 0;
            frm.ShowDialog();
            Biencucbo.hdcv = 2;
            load();
        }

        private void sua()
        {
            Biencucbo.idcvu = gv.GetFocusedRowCellValue("id").ToString();
            Biencucbo.hdcv = 1;
            f_themchucvu frm = new f_themchucvu();
            frm.ShowDialog();
            Biencucbo.hdcv = 2;
            load();
        }
        private void btnsua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sua();
        }

        private void gd_Click(object sender, EventArgs e)
        {
            dbl = false;
        }

        private void gd_DoubleClick(object sender, EventArgs e)
        {
            dbl = true;
        }

        private void gv_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (dbl == true)
            {
                sua();
            }
        }

        private void btnxoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa Chức Vụ này", "Thông Báo", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                cv.xoacv(gv.GetFocusedRowCellValue("id").ToString());
                XtraMessageBox.Show("Done!", "Thông Báo");
                load();
            }
        }
    }
}