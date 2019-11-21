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
    public partial class f_theodoitt_cpk : frm.frmds2
    {
        c_theodoitt_cpk cp = new c_theodoitt_cpk();
        t_history hs = new t_history();
        public f_theodoitt_cpk()
        {
            InitializeComponent();
        }

        #region override

        protected override bool them()
        {
            Biencucbo.hdong = 1;
            var frm = new theodoitt.chiphikhac.f_themtheodoitt_cpk();
            if (frm.ShowDialog() == DialogResult.OK)
                return true;
            return false;
        }

        protected override bool sua()
        {
            if (gv.GetFocusedRowCellValue("idnv").ToString() == Biencucbo.idnv)
            {
                Biencucbo.hdong = 2;
                Biencucbo.key = gv.GetFocusedRowCellValue("id").ToString();
                var frm = new theodoitt.chiphikhac.f_themtheodoitt_cpk();
                if (frm.ShowDialog() == DialogResult.OK)
                    return true;
                return false;
            }
            else
            {
                XtraMessageBox.Show("Bạn không có quyền sửa phiếu này", "THÔNG BÁO");
                return false;
            }
        }


        protected override bool xoa()
        {
            try
            {
                if (gv.GetFocusedRowCellValue("idnv").ToString() == Biencucbo.idnv)
                {
                    cp.xoa(gv.GetFocusedRowCellValue("id").ToString());
                    hs.add(Biencucbo.ma + gv.GetFocusedRowCellValue("ngaychuyen").ToString(), "Xóa Theo Dõi Chuyển Tiền Chi Phí Quản Lý");
                    custom.mes_done();
                    return true;
                }
                else
                {
                    XtraMessageBox.Show("Bạn không có quyền xóa phiếu này", "THÔNG BÁO");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        protected override void load()
        {
            gd.DataSource = (from a in new KetNoiDBDataContext().theodoitt_cpks where a.idcpk == Biencucbo.ma select a);
        }


        #endregion
    }
}