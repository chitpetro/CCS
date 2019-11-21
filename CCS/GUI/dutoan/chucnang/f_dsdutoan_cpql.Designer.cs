namespace GUI.dutoan.chucnang
{
    partial class f_dsdutoan_cpql
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_dsdutoan_cpql));
            this.sPLayDSDuToancpqlResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colkey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colngaylap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coliddv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colteniddv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colidnv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltenidnv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colidct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltenidct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colkhuvuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldiadiem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colloaict = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltiente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltygia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldiengiai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colghichu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnguyente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colthanhtien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstt = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.denngay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.denngay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tungay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tungay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thoigian.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPLayDSDuToancpqlResultBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Size = new System.Drawing.Size(990, 472);
            this.layoutControl1.Controls.SetChildIndex(this.gd, 0);
            this.layoutControl1.Controls.SetChildIndex(this.thoigian, 0);
            this.layoutControl1.Controls.SetChildIndex(this.tungay, 0);
            this.layoutControl1.Controls.SetChildIndex(this.denngay, 0);
            this.layoutControl1.Controls.SetChildIndex(this.btnsearh, 0);
            this.layoutControl1.Controls.SetChildIndex(this.btnsearchall, 0);
            this.layoutControl1.Controls.SetChildIndex(this.btnxls, 0);
            this.layoutControl1.Controls.SetChildIndex(this.btnin, 0);
            // 
            // Root
            // 
            this.Root.Size = new System.Drawing.Size(990, 472);
            // 
            // gd
            // 
            this.gd.DataSource = this.sPLayDSDuToancpqlResultBindingSource;
            this.gd.Size = new System.Drawing.Size(966, 378);
            this.gd.TabIndex = 8;
            // 
            // gv
            // 
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colkey,
            this.colid,
            this.colngaylap,
            this.coliddv,
            this.colteniddv,
            this.colidnv,
            this.coltenidnv,
            this.colidct,
            this.coltenidct,
            this.colkhuvuc,
            this.coldiadiem,
            this.colloaict,
            this.coltiente,
            this.coltygia,
            this.coldiengiai,
            this.colso,
            this.colghichu,
            this.colnguyente,
            this.colthanhtien,
            this.colstt});
            this.gv.GroupCount = 1;
            this.gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "thanhtien", this.colthanhtien, "{0:n2}")});
            this.gv.IndicatorWidth = 44;
            this.gv.OptionsBehavior.AutoExpandAllGroups = true;
            this.gv.OptionsBehavior.Editable = false;
            this.gv.OptionsView.ShowAutoFilterRow = true;
            this.gv.OptionsView.ShowFooter = true;
            this.gv.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colid, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Size = new System.Drawing.Size(970, 382);
            // 
            // btnin
            // 
            this.btnin.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnin.ImageOptions.Image")));
            this.btnin.TabIndex = 7;
            // 
            // btnxls
            // 
            this.btnxls.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnxls.ImageOptions.Image")));
            this.btnxls.TabIndex = 6;
            // 
            // btnsearchall
            // 
            this.btnsearchall.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnsearchall.ImageOptions.Image")));
            this.btnsearchall.TabIndex = 5;
            // 
            // btnsearh
            // 
            this.btnsearh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnsearh.ImageOptions.Image")));
            this.btnsearh.TabIndex = 4;
            // 
            // denngay
            // 
            this.denngay.EditValue = new System.DateTime(2019, 10, 31, 0, 0, 0, 0);
            this.denngay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.denngay.TabIndex = 3;
            // 
            // tungay
            // 
            this.tungay.EditValue = new System.DateTime(2019, 10, 1, 0, 0, 0, 0);
            this.tungay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tungay.TabIndex = 2;
            // 
            // thoigian
            // 
            this.thoigian.EditValue = "Tháng Này";
            this.thoigian.TabIndex = 0;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.Size = new System.Drawing.Size(18, 70);
            // 
            // sPLayDSDuToancpqlResultBindingSource
            // 
            this.sPLayDSDuToancpqlResultBindingSource.DataSource = typeof(DAL.SP_LayDSDuToan_cpqlResult);
            // 
            // colkey
            // 
            this.colkey.FieldName = "key";
            this.colkey.Name = "colkey";
            this.colkey.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colid
            // 
            this.colid.Caption = "ID";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            this.colid.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colid.Visible = true;
            this.colid.VisibleIndex = 0;
            // 
            // colngaylap
            // 
            this.colngaylap.Caption = "Ngày Lập";
            this.colngaylap.FieldName = "ngaylap";
            this.colngaylap.Name = "colngaylap";
            this.colngaylap.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colngaylap.Visible = true;
            this.colngaylap.VisibleIndex = 0;
            // 
            // coliddv
            // 
            this.coliddv.FieldName = "iddv";
            this.coliddv.Name = "coliddv";
            this.coliddv.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colteniddv
            // 
            this.colteniddv.Caption = "Đơn Vị";
            this.colteniddv.FieldName = "teniddv";
            this.colteniddv.Name = "colteniddv";
            this.colteniddv.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colteniddv.Visible = true;
            this.colteniddv.VisibleIndex = 2;
            // 
            // colidnv
            // 
            this.colidnv.FieldName = "idnv";
            this.colidnv.Name = "colidnv";
            this.colidnv.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // coltenidnv
            // 
            this.coltenidnv.Caption = "Nhân Viên";
            this.coltenidnv.FieldName = "tenidnv";
            this.coltenidnv.Name = "coltenidnv";
            this.coltenidnv.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.coltenidnv.Visible = true;
            this.coltenidnv.VisibleIndex = 3;
            // 
            // colidct
            // 
            this.colidct.FieldName = "idct";
            this.colidct.Name = "colidct";
            this.colidct.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // coltenidct
            // 
            this.coltenidct.Caption = "Công Trình";
            this.coltenidct.FieldName = "tenidct";
            this.coltenidct.Name = "coltenidct";
            this.coltenidct.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.coltenidct.Visible = true;
            this.coltenidct.VisibleIndex = 4;
            // 
            // colkhuvuc
            // 
            this.colkhuvuc.FieldName = "khuvuc";
            this.colkhuvuc.Name = "colkhuvuc";
            this.colkhuvuc.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // coldiadiem
            // 
            this.coldiadiem.FieldName = "diadiem";
            this.coldiadiem.Name = "coldiadiem";
            this.coldiadiem.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colloaict
            // 
            this.colloaict.FieldName = "loaict";
            this.colloaict.Name = "colloaict";
            this.colloaict.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // coltiente
            // 
            this.coltiente.Caption = "Tiền Tệ";
            this.coltiente.FieldName = "tiente";
            this.coltiente.Name = "coltiente";
            this.coltiente.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.coltiente.Visible = true;
            this.coltiente.VisibleIndex = 5;
            // 
            // coltygia
            // 
            this.coltygia.FieldName = "tygia";
            this.coltygia.Name = "coltygia";
            this.coltygia.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // coldiengiai
            // 
            this.coldiengiai.Caption = "Diễn Giải";
            this.coldiengiai.FieldName = "diengiai";
            this.coldiengiai.Name = "coldiengiai";
            this.coldiengiai.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.coldiengiai.Visible = true;
            this.coldiengiai.VisibleIndex = 1;
            // 
            // colso
            // 
            this.colso.FieldName = "so";
            this.colso.Name = "colso";
            this.colso.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colghichu
            // 
            this.colghichu.Caption = "Ghi Chú";
            this.colghichu.FieldName = "ghichu";
            this.colghichu.Name = "colghichu";
            this.colghichu.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colghichu.Visible = true;
            this.colghichu.VisibleIndex = 8;
            // 
            // colnguyente
            // 
            this.colnguyente.Caption = "Nguyên Tệ";
            this.colnguyente.FieldName = "nguyente";
            this.colnguyente.Name = "colnguyente";
            this.colnguyente.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colnguyente.Visible = true;
            this.colnguyente.VisibleIndex = 6;
            // 
            // colthanhtien
            // 
            this.colthanhtien.Caption = "Thành Tiền";
            this.colthanhtien.FieldName = "thanhtien";
            this.colthanhtien.Name = "colthanhtien";
            this.colthanhtien.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colthanhtien.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "thanhtien", "{0:n2}")});
            this.colthanhtien.Visible = true;
            this.colthanhtien.VisibleIndex = 7;
            // 
            // colstt
            // 
            this.colstt.FieldName = "stt";
            this.colstt.Name = "colstt";
            this.colstt.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // f_dsdutoan_cpql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 472);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "f_dsdutoan_cpql";
            this.Text = "Dự Toán Chi Phí Quản Lý";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.denngay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.denngay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tungay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tungay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thoigian.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPLayDSDuToancpqlResultBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource sPLayDSDuToancpqlResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colkey;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colngaylap;
        private DevExpress.XtraGrid.Columns.GridColumn coliddv;
        private DevExpress.XtraGrid.Columns.GridColumn colteniddv;
        private DevExpress.XtraGrid.Columns.GridColumn colidnv;
        private DevExpress.XtraGrid.Columns.GridColumn coltenidnv;
        private DevExpress.XtraGrid.Columns.GridColumn colidct;
        private DevExpress.XtraGrid.Columns.GridColumn coltenidct;
        private DevExpress.XtraGrid.Columns.GridColumn colkhuvuc;
        private DevExpress.XtraGrid.Columns.GridColumn coldiadiem;
        private DevExpress.XtraGrid.Columns.GridColumn colloaict;
        private DevExpress.XtraGrid.Columns.GridColumn coltiente;
        private DevExpress.XtraGrid.Columns.GridColumn coltygia;
        private DevExpress.XtraGrid.Columns.GridColumn coldiengiai;
        private DevExpress.XtraGrid.Columns.GridColumn colso;
        private DevExpress.XtraGrid.Columns.GridColumn colghichu;
        private DevExpress.XtraGrid.Columns.GridColumn colnguyente;
        private DevExpress.XtraGrid.Columns.GridColumn colthanhtien;
        private DevExpress.XtraGrid.Columns.GridColumn colstt;
    }
}