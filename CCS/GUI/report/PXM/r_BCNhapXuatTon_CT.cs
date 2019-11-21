using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using BUS;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace GUI.report.PXM
{
    public partial class r_BCNhapXuatTon_CT : DevExpress.XtraReports.UI.XtraReport
    {
        private int _stt1 = 0;
        private int _stt2 = 0;
        private int _stt3 = 0;
        DataTable dt = new DataTable();
        public r_BCNhapXuatTon_CT()
        {
            InitializeComponent();
            txtngayxem.Text = Biencucbo.ngaybc;
            txtinfo.Text = Biencucbo.info;
            dt.Columns.Add("idpn", typeof(string));
            dt.Columns.Add("keypx", typeof (string));
            dt.Columns.Add("congtrinh", typeof(string));
            dt.Columns.Add("key", typeof(string));
        }

        private void stt1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            _stt2 = 0;
            _stt3 = 0;
            _stt1++;
            stt1.Text = _stt1.ToString();

        }

        private void stt2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            _stt3 = 0;
            _stt2++;
            stt2.Text = stt1.Text + "." + _stt2;
        }

        private void stt3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            _stt3++;
            stt3.Text = stt2.Text + "." + _stt3;
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                dt.Rows.Add(GetCurrentColumnValue("idpn").ToString(), GetCurrentColumnValue("idpx").ToString(), GetCurrentColumnValue("congtrinh").ToString(), GetCurrentColumnValue("key").ToString());
            }
            catch (Exception ex)
            {
                
            }
        }

        private void xrTableCell21_PreviewDoubleClick(object sender, PreviewMouseEventArgs e)
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
                            _mact = item[2].ToString();
                            _key = item[3].ToString();
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

        private void xrTableCell22_PreviewDoubleClick(object sender, PreviewMouseEventArgs e)
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
                        if (item[1] == e.Brick.Text)
                        {
                            _mact = item[2].ToString();
                            _key = item[3].ToString();
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
    }
}
