using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid;

namespace GUI.report.nhanvienlaixe
{
    public partial class r_Export : DevExpress.XtraReports.UI.XtraReport
    {
        public r_Export()
        {
            InitializeComponent();
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
                control = value;
                pccReport.PrintableComponent = control;
            }
        }

    }
}
