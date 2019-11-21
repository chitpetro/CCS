// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Windows.Forms;
// End of VB project level imports

using System.Data.SqlClient;
using System.IO;
using DevExpress.XtraEditors;
using System.Data.OleDb;
using System.Threading;
using Microsoft.Office.Interop;


namespace GUI
{
	sealed class mod_KetNoi
	{
		public static SqlConnection strconnect = new SqlConnection();
		public static SqlConnection strconnect2 = new SqlConnection();
		public static string strDiaChiIP;
		public static string strIP;
		public static string strNgayThang;
		public static string strMaNhanVien;
		public static string strTenDangNhap;
		public static bool start;
		public static bool start1;
		public static int reports;
		public static int flag;
		public static DataSet dsReports = new DataSet();
		//public static string strHinh_NV = "F:\\Hinh_NV\\";
		public static void open_connect()
		{
			try
			{
				strconnect.ConnectionString = "server=192.168.0.6;uid=sa;database=CCS;password=2267562676a@#$%;";
				strconnect.Open();
			}
			catch (Exception)
			{
			    XtraMessageBox.Show("Lỗi kết nối đến máy chủ. Vui lòng thử lại.");
			}
		}
		
		
		public static void open_connect2()
		{
			try
			{
				strconnect2.ConnectionString = "server=192.168.0.6;uid=sa;database=CCS;password=2267562676a@#$%;";
				strconnect2.Open();
			}
			catch (Exception)
			{
			    XtraMessageBox.Show("Lỗi kết nối đến máy chủ. Vui lòng thử lại.");
			}
		}
		
		public static void close_connect()
		{
			strconnect.Close();
		}
		
		public static void close_connect2()
		{
			strconnect2.Close();
		}
		
		public static string _getdata(string strLenh)
		{
			string str = "";
			open_connect();
			string d = "set dateformat dmy";
			SqlCommand cmd = new SqlCommand(strLenh, strconnect);
			SqlCommand cmd1 = new SqlCommand(d, strconnect);
			str = System.Convert.ToString(cmd.ExecuteScalar());
			close_connect();
			return str;
		}
		
		public static string _getdata2(string strLenh)
		{
			string str = "";
			open_connect2();
			string d = "set dateformat dmy";
			SqlCommand cmd = new SqlCommand(strLenh, strconnect2);
			SqlCommand cmd1 = new SqlCommand(d, strconnect2);
			str = System.Convert.ToString(cmd.ExecuteScalar());
			close_connect2();
			return str;
		}
		
		public static int _kiemtra(string strLenh)
		{
			int intKiemTra = 0;
			open_connect();
			SqlCommand cmd = new SqlCommand(strLenh, strconnect);
			intKiemTra = System.Convert.ToInt32(cmd.ExecuteScalar());
			close_connect();
			return intKiemTra;
		}
		
		public static DataSet _load_data(string strLenh)
		{
			DataSet ds = new DataSet();
			open_connect();
			string d = "set dateformat dmy";
			SqlCommand cmd1 = new SqlCommand(d, strconnect);
			cmd1.ExecuteNonQuery();
			
			SqlDataAdapter cmd = new SqlDataAdapter(strLenh, strconnect);
			cmd.Fill(ds);
			close_connect();
			return ds;
		}
		
		public static DataSet _load_data2(string strLenh)
		{
			DataSet ds = new DataSet();
			open_connect2();
			string d = "set dateformat dmy";
			SqlCommand cmd1 = new SqlCommand(d, strconnect2);
			cmd1.ExecuteNonQuery();
			
			SqlDataAdapter cmd = new SqlDataAdapter(strLenh, strconnect2);
			cmd.Fill(ds);
			close_connect2();
			return ds;
		}
		
		public static void _Update(string strLenh)
		{
			open_connect();
			string d = "set dateformat dmy";
			SqlCommand cmd1 = new SqlCommand(d, strconnect);
			cmd1.ExecuteNonQuery();
			
			SqlCommand cmd = new SqlCommand(strLenh, strconnect);
			cmd.ExecuteNonQuery();
			close_connect();
		}
		
		public static void _Save(string strLenh)
		{
			open_connect();
			string d = "set dateformat dmy";
			SqlCommand cmd1 = new SqlCommand(d, strconnect);
			cmd1.ExecuteNonQuery();
			SqlCommand cmd = new SqlCommand(strLenh, strconnect);
			cmd.ExecuteNonQuery();
			close_connect();
		}
		
		public static void _Delete(string strLenh)
		{
			open_connect();
			SqlCommand cmd = new SqlCommand(strLenh, strconnect);
			cmd.ExecuteNonQuery();
			close_connect();
		}
		
		public static byte[] encryptData(string data)
		{
			System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
			byte[] hashedBytes;
			System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
			hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));
			return hashedBytes;
		}

  //      public static void ExportToExcel(DataTable dtTemp, string filepath)
  //      {
		//	string strFileName = filepath;
		//	if (File.Exists(strFileName))
		//	{
		//		if (MessageBox.Show("Bạn có muốn chép đè lên file đã tồn tại không?", "Export to Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
		//		{
		//			File.Delete(strFileName);
		//		}
		//		else
		//		{
		//			return ;
		//		}
				
		//	}
		//	Excel.Application _excel = new Excel.Application();
		//	Microsoft.Office.Interop.Excel.Workbook wBook = default(Microsoft.Office.Interop.Excel.Workbook);
		//	Microsoft.Office.Interop.Excel.Worksheet wSheet = default(Microsoft.Office.Interop.Excel.Worksheet);
			
		//	wBook = _excel.Workbooks.Add();
		//	wSheet = wBook.ActiveSheet();
			
		//	System.Data.DataTable dt = dtTemp;
		//	System.Data.DataColumn dc = default(System.Data.DataColumn);
		//	System.Data.DataRow dr = default(System.Data.DataRow);
		//	int colIndex = 0;
		//	int rowIndex = 0;
			
		//	// export the Columns
		//	//  If CheckBox1.Checked Then
		//	foreach (System.Data.DataColumn tempLoopVar_dc in dt.Columns)
		//	{
		//		dc = tempLoopVar_dc;
		//		colIndex++;
		//		wSheet.Cells[1, colIndex] = dc.ColumnName;
		//	}
		//	// End If
			
		//	//export the rows
		//	foreach (System.Data.DataRow tempLoopVar_dr in dt.Rows)
		//	{
		//		dr = tempLoopVar_dr;
		//		rowIndex++;
		//		colIndex = 0;
		//		foreach (System.Data.DataColumn tempLoopVar_dc in dt.Columns)
		//		{
		//			dc = tempLoopVar_dc;
		//			colIndex++;
		//			wSheet.Cells[rowIndex + 1, colIndex] = dr[dc.ColumnName];
		//		}
		//	}
		//	wSheet.Columns.AutoFit();
		//	wBook.SaveAs(strFileName);
			
		//	//release the objects
		//	ReleaseObject(wSheet);
		//	wBook.Close(false);
		//	ReleaseObject(wBook);
		//	_excel.Quit();
		//	ReleaseObject(_excel);
		//	// some time Office application does not quit after automation: so i am calling GC.Collect method.
		//	GC.Collect();
			
		//}
		
		private static void ReleaseObject(object o)
		{
			try
			{
				while (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
				{
				}
			}
			catch
			{
			}
			finally
			{
				o = null;
			}
		}
		
		public static DataTable GetDatatable(string strLenh)
		{
			//Create the data table at runtime
			DataTable dt = new DataTable();
			DataSet ds = new DataSet();
			ds = _load_data(strLenh);
			dt = ds.Tables[0];
			return dt;
		}
		
		public static void center_windows(Form FRM)
		{
			FRM.Top = System.Convert.ToInt32((double) (Screen.PrimaryScreen.Bounds.Height - FRM.Height) / 2);
			FRM.Left = System.Convert.ToInt32((double) (Screen.PrimaryScreen.Bounds.Width - FRM.Width) / 2);
		}
		
		public static string md5(string data)
		{
			return BitConverter.ToString(encryptData(data)).Replace("-", "").ToLower();
		}
	}
	
}
