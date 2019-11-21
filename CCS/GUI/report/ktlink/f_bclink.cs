using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAL;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using GUI.report.chiphimay;

namespace GUI.report.ktlink
{
    public partial class f_bclink : frm.frmreport3
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        public f_bclink()
        {
            InitializeComponent();
        }

        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        protected override void load()
        {
           
            txtdanhmuc.Text = "Link Hồ Sơ";
        }

        //private bool layinfo(string tungay, string denngay)
        //{
        //    Biencucbo.ngaybc = "Từ ngày " + tungay + " Đến ngày " + denngay;
        //    Biencucbo.info = "";
        //    bool checkdv = false;
        //    string loai = "";
        //    gv2.Columns["loai"].SortOrder = ColumnSortOrder.Ascending;
        //    for (int i = 0; i < gv2.DataRowCount; i++)
        //    {
        //        if (gv2.GetRowCellValue(i, "loai").ToString() == "Đơn Vị")
        //        {
        //            checkdv = true;
        //        }
        //        if (loai != gv2.GetRowCellValue(i, "loai").ToString())
        //        {
        //            if (Biencucbo.info == "")
        //            {
        //                Biencucbo.info = gv2.GetRowCellValue(i, "loai") + ": " + gv2.GetRowCellValue(i, "name");
        //            }
        //            else
        //            {
        //                Biencucbo.info = Biencucbo.info + "\n" + gv2.GetRowCellValue(i, "loai") + ": " +
        //                                 gv2.GetRowCellValue(i, "name");
        //            }
        //        }
        //        else
        //        {
        //            Biencucbo.info = Biencucbo.info + ", " + gv2.GetRowCellValue(i, "name");
        //        }
        //        loai = gv2.GetRowCellValue(i, "loai").ToString();
        //    }
        //    if (Biencucbo.info == "")
        //        Biencucbo.info = "Tất cả";
        //    return checkdv;
        //}

        //private void inbc<T>()
        //{
        //    if ( layinfo(DateTime.Parse(tungay.EditValue.ToString()).ToShortDateString(),
        //            DateTime.Parse(denngay.EditValue.ToString()).ToShortDateString()) ==
        //        false)
        //    {
        //        XtraMessageBox.Show("Cần phải chọn một đơn vị bất kỳ để xem báo cáo", "THÔNG BÁO");
        //        return;
        //    }
        //    try
        //    {
        //        var rp = Activator.CreateInstance<T>() as XtraReport;
        //        rp.DataSource = dbData.SP_InBCNhapKho(Nhapdulieu2);
        //        rp.ShowPreview();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        protected override void searchall()
        {
            SplashScreenManager.ShowForm(typeof (SplashScreen2));
            try
            {
                //if (checksohd != 0)
                //{
                //    lst4 = from a in lst5
                //           join b in db.dk_rps on a.sohd equals b.name
                //           where b.user == Biencucbo.idnv && b.loai == "Số Hợp Đồng"
                //           select a;
                //}

                var checklink = 0;
                var checklinkgoc = 0;
                for (var i = 0; i < gv2.DataRowCount; i++)
                {
                    if (gv2.GetRowCellValue(i, "loai").ToString() == "Hồ Sơ Gốc")
                    {
                        checklinkgoc++;
                    }
                    //moi
                    else if (gv2.GetRowCellValue(i, "loai").ToString() == "Link Hồ Sơ")
                    {
                        checklink++;
                    }
                }

                if (checklink == 0 && checklinkgoc == 0)
                {
                    XtraMessageBox.Show("Cần phải chọn ít nhất 1 Hồ sơ Để xem báo cáo");
                    return;

                }


                var lst = (from tt in db.r_linktts
                          
                           select new
                             {
                                 tt.link,
                                 tt.linkgoc,
                                 idct = tt.idct + " - " + tt.tencongtrinh,
                                 ngay = tt.ngaytt,
                                 dt = tt.iddt + " - " + tt.ten,
                                 tt.tiente,
                                 giatrint = tt.giatritt == null ? 0 : tt.giatritt,
                                 giatri = (tt.giatritt == null ? 0 : tt.giatritt) * (tt.tygia == null ? 1 : tt.tygia),
                                 noidung = tt.diengiai + " (Số HĐ: " + tt.sohd + ")",
                                 loai = "Chi Phí Hợp Đồng"
                             }
                    ).Concat(from pn in db.r_linkpnhaps
                            
                             select new
                             {
                                 pn.link,
                                 pn.linkgoc,
                                 idct = pn.idct + " - " + pn.tencongtrinh,
                                 ngay = pn.ngaynhap,
                                 dt = pn.iddt + " - " + pn.ten,
                                 pn.tiente,
                                 giatrint = pn.nguyente == null ? 0 : pn.nguyente,
                                 giatri = (pn.nguyente == null ? 0 : pn.nguyente) * (pn.tygia == null ? 1 : pn.tygia),
                                 noidung = pn.ghichu,
                                 loai = "Chi Phí Nhập Vật Tư"
                             }
                    ).Concat(from pn in db.r_linkpchis
                         
                             select new
                             {
                                 pn.link,
                                 pn.linkgoc,
                                 idct = pn.idct + " - " + pn.tencongtrinh,
                                 ngay = pn.ngaychi,
                                 dt = pn.iddt + " - " + pn.ten,
                                 pn.tiente,
                                 giatrint =
                                     (pn.nguyentebch == null ? 0 : pn.nguyentebch) +
                                     (pn.nguyentecn == null ? 0 : pn.nguyentecn) +
                                     (pn.nguyentect == null ? 0 : pn.nguyentect),
                                 giatri =
                                     ((pn.nguyentebch == null ? 0 : pn.nguyentebch) +
                                      (pn.nguyentecn == null ? 0 : pn.nguyentecn) +
                                      (pn.nguyentect == null ? 0 : pn.nguyentect)) * (pn.tygia == null ? 1 : pn.tygia),
                                 noidung = pn.ghichu,
                                 loai = "Chi Phí Quản Lý"
                             }).Concat(from pn in db.r_linkcpms
                                      
                                       select new
                                       {
                                           pn.link,
                                           pn.linkgoc,
                                           idct = pn.idct + " - " + pn.tencongtrinh,
                                           ngay = pn.ngaychi,
                                           dt = pn.iddt + " - " + pn.ten,
                                           tiente = "Kip",
                                           giatrint = pn.sotien == null ? 0 : pn.sotien,
                                           giatri = (pn.sotien == null ? 0 : pn.sotien) * 1,
                                           noidung = pn.ghichu,
                                           loai = "Chi Phí Máy"
                                       }).ToList();
 
               
                if (checklink != 0)
                {
                    lst = (from a in lst
                          join b in dbData.dkreports on a.link equals b.id
                          where
                              b.idnv == Biencucbo.idnv && b.loai == "Link Hồ Sơ" && b.form == "f_bclink" &&
                              b.PC == Biencucbo.hostname
                          select a).ToList();
                }

                

                if (checklinkgoc != 0)
                {
                    lst = (from a in lst
                          join b in dbData.dkreports on a.linkgoc equals b.id
                          where
                              b.idnv == Biencucbo.idnv && b.loai == "Hồ Sơ Gốc" && b.form == "f_bclink" &&
                              b.PC == Biencucbo.hostname
                          select a).ToList();
                }

                
                var frm = new r_ktlink();
                frm.DataSource = _tTodatatable.addlst(lst.Where(t => t.idct != null).ToList());
                frm.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

            SplashScreenManager.CloseForm();
        }   
        t_todatatable _tTodatatable = new t_todatatable();
    }
}