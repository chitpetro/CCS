using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DAL;
using BUS;

namespace GUI.report.dk_report
{

    public partial class frmdkreport : frmdsmo{
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        private string _form;
        public frmdkreport()
        {
            InitializeComponent();
        }

        private void frmdkreport_Load(object sender, EventArgs e)
        {
            //btnsearchall.Visibility = BarItemVisibility.Never;
            _form = Biencucbo.form;
            txtdanhmuc.Text = "Công Trình";
            loaddata();

        }

        private void loaddata()
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
                dk.key = gv1.GetFocusedRowCellValue("key").ToString();
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

            }
        }

        private void btn_2()
        {
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
    }
}