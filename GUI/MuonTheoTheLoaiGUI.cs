using BUS;
using DTO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class MuonTheoTheLoaiGUI : Form
    {
        public string maNV;
        public int check;
        MuonTheoTheLoaiBUS lopmttl = new MuonTheoTheLoaiBUS(); //khai bao lop doi tuong logic
        public MuonTheoTheLoaiGUI()
        {
            InitializeComponent();
        }


        
        public void LoadData()
        {
            string now = DateTime.Now.ToString("dd-MM-yyyy");
            //DateTime oDateNow = DateTime.Parse(now);
            DateTime oDateNow = DateTime.ParseExact(now, "dd-MM-yyyy", null);
            string iDate = "1970-01-01";
            DateTime oDate = DateTime.Parse(iDate).Date;
            /*MessageBox.Show(dpBatDau.Value.ToString("dd-MM-yyyy"));
            MessageBox.Show(oDate.ToString("dd-MM-yyyy"));*/
            //MessageBox.Show(now);

            lbNgayLap.Text = now;
            //lbNguoiLapbc.Text = lopmttl.getTenNhanVien("NV01").ToString();

            if (dpBatDau.Value.ToString("dd-MM-yyyy").Equals(now) && dpKetThuc.Value.ToString("dd-MM-yyyy").Equals(now))
            {
                dgvThongKeMuon.DataSource = lopmttl.Show(oDate, oDateNow);
                //stt
                for (int i = 0; i < dgvThongKeMuon.Rows.Count - 1; i++)
                {
                    dgvThongKeMuon.Rows[i].Cells[0].Value = i + 1;
                }
            }
            else
            {
                dgvThongKeMuon.DataSource = lopmttl.Show(dpBatDau.Value, dpKetThuc.Value);
                //stt
                for (int i = 0; i < dgvThongKeMuon.Rows.Count - 1; i++)
                {
                    dgvThongKeMuon.Rows[i].Cells[0].Value = i + 1;
                }
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
            using (FileStream stream = new FileStream(folderPath + "MuonTheoTheLoai.pdf", FileMode.Create))
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
                var cell1 = new PdfPCell(new Phrase("Tên thư viện:", text))
                {
                    MinimumHeight = 25f
                };
                var cell2 = new PdfPCell(new Phrase("Thư viện trường Đại học Công nghiệp Hà Nội", text))
                {
                    MinimumHeight = 25f
                };
                headTable.WidthPercentage = 50; // set Width for table
                headTable.HorizontalAlignment = Element.ALIGN_CENTER; // align: center
                headTable.AddCell(cell1);
                headTable.AddCell(cell2);
                headTable.AddCell(new PdfPCell(new Phrase("Ngày lập", text)));
                headTable.AddCell(new PdfPCell(new Phrase(DateTime.Now.ToString("dd/MM/yyyy"), text)));
                headTable.AddCell(new PdfPCell(new Phrase("Người lập:", text)));
                headTable.AddCell(new PdfPCell(new Phrase(lbNguoiLapbc.Text, text)));

                iTextSharp.text.Font text2 = new iTextSharp.text.Font(bf, 24, iTextSharp.text.Font.BOLD);
                Paragraph p1 = new Paragraph("BÁO CÁO THỐNG KÊ SỐ LẦN MƯỢN THEO THỂ LOẠI", text2);
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


        private void MuonTheoTheLoaiGUI_Load(object sender, EventArgs e)
        {
            string now = DateTime.Now.ToString("dd-MM-yyyy");
            lbNgayLap.Text = now;

            //thong tin nguoi dang nhap
            lbNguoiLapbc.Text = lopmttl.getTenNhanVien(maNV);
            /*string ten = lopmttl.getTenNhanVien(maNV);*/
            //MessageBox.Show("ma :" + maNV + "ten: " + ten ) ;

            this.CenterToScreen();
        }

        private void btnLocTheoNgay_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            ExportPdf(dgvThongKeMuon);
            MessageBox.Show("In thành công! Kiểm tra tại C:\\PDFs");
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tb == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}

