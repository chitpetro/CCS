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
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;

namespace GUI.report.PXM
{
    public partial class f_pxmbcNhapXuatTon : GUI.frmdkreport
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        private bool checkct;
        public f_pxmbcNhapXuatTon()
        {
            InitializeComponent();
        }

        protected override void load()
        {
            txtdanhmuc.Properties.Items.Add("Công Trình");
            txtdanhmuc.Properties.Items.Add("Vật Tư");
        }
        protected override void loaddata()
        {
            gd1.DataSource = dbData.Laydkreport(txtdanhmuc.Text, Biencucbo.idnv, Name, Biencucbo.hostname);
            gd2.DataSource = dbData.LayDSdkreport(Biencucbo.idnv, Name, Biencucbo.hostname);
        }
        private bool layinfo(string tungay, string denngay, bool tg)
        {
            if (tg)
                Biencucbo.ngaybc = "";
            else
                Biencucbo.ngaybc = "Từ ngày " + tungay + " Đến ngày " + denngay;
            Biencucbo.info = "";
            bool checkct = false;
            string loai = "";
            gv2.Columns["loai"].SortOrder = ColumnSortOrder.Ascending;

            for (int i = 0; i < gv2.DataRowCount; i++)
            {
                if (gv2.GetRowCellValue(i, "loai").ToString() == "Công Trình")
                {
                    checkct = true;
                }
                if (loai != gv2.GetRowCellValue(i, "loai").ToString())
                {
                    if (Biencucbo.info == "")
                    {
                        Biencucbo.info = gv2.GetRowCellValue(i, "loai") + ": " + gv2.GetRowCellValue(i, "name");
                    }
                    else
                    {
                        Biencucbo.info = Biencucbo.info + "\n" + gv2.GetRowCellValue(i, "loai") + ": " + gv2.GetRowCellValue(i, "name");
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
            return checkct;
        }

        private void inbc<T>(bool tg)
        {
            if (layinfo(DateTime.Parse(tungay.EditValue.ToString()).ToShortDateString(), DateTime.Parse(denngay.EditValue.ToString()).ToShortDateString(), tg) == false)
            {
                XtraMessageBox.Show("Cần phải chọn Kho xuất/Công trình để xem báo cáo", "THÔNG BÁO");

                return;
            }

            try
            {
                var rp = Activator.CreateInstance<T>() as XtraReport;
                  rp.DataSource =
                            dbData.INBCNhapXuatTon(Biencucbo.idnv, Name, Biencucbo.hostname,
                            DateTime.Parse(tungay.EditValue.ToString()),
                            DateTime.Parse(denngay.EditValue.ToString()), tg);
                rp.ShowPreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        protected override void search()
        {
            SplashScreenManager.ShowForm(typeof(SplashScreen1));
            if (tgsmode.IsOn == false)
            {

                inbc<r_BCNhapXuatTon_CT>(false);
            }
            else
            {
                inbc<r_BCNhapXuatTon_TH>(false);
            }

            SplashScreenManager.CloseForm();

        }
        protected override void searchall()
        {
            SplashScreenManager.ShowForm(typeof(SplashScreen1));
            if (tgsmode.IsOn == false)
            {

                inbc<r_BCNhapXuatTon_CT>(true);
            }
            else
            {
                 inbc<r_BCNhapXuatTon_TH>(true);
            }

            SplashScreenManager.CloseForm();

        }
    }
}