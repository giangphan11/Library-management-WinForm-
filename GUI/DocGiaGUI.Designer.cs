namespace GUI
{
    partial class DocGiaGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocGiaGUI));
            this.rNu = new System.Windows.Forms.RadioButton();
            this.rNam = new System.Windows.Forms.RadioButton();
            this.btnHienThi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnNhapLai = new System.Windows.Forms.Button();
            this.cbbMaDTuong = new System.Windows.Forms.ComboBox();
            this.dtpNgayGHan = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayCap = new System.Windows.Forms.DateTimePicker();
            this.dtpNSinh = new System.Windows.Forms.DateTimePicker();
            this.txtHoten = new System.Windows.Forms.TextBox();
            this.txtMaDGia = new System.Windows.Forms.TextBox();
            this.dgvDocGia = new System.Windows.Forms.DataGridView();
            this.MaDGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NSinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDTuong = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.NgayCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayGHan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.btnInThe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocGia)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rNu
            // 
            this.rNu.AutoSize = true;
            this.rNu.Location = new System.Drawing.Point(287, 81);
            this.rNu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rNu.Name = "rNu";
            this.rNu.Size = new System.Drawing.Size(47, 21);
            this.rNu.TabIndex = 59;
            this.rNu.TabStop = true;
            this.rNu.Text = "Nữ";
            this.rNu.UseVisualStyleBackColor = true;
            // 
            // rNam
            // 
            this.rNam.AutoSize = true;
            this.rNam.Location = new System.Drawing.Point(200, 81);
            this.rNam.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rNam.Name = "rNam";
            this.rNam.Size = new System.Drawing.Size(58, 21);
            this.rNam.TabIndex = 58;
            this.rNam.TabStop = true;
            this.rNam.Text = "Nam";
            this.rNam.UseVisualStyleBackColor = true;
            // 
            // btnHienThi
            // 
            this.btnHienThi.Location = new System.Drawing.Point(28, 70);
            this.btnHienThi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHienThi.Name = "btnHienThi";
            this.btnHienThi.Size = new System.Drawing.Size(100, 49);
            this.btnHienThi.TabIndex = 56;
            this.btnHienThi.Text = "Hiển Thị";
            this.btnHienThi.UseVisualStyleBackColor = true;
            this.btnHienThi.Click += new System.EventHandler(this.btnHienThi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(271, 132);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 49);
            this.btnXoa.TabIndex = 55;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(425, 15);
            this.btnTim.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(57, 28);
            this.btnTim.TabIndex = 54;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(271, 70);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 49);
            this.btnSua.TabIndex = 52;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(147, 70);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 49);
            this.btnThem.TabIndex = 51;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnNhapLai
            // 
            this.btnNhapLai.Location = new System.Drawing.Point(28, 135);
            this.btnNhapLai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNhapLai.Name = "btnNhapLai";
            this.btnNhapLai.Size = new System.Drawing.Size(100, 49);
            this.btnNhapLai.TabIndex = 50;
            this.btnNhapLai.Text = "Nhập Lại";
            this.btnNhapLai.UseVisualStyleBackColor = true;
            this.btnNhapLai.Click += new System.EventHandler(this.btnNhapLai_Click);
            // 
            // cbbMaDTuong
            // 
            this.cbbMaDTuong.FormattingEnabled = true;
            this.cbbMaDTuong.Location = new System.Drawing.Point(200, 145);
            this.cbbMaDTuong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbbMaDTuong.Name = "cbbMaDTuong";
            this.cbbMaDTuong.Size = new System.Drawing.Size(281, 24);
            this.cbbMaDTuong.TabIndex = 49;
            // 
            // dtpNgayGHan
            // 
            this.dtpNgayGHan.CustomFormat = "dd-MM-yyyy";
            this.dtpNgayGHan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayGHan.Location = new System.Drawing.Point(200, 213);
            this.dtpNgayGHan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpNgayGHan.Name = "dtpNgayGHan";
            this.dtpNgayGHan.Size = new System.Drawing.Size(281, 22);
            this.dtpNgayGHan.TabIndex = 48;
            // 
            // dtpNgayCap
            // 
            this.dtpNgayCap.CustomFormat = "dd-MM-yyyy";
            this.dtpNgayCap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayCap.Location = new System.Drawing.Point(200, 177);
            this.dtpNgayCap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpNgayCap.Name = "dtpNgayCap";
            this.dtpNgayCap.Size = new System.Drawing.Size(281, 22);
            this.dtpNgayCap.TabIndex = 47;
            // 
            // dtpNSinh
            // 
            this.dtpNSinh.CustomFormat = "dd-MM-yyyy";
            this.dtpNSinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNSinh.Location = new System.Drawing.Point(200, 113);
            this.dtpNSinh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpNSinh.Name = "dtpNSinh";
            this.dtpNSinh.Size = new System.Drawing.Size(281, 22);
            this.dtpNSinh.TabIndex = 46;
            // 
            // txtHoten
            // 
            this.txtHoten.Location = new System.Drawing.Point(200, 49);
            this.txtHoten.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtHoten.Name = "txtHoten";
            this.txtHoten.Size = new System.Drawing.Size(281, 22);
            this.txtHoten.TabIndex = 45;
            // 
            // txtMaDGia
            // 
            this.txtMaDGia.Location = new System.Drawing.Point(200, 17);
            this.txtMaDGia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMaDGia.Name = "txtMaDGia";
            this.txtMaDGia.Size = new System.Drawing.Size(216, 22);
            this.txtMaDGia.TabIndex = 44;
            // 
            // dgvDocGia
            // 
            this.dgvDocGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocGia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDGia,
            this.Hten,
            this.GTinh,
            this.NSinh,
            this.MaDTuong,
            this.NgayCap,
            this.NgayGHan});
            this.dgvDocGia.Location = new System.Drawing.Point(36, 346);
            this.dgvDocGia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvDocGia.Name = "dgvDocGia";
            this.dgvDocGia.RowHeadersWidth = 51;
            this.dgvDocGia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocGia.Size = new System.Drawing.Size(997, 257);
            this.dgvDocGia.TabIndex = 43;
            this.dgvDocGia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocGia_CellClick);
            // 
            // MaDGia
            // 
            this.MaDGia.DataPropertyName = "MaDGia";
            this.MaDGia.HeaderText = "Mã";
            this.MaDGia.MinimumWidth = 6;
            this.MaDGia.Name = "MaDGia";
            this.MaDGia.Width = 50;
            // 
            // Hten
            // 
            this.Hten.DataPropertyName = "Hten";
            this.Hten.HeaderText = "Họ tên";
            this.Hten.MinimumWidth = 6;
            this.Hten.Name = "Hten";
            this.Hten.Width = 150;
            // 
            // GTinh
            // 
            this.GTinh.DataPropertyName = "GTinh";
            this.GTinh.HeaderText = "Giới Tính";
            this.GTinh.MinimumWidth = 6;
            this.GTinh.Name = "GTinh";
            this.GTinh.Width = 125;
            // 
            // NSinh
            // 
            this.NSinh.DataPropertyName = "NSinh";
            this.NSinh.HeaderText = "Ngày Sinh";
            this.NSinh.MinimumWidth = 6;
            this.NSinh.Name = "NSinh";
            this.NSinh.Width = 125;
            // 
            // MaDTuong
            // 
            this.MaDTuong.DataPropertyName = "MaDTuong";
            this.MaDTuong.HeaderText = "Mã Đối Tượng";
            this.MaDTuong.MinimumWidth = 6;
            this.MaDTuong.Name = "MaDTuong";
            this.MaDTuong.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MaDTuong.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.MaDTuong.Width = 125;
            // 
            // NgayCap
            // 
            this.NgayCap.DataPropertyName = "NgayCap";
            this.NgayCap.HeaderText = "Ngày Cấp";
            this.NgayCap.MinimumWidth = 6;
            this.NgayCap.Name = "NgayCap";
            this.NgayCap.Width = 125;
            // 
            // NgayGHan
            // 
            this.NgayGHan.DataPropertyName = "NgayGHan";
            this.NgayGHan.HeaderText = "Ngày Hết Hạn";
            this.NgayGHan.MinimumWidth = 6;
            this.NgayGHan.Name = "NgayGHan";
            this.NgayGHan.Width = 125;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(95, 182);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 20);
            this.label6.TabIndex = 41;
            this.label6.Text = "Ngày Cấp";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(57, 149);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 20);
            this.label5.TabIndex = 40;
            this.label5.Text = "Mã Đối Tượng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(91, 116);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 20);
            this.label4.TabIndex = 39;
            this.label4.Text = "Ngày Sinh";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(111, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 38;
            this.label3.Text = "GioiTinh";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(72, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 37;
            this.label2.Text = "Tên Đọc Giả";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 36;
            this.label1.Text = "Mã Độc Giả";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(57, 215);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 20);
            this.label7.TabIndex = 42;
            this.label7.Text = "Ngày Hết Hạn";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnInThe);
            this.panel1.Controls.Add(this.btnHienThi);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.btnNhapLai);
            this.panel1.Location = new System.Drawing.Point(631, 75);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(402, 252);
            this.panel1.TabIndex = 60;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(424, 16);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(236, 29);
            this.label8.TabIndex = 61;
            this.label8.Text = "QUẢN LÝ ĐỘC GIẢ";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(36, 26);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 42);
            this.button1.TabIndex = 62;
            this.button1.Text = "Quay lại";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(932, 26);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 42);
            this.button2.TabIndex = 63;
            this.button2.Text = "Thoát";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rNu);
            this.panel2.Controls.Add(this.rNam);
            this.panel2.Controls.Add(this.btnTim);
            this.panel2.Controls.Add(this.cbbMaDTuong);
            this.panel2.Controls.Add(this.dtpNgayGHan);
            this.panel2.Controls.Add(this.dtpNgayCap);
            this.panel2.Controls.Add(this.dtpNSinh);
            this.panel2.Controls.Add(this.txtHoten);
            this.panel2.Controls.Add(this.txtMaDGia);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(36, 75);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(566, 252);
            this.panel2.TabIndex = 64;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(32, 620);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(303, 17);
            this.label9.TabIndex = 65;
            this.label9.Text = "Nhóm 5 - Lớp Khoa Học máy tính 2 - K12";
            // 
            // btnInThe
            // 
            this.btnInThe.Location = new System.Drawing.Point(147, 135);
            this.btnInThe.Name = "btnInThe";
            this.btnInThe.Size = new System.Drawing.Size(100, 46);
            this.btnInThe.TabIndex = 57;
            this.btnInThe.Text = "In thẻ";
            this.btnInThe.UseVisualStyleBackColor = true;
            this.btnInThe.Click += new System.EventHandler(this.btnInThe_Click);
            // 
            // DocGiaGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1072, 634);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvDocGia);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DocGiaGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DocGiaGUI";
            this.Load += new System.EventHandler(this.DocGiaGUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocGia)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rNu;
        private System.Windows.Forms.RadioButton rNam;
        private System.Windows.Forms.Button btnHienThi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnNhapLai;
        private System.Windows.Forms.ComboBox cbbMaDTuong;
        private System.Windows.Forms.DateTimePicker dtpNgayGHan;
        private System.Windows.Forms.DateTimePicker dtpNgayCap;
        private System.Windows.Forms.DateTimePicker dtpNSinh;
        private System.Windows.Forms.TextBox txtHoten;
        private System.Windows.Forms.TextBox txtMaDGia;
        private System.Windows.Forms.DataGridView dgvDocGia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hten;
        private System.Windows.Forms.DataGridViewTextBoxColumn GTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn NSinh;
        private System.Windows.Forms.DataGridViewComboBoxColumn MaDTuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGHan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnInThe;
    }
}