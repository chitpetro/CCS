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
//using DevExpress.DXCore.Controls.Data.Linq;
using BUS;

namespace GUI
{
    public partial class f_dschamcong : DevExpress.XtraEditors.XtraForm
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        t_todatatable _todatatable = new t_todatatable();
        private bool dble = false;
        public f_dschamcong()
        {
            InitializeComponent();
        }

        private void f_dschamcong_Load(object sender, EventArgs e)
        {
            this.Text = "Bảng chấm công nhân viên: " + (from a in db.nhanviens select a).Single(t => t.id == Biencucbo.ma).ten;
            WindowState = FormWindowState.Maximized;
            loaddata();
        }

        private void loaddata()
        {
            gcontrol.DataSource =
                _todatatable.addlst((from a in db.chamcongnvcongtrinhs where a.idnv == Biencucbo.ma select a).ToList());
        }

        private void gview_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (dble == true)
            {
                Biencucbo.id = gview.GetFocusedRowCellValue("id").ToString();
                this.Close();
            }
        }

        private void gview_Click(object sender, EventArgs e)
        {
            dble = false;
        }

        private void gview_DoubleClick(object sender, EventArgs e)
        {
            dble = true;
        }
    }
}