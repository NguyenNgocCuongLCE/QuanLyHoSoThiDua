namespace UI_ClassicForms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.MainStatus = new System.Windows.Forms.StatusStrip();
            this.btnQuanLiCaNhanTapThe = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.MainMenu.Size = new System.Drawing.Size(501, 24);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "menuStrip1";
            // 
            // MainStatus
            // 
            this.MainStatus.Location = new System.Drawing.Point(0, 349);
            this.MainStatus.Name = "MainStatus";
            this.MainStatus.Padding = new System.Windows.Forms.Padding(1, 0, 17, 0);
            this.MainStatus.Size = new System.Drawing.Size(501, 22);
            this.MainStatus.TabIndex = 2;
            this.MainStatus.Text = "statusStrip1";
            // 
            // btnQuanLiCaNhanTapThe
            // 
            this.btnQuanLiCaNhanTapThe.Location = new System.Drawing.Point(13, 276);
            this.btnQuanLiCaNhanTapThe.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuanLiCaNhanTapThe.Name = "btnQuanLiCaNhanTapThe";
            this.btnQuanLiCaNhanTapThe.Size = new System.Drawing.Size(234, 63);
            this.btnQuanLiCaNhanTapThe.TabIndex = 1;
            this.btnQuanLiCaNhanTapThe.Text = "CÁ NHÂN VÀ ĐƠN VỊ";
            this.btnQuanLiCaNhanTapThe.UseVisualStyleBackColor = true;
            this.btnQuanLiCaNhanTapThe.Click += new System.EventHandler(this.btnQuanLiCaNhanTapThe_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 216);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(475, 52);
            this.button1.TabIndex = 0;
            this.button1.Text = "HỒ SƠ THI ĐUA";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(254, 276);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(234, 63);
            this.button2.TabIndex = 2;
            this.button2.Text = "DANH MỤC TIÊU CHÍ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI_ClassicForms.Properties.Resources.logo_circle;
            this.pictureBox1.Location = new System.Drawing.Point(160, 34);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 174);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 371);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnQuanLiCaNhanTapThe);
            this.Controls.Add(this.MainStatus);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.MainMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(517, 414);
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÍ HỒ SƠ THI ĐUA";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.StatusStrip MainStatus;
        private System.Windows.Forms.Button btnQuanLiCaNhanTapThe;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

