namespace GUI.theodoitt.chiphikhac
{
    partial class f_theodoitt_cpk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_theodoitt_cpk));
            this.theodoittcpkBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colidcpk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colngaychuyen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsotienchuyen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colghichu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colloaichuyen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colidnv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colngaylap = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.theodoittcpkBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // bar2
            // 
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            // 
            // bar3
            // 
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Size = new System.Drawing.Size(681, 26);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 425);
            this.barDockControlBottom.Size = new System.Drawing.Size(681, 24);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 399);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Location = new System.Drawing.Point(681, 26);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 399);
            // 
            // btnthem
            // 
            this.btnthem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnthem.ImageOptions.Image")));
            this.btnthem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnthem.ImageOptions.LargeImage")));
            // 
            // btnsua
            // 
            this.btnsua.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnsua.ImageOptions.Image")));
            this.btnsua.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnsua.ImageOptions.LargeImage")));
            // 
            // btnxoa
            // 
            this.btnxoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnxoa.ImageOptions.Image")));
            this.btnxoa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnxoa.ImageOptions.LargeImage")));
            // 
            // btnprint
            // 
            this.btnprint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.ImageOptions.Image")));
            this.btnprint.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnprint.ImageOptions.LargeImage")));
            // 
            // btnxls
            // 
            this.btnxls.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnxls.ImageOptions.Image")));
            this.btnxls.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnxls.ImageOptions.LargeImage")));
            // 
            // btnreload
            // 
            this.btnreload.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnreload.ImageOptions.Image")));
            this.btnreload.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnreload.ImageOptions.LargeImage")));
            // 
            // layoutControl1
            // 
            this.layoutControl1.Location = new System.Drawing.Point(0, 26);
            this.layoutControl1.Size = new System.Drawing.Size(681, 399);
            this.layoutControl1.Controls.SetChildIndex(this.gd, 0);
            // 
            // Root
            // 
            this.Root.Size = new System.Drawing.Size(681, 399);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Size = new System.Drawing.Size(661, 379);
            // 
            // gd
            // 
            this.gd.DataSource = this.theodoittcpkBindingSource;
            this.gd.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSpinEdit1});
            this.gd.Size = new System.Drawing.Size(657, 375);
            // 
            // gv
            // 
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colidcpk,
            this.colngaychuyen,
            this.colsotienchuyen,
            this.colghichu,
            this.colloaichuyen,
            this.colidnv,
            this.colngaylap});
            this.gv.IndicatorWidth = 44;
            this.gv.OptionsBehavior.Editable = false;
            this.gv.OptionsView.ShowAutoFilterRow = true;
            this.gv.OptionsView.ShowFooter = true;
            this.gv.OptionsView.ShowGroupPanel = false;
            // 
            // theodoittcpkBindingSource
            // 
            this.theodoittcpkBindingSource.DataSource = typeof(DAL.theodoitt_cpk);
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colidcpk
            // 
            this.colidcpk.FieldName = "idcpk";
            this.colidcpk.Name = "colidcpk";
            // 
            // colngaychuyen
            // 
            this.colngaychuyen.Caption = "Ngày Chuyển";
            this.colngaychuyen.FieldName = "ngaychuyen";
            this.colngaychuyen.Name = "colngaychuyen";
            this.colngaychuyen.Visible = true;
            this.colngaychuyen.VisibleIndex = 1;
            this.colngaychuyen.Width = 144;
            // 
            // colsotienchuyen
            // 
            this.colsotienchuyen.Caption = "Số Tiền Đã Chuyển";
            this.colsotienchuyen.ColumnEdit = this.repositoryItemSpinEdit1;
            this.colsotienchuyen.FieldName = "sotienchuyen";
            this.colsotienchuyen.Name = "colsotienchuyen";
            this.colsotienchuyen.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sotienchuyen", "{0:n2}")});
            this.colsotienchuyen.Visible = true;
            this.colsotienchuyen.VisibleIndex = 2;
            this.colsotienchuyen.Width = 194;
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit1.Mask.EditMask = "n2";
            this.repositoryItemSpinEdit1.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // colghichu
            // 
            this.colghichu.Caption = "Ghi Chú";
            this.colghichu.FieldName = "ghichu";
            this.colghichu.Name = "colghichu";
            this.colghichu.Visible = true;
            this.colghichu.VisibleIndex = 3;
            this.colghichu.Width = 264;
            // 
            // colloaichuyen
            // 
            this.colloaichuyen.Caption = "Loại Chuyển";
            this.colloaichuyen.FieldName = "loaichuyen";
            this.colloaichuyen.Name = "colloaichuyen";
            this.colloaichuyen.Visible = true;
            this.colloaichuyen.VisibleIndex = 0;
            this.colloaichuyen.Width = 208;
            // 
            // colidnv
            // 
            this.colidnv.Caption = "Người Lập";
            this.colidnv.FieldName = "idnv";
            this.colidnv.Name = "colidnv";
            this.colidnv.Visible = true;
            this.colidnv.VisibleIndex = 4;
            this.colidnv.Width = 230;
            // 
            // colngaylap
            // 
            this.colngaylap.FieldName = "ngaylap";
            this.colngaylap.Name = "colngaylap";
            // 
            // f_theodoitt_cpk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 449);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "f_theodoitt_cpk";
            this.Text = "Theo Dõi Chuyển Tiền Chi Phí Quản Lý";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.theodoittcpkBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource theodoittcpkBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colidcpk;
        private DevExpress.XtraGrid.Columns.GridColumn colngaychuyen;
        private DevExpress.XtraGrid.Columns.GridColumn colsotienchuyen;
        private DevExpress.XtraGrid.Columns.GridColumn colghichu;
        private DevExpress.XtraGrid.Columns.GridColumn colloaichuyen;
        private DevExpress.XtraGrid.Columns.GridColumn colidnv;
        private DevExpress.XtraGrid.Columns.GridColumn colngaylap;
    }
}