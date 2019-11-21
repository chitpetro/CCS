using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DAL;
using BUS;
using DevExpress.Data;
using DevExpress.XtraCharts;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;

namespace GUI.report.chiphimay
{
    public partial class f_bccpm : frm.frmreport
    {
        public f_bccpm()
        {
            InitializeComponent();
        }

        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        protected override void load()
        {
            txtdanhmuc.Properties.Items.Add("Loại Chi Phí Máy");
            //txtdanhmuc.Properties.Items.Add("loại Nhập");
            txtdanhmuc.Properties.Items.Add("Phương Tiện");
            txtdanhmuc.Text = "Công Trình";
        }

        private bool layinfo(string tungay, string denngay, bool all)
        {
            Biencucbo.ngaybc = "Từ ngày " + tungay + " Đến ngày " + denngay;
            if (all)
                Biencucbo.ngaybc = "";
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
                rp.DataSource = dbData.SP_InBCChiPhiMay(Biencucbo.idnv, "f_bccpm" ,Biencucbo.hostname,tungay.DateTime,denngay.DateTime,all);
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
                Biencucbo.title = "PHỤ LỤC 03A - BẢNG TỔNG HỢP THEO DÕI CHI PHÍ MÁY";
                inbc<r_bccpm_th>(false);
            }
            else
            {
                Biencucbo.title = "PHỤ LỤC 03B - BẢNG CHI TIẾT THEO DÕI CHI PHÍ MÁY";
                inbc<r_bccpm_ct>(false);
            }
            SplashScreenManager.CloseForm();
        }

        protected override void searchall()
        {
            SplashScreenManager.ShowForm(typeof(SplashScreen1));
            if (tgs.IsOn)
            {
                Biencucbo.title = "PHỤ LỤC 03A - BẢNG TỔNG HỢP THEO DÕI CHI PHÍ MÁY";
                inbc<r_bccpm_th>(true);
            }
            else{
                Biencucbo.title = "PHỤ LỤC 03B - BẢNG CHI TIẾT THEO DÕI CHI PHÍ MÁY";
                inbc<r_bccpm_ct>(true);
            }
            SplashScreenManager.CloseForm();
        }
    }
}