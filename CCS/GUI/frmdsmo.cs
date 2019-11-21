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

namespace GUI
{
    public partial class frmdsmo : DevExpress.XtraEditors.XtraForm
    {
        public frmdsmo()
        {
            InitializeComponent();
        }

        
        private void frmdsmo_Load(object sender, EventArgs e)
        {
            tungay.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            denngay.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            thoigian.EditValue = "Tùy ý";
            changetime();
           search();
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
                search();
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

        protected virtual void exportex()
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

        private void btnepex_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            exportex();}
    }
}