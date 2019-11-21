namespace GUI
{
    partial class frmp
    {

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
        protected void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmp));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnmo = new DevExpress.XtraBars.BarButtonItem();
            this.btnthem = new DevExpress.XtraBars.BarButtonItem();
            this.btnluu = new DevExpress.XtraBars.BarButtonItem();
            this.btnsua = new DevExpress.XtraBars.BarButtonItem();
            this.btnxoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnin = new DevExpress.XtraBars.BarButtonItem();
            this.btnreload = new DevExpress.XtraBars.BarButtonItem();
            this.btntop = new DevExpress.XtraBars.BarButtonItem();
            this.btnprev = new DevExpress.XtraBars.BarButtonItem();
            this.btnnext = new DevExpress.XtraBars.BarButtonItem();
            this.btnend = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.btnduyet = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnmo,
            this.btnthem,
            this.btnluu,
            this.btnsua,
            this.btnxoa,
            this.btnin,
            this.btnreload,
            this.btntop,
            this.btnprev,
            this.btnnext,
            this.btnend,
            this.btnduyet});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 12;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnmo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnthem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnluu, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnsua, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnxoa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnin),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnreload),
            new DevExpress.XtraBars.LinkPersistInfo(this.btntop),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnprev),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnnext),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnend)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnmo
            // 
            this.btnmo.Caption = "Mở";
            this.btnmo.Id = 0;
            this.btnmo.ImageOptions.Image = global::GUI.Properties.Resources.loadfrom_16x16;
            this.btnmo.ImageOptions.LargeImage = global::GUI.Properties.Resources.loadfrom_32x32;
            this.btnmo.Name = "btnmo";
            this.btnmo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnmo_ItemClick);
            // 
            // btnthem
            // 
            this.btnthem.Caption = "Thêm";
            this.btnthem.Id = 1;
            this.btnthem.ImageOptions.Image = global::GUI.Properties.Resources.additem_16x162;
            this.btnthem.ImageOptions.LargeImage = global::GUI.Properties.Resources.additem_32x322;
            this.btnthem.Name = "btnthem";
            this.btnthem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnthem_ItemClick);
            // 
            // btnluu
            // 
            this.btnluu.Caption = "Lưu";
            this.btnluu.Id = 2;
            this.btnluu.ImageOptions.Image = global::GUI.Properties.Resources.save_16x163;
            this.btnluu.ImageOptions.LargeImage = global::GUI.Properties.Resources.save_32x322;
            this.btnluu.Name = "btnluu";
            this.btnluu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnluu_ItemClick);
            // 
            // btnsua
            // 
            this.btnsua.Caption = "Sửa";
            this.btnsua.Id = 3;
            this.btnsua.ImageOptions.Image = global::GUI.Properties.Resources.edit_16x163;
            this.btnsua.ImageOptions.LargeImage = global::GUI.Properties.Resources.edit_32x323;
            this.btnsua.Name = "btnsua";
            this.btnsua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnsua_ItemClick);
            // 
            // btnxoa
            // 
            this.btnxoa.Caption = "Xóa";
            this.btnxoa.Id = 4;
            this.btnxoa.ImageOptions.Image = global::GUI.Properties.Resources.deletelist_16x162;
            this.btnxoa.ImageOptions.LargeImage = global::GUI.Properties.Resources.deletelist_32x322;
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnxoa_ItemClick);
            // 
            // btnin
            // 
            this.btnin.Caption = "In";
            this.btnin.Id = 5;
            this.btnin.ImageOptions.Image = global::GUI.Properties.Resources.preview_16x16;
            this.btnin.ImageOptions.LargeImage = global::GUI.Properties.Resources.preview_32x32;
            this.btnin.Name = "btnin";
            this.btnin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnin_ItemClick);
            // 
            // btnreload
            // 
            this.btnreload.Caption = "Reload";
            this.btnreload.Id = 6;
            this.btnreload.ImageOptions.Image = global::GUI.Properties.Resources.refresh_16x163;
            this.btnreload.ImageOptions.LargeImage = global::GUI.Properties.Resources.refresh_32x323;
            this.btnreload.Name = "btnreload";
            this.btnreload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnreload_ItemClick);
            // 
            // btntop
            // 
            this.btntop.Caption = "Top";
            this.btntop.Id = 7;
            this.btntop.ImageOptions.Image = global::GUI.Properties.Resources.doublefirst_16x16;
            this.btntop.ImageOptions.LargeImage = global::GUI.Properties.Resources.doublefirst_32x32;
            this.btntop.Name = "btntop";
            this.btntop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btntop_ItemClick);
            // 
            // btnprev
            // 
            this.btnprev.Caption = "Prev";
            this.btnprev.Id = 8;
            this.btnprev.ImageOptions.Image = global::GUI.Properties.Resources.prev_16x16;
            this.btnprev.ImageOptions.LargeImage = global::GUI.Properties.Resources.prev_32x32;
            this.btnprev.Name = "btnprev";
            this.btnprev.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnprev_ItemClick);
            // 
            // btnnext
            // 
            this.btnnext.Caption = "Next";
            this.btnnext.Id = 9;
            this.btnnext.ImageOptions.Image = global::GUI.Properties.Resources.next_16x16;
            this.btnnext.ImageOptions.LargeImage = global::GUI.Properties.Resources.next_32x32;
            this.btnnext.Name = "btnnext";
            this.btnnext.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnnext_ItemClick);
            // 
            // btnend
            // 
            this.btnend.Caption = "End";
            this.btnend.Id = 10;
            this.btnend.ImageOptions.Image = global::GUI.Properties.Resources.doublelast_16x16;
            this.btnend.ImageOptions.LargeImage = global::GUI.Properties.Resources.doublelast_32x32;
            this.btnend.Name = "btnend";
            this.btnend.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnend_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnduyet, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // btnduyet
            // 
            this.btnduyet.Caption = "Duyệt";
            this.btnduyet.Id = 11;
            this.btnduyet.ImageOptions.Image = global::GUI.Properties.Resources.folder_full_icon;
            this.btnduyet.Name = "btnduyet";
            this.btnduyet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnduyet_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(744, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 353);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(744, 59);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 329);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(744, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 329);
            // 
            // frmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 412);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmp";
            this.Load += new System.EventHandler(this.frmp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected DevExpress.XtraBars.Bar bar2;
        protected DevExpress.XtraBars.Bar bar3;
        protected DevExpress.XtraBars.BarDockControl barDockControlTop;
        protected DevExpress.XtraBars.BarDockControl barDockControlBottom;
        protected DevExpress.XtraBars.BarDockControl barDockControlLeft;
        protected DevExpress.XtraBars.BarDockControl barDockControlRight;
        protected DevExpress.XtraBars.BarButtonItem btnmo;
        protected DevExpress.XtraBars.BarButtonItem btnthem;
        protected DevExpress.XtraBars.BarButtonItem btnluu;
        protected DevExpress.XtraBars.BarButtonItem btnsua;
        protected DevExpress.XtraBars.BarButtonItem btnxoa;
        protected DevExpress.XtraBars.BarButtonItem btnin;
        protected DevExpress.XtraBars.BarButtonItem btnreload;
        protected DevExpress.XtraBars.BarButtonItem btntop;
        protected DevExpress.XtraBars.BarButtonItem btnprev;
        protected DevExpress.XtraBars.BarButtonItem btnnext;
        protected DevExpress.XtraBars.BarButtonItem btnend;
        protected System.ComponentModel.IContainer components;
        protected DevExpress.XtraBars.BarButtonItem btnduyet;
        protected DevExpress.XtraBars.BarManager barManager1;
    }
}