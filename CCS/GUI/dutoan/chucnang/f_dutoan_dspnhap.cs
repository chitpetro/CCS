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

namespace GUI.dutoan.chucnang
{
    public partial class f_dutoan_dspnhap : frm.frmmop
    {
        private KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        public f_dutoan_dspnhap()
        {
            InitializeComponent();
        }


        protected override void search()
        {
            gd.DataSource = new KetNoiDBDataContext().SP_LayDs_Dutoan_pnhap(tungay.DateTime, denngay.DateTime, Biencucbo.mact, false);
        }

        protected override void searchall()
        {
            gd.DataSource = new KetNoiDBDataContext().SP_LayDs_Dutoan_pnhap(tungay.DateTime, denngay.DateTime, Biencucbo.mact, true);
        }
    }
}