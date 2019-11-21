using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using DevExpress.Utils.Win;
using GUI.Properties;
using DevExpress.XtraEditors.Controls;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;
using DevExpress.DataAccess.Native.Data;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Views.Grid;
using BUS;
using DevExpress.Office.PInvoke;
using DAL;
using DevExpress.XtraGrid;
using DataTable = System.Data.DataTable;
using DAL;
using BUS;

namespace GUI
{
    sealed class custom
    {
        static KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        public static void showdate(DateEdit a, string b)
        {
            try
            {
                a.DateTime = DateTime.Parse(b);
                if (a.Text == "01/01/0001")
                    a.Text = "";
            }
            catch (Exception ex)
            {
                a.Text = "";
            }
        }

        private static SearchLookUpEdit _slUpEdit;
        

        #region gridcontrol
        public static bool cal(GridControl gd, GridView gv)
        {
            SizeF _Size = gd.CreateGraphics().MeasureString("STT", gd.Font);

            Int32 _Width = Convert.ToInt32(_Size.Width) + 21;
            int stt = _Width;
            int so = gv.DataRowCount;

            _Size = gd.CreateGraphics().MeasureString(so.ToString(), gd.Font);
            _Width = Convert.ToInt32(_Size.Width) + 25;
            if (stt > _Width)
                _Width = stt;

            gv.IndicatorWidth = gv.IndicatorWidth < _Width ? _Width : gv.IndicatorWidth;

            return true;
        }
        public static void sttgv(GridView gv, RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //e.Info.DisplayText = "STT";
            SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lấy kích thước của vùng hiển thị Text
            Int32 _Width = Convert.ToInt32(_Size.Width) + 21;


            if (!gv.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
            {
                if (e.Info.IsRowIndicator) //Nếu là dòng Indicator
                {
                    if (e.RowHandle < 0)
                    {
                        e.Info.ImageIndex = 0;
                        e.Info.DisplayText = string.Empty;
                    }
                    else
                    {
                        e.Info.ImageIndex = -1; //Không hiển thị hình
                        e.Info.DisplayText = (e.RowHandle + 1).ToString(); //Số thứ tự tăng dần
                    }
                    _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lấy kích thước của vùng hiển thị Text
                    _Width = Convert.ToInt32(_Size.Width) + 21;
                    gv.IndicatorWidth = gv.IndicatorWidth < _Width ? _Width : gv.IndicatorWidth;


                    //Graphics gr = Graphics.FromHwnd(gv.GridControl.Handle);
                    //SizeF size = gr.MeasureString(gv.RowCount.ToString(), gv.PaintAppearance.Row.GetFont());

                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1)); //Nhân -1 để đánh lại số thứ tự tăng dần
                _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                _Width = Convert.ToInt32(_Size.Width) + 20;
                gv.IndicatorWidth = gv.IndicatorWidth < _Width ? _Width : gv.IndicatorWidth;

            }



        }


        #endregion

        #region Searchlokupedit
        public static void popupslu<C>(object sender, EventArgs e, SearchLookUpEdit slUpEdit, string btn)
        {

            try
            {
                var popupControl = sender as IPopupControl;
                var button = new SimpleButton
                {
                    Image = Resources.additem_16x16,
                    Text = "Edit",
                    BorderStyle = BorderStyles.Default
                };
                var btnreload = new SimpleButton
                {
                    Image = Resources.additem_16x16,
                    Text = "reload",
                    BorderStyle = BorderStyles.Default
                };
                layquyen(btn);
                button.Click += btnclick<C>;
                _slUpEdit = slUpEdit;

                //btnreload.Click += reloadclick<E>;

                button.Location = new Point(5, popupControl.PopupWindow.Height - button.Height - 5);
                popupControl.PopupWindow.Controls.Add(button);
                button.BringToFront();

                //btnreload.Location = new Point(90, popupControl.PopupWindow.Height - btnreload.Height - 5);
                //popupControl.PopupWindow.Controls.Add(btnreload);
                //btnreload.BringToFront();

                var edit = sender as SearchLookUpEdit;
                var popupForm = edit.GetPopupEditForm();
                popupForm.KeyPreview = true;
                popupForm.KeyUp -= txt_KeyUp;
                popupForm.KeyUp += txt_KeyUp;


                //slUpEdit.Properties.DataSource = Biencucbo.Table;
                //Biencucbo.Table = null;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());

            }
        }
        

        //private static void reloadclick<E>(object sender, EventArgs e)
        //{
        //    try
        //    {


        //        //_slUpEdit.Properties.DataSource = fm;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }

        //}

        private static void btnclick<C>(object sender, EventArgs e)
        {
            var fm = Activator.CreateInstance<C>() as Form;// tao đối tượng T thôi
            fm.ShowDialog();

        }
        private static void txt_KeyUp(object sender, KeyEventArgs e)
        {
            PopupSearchLookUpEditForm popupForm = sender as PopupSearchLookUpEditForm;
            if (e.KeyData == System.Windows.Forms.Keys.Enter)
            {
                GridView view = popupForm.OwnerEdit.Properties.View;
                view.FocusedRowHandle = 0;
                popupForm.OwnerEdit.ClosePopup();
            }
        }
        #endregion

        #region mã tự tăng

        public static string matutang(string macheck)
        {
            KetNoiDBDataContext dbData = new KetNoiDBDataContext();
            t_tudong td = new t_tudong();
            var check = macheck;
            var lst1 = (from s in dbData.tudongs where s.maphieu == check select new { s.so }).ToList();

            if (lst1.Count == 0)
            {
                int so;
                so = 2;
                td.themtudong(check, so);
                Biencucbo.so = 1;
                return check + "_000001";

            }
            else
            {
                int k;

                k = 0;
                k = Convert.ToInt32(lst1.Single().so);
                Biencucbo.so = k;
                var so0 = "";
                if (k < 10)
                {
                    so0 = "00000";
                }
                else if (k >= 10 & k < 100)
                {
                    so0 = "0000";
                }
                else if (k >= 100 & k < 1000)
                {
                    so0 = "000";
                }
                else if (k >= 1000 & k < 10000)
                {
                    so0 = "00";
                }
                else if (k >= 10000 & k < 100000)
                {
                    so0 = "0";
                }
                else if (k >= 100000)
                {
                    so0 = "";
                }


                k = k + 1;

                td.suatudong(check, k);
                return check + "_" + so0 + k;
            }
        }
        #endregion

        #region layquyen
        public static void layquyen(string btn)
        {
            var quyen = dbData.PhanQuyen2s.FirstOrDefault(
                          t => t.TaiKhoan == Biencucbo.phongban && t.ChucNang == btn);

            Biencucbo.QuyenDangChon = quyen;
        }
        #endregion

        #region mo form trong bao cao

        public static void mofombc(string ma)
        {
            if (ma.Contains("PNK"))
            {
                layquyen("btnnhapkho");
                Biencucbo.xembc = true;
                var frm = new f_pxmnhapkho();
                frm.ShowDialog();
            }
            else if (ma.Contains("NNB"))
            {
                layquyen("btnpxmnhapnb");
                Biencucbo.xembc = true;
                var frm = new f_pxmpnhapkhoNB();
                frm.ShowDialog();
            }
            else if (ma.Contains("PXK"))
            {
                layquyen("btnpxuatkho");
                Biencucbo.xembc = true;
                var frm = new f_pxmxuatkho();
                frm.ShowDialog();
            }
            else if (ma.Contains("XNB"))
            {
                layquyen("btnpxmxuatnb");
                Biencucbo.xembc = true;
                var frm = new f_pxmpxuatkhoNB();
                frm.ShowDialog();
            }

            else if (ma.Contains("PC"))
            {
                layquyen("btncpql");
                Biencucbo.xembc = true;
                var frm = new f_pchi();
                frm.ShowDialog();
            }

            else if (ma.Contains("CPM"))
            {
                layquyen("btncpm");
                Biencucbo.xembc = true;
                var frm = new f_cpmay();
                frm.ShowDialog();
            }

            else if (ma.Contains("HDTP"))
            {
                layquyen("btnHopDong");
                //Biencucbo.xembc = true;
                Biencucbo.hopdong = Biencucbo.ma;
                var frm = new f_thanhtoan_tp();
                frm.ShowDialog();
            }


        }

        public static void mofombc2(string ma)
        {
           
             if (ma.Contains("PN"))
            {
                layquyen("btnnhap");
                Biencucbo.xembc = true;
                var frm = new f_pnhap();
                frm.ShowDialog();
            }
            else if (ma.Contains("PC"))
            {
                layquyen("btncpql");
                Biencucbo.xembc = true;
                var frm = new f_pchi();
                frm.ShowDialog();
            }

            else if (ma.Contains("CPM"))
            {
                layquyen("btncpm");
                Biencucbo.xembc = true;
                var frm = new f_cpmay();
                frm.ShowDialog();
            }



        }
        #endregion
        #region MD5
        public static string Encrypt(string toEncrypt)
        {
            string key = "chitchareuneco.,ltd";
            try
            {

                bool useHashing = true;
                byte[] keyArray;
                byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

                if (useHashing)
                {
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                }
                else
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                return Convert.ToBase64String(resultArray, 0, resultArray.Length);


            }
            catch (Exception ex) { }
            return "";
        }
        public static string Decrypt(string toDecrypt)
        {
            try
            {
                string key = "chitchareuneco.,ltd";
                bool useHashing = true;
                byte[] keyArray;
                byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

                if (useHashing)
                {
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                }
                else

                    keyArray = UTF8Encoding.UTF8.GetBytes(key);

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception)
            {
                return "";
            }
        }
        #endregion


        static public bool checknulltext(TextEdit _text)
        {

            if (_text.Text.Trim() == string.Empty)
            {
                _text.Properties.ContextImage = GUI.Properties.Resources.trong;
                return true;
            }
            return false;

        }


       static public void mes_thongtinchuadaydu()
        {
            XtraMessageBox.Show("Thông Tin Chưa Đầy Đủ - Vui Lòng Kiểm Tra Lại");
        }

        static public void mes_done()
        {
            XtraMessageBox.Show("Done!");
        }

        public static string laykey()
        {
            return Encrypt(Biencucbo.idnv + Biencucbo.hostname + Biencucbo.IPaddress + Biencucbo.donvi +
                           DateTime.Now);

        }


    }
}
