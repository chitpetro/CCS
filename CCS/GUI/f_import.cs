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
using System.Data.OleDb;
using BUS;
using System.Data.SqlClient;
using System.Xml;
using System.IO;
using DAL;
using System.Diagnostics;
using DevExpress.XtraSplashScreen;

namespace GUI
{
    public partial class f_import : DevExpress.XtraEditors.XtraForm
    {
        public f_import()
        {
            InitializeComponent();
        }
        DataSet dsTest = new DataSet();
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        private readonly OpenFileDialog openfile = new OpenFileDialog();
        private void btnexcel_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof (SplashScreen1));
            try
            {
                OleDbConnection olecon = new OleDbConnection();

                openfile.Title = "Chọn File";
                //openfile.InitialDirectory = @"c:\Program Files";//Thư mục mặc định khi mở
                openfile.Filter = "Excel Files|*.xls;*.xlsx";

                openfile.FilterIndex = 1; //chúng ta có All files là 1,exe là 2
                openfile.RestoreDirectory = true;

                if (openfile.ShowDialog() == DialogResult.OK)
                {
                    string Source = openfile.FileName;

                    string strCon =
                        "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Source + ";Extended Properties=Excel 8.0";

                    olecon.ConnectionString = strCon;
                    olecon.Open();
                    string strSQL = "SELECT * FROM [CPM$] where [id] is not null";
                    OleDbDataAdapter oleda = new OleDbDataAdapter(strSQL, olecon);
                    oleda.Fill(dsTest);
                    olecon.Close();
                    dsTest.Tables[0].TableName = Biencucbo.ma; //Tên này phải giống với tên của Table trên SQL

                    dataGridView1.DataSource = dsTest.Tables[0];

                   

                    //for (int i = dataGridView1.RowCount - 2; i > 0 ; i--)
                    //{
                    //    if(dataGridView1.Rows[i].Cells[0].Value == null)
                    //        dataGridView1.Rows.RemoveAt(i);
                    //}
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
            SplashScreenManager.CloseForm();

        }
        public bool ExecBulkCopy(DataTable pDt, string pDesTableName = "")
        {

            try
            {
                if (pDesTableName.Length == 0) pDesTableName = pDt.TableName;

                // lấy chuỗi kết nối

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("appconn.xml");//mở file.xml lên
                var s = xmlDoc.DocumentElement["conn"].InnerText;
                if (s == string.Empty) return false;
                // giải mã
                var conn = MD5.Decrypt(s);



                using (SqlConnection sqlCon = new SqlConnection(conn))
                {
                    sqlCon.Open();
                    using (SqlBulkCopy sbc = new SqlBulkCopy(sqlCon))
                    {
                        sbc.DestinationTableName = pDesTableName;
                        sbc.WriteToServer(pDt);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
                return false;
            }
        }
        private void btnSQL_Click(object sender, EventArgs e)
        {
            if (!ExecBulkCopy(dsTest.Tables[0], Biencucbo.ma))
                MessageBox.Show("Không thành công!", "Thông Báo");
            else
                MessageBox.Show("Đã thực hiện thành công!", "Thông Báo");
        }
        private readonly SaveFileDialog savefile = new SaveFileDialog();
        private void btnxuatmau_Click(object sender, EventArgs e)
        {
            try
            {
                dbData = new KetNoiDBDataContext();
                var lst = (from a in dbData.xuamauexcels select a).Single(x => x.ma == Biencucbo.ma);
                var filedata = lst.file.ToArray();

                //savefile.Title = lst.formName;
                savefile.FileName = "import_" + Biencucbo.ma + ".xls";
                var tmpPath = savefile.InitialDirectory;
                savefile.FilterIndex = 1;
                savefile.RestoreDirectory = true;
                var file = "";
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(savefile.FileName, filedata);
                    file = savefile.FileName;
                    MessageBox.Show("Tải về Thành Công", "Thông Báo");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btntaomau_Click(object sender, EventArgs e)
        {
            if (Biencucbo.idnv == "AD")
            {
                if ((from a in dbData.xuamauexcels where a.ma == Biencucbo.ma select a).Count() > 0)
                {
                    XtraMessageBox.Show("Phiếu này đã có mẫu không thể tạo thêm");
                    return;
                }

                openfile.Title = "Chọn File";
                //openfile.InitialDirectory = @"c:\Program Files";//Thư mục mặc định khi mở
                openfile.Filter = "Excel Files|*.xls;*.xlsx";

                openfile.FilterIndex = 1; //chúng ta có All files là 1,exe là 2
                openfile.RestoreDirectory = true;

                if (openfile.ShowDialog() == DialogResult.OK)
                {

                    byte[] file = null;

                    if (!string.IsNullOrEmpty(openfile.FileName))
                    {
                        using (var stream = new FileStream(openfile.FileName, FileMode.Open, FileAccess.Read))
                        {
                            using (var reader = new BinaryReader(stream))
                            {
                                file = reader.ReadBytes((int)stream.Length);
                            }
                        }
                    }

                    xuamauexcel xm = new xuamauexcel();
                    xm.ma = Biencucbo.ma;
                    xm.file = file;
                    dbData.xuamauexcels.InsertOnSubmit(xm);
                    dbData.SubmitChanges();
                    XtraMessageBox.Show("done!");
                }
            }
            else
            {
                XtraMessageBox.Show("Bạn không có quyền tạo mẫu. Vui lòng liên hệ admin!");
            }
        }
    }
}