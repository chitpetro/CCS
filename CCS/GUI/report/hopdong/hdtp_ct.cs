using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using BUS;

namespace GUI.report
{
    public partial class hdtp_ct : XtraReport
    {
        DataTable dt = new DataTable();
        private int _stt = 0;
        public hdtp_ct()
        {
            
            InitializeComponent();
            //lblcongtrinh.Text = Biencucbo.bcct;
            //lbldiadiem.Text = Biencucbo.bcdc;
            //lblcht.Text = Biencucbo.bccht;
            ngay2.Text = "Ngày " + DateTime.Now.Day + ", Tháng " + DateTime.Now.Month + ", Năm " + DateTime.Now.Year;
            dt.Columns.Add("stt", typeof (string));
            dt.Columns.Add("id", typeof (string));
            dt.Columns.Add("idct", typeof (string));
        }

        private void xrTableCell15_PreviewDoubleClick(object sender, PreviewMouseEventArgs e)
        {
          //  XtraMessageBox.Show();
        }

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

        private void xrTableCell11_PreviewDoubleClick(object sender, PreviewMouseEventArgs e)
        {
            
        }

        private void stt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            _stt ++;
            stt.Text = _stt.ToString();
            try
            {
                dt.Rows.Add(stt.Text, GetCurrentColumnValue("id").ToString(), GetCurrentColumnValue("idct").ToString());
            }
            catch (Exception ex)
            {
             
            }
        }

        private void stt_PreviewDoubleClick(object sender, PreviewMouseEventArgs e)
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
                          
                            _key = item[2].ToString();
                            Biencucbo.mact = _key;
                            Biencucbo.ma = item[1].ToString();
                            custom.mofombc(item[1].ToString());
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
    }
}