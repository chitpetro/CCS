namespace GUI
{
    partial class f_themtdchuyentien
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
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.lblidnv = new DevExpress.XtraEditors.LabelControl();
            this.ngaychuyenDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.theodoittBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ghichuTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.idnvTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.sotienchuyenSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.loaichuyenComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForngaychuyen = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForsotienchuyen = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForghichu = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForidnv = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForloaichuyen = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ngaychuyenDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngaychuyenDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.theodoittBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ghichuTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idnvTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sotienchuyenSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaichuyenComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForngaychuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsotienchuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForghichu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForidnv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForloaichuyen)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.lblidnv);
            this.dataLayoutControl1.Controls.Add(this.ngaychuyenDateEdit);
            this.dataLayoutControl1.Controls.Add(this.ghichuTextEdit);
            this.dataLayoutControl1.Controls.Add(this.idnvTextEdit);
            this.dataLayoutControl1.Controls.Add(this.sotienchuyenSpinEdit);
            this.dataLayoutControl1.Controls.Add(this.loaichuyenComboBoxEdit);
            this.dataLayoutControl1.DataSource = this.theodoittBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 28);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(537, 87);
            this.dataLayoutControl1.TabIndex = 4;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // lblidnv
            // 
            this.lblidnv.Location = new System.Drawing.Point(211, 12);
            this.lblidnv.Name = "lblidnv";
            this.lblidnv.Size = new System.Drawing.Size(297, 20);
            this.lblidnv.StyleController = this.dataLayoutControl1;
            this.lblidnv.TabIndex = 9;
            // 
            // ngaychuyenDateEdit
            // 
            this.ngaychuyenDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.theodoittBindingSource, "ngaychuyen", true));
            this.ngaychuyenDateEdit.EditValue = null;
            this.ngaychuyenDateEdit.Location = new System.Drawing.Point(85, 36);
            this.ngaychuyenDateEdit.Name = "ngaychuyenDateEdit";
            this.ngaychuyenDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.ngaychuyenDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ngaychuyenDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ngaychuyenDateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.ngaychuyenDateEdit.Size = new System.Drawing.Size(122, 20);
            this.ngaychuyenDateEdit.StyleController = this.dataLayoutControl1;
            this.ngaychuyenDateEdit.TabIndex = 4;
            // 
            // theodoittBindingSource
            // 
            this.theodoittBindingSource.DataSource = typeof(DAL.theodoitt);
            // 
            // ghichuTextEdit
            // 
            this.ghichuTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.theodoittBindingSource, "ghichu", true));
            this.ghichuTextEdit.Location = new System.Drawing.Point(284, 60);
            this.ghichuTextEdit.Name = "ghichuTextEdit";
            this.ghichuTextEdit.Size = new System.Drawing.Size(224, 20);
            this.ghichuTextEdit.StyleController = this.dataLayoutControl1;
            this.ghichuTextEdit.TabIndex = 6;
            // 
            // idnvTextEdit
            // 
            this.idnvTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.theodoittBindingSource, "idnv", true));
            this.idnvTextEdit.Location = new System.Drawing.Point(85, 12);
            this.idnvTextEdit.Name = "idnvTextEdit";
            this.idnvTextEdit.Properties.ReadOnly = true;
            this.idnvTextEdit.Size = new System.Drawing.Size(122, 20);
            this.idnvTextEdit.StyleController = this.dataLayoutControl1;
            this.idnvTextEdit.TabIndex = 8;
            // 
            // sotienchuyenSpinEdit
            // 
            this.sotienchuyenSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.theodoittBindingSource, "sotienchuyen", true));
            this.sotienchuyenSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sotienchuyenSpinEdit.Location = new System.Drawing.Point(284, 36);
            this.sotienchuyenSpinEdit.Name = "sotienchuyenSpinEdit";
            this.sotienchuyenSpinEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.sotienchuyenSpinEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.sotienchuyenSpinEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.sotienchuyenSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sotienchuyenSpinEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.sotienchuyenSpinEdit.Properties.Mask.EditMask = "n2";
            this.sotienchuyenSpinEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.sotienchuyenSpinEdit.Size = new System.Drawing.Size(224, 20);
            this.sotienchuyenSpinEdit.StyleController = this.dataLayoutControl1;
            this.sotienchuyenSpinEdit.TabIndex = 10;
            // 
            // loaichuyenComboBoxEdit
            // 
            this.loaichuyenComboBoxEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.theodoittBindingSource, "loaichuyen", true));
            this.loaichuyenComboBoxEdit.Location = new System.Drawing.Point(85, 60);
            this.loaichuyenComboBoxEdit.Name = "loaichuyenComboBoxEdit";
            this.loaichuyenComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.loaichuyenComboBoxEdit.Properties.Items.AddRange(new object[] {
            "Tiền Mặt",
            "Chuyển Khoản",
            "Cấn Trừ"});
            this.loaichuyenComboBoxEdit.Size = new System.Drawing.Size(122, 20);
            this.loaichuyenComboBoxEdit.StyleController = this.dataLayoutControl1;
            this.loaichuyenComboBoxEdit.TabIndex = 11;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(520, 92);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForngaychuyen,
            this.ItemForsotienchuyen,
            this.ItemForghichu,
            this.ItemForidnv,
            this.layoutControlItem1,
            this.ItemForloaichuyen});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(500, 72);
            // 
            // ItemForngaychuyen
            // 
            this.ItemForngaychuyen.Control = this.ngaychuyenDateEdit;
            this.ItemForngaychuyen.Location = new System.Drawing.Point(0, 24);
            this.ItemForngaychuyen.Name = "ItemForngaychuyen";
            this.ItemForngaychuyen.Size = new System.Drawing.Size(199, 24);
            this.ItemForngaychuyen.Text = "Ngày Chuyển";
            this.ItemForngaychuyen.TextSize = new System.Drawing.Size(70, 13);
            // 
            // ItemForsotienchuyen
            // 
            this.ItemForsotienchuyen.Control = this.sotienchuyenSpinEdit;
            this.ItemForsotienchuyen.Location = new System.Drawing.Point(199, 24);
            this.ItemForsotienchuyen.Name = "ItemForsotienchuyen";
            this.ItemForsotienchuyen.Size = new System.Drawing.Size(301, 24);
            this.ItemForsotienchuyen.Text = "Giá Trị Chuyển";
            this.ItemForsotienchuyen.TextSize = new System.Drawing.Size(70, 13);
            // 
            // ItemForghichu
            // 
            this.ItemForghichu.Control = this.ghichuTextEdit;
            this.ItemForghichu.Location = new System.Drawing.Point(199, 48);
            this.ItemForghichu.Name = "ItemForghichu";
            this.ItemForghichu.Size = new System.Drawing.Size(301, 24);
            this.ItemForghichu.Text = "ghichu";
            this.ItemForghichu.TextSize = new System.Drawing.Size(70, 13);
            // 
            // ItemForidnv
            // 
            this.ItemForidnv.Control = this.idnvTextEdit;
            this.ItemForidnv.Location = new System.Drawing.Point(0, 0);
            this.ItemForidnv.Name = "ItemForidnv";
            this.ItemForidnv.Size = new System.Drawing.Size(199, 24);
            this.ItemForidnv.Text = "Người Xử Lý";
            this.ItemForidnv.TextSize = new System.Drawing.Size(70, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lblidnv;
            this.layoutControlItem1.Location = new System.Drawing.Point(199, 0);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(67, 17);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(301, 24);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // ItemForloaichuyen
            // 
            this.ItemForloaichuyen.Control = this.loaichuyenComboBoxEdit;
            this.ItemForloaichuyen.Location = new System.Drawing.Point(0, 48);
            this.ItemForloaichuyen.Name = "ItemForloaichuyen";
            this.ItemForloaichuyen.Size = new System.Drawing.Size(199, 24);
            this.ItemForloaichuyen.Text = "Loại Chuyển";
            this.ItemForloaichuyen.TextSize = new System.Drawing.Size(70, 13);
            // 
            // f_themtdchuyentien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 143);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "f_themtdchuyentien";
            this.Text = "Theo Dõi Chuyển Tiền";
            this.Controls.SetChildIndex(this.dataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ngaychuyenDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngaychuyenDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.theodoittBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ghichuTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idnvTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sotienchuyenSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaichuyenComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForngaychuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsotienchuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForghichu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForidnv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForloaichuyen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.LabelControl lblidnv;
        private DevExpress.XtraEditors.DateEdit ngaychuyenDateEdit;
        private System.Windows.Forms.BindingSource theodoittBindingSource;
        private DevExpress.XtraEditors.TextEdit ghichuTextEdit;
        private DevExpress.XtraEditors.TextEdit idnvTextEdit;
        private DevExpress.XtraEditors.SpinEdit sotienchuyenSpinEdit;
        private DevExpress.XtraEditors.ComboBoxEdit loaichuyenComboBoxEdit;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForngaychuyen;
        private DevExpress.XtraLayout.LayoutControlItem ItemForsotienchuyen;
        private DevExpress.XtraLayout.LayoutControlItem ItemForghichu;
        private DevExpress.XtraLayout.LayoutControlItem ItemForidnv;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForloaichuyen;
    }
}