using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DAL;

namespace GUI.report.PXM
{
    public partial class r_BCchenhlechCT : DevExpress.XtraReports.UI.XtraReport
        
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        private string _sttct;
        private string _sttvt;
        private string _stt;
        private int _indexct;
        private int _indexvt;
        private int _index;
        DataTable dt = new DataTable();
        public r_BCchenhlechCT()
        {
            InitializeComponent();
            txtngayxem.Text = Biencucbo.ngaybc;
            txtinfo.Text = Biencucbo.info;
            dt.Columns.Add("idpn", typeof(string));
            dt.Columns.Add("congtrinh", typeof(string));
            dt.Columns.Add("key", typeof (string));

        }

        private void sttct_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (_sttct != txtctnhap.Text)
            {
                _sttct = txtctnhap.Text;
                _indexct++;
                _sttvt = string.Empty;
                _indexvt = 0;
            }
            sttct.Text = _indexct.ToString();
        }

        private void sttsp_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (txtvt.Text != _sttvt)
            {
                _sttvt = txtvt.Text;
                _indexvt++;
                _stt = string.Empty;
                _index = 0;
            }
            sttsp.Text = sttct.Text + "." + _indexvt.ToString();
        }

        private void stt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            _index++;
            stt.Text = sttsp.Text + "." + _index;
        }

        private void txtidpn_PreviewDoubleClick(object sender, PreviewMouseEventArgs e)
        {
            if (e.Brick.Text != null)
            {
                try
                {
                      string _mact = "";
                    string _key = "";
                    DataRow[] result = dt.Select();
                    foreach (DataRow item in result)
                    {
                        if (item[0] == e.Brick.Text)
                        {
                            _mact = item[1].ToString();
                            _key = item[2].ToString();
                            break;
                        }
                    }
                    Biencucbo.mact = _mact;
                    Biencucbo.ma = _key;
                    custom.mofombc(e.Brick.Text);
                    
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.ToString());
                }

            }
        }

        private void txtctnhap_PreviewMouseMove(object sender, PreviewMouseEventArgs e)
        {
            Biencucbo.mact = e.Brick.Text;

        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                dt.Rows.Add(GetCurrentColumnValue("idpn").ToString(), GetCurrentColumnValue("congtrinh").ToString(), GetCurrentColumnValue("key").ToString());
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
