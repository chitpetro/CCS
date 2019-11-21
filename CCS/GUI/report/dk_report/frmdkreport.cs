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


namespace GUI
{
    public partial class frmdkreport : DevExpress.XtraEditors.XtraForm
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        private string _form;
        private bool dble1;
        private bool dble2;
        public frmdkreport()
        {
            InitializeComponent();
        }

        
        private void frmdsmo_Load(object sender, EventArgs e)
        {
            tungay.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            denngay.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            thoigian.EditValue = "Tùy ý";
            changetime();
            _form = Biencucbo.form;
            txtdanhmuc.Text = "Công Trình";
            loaddata();
            load();

        }

        //private static int gtime = 0;
        private void changetime()

        {

            string time = thoigian.EditValue.ToString();
            int chieudai = time.Length;
            string chu = time.Substring(0, 5);
            string so = "";
            DateTime ngay;

            if (thoigian.EditValue == "Tùy ý")
            {
                tungay.CanOpenEdit = true;
                denngay.CanOpenEdit = true;
            }
            else
            {

                if (chu == "Tháng") //vietnam
                {
                    if (chieudai == 7)
                    {
                        so = time.Substring(6, 1);

                    }
                    else if (chieudai == 8)
                    {
                        so = time.Substring(6, 2);
                    }
                    ngay = new DateTime(DateTime.Now.Year, int.Parse(so), 1);
                    tungay.EditValue = ngay;
                    ngay = new DateTime(DateTime.Now.Year, int.Parse(so), DateTime.DaysInMonth(DateTime.Now.Year, int.Parse(so)));
                    denngay.EditValue = ngay;
                }

                //              
                if (thoigian.EditValue == "Quý 1")
                {
                    ngay = new DateTime(DateTime.Now.Year, 1, 1);
                    tungay.EditValue = ngay;
                    ngay = new DateTime(DateTime.Now.Year, 3, DateTime.DaysInMonth(DateTime.Now.Year, 3));
                    denngay.EditValue = ngay;

                }
                else if (thoigian.EditValue == "Quý 2")
                {
                    ngay = new DateTime(DateTime.Now.Year, 4, 1);
                    tungay.EditValue = ngay;
                    ngay = new DateTime(DateTime.Now.Year, 6, DateTime.DaysInMonth(DateTime.Now.Year, 6));
                    denngay.EditValue = ngay;
                }
                else if (thoigian.EditValue == "Quý 3")
                {
                    ngay = new DateTime(DateTime.Now.Year, 7, 1);
                    tungay.EditValue = ngay;
                    ngay = new DateTime(DateTime.Now.Year, 9, DateTime.DaysInMonth(DateTime.Now.Year, 9));
                    denngay.EditValue = ngay;
                }
                else if (thoigian.EditValue == "Quý 4")
                {
                    ngay = new DateTime(DateTime.Now.Year, 10, 1);
                    tungay.EditValue = ngay;
                    ngay = new DateTime(DateTime.Now.Year, 12, DateTime.DaysInMonth(DateTime.Now.Year, 12));
                    denngay.EditValue = ngay;
                }
                else if (thoigian.EditValue == "6 Tháng Đầu Năm")
                {
                    ngay = new DateTime(DateTime.Now.Year, 1, 1);
                    tungay.EditValue = ngay;
                    ngay = new DateTime(DateTime.Now.Year, 6, DateTime.DaysInMonth(DateTime.Now.Year, 6));
                    denngay.EditValue = ngay;
                }
                else if (thoigian.EditValue == "6 Tháng Cuối Năm")
                {
                    ngay = new DateTime(DateTime.Now.Year, 7, 1);
                    tungay.EditValue = ngay;
                    ngay = new DateTime(DateTime.Now.Year, 12, DateTime.DaysInMonth(DateTime.Now.Year, 12));
                    denngay.EditValue = ngay;
                }
                else if (thoigian.EditValue == "Cả Năm")
                {
                    ngay = new DateTime(DateTime.Now.Year, 1, 1);
                    tungay.EditValue = ngay;
                    ngay = new DateTime(DateTime.Now.Year, 12, DateTime.DaysInMonth(DateTime.Now.Year, 12));
                    denngay.EditValue = ngay;
                }
               
                tungay.CanOpenEdit = false;
                denngay.CanOpenEdit = false;
            }
        }

        protected virtual void load()
        {
            
        }

        protected virtual void search()
        {

        }

        protected virtual void searchall()
        {

        }

        private void thoigian_EditValueChanged(object sender, EventArgs e)
        {
            changetime();
        }

        private void btnsearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            search();
        }

        private void btnsearchall_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            searchall();
        }

        private void thoigian_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void gv1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {custom.sttgv(gv1,e);
            BeginInvoke(new MethodInvoker(delegate
            {
                custom.cal(gd1, gv1);
            }));
        }

        private void gv2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            custom.sttgv(gv2,e);
            BeginInvoke(new MethodInvoker(delegate
            {
                custom.cal(gd2, gv2);
            }));
          
        }
        
        protected virtual void loaddata()
        {
            gd1.DataSource = dbData.Laydkreport(txtdanhmuc.Text, Biencucbo.idnv, _form, Biencucbo.hostname);
            gd2.DataSource = dbData.LayDSdkreport(Biencucbo.idnv, _form, Biencucbo.hostname);
        }


        private void btn_1()
        {
            try
            {
                dbData = new KetNoiDBDataContext();
                DAL.dk_report dk = new DAL.dk_report();
                dk.id = gv1.GetFocusedRowCellValue("id").ToString();
                dk.name = gv1.GetFocusedRowCellValue("name").ToString();
                dk.key = gv1.GetFocusedRowCellValue("key").ToString().Trim();
                dk.loai = txtdanhmuc.Text;
                dk.user = Biencucbo.idnv;
                dk.form = _form;
                dk.PC = Biencucbo.hostname;
                dbData.dk_reports.InsertOnSubmit(dk);
                dbData.SubmitChanges();
                loaddata();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void btn_2()
        {
            SplashScreenManager.ShowForm(typeof(SplashScreen1));
            try
            {
                dbData = new KetNoiDBDataContext();
                for (int i = 0; i < gv1.DataRowCount; i++)
                {
                    DAL.dk_report dk = new DAL.dk_report();
                    dk.id = gv1.GetRowCellValue(i, "id").ToString();
                    dk.name = gv1.GetRowCellValue(i, "name").ToString();
                    dk.key = gv1.GetRowCellValue(i, "key").ToString();
                    dk.loai = txtdanhmuc.Text;
                    dk.user = Biencucbo.idnv;
                    dk.form = _form;
                    dk.PC = Biencucbo.hostname;
                    dbData.dk_reports.InsertOnSubmit(dk);
                    dbData.SubmitChanges();
                }
                loaddata();
            }
            catch (Exception ex)
            {

            }
            SplashScreenManager.CloseForm();
        }

        private void btn_3()
        {
            try
            {
                dbData = new KetNoiDBDataContext();

                DAL.dk_report dk =
                    (from a in dbData.dk_reports select a).Single(
                        t => t.key == gv2.GetFocusedRowCellValue("key").ToString());
                dbData.dk_reports.DeleteOnSubmit(dk);
                dbData.SubmitChanges();

                loaddata();
            }
            catch (Exception ex)
            {

            }
        }
        private void btn_4()
        {
            SplashScreenManager.ShowForm(typeof(SplashScreen1));
            try
            {
                dbData = new KetNoiDBDataContext();
                for (int i = gv2.DataRowCount - 1; i >= 0; i--)
                {
                    DAL.dk_report dk =
                        (from a in dbData.dk_reports select a).Single(
                            t => t.key == gv2.GetRowCellValue(i, "key").ToString());
                    dbData.dk_reports.DeleteOnSubmit(dk);
                    dbData.SubmitChanges();
                }
                loaddata();

            }
            catch (Exception ex)
            {

            }
            SplashScreenManager.CloseForm();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            btn_1();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            btn_2();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            btn_3();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            btn_4();
        }

        private void gv1_Click(object sender, EventArgs e)
        {
            dble1 = false;
        }

        private void gv1_DoubleClick(object sender, EventArgs e)
        {
            dble1 = true;
        }

        private void gv1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if(dble1)
                    btn_1();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString());
            }
        }

        private void gv2_Click(object sender, EventArgs e)
        {
            dble2 = false;
        }

        private void gv2_DoubleClick(object sender, EventArgs e)
        {
            dble2 = true;
        }

        private void gv2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if(dble2)
                    btn_3();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtdanhmuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddata();
        }
    }
}