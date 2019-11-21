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

namespace GUI.HoSoXeMay
{
    public partial class f_dshopdongmuaxe : frm.frmds2
    {

        t_history hs = new t_history();
        c_hopdongmuaxe hd = new c_hopdongmuaxe();
        public f_dshopdongmuaxe()
        {
            InitializeComponent();
        }

        #region override

        protected override bool them()
        {
            Biencucbo.hdong = 1;
            var frm = new HoSoXeMay.f_themhopdongmuaxe();
            if (frm.ShowDialog() == DialogResult.OK)
                return true;
            return false;
        }

        protected override bool sua()
        {
            Biencucbo.hdong = 2;
            Biencucbo.key = gv.GetFocusedRowCellValue("key").ToString();
            var frm = new HoSoXeMay.f_themhopdongmuaxe();
            if (frm.ShowDialog() == DialogResult.OK)
                return true;
            return false;
        }

        protected override bool xoa()
        {
            try
            {
                string _key = gv.GetFocusedRowCellValue("key").ToString();
                string _sohd = gv.GetFocusedRowCellValue("sohd").ToString();

                hd.xoact(_key);
                hd.xoa(_key);
                hs.add(_sohd, "Xóa Hợp Đồng Mua Xe");
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
            gd.DataSource = new KetNoiDBDataContext().hopdongmuaxes;
        }


        #endregion  
    }
}