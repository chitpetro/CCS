namespace GUI
{
    partial class f_import
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_import));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btntaomau = new DevExpress.XtraEditors.SimpleButton();
            this.btnxuatmau = new DevExpress.XtraEditors.SimpleButton();
            this.btnSQL = new DevExpress.XtraEditors.SimpleButton();
            this.btnexcel = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btntaomau);
            this.layoutControl1.Controls.Add(this.btnxuatmau);
            this.layoutControl1.Controls.Add(this.btnSQL);
            this.layoutControl1.Controls.Add(this.dataGridView1);
            this.layoutControl1.Controls.Add(this.btnexcel);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(657, 466);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(633, 416);
            this.dataGridView1.TabIndex = 5;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem3});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(657, 466);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dataGridView1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(637, 420);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // btntaomau
            // 
            this.btntaomau.ImageOptions.Image = global::GUI.Properties.Resources.createmodeldifferences_16x16;
            this.btntaomau.Location = new System.Drawing.Point(12, 12);
            this.btntaomau.Name = "btntaomau";
            this.btntaomau.Size = new System.Drawing.Size(148, 22);
            this.btntaomau.StyleController = this.layoutControl1;
            this.btntaomau.TabIndex = 8;
            this.btntaomau.Text = "Tạo Mẫu";
            this.btntaomau.Click += new System.EventHandler(this.btntaomau_Click);
            // 
            // btnxuatmau
            // 
            this.btnxuatmau.ImageOptions.Image = global::GUI.Properties.Resources.example_16x16;
            this.btnxuatmau.Location = new System.Drawing.Point(164, 12);
            this.btnxuatmau.Name = "btnxuatmau";
            this.btnxuatmau.Size = new System.Drawing.Size(170, 22);
            this.btnxuatmau.StyleController = this.layoutControl1;
            this.btnxuatmau.TabIndex = 7;
            this.btnxuatmau.Text = "Xuất Mẫu";
            this.btnxuatmau.Click += new System.EventHandler(this.btnxuatmau_Click);
            // 
            // btnSQL
            // 
            this.btnSQL.ImageOptions.Image = global::GUI.Properties.Resources.database_16x16;
            this.btnSQL.Location = new System.Drawing.Point(493, 12);
            this.btnSQL.Name = "btnSQL";
            this.btnSQL.Size = new System.Drawing.Size(152, 22);
            this.btnSQL.StyleController = this.layoutControl1;
            this.btnSQL.TabIndex = 6;
            this.btnSQL.Text = "Thêm vào SQL";
            this.btnSQL.Click += new System.EventHandler(this.btnSQL_Click);
            // 
            // btnexcel
            // 
            this.btnexcel.ImageOptions.Image = global::GUI.Properties.Resources.exporttoxls_16x16;
            this.btnexcel.Location = new System.Drawing.Point(338, 12);
            this.btnexcel.Name = "btnexcel";
            this.btnexcel.Size = new System.Drawing.Size(151, 22);
            this.btnexcel.StyleController = this.layoutControl1;
            this.btnexcel.TabIndex = 4;
            this.btnexcel.Text = "Lấy dữ liệu từ Excel";
            this.btnexcel.Click += new System.EventHandler(this.btnexcel_Click);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnexcel;
            this.layoutControlItem1.Location = new System.Drawing.Point(326, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(155, 26);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnxuatmau;
            this.layoutControlItem4.Location = new System.Drawing.Point(152, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(174, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btntaomau;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(152, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnSQL;
            this.layoutControlItem3.Location = new System.Drawing.Point(481, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(156, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // f_import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 466);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "f_import";
            this.Text = "Import dữ liệu";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton btnexcel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btnSQL;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton btnxuatmau;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton btntaomau;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}