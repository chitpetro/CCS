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
using System.Drawing;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Windows.Forms;
// End of VB project level imports
using System.Threading;
using DevExpress.XtraEditors;
using System.Net.NetworkInformation;
using DAL;



namespace GUI
{
    public partial class testmaychamcong : DevExpress.XtraEditors.XtraForm
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        public zkemkeeper.CZKEM axCZKEM1 = new zkemkeeper.CZKEM();
        public bool bIsConnected = false; //the boolean value identifies whether the device is connected
        private int iMachineNumber; //the
        public testmaychamcong()
        {
            InitializeComponent();
            axCZKEM1.Disconnect();
            axCZKEM1.PullMode = 1;
            //Ketnoi_Maychamcong("162.168.1.10");
            //Ketnoi_Maychamcong("192.168.1.10");
        }


        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = new Ping();
            try
            {
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false; 
            }
            return pingable;
        }
        public void Ketnoi_Maychamcong(string ip)
        {
            int idwErrorCode = 0;
            bIsConnected = axCZKEM1.Connect_Net(ip, 4370);

            if (bIsConnected == true)
            {
                MessageBox.Show("Kết nối thành công");

                iMachineNumber = 1; //In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
                axCZKEM1.RegEvent(iMachineNumber, 65535); //Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                XtraMessageBox.Show("Unable to connect the device,ErrorCode= " + idwErrorCode + ".", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                
                //mod_KetNoi._Update("update tbl_maychamcong set tinhtrang=N'Không thành công' where ip='" + ip + "'");
                //mod_KetNoi._Update("update tbl_maychamcong set tinhtrang=N'Không thành công' where ip='" + ip + "'");
            }
            Cursor = Cursors.Default;
        }
        int iDemso;
        public void loadDemsoQuetthe(string ip)
        {
            Ketnoi_Maychamcong(ip);
            // Dim idwErrorCode As Integer
            var iValue = 0;

            axCZKEM1.EnableDevice(iMachineNumber, false); //disable the device
            if (axCZKEM1.GetDeviceStatus(iMachineNumber, 6, ref iValue) == true) //Here we use the function "GetDeviceStatus" to get the record's count.The parameter "Status" is 6.
            {
                iDemso = iValue;
                //MsgBox("The count of the AttLogs in the device is " + iValue.ToString(), MsgBoxStyle.Information, "Success")
                //Else
                //    axCZKEM1.GetLastError(idwErrorCode)
                //    MsgBox("Operation failed,ErrorCode=" & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
            }
            axCZKEM1.EnableDevice(iMachineNumber, true); //enable the device
        }

        private void xoadulieu(string id)
        {
            CheckInOut pt = (from c in db.CheckInOuts select c).Single(x => x.id == id);
            db.CheckInOuts.DeleteOnSubmit(pt);
            db.CheckInOuts.Context.SubmitChanges();
        }

        private void luudulieu(string id, int manv, DateTime timecheck, DateTime date)

        {
            CheckInOut cio = new CheckInOut();
            cio.id = id;
            cio.UserEnrollNumber = manv;
            cio.TimeStr = timecheck;
            cio.TimeDate = date;
            db.CheckInOuts.InsertOnSubmit(cio);
            db.CheckInOuts.Context.SubmitChanges();

        }

        System.Int32 iGLCount = 0;
        public void loadTaiDuLieu(string ip)
        {
            ip = "192.168.1.10";
            Ketnoi_Maychamcong(ip);

            int idwTMachineNumber = 0;
            string idwEnrollNumber;
            int idwEMachineNumber = 0;
            int idwVerifyMode = 0;
            int idwInOutMode = 0;
            int idwYear = 0;
            int idwMonth = 0;
            int idwDay = 0;
            int idwHour = 0;
            int idwMinute = 0;
            int idwSecond = 0;
            int idwWorkCode = 0;
            //   Dim idwErrorCode As Integer
           
            axCZKEM1.EnableDevice(iMachineNumber, false); //disable the device
            if (axCZKEM1.ReadGeneralLogData(iMachineNumber)) //read all the attendance records to the memory
            {



                //get records from the memory
                //while (axCZKEM1.GetGeneralLogData(iMachineNumber, ref idwTMachineNumber, ref idwEnrollNumber, ref idwEMachineNumber, ref idwVerifyMode, ref idwInOutMode, ref idwYear, ref idwMonth, ref idwDay, ref idwHour, ref idwMinute ))
                while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out idwEnrollNumber, out idwVerifyMode, out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkCode) )//get records from the memory
                {
                    string strNgayThang = "";
                    strNgayThang = idwDay + "/" + System.Convert.ToString(idwMonth) + "/" + System.Convert.ToString(idwYear);
                    if (DateTime.Parse(strNgayThang) == DateTime.Parse("15/01/2019"))
                    {

                        iGLCount++;

                        string strGio = "";
                        string strPhut = "";
                        string strgiay = "";


                        if (idwHour < 10)
                        {
                            strGio = "0" + System.Convert.ToString(idwHour);
                        }
                        else
                        {
                            strGio = System.Convert.ToString(idwHour);
                        }
                        if (idwMinute < 10)
                        {
                            strPhut = "0" + System.Convert.ToString(idwMinute);
                        }
                        else
                        {
                            strPhut = System.Convert.ToString(idwMinute);
                        }
                        if (idwSecond < 10)
                        {
                            strgiay = "0" + System.Convert.ToString(idwSecond);
                        }
                        else
                        {
                            strgiay = System.Convert.ToString(idwSecond);
                        }

                        this.Text = idwEnrollNumber.ToString();





                        DateTime thoigian = DateTime.Parse(strNgayThang + " " + strGio + ":" + strPhut + ":" + strgiay);

                        //kiem tra du lieu, neu tai roi khong luu nua
                        if (
                            (from a in new KetNoiDBDataContext().CheckInOuts
                                where a.id == idwEnrollNumber + thoigian.ToString()
                                select a).Count() > 0)
                        {
                            xoadulieu(idwEnrollNumber + thoigian.ToString());
                        }
                        luudulieu(idwEnrollNumber.ToString() + thoigian.ToString(),
                            int.Parse(idwEnrollNumber.ToString()),
                            thoigian, DateTime.Parse(strNgayThang));
                    }

                }


            }
            else
            {
                //axCZKEM1.GetLastError(idwErrorCode)
                //If idwErrorCode <> 0 Then
                //    MsgBox("Reading data from terminal failed,ErrorCode: " & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
                //Else
                //    XtraMessageBox.Show("Không tồn tại dữ liệu trong máy chấm công.")
                //End If

            }

            axCZKEM1.EnableDevice(iMachineNumber, true); //enable the device
            MessageBox.Show("Thành Công"); Cursor = Cursors.Default;
        }

        private void btntaidulieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //DataSet ds = new DataSet();
            //ds = mod_KetNoi._load_data("select * from tbl_maychamcong where chon=1 order by stt");
            //DataRow dr = default(DataRow);
            //foreach (DataRow tempLoopVar_dr in ds.Tables[0].Rows)
            //{
            //    dr = tempLoopVar_dr;
            //    loadDemsoQuetthe(System.Convert.ToString(dr["ip"]));
            //    if (iDemso > 0)
            //    {
            //loadTaiDuLieu(System.Convert.ToString(dr["ip"]));
            loadTaiDuLieu("192.168.1.10");
            //}
            //iGLCount = 0;
            //}
            //loadMayChamCong();
            this.Text = "Đã tải hoàn tất...";
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PingHost("192.168.1.10");
        }
    }
}