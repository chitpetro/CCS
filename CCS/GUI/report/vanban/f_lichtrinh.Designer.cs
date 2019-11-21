namespace GUI.Report.PhuongTien
{
    partial class f_lichtrinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_lichtrinh));
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.btnin = new DevExpress.XtraEditors.SimpleButton();
            this.thoigian = new DevExpress.XtraEditors.ComboBoxEdit();
            this.tungay = new DevExpress.XtraEditors.DateEdit();
            this.denngay = new DevExpress.XtraEditors.DateEdit();
            this.loaivb = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thoigian.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tungay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tungay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.denngay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.denngay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaivb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.btnin);
            this.dataLayoutControl1.Controls.Add(this.thoigian);
            this.dataLayoutControl1.Controls.Add(this.tungay);
            this.dataLayoutControl1.Controls.Add(this.denngay);
            this.dataLayoutControl1.Controls.Add(this.loaivb);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(954, 46);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // btnin
            // 
            this.btnin.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnin.ImageOptions.Image")));
            this.btnin.Location = new System.Drawing.Point(877, 12);
            this.btnin.Name = "btnin";
            this.btnin.Size = new System.Drawing.Size(65, 22);
            this.btnin.StyleController = this.dataLayoutControl1;
            this.btnin.TabIndex = 8;
            this.btnin.Text = "IN";
            this.btnin.Click += new System.EventHandler(this.btnin_Click);
            // 
            // thoigian
            // 
            this.thoigian.Location = new System.Drawing.Point(130, 12);
            this.thoigian.Name = "thoigian";
            this.thoigian.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.thoigian.Properties.DropDownRows = 20;
            this.thoigian.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.thoigian.Size = new System.Drawing.Size(107, 20);
            this.thoigian.StyleController = this.dataLayoutControl1;
            this.thoigian.TabIndex = 5;
            this.thoigian.SelectedIndexChanged += new System.EventHandler(this.thoigian_SelectedIndexChanged);
            // 
            // tungay
            // 
            this.tungay.EditValue = null;
            this.tungay.Location = new System.Drawing.Point(291, 12);
            this.tungay.Name = "tungay";
            this.tungay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tungay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tungay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tungay.Size = new System.Drawing.Size(119, 20);
            this.tungay.StyleController = this.dataLayoutControl1;
            this.tungay.TabIndex = 4;
            // 
            // denngay
            // 
            this.denngay.EditValue = null;
            this.denngay.Location = new System.Drawing.Point(471, 12);
            this.denngay.Name = "denngay";
            this.denngay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.denngay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.denngay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.denngay.Size = new System.Drawing.Size(112, 20);
            this.denngay.StyleController = this.dataLayoutControl1;
            this.denngay.TabIndex = 6;
            // 
            // loaivb
            // 
            this.loaivb.Location = new System.Drawing.Point(630, 12);
            this.loaivb.Name = "loaivb";
            this.loaivb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.loaivb.Properties.DropDownRows = 15;
            this.loaivb.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.loaivb.Size = new System.Drawing.Size(243, 20);
            this.loaivb.StyleController = this.dataLayoutControl1;
            this.loaivb.TabIndex = 7;
            this.loaivb.TextChanged += new System.EventHandler(this.loaivb_TextChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(954, 46);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.thoigian;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(229, 26);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(229, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(229, 26);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "Chọn Khoảng Thời Gian:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(115, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.tungay;
            this.layoutControlItem2.Location = new System.Drawing.Point(229, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(173, 26);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(173, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(173, 26);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "Từ Ngày:";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(45, 13);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.denngay;
            this.layoutControlItem3.Location = new System.Drawing.Point(402, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(173, 26);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(173, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(173, 26);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "Đến Ngày:";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(52, 13);
            this.layoutControlItem3.TextToControlDistance = 5;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.loaivb;
            this.layoutControlItem4.Location = new System.Drawing.Point(575, 0);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(290, 26);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(290, 26);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(290, 26);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "Loại VB:";
            this.layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(38, 13);
            this.layoutControlItem4.TextToControlDistance = 5;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnin;
            this.layoutControlItem5.Location = new System.Drawing.Point(865, 0);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(69, 26);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(69, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(69, 26);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // f_lichtrinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 46);
            this.Controls.Add(this.dataLayoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "f_lichtrinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo CáoTheo Dõi Lịch Trình Giao Nhận Hồ Sơ";
            this.Load += new System.EventHandler(this.f_chitietnhapkho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.thoigian.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tungay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tungay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.denngay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.denngay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaivb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.SimpleButton btnin;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.ComboBoxEdit thoigian;
        private DevExpress.XtraEditors.DateEdit tungay;
        private DevExpress.XtraEditors.DateEdit denngay;
        private DevExpress.XtraEditors.ComboBoxEdit loaivb;
    }
}