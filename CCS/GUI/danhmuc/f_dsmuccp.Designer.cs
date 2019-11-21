namespace GUI.danhmuc
{
    partial class f_dsmuccp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_dsmuccp));
            this.muccpBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmuccp1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.muccpBindingSource)).BeginInit();
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
            this.barDockControlTop.Size = new System.Drawing.Size(519, 26);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 340);
            this.barDockControlBottom.Size = new System.Drawing.Size(519, 24);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 314);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Location = new System.Drawing.Point(519, 26);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 314);
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
            // btnsaochep
            // 
            this.btnsaochep.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnsaochep.ImageOptions.Image")));
            this.btnsaochep.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnsaochep.ImageOptions.LargeImage")));
            // 
            // layoutControl1
            // 
            this.layoutControl1.Location = new System.Drawing.Point(0, 26);
            this.layoutControl1.Size = new System.Drawing.Size(519, 314);
            this.layoutControl1.Controls.SetChildIndex(this.gd, 0);
            // 
            // Root
            // 
            this.Root.Size = new System.Drawing.Size(519, 314);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Size = new System.Drawing.Size(499, 294);
            // 
            // gd
            // 
            this.gd.DataSource = this.muccpBindingSource;
            this.gd.Size = new System.Drawing.Size(495, 290);
            // 
            // gv
            // 
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colmuccp1});
            this.gv.IndicatorWidth = 44;
            this.gv.OptionsBehavior.Editable = false;
            this.gv.OptionsPrint.RtfReportHeader = resources.GetString("gv.OptionsPrint.RtfReportHeader");
            this.gv.OptionsView.ShowAutoFilterRow = true;
            this.gv.OptionsView.ShowGroupPanel = false;
            // 
            // muccpBindingSource
            // 
            this.muccpBindingSource.DataSource = typeof(DAL.muccp);
            // 
            // colid
            // 
            this.colid.Caption = "ID";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            this.colid.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colid.Visible = true;
            this.colid.VisibleIndex = 0;
            this.colid.Width = 130;
            // 
            // colmuccp1
            // 
            this.colmuccp1.Caption = "Mục Chi Phí";
            this.colmuccp1.FieldName = "muccp1";
            this.colmuccp1.Name = "colmuccp1";
            this.colmuccp1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colmuccp1.Visible = true;
            this.colmuccp1.VisibleIndex = 1;
            this.colmuccp1.Width = 317;
            // 
            // f_dsmuccp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 364);
            this.Name = "f_dsmuccp";
            this.Text = "Danh Mục Chi Phí";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.muccpBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource muccpBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colmuccp1;
    }
}