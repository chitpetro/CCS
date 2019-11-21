namespace GUI.frm
{
    partial class rp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        protected System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        protected void InitializeComponent()
        {
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.txttitle = new DevExpress.XtraReports.UI.XRLabel();
            this.txtngayxem = new DevExpress.XtraReports.UI.XRLabel();
            this.txtinfo = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 50F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 3.125F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.HeightF = 25F;
            this.Detail.Name = "Detail";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPictureBox1,
            this.xrLabel17,
            this.xrLabel18,
            this.txttitle,
            this.txtngayxem,
            this.txtinfo});
            this.ReportHeader.HeightF = 200F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.ImageUrl = "F:\\Solution\\winform\\Code\\CCBH\\2019\\Tháng 05\\21052019\\CCBH\\GUI\\bin\\Debug\\14.-Logo-" +
    "Chitchareune-Const-Co.png";
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(75F, 72.40203F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // xrLabel17
            // 
            this.xrLabel17.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(75F, 0F);
            this.xrLabel17.Multiline = true;
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(186.9478F, 72.40206F);
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.StylePriority.UseTextAlignment = false;
            this.xrLabel17.Text = "\r\nCông Ty TNHH Xây Dựng ChitChareune\r\n";
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel18
            // 
            this.xrLabel18.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(371.3782F, 0F);
            this.xrLabel18.Multiline = true;
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(384.6218F, 72.40204F);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.Text = "\r\nCỘNG HÒA DÂN CHỦ NHÂN DÂN LÀO\r\nHòa bình - Độc lập - Dân chủ - Thống nhất- Thịnh" +
    " Vượng";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // txttitle
            // 
            this.txttitle.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.txttitle.LocationFloat = new DevExpress.Utils.PointFloat(10.00004F, 103.7038F);
            this.txttitle.Multiline = true;
            this.txttitle.Name = "txttitle";
            this.txttitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txttitle.SizeF = new System.Drawing.SizeF(745.9999F, 28.44875F);
            this.txttitle.StylePriority.UseFont = false;
            this.txttitle.StylePriority.UseTextAlignment = false;
            this.txttitle.Text = "BÁO CÁO";
            this.txttitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // txtngayxem
            // 
            this.txtngayxem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
            this.txtngayxem.LocationFloat = new DevExpress.Utils.PointFloat(10.00004F, 136.3193F);
            this.txtngayxem.Multiline = true;
            this.txtngayxem.Name = "txtngayxem";
            this.txtngayxem.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtngayxem.SizeF = new System.Drawing.SizeF(745.9999F, 22.03839F);
            this.txtngayxem.StylePriority.UseFont = false;
            this.txtngayxem.StylePriority.UseTextAlignment = false;
            this.txtngayxem.Text = "Từ Ngày......... Đến ngày.........";
            this.txtngayxem.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // txtinfo
            // 
            this.txtinfo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
            this.txtinfo.LocationFloat = new DevExpress.Utils.PointFloat(10.00004F, 162.5243F);
            this.txtinfo.Multiline = true;
            this.txtinfo.Name = "txtinfo";
            this.txtinfo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtinfo.SizeF = new System.Drawing.SizeF(745.9999F, 22.03847F);
            this.txtinfo.StylePriority.UseFont = false;
            this.txtinfo.StylePriority.UseTextAlignment = false;
            this.txtinfo.Text = "THÔNG TIN";
            this.txtinfo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // PageHeader
            // 
            this.PageHeader.HeightF = 25F;
            this.PageHeader.Name = "PageHeader";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel3,
            this.xrLabel4,
            this.xrPageInfo2});
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(437.4025F, 43.41667F);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(318.5973F, 18.99357F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "NGƯỜI LẬP";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(437.4029F, 62.41024F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(318.5973F, 18.99357F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "(Ký & họ tên)";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Italic);
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(437.4029F, 20.41665F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(318.5971F, 23F);
            this.xrPageInfo2.StylePriority.UseFont = false;
            this.xrPageInfo2.StylePriority.UseTextAlignment = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrPageInfo2.TextFormatString = "Ngày {0:dd} Tháng {0:MM} Năm {0:yyyy}";
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1});
            this.PageFooter.HeightF = 58.33333F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(655.9998F, 9.999957F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrPageInfo1.TextFormatString = "Trang {0}/{1}";
            // 
            // rp
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.ReportHeader,
            this.PageHeader,
            this.ReportFooter,
            this.PageFooter});
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(18, 43, 50, 3);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "18.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        protected DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        protected DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        protected DevExpress.XtraReports.UI.DetailBand Detail;
        protected DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        protected DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        protected DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        protected DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        protected DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        protected DevExpress.XtraReports.UI.XRLabel xrLabel17;
        protected DevExpress.XtraReports.UI.XRLabel xrLabel18;
        protected DevExpress.XtraReports.UI.XRLabel txttitle;
        protected DevExpress.XtraReports.UI.XRLabel txtngayxem;
        protected DevExpress.XtraReports.UI.XRLabel txtinfo;
        protected DevExpress.XtraReports.UI.XRLabel xrLabel3;
        protected DevExpress.XtraReports.UI.XRLabel xrLabel4;
        protected DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        protected DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
    }
}
