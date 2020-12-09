namespace GUI
{
    partial class DoiThongTin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoiThongTin));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtMatKhauCu = new System.Windows.Forms.TextBox();
            this.radioDoiMatKhau = new System.Windows.Forms.RadioButton();
            this.txtMatKhauMoi = new System.Windows.Forms.TextBox();
            this.txtNhapLai = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbXacNhanMK = new System.Windows.Forms.Label();
            this.txtMatKhauXacNhan = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.pn1 = new System.Windows.Forms.Panel();
            this.txtMaNV = new System.Windows.Forms.Label();
            this.ma = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pn1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(122, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(177, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Họ tên :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mật khẩu cũ :";
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Location = new System.Drawing.Point(248, 52);
            this.txtTaiKhoan.Margin = new System.Windows.Forms.Padding(4);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(203, 23);
            this.txtTaiKhoan.TabIndex = 3;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(248, 92);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(4);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(203, 23);
            this.txtHoTen.TabIndex = 4;
            // 
            // txtMatKhauCu
            // 
            this.txtMatKhauCu.Location = new System.Drawing.Point(150, 12);
            this.txtMatKhauCu.Margin = new System.Windows.Forms.Padding(4);
            this.txtMatKhauCu.Name = "txtMatKhauCu";
            this.txtMatKhauCu.Size = new System.Drawing.Size(203, 23);
            this.txtMatKhauCu.TabIndex = 5;
            this.txtMatKhauCu.UseSystemPasswordChar = true;
            // 
            // radioDoiMatKhau
            // 
            this.radioDoiMatKhau.AutoSize = true;
            this.radioDoiMatKhau.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioDoiMatKhau.Location = new System.Drawing.Point(248, 168);
            this.radioDoiMatKhau.Margin = new System.Windows.Forms.Padding(4);
            this.radioDoiMatKhau.Name = "radioDoiMatKhau";
            this.radioDoiMatKhau.Size = new System.Drawing.Size(112, 20);
            this.radioDoiMatKhau.TabIndex = 6;
            this.radioDoiMatKhau.TabStop = true;
            this.radioDoiMatKhau.Text = "Đổi mật khẩu";
            this.radioDoiMatKhau.UseVisualStyleBackColor = true;
            this.radioDoiMatKhau.CheckedChanged += new System.EventHandler(this.radioDoiMatKhau_CheckedChanged);
            // 
            // txtMatKhauMoi
            // 
            this.txtMatKhauMoi.Location = new System.Drawing.Point(150, 52);
            this.txtMatKhauMoi.Margin = new System.Windows.Forms.Padding(4);
            this.txtMatKhauMoi.Name = "txtMatKhauMoi";
            this.txtMatKhauMoi.Size = new System.Drawing.Size(203, 23);
            this.txtMatKhauMoi.TabIndex = 7;
            this.txtMatKhauMoi.UseSystemPasswordChar = true;
            // 
            // txtNhapLai
            // 
            this.txtNhapLai.Location = new System.Drawing.Point(150, 94);
            this.txtNhapLai.Margin = new System.Windows.Forms.Padding(4);
            this.txtNhapLai.Name = "txtNhapLai";
            this.txtNhapLai.Size = new System.Drawing.Size(203, 23);
            this.txtNhapLai.TabIndex = 8;
            this.txtNhapLai.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(71, 97);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Nhập lại :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(35, 55);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Mật khẩu mới :";
            // 
            // lbXacNhanMK
            // 
            this.lbXacNhanMK.AutoSize = true;
            this.lbXacNhanMK.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbXacNhanMK.Location = new System.Drawing.Point(95, 138);
            this.lbXacNhanMK.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbXacNhanMK.Name = "lbXacNhanMK";
            this.lbXacNhanMK.Size = new System.Drawing.Size(145, 16);
            this.lbXacNhanMK.TabIndex = 11;
            this.lbXacNhanMK.Text = "Mật khẩu xác nhận :";
            // 
            // txtMatKhauXacNhan
            // 
            this.txtMatKhauXacNhan.Location = new System.Drawing.Point(248, 135);
            this.txtMatKhauXacNhan.Margin = new System.Windows.Forms.Padding(4);
            this.txtMatKhauXacNhan.Name = "txtMatKhauXacNhan";
            this.txtMatKhauXacNhan.Size = new System.Drawing.Size(203, 23);
            this.txtMatKhauXacNhan.TabIndex = 12;
            this.txtMatKhauXacNhan.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(198, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(230, 23);
            this.label7.TabIndex = 13;
            this.label7.Text = "TÀI KHOẢN CỦA TÔI";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.pn1);
            this.panel1.Controls.Add(this.txtMaNV);
            this.panel1.Controls.Add(this.ma);
            this.panel1.Controls.Add(this.txtMatKhauXacNhan);
            this.panel1.Controls.Add(this.lbXacNhanMK);
            this.panel1.Controls.Add(this.radioDoiMatKhau);
            this.panel1.Controls.Add(this.txtHoTen);
            this.panel1.Controls.Add(this.txtTaiKhoan);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(32, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(555, 371);
            this.panel1.TabIndex = 14;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(220, 332);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(108, 34);
            this.button4.TabIndex = 16;
            this.button4.Text = "Xác nhận";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // pn1
            // 
            this.pn1.Controls.Add(this.label5);
            this.pn1.Controls.Add(this.label4);
            this.pn1.Controls.Add(this.txtNhapLai);
            this.pn1.Controls.Add(this.txtMatKhauMoi);
            this.pn1.Controls.Add(this.txtMatKhauCu);
            this.pn1.Controls.Add(this.label3);
            this.pn1.Location = new System.Drawing.Point(98, 193);
            this.pn1.Name = "pn1";
            this.pn1.Size = new System.Drawing.Size(364, 133);
            this.pn1.TabIndex = 15;
            // 
            // txtMaNV
            // 
            this.txtMaNV.AutoSize = true;
            this.txtMaNV.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNV.Location = new System.Drawing.Point(245, 11);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(57, 18);
            this.txtMaNV.TabIndex = 14;
            this.txtMaNV.Text = "label8";
            // 
            // ma
            // 
            this.ma.AutoSize = true;
            this.ma.BackColor = System.Drawing.SystemColors.Control;
            this.ma.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ma.Location = new System.Drawing.Point(133, 11);
            this.ma.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(107, 16);
            this.ma.TabIndex = 13;
            this.ma.Text = "Mã nhân viên :";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(32, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 34);
            this.button1.TabIndex = 15;
            this.button1.Text = "Quay lại";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(497, 28);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 34);
            this.button3.TabIndex = 17;
            this.button3.Text = "Thoát";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(-2, 454);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(242, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Nhóm 5 - Lớp Khoa Học máy tính 2 - K12";
            // 
            // DoiThongTin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(623, 468);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DoiThongTin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DoiThongTin";
            this.Load += new System.EventHandler(this.DoiThongTin_Load);
            this.Click += new System.EventHandler(this.DoiThongTin_Click);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pn1.ResumeLayout(false);
            this.pn1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtMatKhauCu;
        private System.Windows.Forms.RadioButton radioDoiMatKhau;
        private System.Windows.Forms.TextBox txtMatKhauMoi;
        private System.Windows.Forms.TextBox txtNhapLai;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbXacNhanMK;
        private System.Windows.Forms.TextBox txtMatKhauXacNhan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtMaNV;
        private System.Windows.Forms.Label ma;
        private System.Windows.Forms.Panel pn1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label6;
    }
}