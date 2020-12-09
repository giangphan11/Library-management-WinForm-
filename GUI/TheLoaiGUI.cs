using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
namespace GUI
{
    public partial class TheLoaiGUI : Form
    {
        public string maNV;
        public TheLoaiGUI()
        {
            InitializeComponent();
        }
        private void loadData()
        {
            TheLoaiBUS theLoaiBUS = new TheLoaiBUS();
            List<TheLoai> dsTL = theLoaiBUS.getListTheLoai();

            int row = 0;
            gvTheLoai.Rows.Clear();
            foreach (TheLoai tl in dsTL)
            {
                gvTheLoai.Rows.Add();
                gvTheLoai.Rows[row].Cells[0].Value = tl.MaTLoai;
                gvTheLoai.Rows[row].Cells[1].Value = tl.TenTLoai;
                gvTheLoai.Rows[row].Cells[2].Value = tl.GhiChu;
                row++;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txtMa.Focus();
            loadData();
        }

        private void gvTheLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = e.RowIndex;
            if (vt != -1 && vt < gvTheLoai.Rows.Count - 1)
            {
                DataGridViewRow row = gvTheLoai.Rows[vt];
                txtMa.Text = row.Cells[0].Value.ToString();
                txtTen.Text = row.Cells[1].Value.ToString();
                txtGhiChu.Text = row.Cells[2].Value.ToString();
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            loadData();
            txtMa.Text = "";
            txtTen.Text = "";
            txtGhiChu.Text = "";
            txtMa.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            TheLoai theLoai = new TheLoai();
            theLoai.MaTLoai = txtMa.Text;
            theLoai.TenTLoai = txtTen.Text;
            theLoai.GhiChu = txtGhiChu.Text;
            TheLoaiBUS theLoaiBUS = new TheLoaiBUS();
            if (theLoaiBUS.themTheLoai(theLoai))
            {
                MessageBox.Show("Thêm OK !");
                loadData();
            }
            else
            {
                MessageBox.Show("Thêm lỗi !");
                return;
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            TheLoai theLoai = new TheLoai();
            theLoai.MaTLoai = txtMa.Text;
            theLoai.TenTLoai = txtTen.Text;
            theLoai.GhiChu = txtGhiChu.Text;
            TheLoaiBUS theLoaiBUS = new TheLoaiBUS();
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc xoá mã " + txtMa.Text + "?", "Xác nhận xoá", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (theLoaiBUS.xoaTheLoai(theLoai))
                {
                    MessageBox.Show("Xoá OK !");
                    loadData();
                }
                else
                {
                    MessageBox.Show("Xoá lỗi !");
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TheLoaiBUS theLoaiBUS = new TheLoaiBUS();
            List<TheLoai> dsTL = theLoaiBUS.getListTheLoai(txtMa.Text);

            int row = 0;
            gvTheLoai.Rows.Clear();
            foreach (TheLoai tl in dsTL)
            {
                gvTheLoai.Rows.Add();
                gvTheLoai.Rows[row].Cells[0].Value = tl.MaTLoai;
                gvTheLoai.Rows[row].Cells[1].Value = tl.TenTLoai;
                gvTheLoai.Rows[row].Cells[2].Value = tl.GhiChu;
                row++;
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            TheLoai theLoai = new TheLoai();
            theLoai.MaTLoai = txtMa.Text;
            theLoai.TenTLoai = txtTen.Text;
            theLoai.GhiChu = txtGhiChu.Text;
            TheLoaiBUS theLoaiBUS = new TheLoaiBUS();
            if (theLoaiBUS.upodateTheLoai(theLoai))
            {
                MessageBox.Show("Sửa OK !");
                loadData();
            }
            else
            {
                MessageBox.Show("Sửa lỗi !");
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TaiLieuGUI form2 = new TaiLieuGUI();

            form2.Show();

            this.Hide();
        }

        private void gvTheLoai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //quay lai admin
            var frm = new TrangChu_QuanTriVien();
            frm.maNV = maNV;
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tb == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
