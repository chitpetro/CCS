using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using BUS;
using DevExpress.XtraReports.UI;

namespace GUI.report.pnhap
{
    public partial class r_bccpvt_ct : frm.rp
    {
        private int _stt = 0, _stt1 = 0, _stt2 = 0;

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                dt.Rows.Add(GetCurrentColumnValue("id").ToString(), GetCurrentColumnValue("idct").ToString());
            }
            catch (Exception ex)
            {
                
            }
        }

        private void stt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            _stt1 = 0;
            _stt2 = 0;
            _stt ++;
            stt.Text = _stt.ToString();
        }

        private void stt1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            _stt2 = 0;
            _stt1 ++;
            stt1.Text = stt.Text + "." + _stt1;
        }

        private void stt2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            _stt2++;
            stt2.Text = stt1.Text + "." + _stt2;
        }

        private void txtid_PreviewDoubleClick(object sender, PreviewMouseEventArgs e)
        {
            if (e.Brick.Text != null)
            {
                try
                {
                    string _key = "";
                    DataRow[] rows = dt.Select();
                    foreach (DataRow item in rows)
                    {
                        if (item[0] == e.Brick.Text)
                        {
                            _key = item[1].ToString();
                            Biencucbo.mact = _key;
                            Biencucbo.ma = e.Brick.Text;
                            custom.mofombc2(e.Brick.Text);
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        DataTable dt = new DataTable();
        
        public r_bccpvt_ct()
        {
            InitializeComponent();
            dt.Columns.Add("id", typeof (string));
            dt.Columns.Add("idct", typeof (string));
        }
        


    }
}
