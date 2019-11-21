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

namespace GUI.danhmuc
{
    public partial class f_dsmuccp : frm.frmds
    {
        t_history hs = new t_history();
        c_dmchiphi muccp = new c_dmchiphi();
        public f_dsmuccp()
        {
            InitializeComponent();
        }

        #region override

        protected override bool them()
        {
            Biencucbo.hdong = 1;
            var frm = new danhmuc.f_themmuccp();
            if (frm.ShowDialog() == DialogResult.OK)
                return true;
            return false;
        }

        protected override bool sua()
        {
            Biencucbo.hdong = 2;
            Biencucbo.key = gv.GetFocusedRowCellValue("id").ToString();
            var frm = new danhmuc.f_themmuccp();
            if (frm.ShowDialog() == DialogResult.OK)
                return true;
            return false;
        }

        protected override bool saochep()
        {
            Biencucbo.hdong = 3;
            Biencucbo.key = gv.GetFocusedRowCellValue("id").ToString();
            var frm = new danhmuc.f_themmuccp();
            if (frm.ShowDialog() == DialogResult.OK)
                return true;
            return false;
        }

        protected override bool xoa()
        {
            try
            {
                muccp.xoa(gv.GetFocusedRowCellValue("id").ToString());
                hs.add(gv.GetFocusedRowCellValue("id").ToString(), "Xóa Xóa Mục Chi Phí");
                custom.mes_done();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        protected override void load()
        {
            gd.DataSource = new KetNoiDBDataContext().muccps;
        }


        #endregion
        
    }
}