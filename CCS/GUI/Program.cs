using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System.Xml;
using System.Net;

namespace GUI
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CapNhatOnline();

            SplashScreenManager.ShowForm(typeof (SplashScreen1));





            // kiem tra kêt nối nối

            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load("appconn.xml");
            }
            catch
            {
                try
                {

                    string filepath = "appconn.xml";
                    WebClient webClient = new WebClient();
                    //webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                    webClient.DownloadFileAsync(new Uri("http://www.petrolao.com.la/config/CCS/appconn.xml"), filepath);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
            var fKetNoi = new f_connectDB();

            var isconnected = fKetNoi.KiemTraKetNoi();
            // nếu không kết nối được
            // hiện form cau hinh ket nối
            if (isconnected == false)
            {
                XtraMessageBox.Show("Connection failed!");
                SplashScreenManager.CloseForm();
                if (fKetNoi.ShowDialog() == DialogResult.Cancel)
                    return;
            }
            else
            {
                SplashScreenManager.CloseForm();
            }
            try
            {
                var tmpPath = Application.StartupPath + "\\tmp";
                Directory.Delete(tmpPath, true);
            }
            catch (Exception ex)
            {
            }

            // ok
            // hien form main
            Application.Run(new f_main());
        }

        public static void CapNhatOnline()
        {
            SplashScreenManager.ShowForm(typeof (SplashScreen1));

            //var app = String.Format("{0}\\{1}", Application.StartupPath, "Lotus.AutoUpdate.exe");
            var app = string.Format("{0}\\{1}", Application.StartupPath, "Lotus.AutoUpdate_eng.exe");
            if (!File.Exists(app)) return;

            var host = "http://www.petrolao.com.la/config/CCS/dev18/info.xml";

            var info = new ProcessStartInfo();
            info.FileName = app;
            info.Arguments = string.Format("{0} {1} {2}",
                Assembly.GetExecutingAssembly().GetName().Name,
                Assembly.GetExecutingAssembly().GetName().Version,
                host);

            var process = Process.Start(info);
            if (process != null) process.WaitForExit();
            SplashScreenManager.CloseForm();
        }
    }
}