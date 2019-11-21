using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using BUS;
using DevExpress.XtraReports.UI;

namespace GUI.frm
{
    public partial class rp : DevExpress.XtraReports.UI.XtraReport
    {
        public rp()
        {
            InitializeComponent();txtngayxem.Text = Biencucbo.ngaybc;
            txtinfo.Text = Biencucbo.info;
            txttitle.Text = Biencucbo.title;
        }

    }
}
