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
using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
namespace GUI
{
    public partial class NgayMuonQuaHanGUI : Form
    {
        public string maNV;
        public int check;
        NgayMuonQuaHanBUS obj = new NgayMuonQuaHanBUS();
        public NgayMuonQuaHanGUI()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            DataTable dt = obj.Show();
            
/*            for (int i = 0; i < dt.Rows.Count; i++) {
                dt.Rows[i]["e"] = Convert.ToDateTime("2099-02-02").ToString("dd-MM-yyyy");
            }*/

            dgvList.DataSource = dt;

            for (int i = 0; i < dgvList.Rows.Count - 1; i++)
            {
                dgvList.Rows[i].Cells[0].Value = i + 1;
            }
           
        }
        private void NgayMuonQuaHanGUI_Load(object sender, EventArgs e)
        {
            LoadData();
            
          
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void ExportPdf(DataGridView dataGridView)
        {

            string ARIALUNI_TFF = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.TTF");

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
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE };
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
            using (FileStream stream = new FileStream(folderPath + "NgayMuonQuaHan.pdf", FileMode.Create))
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
                    WidthPercentage = 150,
                    DefaultCell = { MinimumHeight = 30f, BorderWidthLeft = 2 }
                };
                //headTable.DefaultCell.BorderWidth = 0f;
                var cell1 = new PdfPCell(new Phrase("Tên thư viện:", text))
                {
                    MinimumHeight = 25f
                };
                var cell2 = new PdfPCell(new Phrase("Tên thư x", text))
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
                headTable.AddCell(new PdfPCell(new Phrase("Ngô Xuân Giang", text)));

                iTextSharp.text.Font text2 = new iTextSharp.text.Font(bf, 24, iTextSharp.text.Font.BOLD);
                Paragraph p1 = new Paragraph("Tài liệu mượn quá han", text2);
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

        private void btnIn_Click(object sender, EventArgs e)
        {
            ExportPdf(dgvList);
            MessageBox.Show("In thành công! Kiểm tra tại C:\\PDFs");
        }

        private void NgayMuonQuaHanGUI_Load_1(object sender, EventArgs e)
        {
            lbTenNguoiLap.Text =  obj.getTenNhanVien(maNV);
            string now = DateTime.Now.ToString("dd-MM-yyyy");
            lbNgayLap.Text = now;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
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
