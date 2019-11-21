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
using  DAL;
using BUS;
using DevExpress.Data;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;

namespace GUI.report.chiphikhac
{
    public partial class f_bccpk : frm.frmreport    
    {
        t_todatatable _tTodatatable = new t_todatatable();
        public f_bccpk()
        {
            InitializeComponent();
        }

        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        protected override void load()
        {
            txtdanhmuc.Properties.Items.Add("Mục Chi Phí");
            //txtdanhmuc.Properties.Items.Add("loại Nhập");
            //
            txtdanhmuc.Text = "Công Trình";
        }

        private bool layinfo(string tungay, string denngay, bool all)
        {
            Biencucbo.ngaybc = "Từ ngày " + tungay + " Đến ngày " + denngay;
            if (all)
                Biencucbo.ngaybc = "";
            Biencucbo.info = "";
            bool checkdv = false;
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
            
            return true;
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
                rp.DataSource = _tTodatatable.addlst(dbData.SP_InBCChiPhiQuanLy(Biencucbo.idnv, Name, Biencucbo.hostname, tungay.DateTime, denngay.DateTime, all).ToList()) ;
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
                Biencucbo.title = "PHỤ LỤC 04A - BẢNG TỔNG HỢP THEO DÕI CHI PHÍ KHÁC";
                inbc<r_bcchiphiquanly_th>(false);
            }
            else
            {
                Biencucbo.title = "PHỤ LỤC 04B - BẢNG CHI TIẾT THEO DÕI CHI PHÍ KHÁC";
                inbc<r_bcchiphiquanly_ct>(false);
            }
            SplashScreenManager.CloseForm();
        }
        protected override void searchall()
        {
            SplashScreenManager.ShowForm(typeof(SplashScreen1));
            if (tgs.IsOn)
            {
                Biencucbo.title = "PHỤ LỤC 04A - BẢNG TỔNG HỢP THEO DÕI CHI PHÍ KHÁC";
                inbc<r_bcchiphiquanly_th>(true);
            }
            else
            {
                Biencucbo.title = "PHỤ LỤC 04B - BẢNG CHI TIẾT THEO DÕI CHI PHÍ KHÁC";
                inbc<r_bcchiphiquanly_ct>(true);
            }
            SplashScreenManager.CloseForm();
        }
    }
}