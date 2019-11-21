using BUS;
using ControlLocalizer;
using DAL;
using DevExpress.XtraGrid;
using DevExpress.XtraReports.UI;

namespace GUI
{
    public partial class r_DsTheoDoi_PT : XtraReport
    {
        private GridControl control;

        public r_DsTheoDoi_PT()
        {
            InitializeComponent();
            LanguageHelper.Translate(this);
            changeFont.Translate(this);

            var db = new KetNoiDBDataContext();

            txtcongtrinh.Text = Biencucbo.mact + " - " + f_ds_theodoipt2.tenct;
            txtthoigian.Text = Biencucbo.time;
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