namespace UI_ClassicForms
{
    partial class frmCaNhanTapThe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCaNhanTapThe));
            this.splContainer = new System.Windows.Forms.SplitContainer();
            this.trvDonVi = new System.Windows.Forms.TreeView();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctmnThemDonVi = new System.Windows.Forms.ToolStripMenuItem();
            this.ctmnThemCaNhan = new System.Windows.Forms.ToolStripMenuItem();
            this.ctmnSuaThongTin = new System.Windows.Forms.ToolStripMenuItem();
            this.ctmnXoa = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList24 = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbl_CaNhanTapThe = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splContainer)).BeginInit();
            this.splContainer.Panel1.SuspendLayout();
            this.splContainer.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splContainer
            // 
            this.splContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splContainer.Location = new System.Drawing.Point(0, 0);
            this.splContainer.Margin = new System.Windows.Forms.Padding(4);
            this.splContainer.Name = "splContainer";
            // 
            // splContainer.Panel1
            // 
            this.splContainer.Panel1.Controls.Add(this.trvDonVi);
            this.splContainer.Panel2Collapsed = true;
            this.splContainer.Size = new System.Drawing.Size(654, 459);
            this.splContainer.SplitterDistance = 271;
            this.splContainer.TabIndex = 0;
            // 
            // trvDonVi
            // 
            this.trvDonVi.ContextMenuStrip = this.contextMenu;
            this.trvDonVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvDonVi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvDonVi.HideSelection = false;
            this.trvDonVi.ImageIndex = 0;
            this.trvDonVi.ImageList = this.imageList24;
            this.trvDonVi.ItemHeight = 24;
            this.trvDonVi.Location = new System.Drawing.Point(0, 0);
            this.trvDonVi.Margin = new System.Windows.Forms.Padding(4);
            this.trvDonVi.Name = "trvDonVi";
            this.trvDonVi.SelectedImageIndex = 0;
            this.trvDonVi.Size = new System.Drawing.Size(654, 459);
            this.trvDonVi.TabIndex = 0;
            this.trvDonVi.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvDonVi_AfterSelect);
            this.trvDonVi.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trvDonVi_MouseDown);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctmnThemDonVi,
            this.ctmnThemCaNhan,
            this.ctmnSuaThongTin,
            this.ctmnXoa});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(153, 114);
            this.contextMenu.Text = "dffffff";
            this.contextMenu.Opened += new System.EventHandler(this.contextMenu_Opened);
            // 
            // ctmnThemDonVi
            // 
            this.ctmnThemDonVi.Image = global::UI_ClassicForms.Properties.Resources.plus;
            this.ctmnThemDonVi.Name = "ctmnThemDonVi";
            this.ctmnThemDonVi.Size = new System.Drawing.Size(152, 22);
            this.ctmnThemDonVi.Text = "Thêm đơn vị";
            this.ctmnThemDonVi.Click += new System.EventHandler(this.ctmnThemDonVi_Click);
            // 
            // ctmnThemCaNhan
            // 
            this.ctmnThemCaNhan.Image = global::UI_ClassicForms.Properties.Resources.plus;
            this.ctmnThemCaNhan.Name = "ctmnThemCaNhan";
            this.ctmnThemCaNhan.Size = new System.Drawing.Size(152, 22);
            this.ctmnThemCaNhan.Text = "Thêm cán bộ";
            this.ctmnThemCaNhan.Click += new System.EventHandler(this.ctmnThemCaNhan_Click);
            // 
            // ctmnSuaThongTin
            // 
            this.ctmnSuaThongTin.Image = global::UI_ClassicForms.Properties.Resources.edit;
            this.ctmnSuaThongTin.Name = "ctmnSuaThongTin";
            this.ctmnSuaThongTin.Size = new System.Drawing.Size(152, 22);
            this.ctmnSuaThongTin.Text = "Sửa thông tin";
            this.ctmnSuaThongTin.Click += new System.EventHandler(this.ctmnSuaThongTin_Click);
            // 
            // ctmnXoa
            // 
            this.ctmnXoa.Image = global::UI_ClassicForms.Properties.Resources.remove;
            this.ctmnXoa.Name = "ctmnXoa";
            this.ctmnXoa.Size = new System.Drawing.Size(152, 22);
            this.ctmnXoa.Text = "Xóa";
            this.ctmnXoa.Click += new System.EventHandler(this.ctmnXoa_Click);
            // 
            // imageList24
            // 
            this.imageList24.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList24.ImageStream")));
            this.imageList24.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList24.Images.SetKeyName(0, "group24.png");
            this.imageList24.Images.SetKeyName(1, "group24s.png");
            this.imageList24.Images.SetKeyName(2, "user24.png");
            this.imageList24.Images.SetKeyName(3, "user24s.png");
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_CaNhanTapThe});
            this.statusStrip1.Location = new System.Drawing.Point(0, 459);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.statusStrip1.Size = new System.Drawing.Size(654, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbl_CaNhanTapThe
            // 
            this.lbl_CaNhanTapThe.Name = "lbl_CaNhanTapThe";
            this.lbl_CaNhanTapThe.Size = new System.Drawing.Size(118, 17);
            this.lbl_CaNhanTapThe.Text = "toolStripStatusLabel1";
            // 
            // frmCaNhanTapThe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 481);
            this.Controls.Add(this.splContainer);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(670, 520);
            this.MinimumSize = new System.Drawing.Size(670, 520);
            this.Name = "frmCaNhanTapThe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "CÁ NHÂN VÀ ĐƠN VỊ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCaNhanTapThe_FormClosed);
            this.Load += new System.EventHandler(this.frmCaNhanTapThe_Load);
            this.splContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splContainer)).EndInit();
            this.splContainer.ResumeLayout(false);
            this.contextMenu.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splContainer;
        private System.Windows.Forms.TreeView trvDonVi;
        private System.Windows.Forms.ImageList imageList24;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem ctmnThemDonVi;
        private System.Windows.Forms.ToolStripMenuItem ctmnSuaThongTin;
        private System.Windows.Forms.ToolStripMenuItem ctmnXoa;
        private System.Windows.Forms.ToolStripMenuItem ctmnThemCaNhan;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbl_CaNhanTapThe;
    }
}