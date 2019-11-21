namespace GUI.HoSoXeMay
{
    partial class f_dslephididuong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_dslephididuong));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.gd = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lephididuongBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colkey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colngaydk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colthoihan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldiengiai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colidpt = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lephididuongBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tungay
            // 
            this.tungay.EditValue = new System.DateTime(2019, 6, 1, 0, 0, 0, 0);
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.CalendarTimeProperties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.repositoryItemDateEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.repositoryItemDateEdit1.Mask.UseMaskAsDisplayFormat = true;
            // 
            // denngay
            // 
            this.denngay.EditValue = new System.DateTime(2019, 6, 30, 0, 0, 0, 0);
            // 
            // repositoryItemDateEdit2
            // 
            this.repositoryItemDateEdit2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.repositoryItemDateEdit2.Mask.UseMaskAsDisplayFormat = true;
            // 
            // btnsearch
            // 
            this.btnsearch.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnsearch.ImageOptions.Image")));
            // 
            // btnsearchall
            // 
            this.btnsearchall.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnsearchall.ImageOptions.Image")));
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
            this.barDockControlTop.Size = new System.Drawing.Size(788, 53);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 459);
            this.barDockControlBottom.Size = new System.Drawing.Size(788, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 53);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 406);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Location = new System.Drawing.Point(788, 53);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 406);
            // 
            // thoigian
            // 
            this.thoigian.EditValue = "Tùy ý";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gd);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 53);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(788, 406);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(788, 406);
            this.Root.TextVisible = false;
            // 
            // gd
            // 
            this.gd.DataSource = this.lephididuongBindingSource;
            this.gd.Location = new System.Drawing.Point(12, 12);
            this.gd.MainView = this.gv;
            this.gd.MenuManager = this.barManager1;
            this.gd.Name = "gd";
            this.gd.Size = new System.Drawing.Size(764, 382);
            this.gd.TabIndex = 4;
            this.gd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // gv
            // 
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colkey,
            this.colid,
            this.colngaydk,
            this.colthoihan,
            this.coldiengiai,
            this.colso,
            this.colidpt});
            this.gv.GridControl = this.gd;
            this.gv.Name = "gv";
            this.gv.OptionsBehavior.Editable = false;
            this.gv.OptionsView.ShowAutoFilterRow = true;
            this.gv.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gv_RowClick);
            this.gv.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gv_CustomDrawRowIndicator);
            this.gv.Click += new System.EventHandler(this.gv_Click);
            this.gv.DoubleClick += new System.EventHandler(this.gv_DoubleClick);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gd;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(768, 386);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // lephididuongBindingSource
            // 
            this.lephididuongBindingSource.DataSource = typeof(DAL.lephididuong);
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
            this.colid.Width = 186;
            // 
            // colngaydk
            // 
            this.colngaydk.Caption = "Ngày Đăng Ký";
            this.colngaydk.FieldName = "ngaydk";
            this.colngaydk.Name = "colngaydk";
            this.colngaydk.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colngaydk.Visible = true;
            this.colngaydk.VisibleIndex = 1;
            this.colngaydk.Width = 138;
            // 
            // colthoihan
            // 
            this.colthoihan.Caption = "Thời Hạn (Tháng)";
            this.colthoihan.FieldName = "thoihan";
            this.colthoihan.Name = "colthoihan";
            this.colthoihan.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colthoihan.Visible = true;
            this.colthoihan.VisibleIndex = 2;
            this.colthoihan.Width = 132;
            // 
            // coldiengiai
            // 
            this.coldiengiai.Caption = "Diễn Giải";
            this.coldiengiai.FieldName = "diengiai";
            this.coldiengiai.Name = "coldiengiai";
            this.coldiengiai.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.coldiengiai.Visible = true;
            this.coldiengiai.VisibleIndex = 3;
            this.coldiengiai.Width = 290;
            // 
            // colso
            // 
            this.colso.FieldName = "so";
            this.colso.Name = "colso";
            this.colso.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colidpt
            // 
            this.colidpt.FieldName = "idpt";
            this.colidpt.Name = "colidpt";
            this.colidpt.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // f_dslephididuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 482);
            this.Controls.Add(this.layoutControl1);
            this.Name = "f_dslephididuong";
            this.Text = "Danh Sách Lệ Phí Đi Đường";
            this.Controls.SetChildIndex(this.barDockControlTop, 0);
            this.Controls.SetChildIndex(this.barDockControlBottom, 0);
            this.Controls.SetChildIndex(this.barDockControlRight, 0);
            this.Controls.SetChildIndex(this.barDockControlLeft, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lephididuongBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl gd;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.BindingSource lephididuongBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colkey;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colngaydk;
        private DevExpress.XtraGrid.Columns.GridColumn colthoihan;
        private DevExpress.XtraGrid.Columns.GridColumn coldiengiai;
        private DevExpress.XtraGrid.Columns.GridColumn colso;
        private DevExpress.XtraGrid.Columns.GridColumn colidpt;
    }
}