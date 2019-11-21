namespace GUI.theodoitt.Chiphivattu
{
    partial class f_themtheodoitt_cpvt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_themtheodoitt_cpvt));
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.lbltenidnv = new DevExpress.XtraEditors.LabelControl();
            this.ngaychuyenDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.theodoittcpvtBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sotienchuyenSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.ghichuTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.loaichuyenComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.idnvTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForngaychuyen = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForghichu = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForidnv = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForloaichuyen = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForsotienchuyen = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ngaychuyenDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngaychuyenDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.theodoittcpvtBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sotienchuyenSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ghichuTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaichuyenComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idnvTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForngaychuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForghichu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForidnv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForloaichuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsotienchuyen)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.lbltenidnv);
            this.dataLayoutControl1.Controls.Add(this.ngaychuyenDateEdit);
            this.dataLayoutControl1.Controls.Add(this.sotienchuyenSpinEdit);
            this.dataLayoutControl1.Controls.Add(this.ghichuTextEdit);
            this.dataLayoutControl1.Controls.Add(this.loaichuyenComboBoxEdit);
            this.dataLayoutControl1.Controls.Add(this.idnvTextEdit);
            this.dataLayoutControl1.DataSource = this.theodoittcpvtBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 28);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(446, 114);
            this.dataLayoutControl1.TabIndex = 4;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // lbltenidnv
            // 
            this.lbltenidnv.Location = new System.Drawing.Point(201, 12);
            this.lbltenidnv.Name = "lbltenidnv";
            this.lbltenidnv.Size = new System.Drawing.Size(216, 20);
            this.lbltenidnv.StyleController = this.dataLayoutControl1;
            this.lbltenidnv.TabIndex = 9;
            // 
            // ngaychuyenDateEdit
            // 
            this.ngaychuyenDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.theodoittcpvtBindingSource, "ngaychuyen", true));
            this.ngaychuyenDateEdit.EditValue = null;
            this.ngaychuyenDateEdit.Location = new System.Drawing.Point(103, 36);
            this.ngaychuyenDateEdit.Name = "ngaychuyenDateEdit";
            this.ngaychuyenDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.ngaychuyenDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ngaychuyenDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ngaychuyenDateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.ngaychuyenDateEdit.Size = new System.Drawing.Size(94, 20);
            this.ngaychuyenDateEdit.StyleController = this.dataLayoutControl1;
            this.ngaychuyenDateEdit.TabIndex = 4;
            // 
            // theodoittcpvtBindingSource
            // 
            this.theodoittcpvtBindingSource.DataSource = typeof(DAL.theodoitt_cpvt);
            // 
            // sotienchuyenSpinEdit
            // 
            this.sotienchuyenSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.theodoittcpvtBindingSource, "sotienchuyen", true));
            this.sotienchuyenSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sotienchuyenSpinEdit.Location = new System.Drawing.Point(103, 60);
            this.sotienchuyenSpinEdit.Name = "sotienchuyenSpinEdit";
            this.sotienchuyenSpinEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.sotienchuyenSpinEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.sotienchuyenSpinEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.sotienchuyenSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sotienchuyenSpinEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.sotienchuyenSpinEdit.Properties.Mask.EditMask = "n2";
            this.sotienchuyenSpinEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.sotienchuyenSpinEdit.Size = new System.Drawing.Size(314, 20);
            this.sotienchuyenSpinEdit.StyleController = this.dataLayoutControl1;
            this.sotienchuyenSpinEdit.TabIndex = 5;
            // 
            // ghichuTextEdit
            // 
            this.ghichuTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.theodoittcpvtBindingSource, "ghichu", true));
            this.ghichuTextEdit.Location = new System.Drawing.Point(103, 84);
            this.ghichuTextEdit.Name = "ghichuTextEdit";
            this.ghichuTextEdit.Size = new System.Drawing.Size(314, 20);
            this.ghichuTextEdit.StyleController = this.dataLayoutControl1;
            this.ghichuTextEdit.TabIndex = 6;
            // 
            // loaichuyenComboBoxEdit
            // 
            this.loaichuyenComboBoxEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.theodoittcpvtBindingSource, "loaichuyen", true));
            this.loaichuyenComboBoxEdit.EditValue = "Chuyển Khoản";
            this.loaichuyenComboBoxEdit.Location = new System.Drawing.Point(292, 36);
            this.loaichuyenComboBoxEdit.Name = "loaichuyenComboBoxEdit";
            this.loaichuyenComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.loaichuyenComboBoxEdit.Properties.Items.AddRange(new object[] {
            "Chuyển Khoản",
            "Tiền Mặt",
            "Cấn Trừ"});
            this.loaichuyenComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.loaichuyenComboBoxEdit.Size = new System.Drawing.Size(125, 20);
            this.loaichuyenComboBoxEdit.StyleController = this.dataLayoutControl1;
            this.loaichuyenComboBoxEdit.TabIndex = 7;
            // 
            // idnvTextEdit
            // 
            this.idnvTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.theodoittcpvtBindingSource, "idnv", true));
            this.idnvTextEdit.Location = new System.Drawing.Point(103, 12);
            this.idnvTextEdit.Name = "idnvTextEdit";
            this.idnvTextEdit.Properties.ReadOnly = true;
            this.idnvTextEdit.Size = new System.Drawing.Size(94, 20);
            this.idnvTextEdit.StyleController = this.dataLayoutControl1;
            this.idnvTextEdit.TabIndex = 8;
            this.idnvTextEdit.EditValueChanged += new System.EventHandler(this.idnvTextEdit_EditValueChanged);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(429, 116);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForngaychuyen,
            this.ItemForghichu,
            this.ItemForidnv,
            this.layoutControlItem1,
            this.ItemForloaichuyen,
            this.ItemForsotienchuyen});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(409, 96);
            // 
            // ItemForngaychuyen
            // 
            this.ItemForngaychuyen.Control = this.ngaychuyenDateEdit;
            this.ItemForngaychuyen.Location = new System.Drawing.Point(0, 24);
            this.ItemForngaychuyen.Name = "ItemForngaychuyen";
            this.ItemForngaychuyen.Size = new System.Drawing.Size(189, 24);
            this.ItemForngaychuyen.Text = "Ngày Chuyển Tiền";
            this.ItemForngaychuyen.TextSize = new System.Drawing.Size(88, 13);
            // 
            // ItemForghichu
            // 
            this.ItemForghichu.Control = this.ghichuTextEdit;
            this.ItemForghichu.Location = new System.Drawing.Point(0, 72);
            this.ItemForghichu.Name = "ItemForghichu";
            this.ItemForghichu.Size = new System.Drawing.Size(409, 24);
            this.ItemForghichu.Text = "Ghi Chú";
            this.ItemForghichu.TextSize = new System.Drawing.Size(88, 13);
            // 
            // ItemForidnv
            // 
            this.ItemForidnv.Control = this.idnvTextEdit;
            this.ItemForidnv.Location = new System.Drawing.Point(0, 0);
            this.ItemForidnv.Name = "ItemForidnv";
            this.ItemForidnv.Size = new System.Drawing.Size(189, 24);
            this.ItemForidnv.Text = "Người Lập";
            this.ItemForidnv.TextSize = new System.Drawing.Size(88, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lbltenidnv;
            this.layoutControlItem1.Location = new System.Drawing.Point(189, 0);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(67, 17);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(220, 24);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // ItemForloaichuyen
            // 
            this.ItemForloaichuyen.Control = this.loaichuyenComboBoxEdit;
            this.ItemForloaichuyen.Location = new System.Drawing.Point(189, 24);
            this.ItemForloaichuyen.Name = "ItemForloaichuyen";
            this.ItemForloaichuyen.Size = new System.Drawing.Size(220, 24);
            this.ItemForloaichuyen.Text = "Loại Chuyển";
            this.ItemForloaichuyen.TextSize = new System.Drawing.Size(88, 13);
            // 
            // ItemForsotienchuyen
            // 
            this.ItemForsotienchuyen.Control = this.sotienchuyenSpinEdit;
            this.ItemForsotienchuyen.Location = new System.Drawing.Point(0, 48);
            this.ItemForsotienchuyen.Name = "ItemForsotienchuyen";
            this.ItemForsotienchuyen.Size = new System.Drawing.Size(409, 24);
            this.ItemForsotienchuyen.Text = "Số Tiền Chuyển";
            this.ItemForsotienchuyen.TextSize = new System.Drawing.Size(88, 13);
            // 
            // f_themtheodoitt_cpvt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 168);
            this.Controls.Add(this.dataLayoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "f_themtheodoitt_cpvt";
            this.Text = "Theo Dõi Chuyển Tiền Chi Phí Vật Tư";
            this.Controls.SetChildIndex(this.dataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ngaychuyenDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngaychuyenDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.theodoittcpvtBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sotienchuyenSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ghichuTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaichuyenComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idnvTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForngaychuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForghichu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForidnv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForloaichuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsotienchuyen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.LabelControl lbltenidnv;
        private DevExpress.XtraEditors.DateEdit ngaychuyenDateEdit;
        private System.Windows.Forms.BindingSource theodoittcpvtBindingSource;
        private DevExpress.XtraEditors.SpinEdit sotienchuyenSpinEdit;
        private DevExpress.XtraEditors.TextEdit ghichuTextEdit;
        private DevExpress.XtraEditors.ComboBoxEdit loaichuyenComboBoxEdit;
        private DevExpress.XtraEditors.TextEdit idnvTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForngaychuyen;
        private DevExpress.XtraLayout.LayoutControlItem ItemForghichu;
        private DevExpress.XtraLayout.LayoutControlItem ItemForidnv;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForloaichuyen;
        private DevExpress.XtraLayout.LayoutControlItem ItemForsotienchuyen;
    }
}