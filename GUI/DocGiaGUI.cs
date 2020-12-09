using DTO;
using BUS;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace GUI
{
    public partial class DocGiaGUI : Form
    {
        public DocGiaGUI()
        {
            InitializeComponent();
        }
        DocGia docGiaChon = null;
        public string maNV;
        public int check;



        DocGia Dg = new DocGia(); //khai bao lop doi tuong LOP
        DoiTuong Dt = new DoiTuong();
        DocGiaBUS loph = new DocGiaBUS(); //khai bao lop doi tuong logic
        //Data da = new Data();

        public void LoadData()
        {
            dgvDocGia.DataSource = loph.Show();

            //lam moi
            txtMaDGia.ResetText();
            txtHoten.ResetText();
            this.CenterToScreen();


        }
        string pMaDocGia = "^[D][G][0-9]{2}$";
        string pTenDocGia = "^[a-zA-Z_ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶ" +
        "ẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợ" +
        "ụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ\\s]+$";


        private void DocGiaGUI_Load(object sender, EventArgs e)
        {
            LoadData();
            cbbMaDTuong.DataSource = loph.cbDGV();
            cbbMaDTuong.DisplayMember = "TenDTuong";
            cbbMaDTuong.ValueMember = "MaDTuong";
            (dgvDocGia.Columns["MaDTuong"] as DataGridViewComboBoxColumn).DataSource = loph.cbDGV();
            (dgvDocGia.Columns["MaDTuong"] as DataGridViewComboBoxColumn).DisplayMember = "TenDTuong";
            (dgvDocGia.Columns["MaDTuong"] as DataGridViewComboBoxColumn).ValueMember = "MaDTuong";
        }

        private void dgvDocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int dongchon = e.RowIndex;
            if (dongchon != -1 && dongchon < dgvDocGia.Rows.Count - 1)
            {
                int dong = dgvDocGia.CurrentCell.RowIndex;
                string gt = dgvDocGia.Rows[dong].Cells[2].Value.ToString().Trim();
                //MessageBox.Show(gt);
                if (gt.Equals("nam"))
                {
                    rNam.Select();
                }
                else
                {
                    rNu.Select();
                }
                docGiaChon = new DocGia();
                docGiaChon.MaDocGia = dgvDocGia.Rows[e.RowIndex].Cells[0].Value.ToString();
                docGiaChon.HoTen = Convert.ToString(dgvDocGia.Rows[e.RowIndex].Cells[1].Value);
                docGiaChon.GioiTinh = dgvDocGia.Rows[e.RowIndex].Cells[2].Value.ToString();
                docGiaChon.NgaySinh = DateTime.Parse(dgvDocGia.Rows[e.RowIndex].Cells[3].Value.ToString());
                docGiaChon.MaDoiTuong = dgvDocGia.Rows[e.RowIndex].Cells[4].Value.ToString();
                docGiaChon.NgayCap = DateTime.Parse(dgvDocGia.Rows[e.RowIndex].Cells[5].Value.ToString());
                docGiaChon.NgayGHan = DateTime.Parse(dgvDocGia.Rows[e.RowIndex].Cells[6].Value.ToString());
                //
                txtMaDGia.Text = Convert.ToString(dgvDocGia.Rows[e.RowIndex].Cells[0].Value);
                txtHoten.Text = Convert.ToString(dgvDocGia.Rows[e.RowIndex].Cells[1].Value);
                //txtGTinh.Text = Convert.ToString(dgvDocGia.Rows[e.RowIndex].Cells[2].Value);
                //rNu.Select();
                dtpNSinh.Text = Convert.ToString(dgvDocGia.Rows[e.RowIndex].Cells[3].Value);
                cbbMaDTuong.SelectedValue = Convert.ToString(dgvDocGia.Rows[e.RowIndex].Cells[4].Value);
                dtpNgayCap.Text = Convert.ToString(dgvDocGia.Rows[e.RowIndex].Cells[5].Value);
                dtpNgayGHan.Text = Convert.ToString(dgvDocGia.Rows[e.RowIndex].Cells[6].Value);
            }
            else return;
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {


            if (txtMaDGia.TextLength == 0)
            {
                MessageBox.Show("Mã Độc Giả Không Được Bỏ Trống");
            }
            else if (txtHoten.TextLength == 0)
            {
                MessageBox.Show("Tên Độc Giả Không Được Bỏ Trống");
            }

            else
            {

                string err = "";
                if (!Regex.IsMatch(txtMaDGia.Text, pMaDocGia))
                {
                    err += "\n Mã độc giả phải bắt đầu bằng 'DG', tiếp sau là 2 số";
                }
                if (!Regex.IsMatch(txtHoten.Text, pTenDocGia))
                {
                    err += "\n Họ tên phải là các kỹ tự Alphabet";
                }
                string gt = "";
                if (!rNam.Checked && !rNu.Checked)
                {
                    MessageBox.Show("Bạn cần chọn giới tính");
                    return;
                }
                if (err == "")
                {
                    try
                    {
                        if (rNam.Checked)
                        { gt = "Nam"; }
                        else if (rNu.Checked)
                        { gt = "Nu"; }

                        Dg.MaDocGia = txtMaDGia.Text;
                        Dg.HoTen = txtHoten.Text;
                        Dg.GioiTinh = gt;
                        Dg.NgaySinh = dtpNSinh.Value;
                        Dg.MaDoiTuong = cbbMaDTuong.SelectedValue.ToString();
                        Dg.NgayCap = dtpNgayCap.Value;
                        Dg.NgayGHan = dtpNgayGHan.Value;
                        //MessageBox.Show("aa"+Dg.MaDGia+Dg.HTen+ Dg.GTinh+ Dg.NSinh+ Dg.MaDGia+Dg.NgayCap+ Dg.NgayGHan);

                        loph.InsertLop(Dg.MaDocGia, Dg.HoTen, Dg.GioiTinh, Dg.NgaySinh, Dg.MaDoiTuong, Dg.NgayCap, Dg.NgayGHan);
                        MessageBox.Show("Thêm Thành Công!!!");
                        DocGiaGUI_Load(sender, e);
                    }
                    catch
                    {
                        MessageBox.Show("loi");
                    }
                }
                else
                {
                    MessageBox.Show(err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaDGia.TextLength == 0)
            {
                MessageBox.Show("Mã Độc Giả Không Được Bỏ Trống");
            }
            else if (txtHoten.TextLength == 0)
            {
                MessageBox.Show("Tên Độc Giả Không Được Bỏ Trống");
            }

            else
            {
                string err = "";
                if (!Regex.IsMatch(txtMaDGia.Text, pMaDocGia))
                {
                    err += "\n Mã độc giả phải bắt đầu bằng 'DG', tiếp sau là 2 số";
                }
                if (!Regex.IsMatch(txtHoten.Text, pTenDocGia))
                {
                    err += "\n Họ tên phải là các kỹ tự Alphabet";
                }
                if (err == "")
                {
                    try
                    {
                        string gt = "";
                        if (!rNam.Checked && !rNu.Checked)
                        {
                            MessageBox.Show("Bạn cần chọn giới tính");
                            return;
                        }

                        if (rNam.Checked)
                        { gt = "Nam"; }
                        else if (rNu.Checked)
                        { gt = "Nu"; }

                        Dg.MaDocGia = txtMaDGia.Text;
                        Dg.HoTen = txtHoten.Text;
                        Dg.GioiTinh = gt;
                        Dg.NgaySinh = dtpNSinh.Value;
                        Dg.MaDoiTuong = cbbMaDTuong.SelectedValue.ToString();
                        Dg.NgayCap = dtpNgayCap.Value;
                        Dg.NgayGHan = dtpNgayGHan.Value;
                        loph.UpdateLop(Dg.MaDocGia, Dg.HoTen, Dg.GioiTinh, Dg.NgaySinh, Dg.MaDoiTuong, Dg.NgayCap, Dg.NgayGHan);
                        MessageBox.Show("Sửa thành công!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DocGiaGUI_Load(sender, e);

                    }
                    catch
                    {
                        MessageBox.Show("Lỗi sửa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rs = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    if (txtMaDGia.TextLength == 0)
                    {
                        MessageBox.Show("Mã Đọc giả Không Được Bỏ Trống");
                    }
                    else
                    {
                        Dg.MaDocGia = txtMaDGia.Text;
                        loph.DeleteLop(Dg.MaDocGia);
                        MessageBox.Show("Xóa thành công!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi xóa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtMaDGia.TextLength == 0)
            {
                MessageBox.Show("Mã Đọc giả Không Được Bỏ Trống");
            }
            else
            {
                dgvDocGia.DataSource = loph.LookLop(txtMaDGia.Text);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtMaDGia.ResetText();
            txtHoten.ResetText();
        }

        private void txtMaDGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tb == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //quay lai admin
            var frm = new TrangChu_QuanTriVien();
            frm.maNV = maNV;
            frm.Show();
            this.Hide();
        }
        private void ExportPdf( DocGia docGia)
        {

            string ARIALUNI_TFF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.TTF");

            //Create a base font object making sure to specify IDENTITY-H
            BaseFont bf = BaseFont.CreateFont(ARIALUNI_TFF, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            //Creating iTextSharp Table from the DataTable data
            

            //Font f = new System.Drawing.Font(bf, 12, Font.NORMAL);
            //Font f = new Font(bf, 12, Font.NORMAL);
            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 14, iTextSharp.text.Font.NORMAL);
            //Adding Header row
            

            //Exporting to PDF
            string folderPath = "C:\\PDFs\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "TheDocGia"+docGia.MaDocGia+".pdf", FileMode.Create))
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
                var headTable = new PdfPTable(new[] { .3f, .7f })
                {
                    HorizontalAlignment = Left,
                    WidthPercentage = 75,
                    DefaultCell = { MinimumHeight = 25f }
                };
                headTable.DefaultCell.BorderWidth = 1;
                headTable.DefaultCell.MinimumHeight=30f ;

                headTable.WidthPercentage = 30; // set Width for table
                headTable.HorizontalAlignment = Element.ALIGN_CENTER; // align: center
                headTable.AddCell(new PdfPCell(new Phrase("Mã độc giả", text)));
                headTable.AddCell(new PdfPCell(new Phrase(docGia.MaDocGia, text)));
                headTable.AddCell(new PdfPCell(new Phrase("Họ và tên", text)));
                headTable.AddCell(new PdfPCell(new Phrase(docGia.HoTen, text)));
                headTable.AddCell(new PdfPCell(new Phrase("Giới tính", text)));
                headTable.AddCell(new PdfPCell(new Phrase(docGia.GioiTinh, text)));
                headTable.AddCell(new PdfPCell(new Phrase("Ngày sinh", text)));
                headTable.AddCell(new PdfPCell(new Phrase(docGia.NgaySinh.ToString("dd/MM/yyyy"), text)));
                headTable.AddCell(new PdfPCell(new Phrase("Ngày cấp thẻ", text)));
                headTable.AddCell(new PdfPCell(new Phrase(docGia.NgayCap.ToString("dd/MM/yyyy"), text)));
                headTable.AddCell(new PdfPCell(new Phrase("Ngày gia hạn thẻ", text)));
                headTable.AddCell(new PdfPCell(new Phrase(docGia.NgayGHan.ToString("dd/MM/yyyy"), text)));

                iTextSharp.text.Font text2 = new iTextSharp.text.Font(bf, 24, iTextSharp.text.Font.BOLD);
                Paragraph p1 = new Paragraph("THÔNG TIN THẺ", text2);
                p1.Alignment = Element.ALIGN_CENTER;

                pdfDoc.Add(p1);
                pdfDoc.Add(spacer);
                pdfDoc.Add(headTable);
                pdfDoc.Add(spacer);
                //pdfDoc.Add(pdfTable);


                pdfDoc.Close();
                stream.Close();
            }
        }
        private void btnInThe_Click(object sender, EventArgs e)
        {
            if (docGiaChon == null)
            {
                MessageBox.Show("Mời chọn độc giả !");
                return;
            }
            else
            {
                ExportPdf(docGiaChon);
                MessageBox.Show("In thành công! Kiểm tra tại C:\\PDFs");
            }
        }
    }
}
