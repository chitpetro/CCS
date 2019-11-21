using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using BUS;
using DevExpress.XtraReports.UI;


namespace GUI.report.chiphikhac
{
    public partial class r_bcchiphiquanly_ct : frm.rp
    {
        int _stt = 0;
        int _stt1 = 0;
        int _stt2 = 0;
        
        DataTable dt = new DataTable();
        public r_bcchiphiquanly_ct()
        {
            InitializeComponent();
            dt.Columns.Add("idct", typeof (string));
            dt.Columns.Add("id", typeof (string));
            
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                dt.Rows.Add(GetCurrentColumnValue("idct").ToString(), GetCurrentColumnValue("id").ToString());
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
                        if (item[1] == e.Brick.Text)
                        {
                            _key = item[1].ToString();
                            Biencucbo.ma = _key;
                            Biencucbo.mact = item[0].ToString();
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
            _stt++;
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
    }
}
