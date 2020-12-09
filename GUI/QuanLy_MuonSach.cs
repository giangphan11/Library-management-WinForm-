using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

//import
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace GUI
{
    public partial class QuanLy_MuonSach : Form
    {
        public int sl_muonHienTai;
        public  int check;
        public string maNV;

        PhieuMuonSachBUS obj_phieu = new PhieuMuonSachBUS();

        public QuanLy_MuonSach()
        {
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //quay lai admin
            if (check == 1)
            {
                var frm = new TrangChu_QuanTriVien();
                frm.maNV = maNV;

                frm.Show();
                this.Hide();
            }
            else
            {
                var frm = new TrangChu_ThuThu();
                frm.maNV = maNV;

                frm.Show();
                this.Hide();
            }
        }

        private void QuanLy_MuonSach_Load(object sender, EventArgs e)
        {
            //Hiển thị mã tài liệu lên combobox
            loadcCombo();

            txtMaSach.Enabled = false;
            txtTenTL.Enabled = false;
            dtpNgayTra.Enabled = false;
            txtSLM.Enabled = false;
            txtTenDocGia.Enabled = false;

            btnThemTL.Enabled = false;
            btnSuaTL.Enabled = false;
            btnXoaTL.Enabled = false;
            cbTrangThai.Enabled = false;

            txtTenNhanVien.Enabled = false;

            cbTrangThai.Items.Add("Đang mượn");
            cbTrangThai.Items.Add("Đã trả"); 
            cbTrangThai.SelectedIndex = 0;

            //hien thi sau 1 thang ke tu ngay hien tai
            DateTime now = DateTime.Now;
            DateTime newAfter1Month = now.AddMonths(1);

            dtpNgayTra.Value = newAfter1Month;
        }

        public void loadcCombo()
        {
            DataTable dtb = new DataTable();
            dtb = obj_phieu.getTaiLieu();
            
        }
        
        private void button8_Click(object sender, EventArgs e)
        {
            //hien thi len textbox
            try
            {
                //Mang gia tri
                string[] param = obj_phieu.layThongTinPhieu2(txtMaPhieu.Text);

                if (txtMaPhieu.Text == "")
                {
                    MessageBox.Show("Mã phiếu không được để trống");
                    return;
                }

                Regex reg = new Regex(@"^[P]\d{2,4}$");
                if (!reg.IsMatch(txtMaPhieu.Text)) {
                    MessageBox.Show("Mã phiếu bắt đầu từ P theo sau là 2-4 số, ví dụ: P01");
                    return;
                }    

                if (param[0] == null)
                {
                    MessageBox.Show("Không tìm thấy mã phiếu :" + txtMaPhieu.Text);
                    clearText();
                    return;
                }

                //dua len textbox
                txtMaDocGia.Text = param[0];
                txtTenDocGia.Text = param[1];
                dtpNgayMuon.Text = param[2];
                txtMaNhanVien.Text = param[3];
                txtTenNhanVien.Text = param[4];
            }
            catch{
                MessageBox.Show("Có lỗi, kiểm tra lại!");
            }

            //neu nhu chua co gi thi thong bao nhap
            DataTable dtb = obj_phieu.chiTietMuonSach(txtMaPhieu.Text);
            if(dtb.Rows.Count == 0)
            {
                MessageBox.Show("Phiếu hiện tại chưa có tài liệu mượn, hãy nhập thông tin");
                return;
            }

            //hien thi tren bang chi tiet
            try {
                loadDgv();
            }
            catch
            {
                MessageBox.Show("Có lỗi!");
            } 
        }

        public void loadDgv()
        {
            DataTable dtb = obj_phieu.chiTietMuonSach(txtMaPhieu.Text);
            dgvTaiLieu.DataSource = dtb;

            //thay doi dinh dang date trong datatable


            //cuon nao tra roi se duoc danh dau mau
            for (int i = 0; i < dgvTaiLieu.Rows.Count - 1; i++)
            {
                if (dgvTaiLieu.Rows[i].Cells[4].Value.ToString() == "Đã trả")
                {
                    dgvTaiLieu.Rows[i].DefaultCellStyle.ForeColor = Color.Gray;
                }
            }

            //dinh dang lai ngay/thang/nam trong dgv
            dgvTaiLieu.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        public void clearText()
        {
            DateTime now = DateTime.Now;
            txtMaDocGia.Text = "";
            txtTenDocGia.Text = "";
            dtpNgayMuon.Text = now + "";
            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clearText();
        }

        //lưu
        private void button1_Click(object sender, EventArgs e)
        {
            //regex
            Regex reg = new Regex(@"^[P]\d{2,5}$");
            if (!reg.IsMatch(txtMaPhieu.Text))
            {
                MessageBox.Show("Sai định dạng mã phiếu, ví dụ: P01");
                return;
            }

            if (txtTenNhanVien.Text == "" || txtTenDocGia.Text == "") {
                MessageBox.Show("Hãy nhập đầy đủ thông tin");
                return;
            }

            //them phieu
            try
            {
                DateTime ngayMuon = dtpNgayMuon.Value;
                PhieuMuon pm = new PhieuMuon(txtMaPhieu.Text, txtMaDocGia.Text, txtMaNhanVien.Text, ngayMuon);
                obj_phieu.themPhieu(pm);

                MessageBox.Show("Tạo phiếu thành công, nhập tài liệu mượn");

                //cho phép nhập và hiển thị thông tin chi tiết tài liệu mượn của Phiếu vừa tạo ra:
                loadDgv();


            }
            catch {
                MessageBox.Show("Đã tồn tại mã phiếu: " + txtMaPhieu.Text);
            }


        }

        private void txtNgayMuon_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaDocGia_TextChanged(object sender, EventArgs e)
        {
            if (txtMaDocGia.Text != "")
            {
                string ht = obj_phieu.tenDocGia(txtMaDocGia.Text);

                //neu nhu khong tim thay ma sv thi ko lam gi, và xóa text cũ
                if (ht.Equals(""))
                {
                    txtTenDocGia.Text = "";
                    return;
                }

                txtTenDocGia.Text = ht;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtMaNhanVien_TextChanged_1(object sender, EventArgs e)
        {
            if (txtMaNhanVien.Text != "")
            {
                string ht = obj_phieu.tenNhanVien(txtMaNhanVien.Text);

                //neu nhu khong tim thay ma sv thi ko lam gi, và xóa text cũ
                if (ht.Equals(""))
                {
                    txtTenNhanVien.Text = "";
                    return;
                }

                txtTenNhanVien.Text = ht;
            }
        }

        private void dgvTaiLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSach.Enabled = true;
            txtTenTL.Enabled = false;
            dtpNgayTra.Enabled = true;
            txtSLM.Enabled = true;

            btnThemTL.Enabled = true;
            btnSuaTL.Enabled = true;
            btnXoaTL.Enabled = true;

            //dua len text
            int i = dgvTaiLieu.CurrentCell.RowIndex;

            if (dgvTaiLieu.Rows.Count - 1 == i ) {
                return;
            }

            txtMaSach.Text = dgvTaiLieu.Rows[i].Cells[0].Value.ToString();
            txtTenTL.Text = dgvTaiLieu.Rows[i].Cells[1].Value.ToString();
            txtSLM.Text = dgvTaiLieu.Rows[i].Cells[2].Value.ToString();
            dtpNgayTra.Text = dgvTaiLieu.Rows[i].Cells[3].Value.ToString();

            if (dgvTaiLieu.Rows[i].Cells[4].Value.ToString().Trim().Equals("Đang mượn"))
            {
                cbTrangThai.SelectedIndex = 0;
            }
            else {
                cbTrangThai.SelectedIndex = 1;
                btnSuaTL.Enabled = false;
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            txtMaSach.Text = "";

            txtMaSach.Enabled = true;
            txtTenTL.Enabled = false;
            dtpNgayTra.Enabled = true;
            txtSLM.Enabled = true;
        }

        private void btnThemTL_Click(object sender, EventArgs e)
        {
            //tạo một đối tượng chi tiết
            PhieuMuonChiTiet CT = new PhieuMuonChiTiet();
            CT.MaPMuon = txtMaPhieu.Text; //mã lấy mã hiện tại của Phiếu
            CT.MaSach = txtMaSach.Text;
            CT.SLMuon = Convert.ToInt32(txtSLM.Value);
            CT.NgayTra = dtpNgayTra.Value;
            CT.TrangThai = "Đang mượn";

            //mã phiếu không được thiếu
            if (txtMaPhieu.Text == "") {
                MessageBox.Show("Hãy điền mã phiếu !");
                return;
            }

            //kiểm tra ngày hợp lệ
            /*DateTime now = DateTime.Now;
            DateTime enter_value = dtpNgayTra.Value;
            if (now > enter_value) {
                MessageBox.Show("Thời gian không hợp lệ - Thời gian > ngày hiện tại");
                //quay tro lai ngay hien tai
                dtpNgayTra.Value = now;
                return;
            }*/

            //điều kiện hợp lê: số lương có >= số lượng mượn
            if (obj_phieu.check_soLuong(txtMaSach.Text, Convert.ToInt32(txtSLM.Value)))
            {
                try
                {
                    //Thêm thông tin vào phiếu chi tiết
                    obj_phieu.themChiTietTaiLieuMuon(CT);

                    //cập nhật lại số lượng còn lại trong bảng Tài Liêu:
                    obj_phieu.capNhatSoLuongThem(txtMaSach.Text, Convert.ToInt32(txtSLM.Value));

                    //load du lieu
                    loadDgv();
                    //MessageBox.Show("Thành công!");
                }
                catch
                {
                    MessageBox.Show("Thêm lỗi - kiểm tra mã phiếu, hoặc mã tài liệu đã tồn tại!");
                }
            }
            else { 
                MessageBox.Show("Số lượng hiện tại không đủ!");
                txtSLM.Focus();
            }
        }

        private void btnXoaTL_Click(object sender, EventArgs e)
        {
            //kiếm tra trống
            if(txtMaPhieu.Text == "" || txtMaSach.Text == "")
            {
                MessageBox.Show("Không được bỏ trống MÃ PHIẾU / MÃ SÁCH ");
                return;
            }
            DialogResult tb = MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tb == DialogResult.Yes) {
                try
                {
                    //nếu Trạng thái = "Đã trả" thì khi xóa không cần update lại số lượng, bởi vì khi trả sách đã Update rồi
                    if (cbTrangThai.Text.Trim().Equals("Đã trả")) {
                        obj_phieu.xoaChiTietTaiLieuMuon(txtMaPhieu.Text, txtMaSach.Text);
                        loadDgv();
                        return;
                    }

                    //xóa
                    obj_phieu.xoaChiTietTaiLieuMuon(txtMaPhieu.Text, txtMaSach.Text);

                    //cập nhật lại số lượng có: sl có + sl đã xóa
                    obj_phieu.capNhatSoLuongXoa(txtMaSach.Text, Convert.ToInt32(txtSLM.Value));

                    loadDgv();  
                    //Clear
                    txtMaSach.Text = "";
                    txtTenTL.Text = "";
                    txtSLM.Value = 1;
                    txtMaSach.Focus();
                }
                catch {
                    MessageBox.Show("Có lỗi, kiểm tra lại!");
                }       
            }
        }

        private void btnSuaTL_Click(object sender, EventArgs e)
        {
            //kiếm tra trống
            if (txtMaPhieu.Text == "" || txtMaSach.Text == "")
            {
                MessageBox.Show("Không được bỏ trống MÃ PHIẾU / MÃ SÁCH ");
                return;
            }

            //kiểm tra ngày hợp lệ
            /*DateTime now = DateTime.Now;
            DateTime enter_value = dtpNgayTra.Value;
            if (now > enter_value)
            {
                MessageBox.Show("Thời gian không hợp lệ - Thời gian > ngày hiện tại");
                //quay tro lai ngay hien tai
                dtpNgayTra.Value = now;
                return;
            }*/

            //tạo một đối tượng chi tiết
            PhieuMuonChiTiet CT = new PhieuMuonChiTiet();
            CT.MaPMuon = txtMaPhieu.Text; //mã lấy mã hiện tại của Phiếu
            CT.MaSach = txtMaSach.Text;
            CT.SLMuon = Convert.ToInt32(txtSLM.Value); 
            CT.NgayTra = dtpNgayTra.Value;
            CT.TrangThai = cbTrangThai.Text;

            //điều kiện hợp lê: số lương có >= số lượng mượn
            if (obj_phieu.check_soLuong_Sua(txtMaPhieu.Text,txtMaSach.Text, Convert.ToInt32(txtSLM.Value)))
            {
                try
                {
                    //cap nhat lai so luong
                    obj_phieu.capNhatSoLuongCapNhat(txtMaPhieu.Text, txtMaSach.Text, Convert.ToInt32(txtSLM.Value));
                    obj_phieu.suaChiTietTaiLieuMuon(CT);

                    loadDgv();
                    MessageBox.Show("Sửa thành công!");
                }
                catch
                {
                    MessageBox.Show("Có lỗi, kiểm tra lại!");
                }
            }
            else {
                MessageBox.Show("Số lượng hiện tại không đủ!");
                txtSLM.Focus();
            }
        }

        private void txtMaSach_TextChanged(object sender, EventArgs e)
        {
            if (txtMaSach.Text == "") {
                btnThemTL.Enabled = false;
                btnSuaTL.Enabled = false;
                btnXoaTL.Enabled = false;
            }

            if (txtMaSach.Text != "")
            {
                string tenSach = obj_phieu.tenSach(txtMaSach.Text);

                //Hiển thị nút "thêm" và "sửa", "xóa"
                btnThemTL.Enabled = true;
                btnSuaTL.Enabled = true;
                btnXoaTL.Enabled = true;

                //neu nhu khong tim thay ma sv thi ko lam gi, và xóa text cũ
                if (tenSach.Equals(""))  //rỗng từ bên BUS truyền sang
                {
                    txtTenTL.Text = "<Tài liệu không tồn tại, xin kiểm tra lại!>";

                    //Ẩn nút "thêm" và "sửa", "xóa"
                    btnThemTL.Enabled = false;
                    btnSuaTL.Enabled = false;                    
                    btnXoaTL.Enabled = false;
                    return;
                }
                txtTenTL.Text = tenSach;
            }
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        //Xóa
        private void button2_Click(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"^[P]\d{2,5}$");
            if (!reg.IsMatch(txtMaPhieu.Text))
            {
                MessageBox.Show("Sai định dạng mã phiếu, ví dụ: P01");
                return;
            }

            DialogResult tb = MessageBox.Show("Bạn có muốn xóa mã phiếu: " + txtMaPhieu.Text, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tb == DialogResult.Yes) {
                try
                {
                    //xoa
                    obj_phieu.XoaPhieu(txtMaPhieu.Text);
                    txtMaPhieu.Text = "";
                    txtMaDocGia.Text = "";
                    txtMaNhanVien.Text = "";

                    MessageBox.Show("Đã xóa");
                }
                catch{
                    MessageBox.Show("Lỗi Xóa - Phiếu mượn đang tồn tại các thông tin tài liệu mượn");
                }
                
            }
            else {
                return;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //regex
            Regex reg = new Regex(@"^[P]\d{2,5}$");
            if (!reg.IsMatch(txtMaPhieu.Text))
            {
                MessageBox.Show("Sai định dạng mã phiếu, ví dụ: P01");
                return;
            }

            if (txtTenNhanVien.Text == "" || txtTenDocGia.Text == "")
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin");
                return;
            }

            DateTime ngayMuon = dtpNgayMuon.Value;
            PhieuMuon pm = new PhieuMuon(txtMaPhieu.Text, txtMaDocGia.Text, txtMaNhanVien.Text, ngayMuon);

            DialogResult tb = MessageBox.Show("Cập nhật phiếu: " + txtMaPhieu.Text+" ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tb == DialogResult.Yes)
            {
                //cap nhat
                obj_phieu.SuaPhieu(pm);

                //hiển thị lại lên textbox
                string[] param = obj_phieu.layThongTinPhieu2(txtMaPhieu.Text);
                //dua len textbox
                txtMaDocGia.Text = param[0];
                txtTenDocGia.Text = param[1];
                dtpNgayMuon.Text = param[2];
                txtMaNhanVien.Text = param[3];
                txtTenNhanVien.Text = param[4];

                //thông báo
                MessageBox.Show("Cập nhật thành công phiếu:" +txtMaPhieu.Text);
            }
            else
            {
                return;
            }

        }


        private void ExportPdf(DataGridView dataGridView)
        {

            string ARIALUNI_TFF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.TTF");

            //Create a base font object making sure to specify IDENTITY-H
            BaseFont bf = BaseFont.CreateFont(ARIALUNI_TFF, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(dataGridView.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 50;
            //int[] intTblWidth = { 20, 50, 50, 50,50 };

            //pdfTable.setH


            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable.DefaultCell.BorderWidth = 1;

            //Font f = new System.Drawing.Font(bf, 12, Font.NORMAL);
            //Font f = new Font(bf, 12, Font.NORMAL);
            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 14, iTextSharp.text.Font.NORMAL);
            //Adding Header row
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text))
                { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE };
                cell.MinimumHeight = 30;
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    try
                    {
                        String s = cell.Value.ToString();
                        //PdfCe
                        PdfPCell cell2 = new PdfPCell(new Phrase(s, text));
                        cell2.MinimumHeight = 30;
                        pdfTable.AddCell(cell2);
                    }
                    catch { }
                }
            }

            //Exporting to PDF
            string folderPath = "C:\\PDFs\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "QuanLyMuonSach.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                // Tieude


                // khoang trang
                var spacer = new Paragraph("")
                {
                    SpacingBefore = 10f,
                    SpacingAfter = 10f,
                };

                // Bang
                var headTable = new PdfPTable(new[] { .5f, 1f })
                {
                    HorizontalAlignment = Left,
                    WidthPercentage = 75,
                    DefaultCell = { MinimumHeight = 30f, BorderWidthLeft = 2 }
                };
                //headTable.DefaultCell.BorderWidth = 0f;
                /*
                var cell1 = new PdfPCell(new Phrase("Mã:", text))
                {
                    MinimumHeight = 25f
                };
                
                var cell2 = new PdfPCell(new Phrase(txtTenThuVien.Text, text))
                {
                    MinimumHeight = 25f
                };
                */
                headTable.WidthPercentage = 50; // set Width for table
                headTable.HorizontalAlignment = Element.ALIGN_CENTER; // align: center
                //headTable.AddCell(cell1);
                //headTable.AddCell(cell2);
                headTable.AddCell(new PdfPCell(new Phrase("Mã phiếu", text)));
                headTable.AddCell(new PdfPCell(new Phrase(txtMaPhieu.Text, text)));
                headTable.AddCell(new PdfPCell(new Phrase("Mã độc giả", text)));
                headTable.AddCell(new PdfPCell(new Phrase(txtMaDocGia.Text, text)));
                headTable.AddCell(new PdfPCell(new Phrase("Tên độc giả", text)));
                headTable.AddCell(new PdfPCell(new Phrase(txtTenDocGia.Text, text)));
                headTable.AddCell(new PdfPCell(new Phrase("Ngày mượn", text)));
                headTable.AddCell(new PdfPCell(new Phrase(dtpNgayMuon.Value.ToString("dd/MM/yyyy"), text)));
                headTable.AddCell(new PdfPCell(new Phrase("Mã nhân viên", text)));
                headTable.AddCell(new PdfPCell(new Phrase(txtMaNhanVien.Text, text)));
                headTable.AddCell(new PdfPCell(new Phrase("Tên nhân viên", text)));
                headTable.AddCell(new PdfPCell(new Phrase(txtTenNhanVien.Text, text)));

                iTextSharp.text.Font text2 = new iTextSharp.text.Font(bf, 24, iTextSharp.text.Font.BOLD);
                Paragraph p1 = new Paragraph("QUẢN LÝ MƯỢN SÁCH", text2);
                p1.Alignment = Element.ALIGN_CENTER;

                pdfDoc.Add(p1);
                pdfDoc.Add(spacer);
                pdfDoc.Add(headTable);
                pdfDoc.Add(spacer);
                pdfDoc.Add(pdfTable);


                pdfDoc.Close();
                stream.Close();
            }
        }


        //code in ở đây
        private void button4_Click(object sender, EventArgs e)
        {
            ExportPdf(dgvTaiLieu);
            MessageBox.Show("In thành công! Kiểm tra tại C:\\PDFs");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tb == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtMaPhieu.Text = "";
            txtMaDocGia.Text = "";
            txtMaNhanVien.Text = "";
        }
    }
}
