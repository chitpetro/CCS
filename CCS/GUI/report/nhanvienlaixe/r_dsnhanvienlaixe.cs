using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using BUS;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid;

namespace GUI.report.nhanvienlaixe
{
    public partial class r_dsnhanvienlaixe : DevExpress.XtraReports.UI.XtraReport
    {
        public r_dsnhanvienlaixe()
        {
            InitializeComponent();
            lbltit.Text = "BẢNG CHẤM CÔNG THÁNG " + Biencucbo.thang + " NĂM " + Biencucbo.nam;
        }
        private GridControl control;
        public GridControl GridControl
        {
            get
            {
                return control;
            }
            set
            {
                //control = value;
                //pccReport.PrintableComponent = control;
            }
        }
    }
}
