using BUS;
using ControlLocalizer;
using DAL;
using DevExpress.XtraGrid;
using DevExpress.XtraReports.UI;

namespace GUI
{
    public partial class r_dsVatTu : XtraReport
    {
        private GridControl control;

        public r_dsVatTu()
        {
            InitializeComponent();
        }

        public GridControl GridControl
        {
            get { return control; }
            set
            {
                control = value;
                pccReport.PrintableComponent = control;
            }
        }
    }
}