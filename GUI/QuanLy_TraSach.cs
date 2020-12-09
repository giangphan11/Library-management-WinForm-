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

namespace GUI
{
    public partial class QuanLy_TraSach : Form
    {
        public int check;
        public string maNV;
        PhieuTraSachBUS obj = new PhieuTraSachBUS();
        
        public QuanLy_TraSach()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        
        //Tìm kiếm
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtMaDGia.Text != "")
            {
                if (!obj.check_maDG(txtMaDGia.Text)) {
                    //thong bao
                    lbThongBao.Text = "Không tồn tại mã độc giả: " + txtMaDGia.Text;
                    lbThongBao.ForeColor = Color.Red;
                    lbThongBao.Show();

                    //Disnable
                    list1.Enabled = false;
                    list1.ForeColor = Color.Gray;

                    list2.Enabled = false;
                    list2.ForeColor = Color.Gray;
                }
                else
                {
                    //enable
                    list1.Enabled = true;
                    list1.ForeColor = Color.Black;

                    list2.Enabled = true;
                    list2.ForeColor = Color.Black;

                    //do du lieu
                    DataTable dt = obj.timkiem(txtMaDGia.Text);
                    list1.DataSource = dt;

                    //nếu như với mã DG vừa tìm đc không có phiếu mượn nào thì disnable list2
                    if (dt.Rows.Count == 0) {
                        list2.Enabled = false;
                        list2.ForeColor = Color.Gray;
                    }

                    //thong bao
                    lbThongBao.Text = "Kết quả tìm được: " + (list1.RowCount-1) + " phiếu mượn";
                    lbThongBao.ForeColor = Color.Blue;
                    lbThongBao.Show();
                }    
            }
            else {
                MessageBox.Show("Mã độc giả không được để trống!");
            }
        }

        private void QuanLy_TraSach_Load(object sender, EventArgs e)
        {
            lbThongBao.Hide();
            btnTraSach.Enabled = false;

            txtMaSach.Enabled = false;
            txtTenSach.Enabled = false;
            dtpNgayTra.Enabled = false;
            txtSoLuongTra.Enabled = false;
            txtMaPhieu.Enabled = false;
        }

        private void txtMaDGia_TextChanged(object sender, EventArgs e)
        {
            if (txtMaDGia.Text == "") {
                lbThongBao.Hide();
            }
        }

        //hien thi len lable
        private void list1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //lay dong hien tai
            int dong = list1.CurrentCell.RowIndex;
            if (list1.Rows.Count - 1 == dong)
            {
                return;
            }

            //lay ma phieu
            string maPhieu = list1.Rows[dong].Cells[0].Value.ToString();

            //Mang gia tri
            string[] param = obj.layThongTinPhieu(maPhieu);
            string ngay = param[2].Substring(0, 9);
            string oDate = Convert.ToDateTime(ngay).ToString("dd/MM/yyyy");

            //hien thi label
            lbMaPhieu.Text = maPhieu;
            lbMaDocGia.Text = param[0];
            lbTenDocGia.Text = param[1];
            lbNgayMuon.Text = oDate;
            lbMaNV.Text = param[3];
            lbTenNV.Text = param[4];

            //hien thi chi tiet cac tai lieu muon (PhieuMuonChiIiet5)
            loadList2();    
        }

        public void loadList2() {
            try
            {
                int dong = list1.CurrentCell.RowIndex;
                string maPhieu = list1.Rows[dong].Cells[0].Value.ToString();

                DataTable dt = new DataTable();
                dt = obj.chiTietMuonSach(maPhieu);
                list2.DataSource = dt;

                //dinh dang lai ngay/thang/nam trong dgv
                list2.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";

             }
            catch
            {
                MessageBox.Show("Có lỗi, vui lòng kiểm tra lại");
            }
        }

        private void list2_CellClick(object sender, DataGridViewCellEventArgs e)
        {   //hien thi len form tailieu
            int dong = list2.CurrentCell.RowIndex;
            if (list1.Rows.Count - 1 == 0)
            {
                return;
            }

            txtMaSach.Text = list2.Rows[dong].Cells[0].Value.ToString();
            txtTenSach.Text = list2.Rows[dong].Cells[1].Value.ToString();
            txtMaPhieu.Text = lbMaPhieu.Text;
            txtSoLuongTra.Text = list2.Rows[dong].Cells[2].Value.ToString();

            //button
            btnTraSach.Enabled = true;
        }

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            try
            {
                string date = DateTime.Now.ToString("yyyy-MM-dd");
                obj.traSach(lbMaPhieu.Text, txtMaSach.Text,Convert.ToInt32(txtSoLuongTra.Text), date);
                loadList2();
                MessageBox.Show("Trả thành công!");
                btnTraSach.Enabled = false;
            }
            catch {
                MessageBox.Show("Có lỗi, vui lòng kiểm tra lại!");
                //MessageBox.Show("Có lỗi, Cuốn này đã trả rồi!");
            }
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

        private void txtSoLuongTra_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tb == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
