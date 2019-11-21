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
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using DAL;
using DevExpress.Data;
using DevExpress.Utils.Zip.Internal;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSpreadsheet.Model;

namespace GUI.report.dk_report
{

    public partial class f_pxmbcnhapkho : GUI.frmdkreport
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        private bool checkct;
        private bool checkdt;
        public f_pxmbcnhapkho()
        {
            InitializeComponent();

        }
        protected override void load()
        {
            rdgloai.SelectedIndex = 2;
            txtdanhmuc.Properties.Items.Add("Công Trình");
            txtdanhmuc.Properties.Items.Add("Đối Tượng");
            txtdanhmuc.Properties.Items.Add("Vật Tư");

        }

        protected override void loaddata()
        {
            gd1.DataSource = dbData.Laydkreport(txtdanhmuc.Text, Biencucbo.idnv, Name, Biencucbo.hostname);
            switch (rdgloai.SelectedIndex)
            {
                case 0:
                case 2:
                    gd2.DataSource = dbData.LayDSdkreport_unctnhapxuat(Biencucbo.idnv, Name, Biencucbo.hostname);
                    break;
                case 1:

                    gd2.DataSource = dbData.LayDSdkreport(Biencucbo.idnv, Name, Biencucbo.hostname);
                    break;
            }
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
            if (layinfo(DateTime.Parse(tungay.EditValue.ToString()).ToShortDateString(), DateTime.Parse(denngay.EditValue.ToString()).ToShortDateString(),tg) ==
                false)
            {
                XtraMessageBox.Show("Cần phải chọn Kho nhập/Công trình để xem báo cáo", "THÔNG BÁO");

                return;
            }

            try
            {
                var rp = Activator.CreateInstance<T>() as XtraReport;

                switch (rdgloai.SelectedIndex)
                {
                    case 0:
                        rp.DataSource =
                            dbData.InBCNhapKhoMua(Biencucbo.idnv, Name, Biencucbo.hostname,
                            DateTime.Parse(tungay.EditValue.ToString()),
                            DateTime.Parse(denngay.EditValue.ToString()), tg);

                        break;
                    case 1:
                        rp.DataSource =
                            dbData.InBCNhapKhoNB(Biencucbo.idnv, Name, Biencucbo.hostname,
                                DateTime.Parse(tungay.EditValue.ToString()),
                                DateTime.Parse(denngay.EditValue.ToString()), tg);

                        break;
                    case 2:
                        rp.DataSource =
                            dbData.InBCNhapKhoALL(Biencucbo.idnv, Name, Biencucbo.hostname,
                                DateTime.Parse(tungay.EditValue.ToString()),
                                DateTime.Parse(denngay.EditValue.ToString()), tg);

                        break;
                }

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
                if (tgsloai.IsOn)
                {

                    inbc<r_BCnhapkhopn_CT>(false);
                }
                else
                {
                    inbc<PXM.r_BCNhapKho_CT>(false);
                }
            }
            else
            {
                inbc<PXM.r_BCNhapkho_TH>(false);
            }

            SplashScreenManager.CloseForm();

        }

        protected override void searchall()
        {
            SplashScreenManager.ShowForm(typeof(SplashScreen1));
            if (tgsmode.IsOn == false)
            {
                if (tgsloai.IsOn)
                {

                    inbc<r_BCnhapkhopn_CT>(true);
                }
                else
                {
                    inbc<PXM.r_BCNhapKho_CT>(true);
                }
            }
            else
            {
                inbc<PXM.r_BCNhapkho_TH>(true);
            }

            SplashScreenManager.CloseForm();
        }


        private void loainhap()
        {
            if (rdgloai.SelectedIndex == 1)
            {
                txtdanhmuc.Properties.Items.Remove("Kho Xuất Nội Bộ");
                txtdanhmuc.Properties.Items.Add("Kho Xuất Nội Bộ");
                loaddata();
            }
            else
            {
                loaddata();
                txtdanhmuc.Properties.Items.Remove("Kho Xuất Nội Bộ");
                if (txtdanhmuc.Text == "Kho Xuất Nội Bộ")
                    txtdanhmuc.Text = "Công Trình";
            }
        }
        private void rdgloai_SelectedIndexChanged(object sender, EventArgs e)
        {

            SplashScreenManager.ShowForm(typeof(SplashScreen1));
            loainhap();
            SplashScreenManager.CloseForm();



        }

        private void tgsmode_EditValueChanged(object sender, EventArgs e)
        {
            if (tgsmode.IsOn)
            {
                ltgsloai.Visibility = LayoutVisibility.Never;
            }
            else
            {
                ltgsloai.Visibility = LayoutVisibility.Always;
            }
        }
    }
}