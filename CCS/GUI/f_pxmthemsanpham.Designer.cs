namespace GUI
{
    partial class f_pxmthemsanpham
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lblloai = new DevExpress.XtraEditors.LabelControl();
            this.txtloai = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.pxmloaispBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtdvt = new DevExpress.XtraEditors.TextEdit();
            this.txttensp = new System.Windows.Forms.TextBox();
            this.txtid = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblcontrol = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtloai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pxmloaispBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdvt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblcontrol)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lblloai);
            this.layoutControl1.Controls.Add(this.txtloai);
            this.layoutControl1.Controls.Add(this.txtdvt);
            this.layoutControl1.Controls.Add(this.txttensp);
            this.layoutControl1.Controls.Add(this.txtid);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 24);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(597, 98);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lblloai
            // 
            this.lblloai.Location = new System.Drawing.Point(337, 36);
            this.lblloai.Name = "lblloai";
            this.lblloai.Size = new System.Drawing.Size(248, 20);
            this.lblloai.StyleController = this.layoutControl1;
            this.lblloai.TabIndex = 8;
            // 
            // txtloai
            // 
            this.txtloai.EditValue = "";
            this.txtloai.Location = new System.Drawing.Point(208, 36);
            this.txtloai.Name = "txtloai";
            this.txtloai.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtloai.Properties.DataSource = this.pxmloaispBindingSource;
            this.txtloai.Properties.DisplayMember = "id";
            this.txtloai.Properties.NullText = "";
            this.txtloai.Properties.PopupView = this.searchLookUpEdit1View;
            this.txtloai.Properties.ValueMember = "id";
            this.txtloai.Size = new System.Drawing.Size(125, 20);
            this.txtloai.StyleController = this.layoutControl1;
            this.txtloai.TabIndex = 7;
            this.txtloai.Popup += new System.EventHandler(this.txtloai_Popup);
            this.txtloai.EditValueChanged += new System.EventHandler(this.txtloai_EditValueChanged);
            // 
            // pxmloaispBindingSource
            // 
            this.pxmloaispBindingSource.DataSource = typeof(DAL.pxm_loaisp);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã";
            this.gridColumn1.FieldName = "id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Loại";
            this.gridColumn2.FieldName = "tenloai";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // txtdvt
            // 
            this.txtdvt.Location = new System.Drawing.Point(68, 36);
            this.txtdvt.Name = "txtdvt";
            this.txtdvt.Size = new System.Drawing.Size(80, 20);
            this.txtdvt.StyleController = this.layoutControl1;
            this.txtdvt.TabIndex = 6;
            // 
            // txttensp
            // 
            this.txttensp.Location = new System.Drawing.Point(269, 12);
            this.txttensp.Name = "txttensp";
            this.txttensp.Size = new System.Drawing.Size(316, 20);
            this.txttensp.TabIndex = 5;
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(68, 12);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(141, 20);
            this.txtid.StyleController = this.layoutControl1;
            this.txtid.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.lblcontrol});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(597, 98);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtid;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(201, 24);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(201, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(201, 24);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "Mã Vật Tư";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(53, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(577, 30);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtdvt;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(140, 24);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(140, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(140, 24);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "ĐVT";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(53, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txttensp;
            this.layoutControlItem2.Location = new System.Drawing.Point(201, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(376, 24);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(376, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(376, 24);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "Tên Vật Tư";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(53, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtloai;
            this.layoutControlItem4.Location = new System.Drawing.Point(140, 24);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(185, 24);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(185, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(185, 24);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "Loại";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(53, 13);
            // 
            // lblcontrol
            // 
            this.lblcontrol.Control = this.lblloai;
            this.lblcontrol.Location = new System.Drawing.Point(325, 24);
            this.lblcontrol.MinSize = new System.Drawing.Size(67, 17);
            this.lblcontrol.Name = "lblcontrol";
            this.lblcontrol.Size = new System.Drawing.Size(252, 24);
            this.lblcontrol.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lblcontrol.TextSize = new System.Drawing.Size(0, 0);
            this.lblcontrol.TextVisible = false;
            // 
            // f_pxmthemsanpham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 145);
            this.Controls.Add(this.layoutControl1);
            this.KeyPreview = true;
            this.Name = "f_pxmthemsanpham";
            this.Text = "Thêm Vật Tư";
            this.Load += new System.EventHandler(this.f_pxmthemsanpham_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.f_pxmthemsanpham_KeyDown);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtloai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pxmloaispBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdvt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblcontrol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.LabelControl lblloai;
        private DevExpress.XtraEditors.SearchLookUpEdit txtloai;
        private System.Windows.Forms.BindingSource pxmloaispBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.TextEdit txtdvt;
        private System.Windows.Forms.TextBox txttensp;
        private DevExpress.XtraEditors.TextEdit txtid;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem lblcontrol;
    }
}