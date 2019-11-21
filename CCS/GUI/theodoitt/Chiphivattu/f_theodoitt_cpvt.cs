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

namespace GUI.theodoitt.Chiphivattu
{
    public partial class f_theodoitt_cpvt : frm.frmds2
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        t_history hs = new t_history();
        c_theodoitt_cpvt vt = new c_theodoitt_cpvt();
        public f_theodoitt_cpvt()
        {
            InitializeComponent();
        }
        #region override

        protected override bool them()
        {
            Biencucbo.hdong = 1;
            var frm = new theodoitt.Chiphivattu.f_themtheodoitt_cpvt();
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
                var frm = new theodoitt.Chiphivattu.f_themtheodoitt_cpvt();
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
                    vt.xoa(gv.GetFocusedRowCellValue("id").ToString());
                    hs.add(Biencucbo.ma + gv.GetFocusedRowCellValue("ngaychuyen").ToString(), "Xóa Theo Dõi Chuyển Tiền Chi Phí Vật Tư");
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
            gd.DataSource = (from a in new KetNoiDBDataContext().theodoitt_cpvts where a.idpn == Biencucbo.ma select a);
        }


        #endregion

    }
}