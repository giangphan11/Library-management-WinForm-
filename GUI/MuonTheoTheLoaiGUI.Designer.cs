namespace GUI
{
    partial class MuonTheoTheLoaiGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MuonTheoTheLoaiGUI));
            this.lbNgayLap = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnLocTheoNgay = new System.Windows.Forms.Button();
            this.gbTime = new System.Windows.Forms.GroupBox();
            this.dpKetThuc = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtp = new System.Windows.Forms.Label();
            this.dpBatDau = new System.Windows.Forms.DateTimePicker();
            this.lbNguoiLapbc = new System.Windows.Forms.Label();
            this.lbTenThuVien = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvThongKeMuon = new System.Windows.Forms.DataGridView();
            this.stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaTLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soLanMuon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ghiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuayLai = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gbTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKeMuon)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbNgayLap
            // 
            this.lbNgayLap.AutoSize = true;
            this.lbNgayLap.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNgayLap.Location = new System.Drawing.Point(164, 85);
            this.lbNgayLap.Name = "lbNgayLap";
            this.lbNgayLap.Size = new System.Drawing.Size(28, 18);
            this.lbNgayLap.TabIndex = 33;
            this.lbNgayLap.Text = "xx";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.btnIn);
            this.groupBox1.Controls.Add(this.btnLocTheoNgay);
            this.groupBox1.Location = new System.Drawing.Point(469, 414);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 85);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Điều Khiển";
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(149, 19);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 55);
            this.btnIn.TabIndex = 17;
            this.btnIn.Text = "In Báo Cáo";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnLocTheoNgay
            // 
            this.btnLocTheoNgay.Location = new System.Drawing.Point(25, 19);
            this.btnLocTheoNgay.Name = "btnLocTheoNgay";
            this.btnLocTheoNgay.Size = new System.Drawing.Size(85, 55);
            this.btnLocTheoNgay.TabIndex = 16;
            this.btnLocTheoNgay.Text = "Xem";
            this.btnLocTheoNgay.UseVisualStyleBackColor = true;
            this.btnLocTheoNgay.Click += new System.EventHandler(this.btnLocTheoNgay_Click);
            // 
            // gbTime
            // 
            this.gbTime.BackColor = System.Drawing.SystemColors.Control;
            this.gbTime.Controls.Add(this.dpKetThuc);
            this.gbTime.Controls.Add(this.label6);
            this.gbTime.Controls.Add(this.dtp);
            this.gbTime.Controls.Add(this.dpBatDau);
            this.gbTime.Location = new System.Drawing.Point(28, 414);
            this.gbTime.Name = "gbTime";
            this.gbTime.Size = new System.Drawing.Size(420, 85);
            this.gbTime.TabIndex = 31;
            this.gbTime.TabStop = false;
            this.gbTime.Text = "Chọn Thời Gian";
            // 
            // dpKetThuc
            // 
            this.dpKetThuc.CustomFormat = "dd-MM-yyyy";
            this.dpKetThuc.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpKetThuc.Location = new System.Drawing.Point(287, 30);
            this.dpKetThuc.Name = "dpKetThuc";
            this.dpKetThuc.Size = new System.Drawing.Size(124, 23);
            this.dpKetThuc.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Bắt đầu:";
            // 
            // dtp
            // 
            this.dtp.AutoSize = true;
            this.dtp.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp.Location = new System.Drawing.Point(212, 33);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(71, 16);
            this.dtp.TabIndex = 7;
            this.dtp.Text = "Kết thúc:";
            // 
            // dpBatDau
            // 
            this.dpBatDau.CustomFormat = "dd-MM-yyyy";
            this.dpBatDau.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpBatDau.Location = new System.Drawing.Point(84, 30);
            this.dpBatDau.Name = "dpBatDau";
            this.dpBatDau.Size = new System.Drawing.Size(124, 23);
            this.dpBatDau.TabIndex = 8;
            // 
            // lbNguoiLapbc
            // 
            this.lbNguoiLapbc.AutoSize = true;
            this.lbNguoiLapbc.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNguoiLapbc.Location = new System.Drawing.Point(164, 124);
            this.lbNguoiLapbc.Name = "lbNguoiLapbc";
            this.lbNguoiLapbc.Size = new System.Drawing.Size(28, 18);
            this.lbNguoiLapbc.TabIndex = 30;
            this.lbNguoiLapbc.Text = "xx";
            // 
            // lbTenThuVien
            // 
            this.lbTenThuVien.AutoSize = true;
            this.lbTenThuVien.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenThuVien.Location = new System.Drawing.Point(164, 48);
            this.lbTenThuVien.Name = "lbTenThuVien";
            this.lbTenThuVien.Size = new System.Drawing.Size(365, 18);
            this.lbTenThuVien.TabIndex = 29;
            this.lbTenThuVien.Text = "Thư viện trường Đại học Công nghiệp Hà Nội";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(164, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(295, 18);
            this.label7.TabIndex = 28;
            this.label7.Text = "Thống kê số lần mượn theo thể loại";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // dgvThongKeMuon
            // 
            this.dgvThongKeMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKeMuon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stt,
            this.MaTLoai,
            this.TenTLoai,
            this.soLanMuon,
            this.ghiChu});
            this.dgvThongKeMuon.Location = new System.Drawing.Point(29, 235);
            this.dgvThongKeMuon.Name = "dgvThongKeMuon";
            this.dgvThongKeMuon.Size = new System.Drawing.Size(694, 173);
            this.dgvThongKeMuon.TabIndex = 27;
            // 
            // stt
            // 
            this.stt.HeaderText = "STT";
            this.stt.Name = "stt";
            this.stt.Width = 50;
            // 
            // MaTLoai
            // 
            this.MaTLoai.DataPropertyName = "MaTLoai";
            this.MaTLoai.HeaderText = "Mã Thể Loại";
            this.MaTLoai.Name = "MaTLoai";
            // 
            // TenTLoai
            // 
            this.TenTLoai.DataPropertyName = "TenTLoai";
            this.TenTLoai.HeaderText = "Tên Thể Loại";
            this.TenTLoai.Name = "TenTLoai";
            this.TenTLoai.Width = 200;
            // 
            // soLanMuon
            // 
            this.soLanMuon.DataPropertyName = "SoLanMuon";
            this.soLanMuon.HeaderText = "Số Lần Mượn";
            this.soLanMuon.Name = "soLanMuon";
            // 
            // ghiChu
            // 
            this.ghiChu.DataPropertyName = "ghiChu";
            this.ghiChu.HeaderText = "Ghi Chú";
            this.ghiChu.Name = "ghiChu";
            this.ghiChu.Width = 200;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 18);
            this.label5.TabIndex = 26;
            this.label5.Text = "Người lập báo cáo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 18);
            this.label4.TabIndex = 25;
            this.label4.Text = "Ngày lập báo cáo: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 18);
            this.label3.TabIndex = 24;
            this.label3.Text = "Tên thư viện:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 18);
            this.label2.TabIndex = 23;
            this.label2.Text = "Tiêu đề báo cáo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(163, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(456, 23);
            this.label1.TabIndex = 22;
            this.label1.Text = "THỐNG KÊ SỐ LẦN MƯỢN THEO THỂ LOẠI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuayLai.Location = new System.Drawing.Point(29, 28);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(81, 34);
            this.btnQuayLai.TabIndex = 34;
            this.btnQuayLai.Text = "Quay lại";
            this.btnQuayLai.UseVisualStyleBackColor = true;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(646, 28);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(76, 34);
            this.button3.TabIndex = 35;
            this.button3.Text = "Thoát";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbNgayLap);
            this.panel1.Controls.Add(this.lbNguoiLapbc);
            this.panel1.Controls.Add(this.lbTenThuVien);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(29, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(694, 155);
            this.panel1.TabIndex = 36;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(25, 505);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(242, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Nhóm 5 - Lớp Khoa Học máy tính 2 - K12";
            // 
            // MuonTheoTheLoaiGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(755, 525);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnQuayLai);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbTime);
            this.Controls.Add(this.dgvThongKeMuon);
            this.Controls.Add(this.label1);
            this.Name = "MuonTheoTheLoaiGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MuonTheoTheLoaiGUI";
            this.Load += new System.EventHandler(this.MuonTheoTheLoaiGUI_Load);
            this.groupBox1.ResumeLayout(false);
            this.gbTime.ResumeLayout(false);
            this.gbTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKeMuon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNgayLap;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnLocTheoNgay;
        private System.Windows.Forms.GroupBox gbTime;
        private System.Windows.Forms.DateTimePicker dpKetThuc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label dtp;
        private System.Windows.Forms.DateTimePicker dpBatDau;
        private System.Windows.Forms.Label lbNguoiLapbc;
        private System.Windows.Forms.Label lbTenThuVien;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvThongKeMuon;
        private System.Windows.Forms.DataGridViewTextBoxColumn stt;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn soLanMuon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ghiChu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQuayLai;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
    }
}