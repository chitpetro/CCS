using ControlLocalizer;
using DevExpress.XtraGrid;
using DevExpress.XtraReports.UI;

namespace GUI
{
    public partial class r_DsDieuChuyenPT : XtraReport
    {
        private GridControl control;

        public r_DsDieuChuyenPT()
        {
            InitializeComponent();
            LanguageHelper.Translate(this);
            changeFont.Translate(this);
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