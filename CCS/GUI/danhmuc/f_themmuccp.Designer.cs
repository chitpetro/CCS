namespace GUI.danhmuc
{
    partial class f_themmuccp
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
            this.idTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.muccpBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.muccp1TextEdit = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForid = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemFormuccp1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.muccpBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.muccp1TextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemFormuccp1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.idTextEdit);
            this.dataLayoutControl1.Controls.Add(this.muccp1TextEdit);
            this.dataLayoutControl1.DataSource = this.muccpBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 28);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(418, 68);
            this.dataLayoutControl1.TabIndex = 4;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // idTextEdit
            // 
            this.idTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.muccpBindingSource, "id", true));
            this.idTextEdit.Location = new System.Drawing.Point(69, 12);
            this.idTextEdit.Name = "idTextEdit";
            this.idTextEdit.Size = new System.Drawing.Size(97, 20);
            this.idTextEdit.StyleController = this.dataLayoutControl1;
            this.idTextEdit.TabIndex = 4;
            // 
            // muccpBindingSource
            // 
            this.muccpBindingSource.DataSource = typeof(DAL.muccp);
            // 
            // muccp1TextEdit
            // 
            this.muccp1TextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.muccpBindingSource, "muccp1", true));
            this.muccp1TextEdit.Location = new System.Drawing.Point(69, 36);
            this.muccp1TextEdit.Name = "muccp1TextEdit";
            this.muccp1TextEdit.Size = new System.Drawing.Size(337, 20);
            this.muccp1TextEdit.StyleController = this.dataLayoutControl1;
            this.muccp1TextEdit.TabIndex = 5;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(418, 68);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForid,
            this.ItemFormuccp1,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(398, 48);
            // 
            // ItemForid
            // 
            this.ItemForid.Control = this.idTextEdit;
            this.ItemForid.Location = new System.Drawing.Point(0, 0);
            this.ItemForid.Name = "ItemForid";
            this.ItemForid.Size = new System.Drawing.Size(158, 24);
            this.ItemForid.Text = "ID";
            this.ItemForid.TextSize = new System.Drawing.Size(54, 13);
            // 
            // ItemFormuccp1
            // 
            this.ItemFormuccp1.Control = this.muccp1TextEdit;
            this.ItemFormuccp1.Location = new System.Drawing.Point(0, 24);
            this.ItemFormuccp1.Name = "ItemFormuccp1";
            this.ItemFormuccp1.Size = new System.Drawing.Size(398, 24);
            this.ItemFormuccp1.Text = "Mục Chi Phí";
            this.ItemFormuccp1.TextSize = new System.Drawing.Size(54, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(158, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(240, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // f_themmuccp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 122);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "f_themmuccp";
            this.Text = "Thêm danh mục chi phí";
            this.Controls.SetChildIndex(this.dataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.muccpBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.muccp1TextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemFormuccp1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit idTextEdit;
        private System.Windows.Forms.BindingSource muccpBindingSource;
        private DevExpress.XtraEditors.TextEdit muccp1TextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForid;
        private DevExpress.XtraLayout.LayoutControlItem ItemFormuccp1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}