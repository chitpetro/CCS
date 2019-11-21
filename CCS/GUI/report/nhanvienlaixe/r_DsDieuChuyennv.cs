using ControlLocalizer;
using DevExpress.XtraGrid;
using DevExpress.XtraReports.UI;

namespace GUI
{
    public partial class r_DsDieuChuyennv : XtraReport
    {
        private GridControl control;

        public r_DsDieuChuyennv()
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