using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BUS;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace GUI.frm
{
    public partial class frmreport3 : DevExpress.XtraEditors.XtraForm
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        private string _form;
        private bool dble1;
        private bool dble2;
        public frmreport3()
        {
            InitializeComponent();
        }

        private void gv1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            custom.sttgv(gv1, e);
            BeginInvoke(new MethodInvoker(delegate
            {
                custom.cal(gd1, gv1);
            }));
        }

        private void gv2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            custom.sttgv(gv2, e);
            BeginInvoke(new MethodInvoker(delegate
            {
                custom.cal(gd2, gv2);
            }));
        }

      
        private void frmreport_Load(object sender, EventArgs e)
        {

          
            _form = Biencucbo.form;
            txtdanhmuc.Properties.Items.Add("Link Hồ Sơ");
            txtdanhmuc.Properties.Items.Add("Hồ Sơ Gốc");
            load();
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



        protected virtual void loaddata()
        {
            gd1.DataSource = dbData.SP_LayRP_GD1(txtdanhmuc.Text, Biencucbo.idnv, _form, Biencucbo.hostname, Biencucbo.donvi);
            gd2.DataSource = dbData.SP_LayRP_GD2(Biencucbo.idnv, _form, Biencucbo.hostname, Biencucbo.donvi);
        }



        private void add()
        {
            try
            {
                dbData = new KetNoiDBDataContext();
                dkreport dk = new dkreport();
                dk.id = gv1.GetFocusedRowCellValue("id").ToString();
                dk.name = gv1.GetFocusedRowCellValue("name").ToString();
                dk.key = gv1.GetFocusedRowCellValue("key").ToString().Trim();
                dk.loai = txtdanhmuc.Text;
                dk.idnv = Biencucbo.idnv;
                dk.form = _form;
                dk.PC = Biencucbo.hostname; dbData.dkreports.InsertOnSubmit(dk);
                dbData.SubmitChanges();
                loaddata();
            }
            catch (Exception ex)
            {

            }
        }

        private void addall()
        {
            SplashScreenManager.ShowForm(typeof(SplashScreen1));
            try
            {
                dbData = new KetNoiDBDataContext();
                for (int i = 0; i < gv1.DataRowCount; i++)
                {
                    dkreport dk = new dkreport();
                    dk.id = gv1.GetRowCellValue(i, "id").ToString();
                    dk.name = gv1.GetRowCellValue(i, "name").ToString();
                    dk.key = gv1.GetRowCellValue(i, "key").ToString();
                    dk.loai = txtdanhmuc.Text;
                    dk.idnv = Biencucbo.idnv;
                    dk.form = _form;
                    dk.PC = Biencucbo.hostname;
                    dbData.dkreports.InsertOnSubmit(dk);
                    dbData.SubmitChanges();
                }
                loaddata();
            }
            catch (Exception ex)
            {

            }
            SplashScreenManager.CloseForm();
        }

        private void remove()
        {
            try
            {
                dbData = new KetNoiDBDataContext();

                dkreport dk =
                     (from a in dbData.dkreports select a).Single(
                         t => t.key == gv2.GetFocusedRowCellValue("key").ToString());
                dbData.dkreports.DeleteOnSubmit(dk);
                dbData.SubmitChanges();

                loaddata();
            }
            catch (Exception ex)
            {

            }
        }
        private void removeall()
        {
            SplashScreenManager.ShowForm(typeof(SplashScreen1));
            try
            {
                dbData = new KetNoiDBDataContext();
                for (int i = gv2.DataRowCount - 1; i >= 0; i--)
                {
                    dkreport dk =
                        (from a in dbData.dkreports select a).Single(
                            t => t.key == gv2.GetRowCellValue(i, "key").ToString());
                    dbData.dkreports.DeleteOnSubmit(dk);
                    dbData.SubmitChanges();
                }
                loaddata();

            }
            catch (Exception ex)
            {

            }
            SplashScreenManager.CloseForm();
        }

        private void btnin_Click(object sender, EventArgs e)
        {
            searchall();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            add();
        }

        private void btnaddall_Click(object sender, EventArgs e)
        {
            addall();
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            remove();
        }

        private void btnremoveall_Click(object sender, EventArgs e)
        {
            removeall();
        }

        private void gv1_Click(object sender, EventArgs e)
        {
            dble1 = false;
        }

        private void gv1_DoubleClick(object sender, EventArgs e)
        {
            dble1 = true;
        }

        private void gv1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (dble1)
                add();
        }

        private void gv2_Click(object sender, EventArgs e)
        {
            dble2 = false;
        }

        private void gv2_DoubleClick(object sender, EventArgs e)
        {
            dble2 = true;
        }

        private void gv2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (dble2)
                remove();
        }

        private void txtdanhmuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddata();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            search();
        }
    }
}