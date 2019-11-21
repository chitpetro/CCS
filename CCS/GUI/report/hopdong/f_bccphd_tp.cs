using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAL;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;


namespace GUI.report.hopdong
{
    public partial class f_bccphd_tp : frm.frmreport
    {
        public f_bccphd_tp()
        {
            InitializeComponent();
        }

        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        protected override void load()
        {
            //txtdanhmuc.Properties.Items.Add("SảnPhẩm");
            //txtdanhmuc.Properties.Items.Add("loại Nhập");
            //Nhapdulieu1
            txtdanhmuc.Text = "Công Trình";
        }

        private bool layinfo(string tungay, string denngay,bool all)
        {
            Biencucbo.ngaybc = "Từ ngày " + tungay + " Đến ngày " + denngay;
            if (all)
                Biencucbo.ngay = "";
            Biencucbo.info = "";
            bool checkdv = true;
            string loai = "";
            gv2.Columns["loai"].SortOrder = ColumnSortOrder.Ascending;
            for (int i = 0; i < gv2.DataRowCount; i++)
            {
                if (gv2.GetRowCellValue(i, "loai").ToString() == "Đơn Vị")
                {
                    checkdv = true;
                }
                if (loai != gv2.GetRowCellValue(i, "loai").ToString())
                {
                    if (Biencucbo.info == "")
                    {
                        Biencucbo.info = gv2.GetRowCellValue(i, "loai") + ": " + gv2.GetRowCellValue(i, "name");
                    }
                    else
                    {
                        Biencucbo.info = Biencucbo.info + "\n" + gv2.GetRowCellValue(i, "loai") + ": " +
                                         gv2.GetRowCellValue(i, "name");
                    }
                }
                else
                {
                    Biencucbo.info = Biencucbo.info + ", " + gv2.GetRowCellValue(i, "name");
                }
                loai = gv2.GetRowCellValue(i, "loai").ToString();
            }
            if (Biencucbo.info == "")
                Biencucbo.info = "Tất cả";
            return checkdv;
        }

        private void inbc<T>(bool all)
        {
            if (
                layinfo(DateTime.Parse(tungay.EditValue.ToString()).ToShortDateString(),
                    DateTime.Parse(denngay.EditValue.ToString()).ToShortDateString(), all) ==
                false)
            {
                XtraMessageBox.Show("Cần phải chọn một đơn vị bất kỳ để xem báo cáo", "THÔNG BÁO");
                return;
            }
            try
            {
                var rp = Activator.CreateInstance<T>() as XtraReport;
                rp.DataSource = dbData.SP_InBCChiPhiHopDongTP(Biencucbo.idnv, "f_bccphd_tp",Biencucbo.hostname, tungay.DateTime, denngay.DateTime,all);
                rp.ShowPreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        protected override void search()
        {
            SplashScreenManager.ShowForm(typeof (SplashScreen1));
            if (tgs.IsOn)
            {
                Biencucbo.title = "BÁOCÁOTỔNGHỢPNHẬPKHO";
                inbc<r_bccphdtp_ct>(false);
            }
            else
            {
                Biencucbo.title = "BÁOCÁOCHITIẾTNHẬPKHO";
                inbc<r_bccphdtp_ct>(false);
            }
            SplashScreenManager.CloseForm();
        }

        protected override void searchall()
        {
            SplashScreenManager.ShowForm(typeof(SplashScreen2));
            if (tgs.IsOn)
            {
                Biencucbo.title = "BÁOCÁOTỔNGHỢPNHẬPKHO";
                inbc<r_bccphdtp_ct>(true);
            }
            else
            {
                Biencucbo.title = "BÁOCÁOCHITIẾTNHẬPKHO";
                inbc<r_bccphdtp_ct>(true);
            }
            SplashScreenManager.CloseForm();
        }
    }
}