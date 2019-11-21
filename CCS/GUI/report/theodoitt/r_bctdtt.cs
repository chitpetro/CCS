using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using BUS;
using DevExpress.XtraReports.UI;

namespace GUI.report.theodoitt
{
    public partial class r_bctdtt : frm.rp
    {
        private int _stt = 0;
        private int _stt1 = 0;
        private int _stt2 = 0;
        DataTable dt = new DataTable();
        public r_bctdtt()
        {
            InitializeComponent();
            dt.Columns.Add("id", typeof (string));
            dt.Columns.Add("idct", typeof (string));
        }

        private void GroupHeader2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                dt.Rows.Add(GetCurrentColumnValue("id").ToString(), GetCurrentColumnValue("idct").ToString());
            }
            catch (Exception ex)
            {
                
            }
        }

        private void xrTableCell15_PreviewDoubleClick(object sender, PreviewMouseEventArgs e)
        {
            if (e.Brick.Text != null)
            {
                try
                {
                    string _key = "";
                    DataRow[] rows = dt.Select();
                    foreach (DataRow item in rows)
                    {
                        if (e.Brick.Text.Contains(item[0].ToString()))
                        {
                            _key = item[1].ToString();
                            Biencucbo.mact = _key;
                            Biencucbo.ma = item[0].ToString();
                            custom.mofombc2(item[0].ToString());
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
            _stt2 ++;
            stt2.Text = stt1.Text + "." + _stt2;
        }
    }
}
