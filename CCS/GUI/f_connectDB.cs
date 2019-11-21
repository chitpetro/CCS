using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using BUS;
using ControlLocalizer;
using DAL;
using DevExpress.XtraEditors;
using Lotus;
using Settings = GUI.Properties.Settings;
using System.Xml;

namespace GUI
{
    public partial class f_connectDB : XtraForm
    {
        private KetNoiDBDataContext db = new KetNoiDBDataContext();

        private bool thoat_luon;

        public f_connectDB()
        {
            InitializeComponent();
        }

        public bool KiemTraKetNoi()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("appconn.xml");//mở file.xml lên
            var s = xmlDoc.DocumentElement["conn"].InnerText;
            if (s == string.Empty) return false;

            // giải mã
            var conn = MD5.Decrypt(s);
            var b = new SqlConnectionStringBuilder();
            b.ConnectionString = conn;
            Biencucbo.DbName = b.InitialCatalog;
            Biencucbo.ServerName = b.DataSource;
            var sqlCon = new SqlConnection(conn);

            // gán cho DAL tren bo nhớ 
            DAL.Settings.Default.ConnectionString = conn;
            try
            {
                sqlCon.Open();
                db = new KetNoiDBDataContext(sqlCon);
                return true;
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtDbName.Text == "")
            {
                XtraMessageBox.Show("Database name is not be empty", "Warning");
                return;
            }
            var thatluangplazaConnectionString_new = "";

            thatluangplazaConnectionString_new = "Data Source = " + txtServer.Text + "; Initial Catalog = " +
                                                 txtDbName.Text + "; Persist Security Info = True; User ID = " +
                                                 txtTen.Text + "; Password = " + txtPass.Text + "";

            var sqlCon = new SqlConnection(thatluangplazaConnectionString_new);
            try
            {
                sqlCon.Open();

                db = new KetNoiDBDataContext(sqlCon);

                XtraMessageBox.Show("Connection succeeded");
                Biencucbo.DbName = txtDbName.Text;
                Biencucbo.ServerName = txtServer.Text;
                thoat_luon = true;
                // luu connstring mã hóa vào setting
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("appconn.xml");//mở file.xml lên
                xmlDoc.DocumentElement["conn"].InnerText = MD5.Encrypt(thatluangplazaConnectionString_new);
                xmlDoc.Save("appconn.xml");
                DAL.Settings.Default.ConnectionString = thatluangplazaConnectionString_new;

                //Settings.Default.Save();

                DialogResult = DialogResult.OK;
            }
            catch
            {
                XtraMessageBox.Show("Connection failed, please check again or contact Admin");
                sqlCon.Close();
            }
        }

        private void f_connectDB_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "CẬP NHẬT KẾT NỐI CƠ SỞ DỮ LIỆU");

            changeFont.Translate(this);

            txtDbName.Text = Biencucbo.DbName;
            if (Biencucbo.ServerName == "192.168.2.10,1433")
            {
                rlan.Checked = true;
            }
            else
            {
                rnet.Checked = true;
            }
        }

    

        private void rlan_CheckedChanged(object sender, EventArgs e)
        {
            txtTen.ReadOnly = true;
            //txtServer.Enabled = false;
            txtPass.ReadOnly = true;

            if (rlan.Checked)
            {
                rnet.Checked = false;
                txtServer.Text = "192.168.2.10,1433";
                txtTen.Text = "sa";
                txtPass.Text = "2267562676a@#$%";
            }
        }

        private void rnet_CheckedChanged(object sender, EventArgs e)
        {
            txtTen.ReadOnly = true;
            //txtServer.Enabled = false;
            txtPass.ReadOnly = true;
            if (rnet.Checked)
            {
                rlan.Checked = false;
                txtServer.Text = "183.182.109.4";
                txtTen.Text = "sa";
                txtPass.Text = "2267562676a@#$%";
            }
        }

        //hàm mã hoá
        public static string EncryptString(string Message, string Passphrase)
        {
            byte[] Results;
            var UTF8 = new UTF8Encoding();

            var HashProvider = new MD5CryptoServiceProvider();
            var TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            var TDESAlgorithm = new TripleDESCryptoServiceProvider();

            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            var DataToEncrypt = UTF8.GetBytes(Message);

            try
            {
                var Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            return Convert.ToBase64String(Results);
        }

        //hàm giải mã
        public static string DecryptString(string Message, string Passphrase)
        {
            byte[] Results;
            var UTF8 = new UTF8Encoding();


            var HashProvider = new MD5CryptoServiceProvider();
            var TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            var TDESAlgorithm = new TripleDESCryptoServiceProvider();

            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;


            try
            {
                var DataToDecrypt = Convert.FromBase64String(Message);
                var Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            catch
            {
                return string.Empty;
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            return UTF8.GetString(Results);
        }

        private void btntest_Click(object sender, EventArgs e)
        {
            if (txtDbName.Text == "")
            {
                XtraMessageBox.Show("Database name is not be empty", "Warning");
                return;
            }
            var thatluangplazaConnectionString_new = "";

            thatluangplazaConnectionString_new = "Data Source = " + txtServer.Text + "; Initial Catalog = " +
                                                 txtDbName.Text + "; Persist Security Info = True; User ID = " +
                                                 txtTen.Text + "; Password = " + txtPass.Text + "";

            var sqlCon = new SqlConnection(thatluangplazaConnectionString_new);
            try
            {
                sqlCon.Open();
                //db = new KetNoiDBDataContext(sqlCon);

                XtraMessageBox.Show("Connection succeeded");
                //Settings.Default.Save();
            }
            catch
            {
                XtraMessageBox.Show("Connection failed, please check again or contact Admin");
                sqlCon.Close();
            }
        }
    }
}