﻿using System;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using BUS;
using DAL;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace GUI
{
    public partial class f_import_bo : Form
    {
        private string a = "";

        private readonly KetNoiDBDataContext db = new KetNoiDBDataContext();


        //nút upload file
        private readonly OpenFileDialog openfile = new OpenFileDialog();
        private t_tudong td = new t_tudong();

        public f_import_bo()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();

            txtid.ReadOnly = true;
            txtname.ReadOnly = true;
            txtlink.ReadOnly = true;
        }

        private void f_themaccount_Load(object sender, EventArgs e)
        {
            //LanguageHelper.Translate(this);
            //LanguageHelper.Translate(barManager1);
            //this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Thêm File").ToString();

            //changeFont.Translate(this);
            //changeFont.Translate(barManager1);
        }

        private void txtlink_Click(object sender, EventArgs e)
        {


            openfile.Title = "Chọn File";
            //openfile.InitialDirectory = @"c:\Program Files";//Thư mục mặc định khi mở
            openfile.Filter = "Excel Files|*.xls;*.xlsx";

            openfile.FilterIndex = 1; //chúng ta có All files là 1,exe là 2
            openfile.RestoreDirectory = true;

            if (openfile.ShowDialog() == DialogResult.OK)
            {
                txtlink.Text = openfile.FileName;
                txtname.Text = openfile.FileName.Substring(openfile.FileName.LastIndexOf('\\') + 1);

                //get Sheet Name
                var xlApp = new Application();
                var excelBook = xlApp.Workbooks.Open(txtlink.Text);

                //String[] excelSheets = new String[excelBook.Worksheets.Count];
                var i = 0;

                cboSheetName.Properties.Items.Clear();
                foreach (Worksheet wSheet in excelBook.Worksheets)
                {
                    //excelSheets[i] = wSheet.Name;
                    cboSheetName.Properties.Items.Add(wSheet.Name);
                    i++;
                }
            }
        }

        private void btnImport_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (txtlink.Text == "") return;

            try
            {
                var ext = Path.GetExtension(openfile.FileName);
                // Connection String to Excel Workbook
                var excelConnectionString =
                    string.Format(
                        "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + openfile.FileName +
                        "; Extended Properties=Excel 8.0", ext); //format .xlsx, .xls : 12.0

                if (cboSheetName.Text == "")
                {
                    MessageBox.Show("Ban Chua Chon Sheet", "Thong Bao");
                    return;
                }

                var connection = new OleDbConnection();
                connection.ConnectionString = excelConnectionString;

                //OleDbCommand command = new OleDbCommand("select * from [Sheet1$]", connection);
                var command = new OleDbCommand("select * from [" + cboSheetName.Text + "$]", connection); //chon sheet

                connection.Open();

                // Create DbDataReader to Data Worksheet
                DbDataReader dr = command.ExecuteReader();

                // Bulk Copy to SQL Server 
                var bulkInsert = new SqlBulkCopy(db.Connection.ConnectionString);

                bulkInsert.DestinationTableName = Biencucbo.ma; //ten bang

                bulkInsert.WriteToServer(dr);

                XtraMessageBox.Show("Done!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtlink_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}