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
    public partial class f_tdchuyentien : frmds
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        t_history hs = new t_history();
        c_tdchuyentien td = new c_tdchuyentien();

        public f_tdchuyentien()
        {
            InitializeComponent();
        }

        private void gv_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            custom.sttgv(gv, e);
            BeginInvoke(new MethodInvoker(delegate
            {
                custom.cal(gd, gv);
            }));
        }

        #region override

        protected override bool them()
        {
            
            Biencucbo.hdong = 1;
            int i = 0, k = 0;
            string a;

            k = gv.DataRowCount;
            a = Biencucbo.ma + k;

            for (i = 0; i <= gv.DataRowCount - 1;)
            {
                if (a == gv.GetRowCellValue(i, "id").ToString())
                {
                    k = k + 1;
                    a = Biencucbo.ma + k;
                    i = 0;
                }
                else
                {
                    i++;
                }
            }
            Biencucbo.key = a;

            var frm = new f_themtdchuyentien();
            if (frm.ShowDialog() == DialogResult.OK)
                return true;
            return false;
        }

        protected override bool sua()
        {
            if (Biencucbo.idnv != gv.GetFocusedRowCellValue("idnv").ToString())
            {
                XtraMessageBox.Show("Bạn không có quyền sửa phiếu này");
                return false;
            }

            Biencucbo.hdong = 2;
            Biencucbo.key = gv.GetFocusedRowCellValue("id").ToString();
            var frm = new f_themtdchuyentien();
            if (frm.ShowDialog() == DialogResult.OK)
                return true;
            return false;
        }



        protected override bool xoa()
        {
            if (Biencucbo.idnv != gv.GetFocusedRowCellValue("idnv").ToString())
            {
                XtraMessageBox.Show("Bạn không có quyền xóa phiếu này");
                return false;
            }
            try
            {
                td.xoa(gv.GetFocusedRowCellValue("id").ToString());
                hs.add(gv.GetFocusedRowCellValue("id").ToString(), "Xóa Chuyển Tiền Thanh Toán");
                XtraMessageBox.Show("Done!");
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
            gd.DataSource = (from a in new  KetNoiDBDataContext().theodoitts where a.idtt == Biencucbo.ma select  a);
            txtgttt.Text = Biencucbo.theodoitt.ToString();
            txtgtth.Text = Biencucbo.theodoith.ToString();
            txtcltt.Text = (double.Parse(txtgttt.Text) - double.Parse(colsotienchuyen.SummaryItem.SummaryValue.ToString())).ToString();
            txtclth.Text = (double.Parse(txtgtth.Text) - double.Parse(colsotienchuyen.SummaryItem.SummaryValue.ToString())).ToString();
        }


        #endregion  
    }
}