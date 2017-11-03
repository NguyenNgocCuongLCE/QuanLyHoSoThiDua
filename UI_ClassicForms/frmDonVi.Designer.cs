namespace UI_ClassicForms
{
    partial class frmDonVi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDonVi));
            this.lbl_ID = new System.Windows.Forms.Label();
            this.cmbLoai = new System.Windows.Forms.ComboBox();
            this.txbDiaDiem = new System.Windows.Forms.TextBox();
            this.txbEmail = new System.Windows.Forms.TextBox();
            this.txbPhone = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txbTen = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_ID
            // 
            this.lbl_ID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_ID.AutoSize = true;
            this.lbl_ID.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ID.Location = new System.Drawing.Point(12, 210);
            this.lbl_ID.Name = "lbl_ID";
            this.lbl_ID.Size = new System.Drawing.Size(36, 13);
            this.lbl_ID.TabIndex = 0;
            this.lbl_ID.Text = "label1";
            // 
            // cmbLoai
            // 
            this.cmbLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoai.FormattingEnabled = true;
            this.cmbLoai.Location = new System.Drawing.Point(116, 17);
            this.cmbLoai.Name = "cmbLoai";
            this.cmbLoai.Size = new System.Drawing.Size(121, 25);
            this.cmbLoai.TabIndex = 0;
            // 
            // txbDiaDiem
            // 
            this.txbDiaDiem.Location = new System.Drawing.Point(116, 49);
            this.txbDiaDiem.Multiline = true;
            this.txbDiaDiem.Name = "txbDiaDiem";
            this.txbDiaDiem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbDiaDiem.Size = new System.Drawing.Size(483, 69);
            this.txbDiaDiem.TabIndex = 2;
            // 
            // txbEmail
            // 
            this.txbEmail.Location = new System.Drawing.Point(116, 124);
            this.txbEmail.Name = "txbEmail";
            this.txbEmail.Size = new System.Drawing.Size(483, 25);
            this.txbEmail.TabIndex = 3;
            // 
            // txbPhone
            // 
            this.txbPhone.Location = new System.Drawing.Point(116, 155);
            this.txbPhone.Name = "txbPhone";
            this.txbPhone.Size = new System.Drawing.Size(483, 25);
            this.txbPhone.TabIndex = 4;
            this.txbPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbDienThoai_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tên đơn vị:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Địa điểm:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Email:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Số điện thoại:";
            // 
            // txbTen
            // 
            this.txbTen.Location = new System.Drawing.Point(243, 17);
            this.txbTen.Name = "txbTen";
            this.txbTen.Size = new System.Drawing.Size(356, 25);
            this.txbTen.TabIndex = 1;
            this.txbTen.TextChanged += new System.EventHandler(this.txbTen_TextChanged);
            // 
            // btnOK
            // 
            this.btnOK.Image = global::UI_ClassicForms.Properties.Resources.ok;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(180, 186);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(189, 40);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "Thêm đơn vị mới";
            this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Image = global::UI_ClassicForms.Properties.Resources.logout;
            this.btnHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHuy.Location = new System.Drawing.Point(410, 186);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(189, 40);
            this.btnHuy.TabIndex = 6;
            this.btnHuy.Text = "Đóng";
            this.btnHuy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // frmDonVi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 232);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbPhone);
            this.Controls.Add(this.txbEmail);
            this.Controls.Add(this.txbTen);
            this.Controls.Add(this.txbDiaDiem);
            this.Controls.Add(this.cmbLoai);
            this.Controls.Add(this.lbl_ID);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(628, 231);
            this.Name = "frmDonVi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "THÔNG TIN ĐƠN VỊ";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ID;
        private System.Windows.Forms.ComboBox cmbLoai;
        private System.Windows.Forms.TextBox txbDiaDiem;
        private System.Windows.Forms.TextBox txbEmail;
        private System.Windows.Forms.TextBox txbPhone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txbTen;
    }
}