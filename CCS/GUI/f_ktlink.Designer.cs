namespace GUI
{
    partial class f_ktlink
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_ktlink));
            this.txtlink = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.vanbandenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblid = new DevExpress.XtraEditors.LabelControl();
            this.lblsovb = new DevExpress.XtraEditors.LabelControl();
            this.lblngaynhan = new DevExpress.XtraEditors.LabelControl();
            this.lblnoidung = new DevExpress.XtraEditors.LabelControl();
            this.lbltrichyeu = new DevExpress.XtraEditors.LabelControl();
            this.btnin = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtlink.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vanbandenBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // txtlink
            // 
            this.txtlink.EditValue = "";
            this.txtlink.Location = new System.Drawing.Point(12, 12);
            this.txtlink.Name = "txtlink";
            this.txtlink.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtlink.Properties.DataSource = this.vanbandenBindingSource;
            this.txtlink.Properties.DisplayMember = "id";
            this.txtlink.Properties.ValueMember = "id";
            this.txtlink.Properties.View = this.searchLookUpEdit1View;
            this.txtlink.Size = new System.Drawing.Size(626, 20);
            this.txtlink.TabIndex = 0;
            this.txtlink.EditValueChanged += new System.EventHandler(this.txtlink_EditValueChanged);
            // 
            // vanbandenBindingSource
            // 
            this.vanbandenBindingSource.DataSource = typeof(DAL.vanbanden);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Mã Văn Bản";
            this.gridColumn2.FieldName = "sovb";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Ngày Nhận";
            this.gridColumn3.FieldName = "ngaynhan";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Nội Dung";
            this.gridColumn4.FieldName = "noidung";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Trích yếu";
            this.gridColumn5.FieldName = "trichyeu";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // lblid
            // 
            this.lblid.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblid.Location = new System.Drawing.Point(12, 38);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(52, 18);
            this.lblid.TabIndex = 1;
            this.lblid.Text = "ID: N/A";
            // 
            // lblsovb
            // 
            this.lblsovb.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsovb.Location = new System.Drawing.Point(12, 57);
            this.lblsovb.Name = "lblsovb";
            this.lblsovb.Size = new System.Drawing.Size(74, 18);
            this.lblsovb.TabIndex = 2;
            this.lblsovb.Text = "Số VB: N/A";
            // 
            // lblngaynhan
            // 
            this.lblngaynhan.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblngaynhan.Location = new System.Drawing.Point(12, 76);
            this.lblngaynhan.Name = "lblngaynhan";
            this.lblngaynhan.Size = new System.Drawing.Size(108, 18);
            this.lblngaynhan.TabIndex = 3;
            this.lblngaynhan.Text = "Ngày Nhận: N/A";
            // 
            // lblnoidung
            // 
            this.lblnoidung.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnoidung.Location = new System.Drawing.Point(12, 95);
            this.lblnoidung.Name = "lblnoidung";
            this.lblnoidung.Size = new System.Drawing.Size(94, 18);
            this.lblnoidung.TabIndex = 4;
            this.lblnoidung.Text = "Nội Dung: N/A";
            // 
            // lbltrichyeu
            // 
            this.lbltrichyeu.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltrichyeu.Location = new System.Drawing.Point(12, 114);
            this.lbltrichyeu.Name = "lbltrichyeu";
            this.lbltrichyeu.Size = new System.Drawing.Size(98, 18);
            this.lbltrichyeu.TabIndex = 5;
            this.lbltrichyeu.Text = "Trích Yếu: N/A";
            // 
            // btnin
            // 
            this.btnin.Image = ((System.Drawing.Image)(resources.GetObject("btnin.Image")));
            this.btnin.Location = new System.Drawing.Point(644, 10);
            this.btnin.Name = "btnin";
            this.btnin.Size = new System.Drawing.Size(27, 23);
            this.btnin.TabIndex = 6;
            this.btnin.Click += new System.EventHandler(this.btnin_Click);
            // 
            // f_ktlink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 159);
            this.Controls.Add(this.btnin);
            this.Controls.Add(this.lbltrichyeu);
            this.Controls.Add(this.lblnoidung);
            this.Controls.Add(this.lblngaynhan);
            this.Controls.Add(this.lblsovb);
            this.Controls.Add(this.lblid);
            this.Controls.Add(this.txtlink);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "f_ktlink";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kiểm Tra Theo Hồ Sơ";
            this.Load += new System.EventHandler(this.f_ktlink_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtlink.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vanbandenBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SearchLookUpEdit txtlink;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private System.Windows.Forms.BindingSource vanbandenBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.LabelControl lblid;
        private DevExpress.XtraEditors.LabelControl lblsovb;
        private DevExpress.XtraEditors.LabelControl lblngaynhan;
        private DevExpress.XtraEditors.LabelControl lblnoidung;
        private DevExpress.XtraEditors.LabelControl lbltrichyeu;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.SimpleButton btnin;
    }
}