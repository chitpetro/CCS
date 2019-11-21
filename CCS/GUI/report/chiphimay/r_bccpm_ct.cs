using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using BUS;
using DevExpress.XtraReports.UI;

namespace GUI.report.chiphimay
{
    public partial class r_bccpm_ct : frm.rp
    {
        private int _stt = 0;
        int _stt1 = 0,_stt2 = 0,_stt3 = 0;

        private void GroupHeader1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                dt.Rows.Add(GetCurrentColumnValue("id").ToString(), GetCurrentColumnValue("idct").ToString());
            }
            catch (Exception ex)
            {
                
            }
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
                            custom.mofombc(e.Brick.Text);
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

        private void stt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            _stt1 = 0;
            _stt2 = 0;
            _stt3 = 0;
            _stt++;
            stt.Text = _stt.ToString();
        }

        private void stt1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
            _stt2 = 0;
            _stt3 = 0;
            _stt1++;
            stt1.Text = stt.Text +"." + _stt1.ToString();
        }

        private void stt2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
            _stt3 = 0;
            _stt2++;
            stt2.Text = stt1.Text + "." + _stt2.ToString();
        }

        private void stt3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            _stt3++;
            stt3.Text = stt2.Text + "." + _stt3.ToString();
        }

        DataTable dt = new DataTable();
        public r_bccpm_ct()
        {
            InitializeComponent();
            dt.Columns.Add("id", typeof (string));
            dt.Columns.Add("idct", typeof (string));
        }

    }
}
