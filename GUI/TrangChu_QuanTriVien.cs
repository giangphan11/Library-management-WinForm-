using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class TrangChu_QuanTriVien : Form
    {
        public string maNV;
        public TrangChu_QuanTriVien()
        {
            InitializeComponent();
            this.CenterToScreen();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var frm = new QuanLy_MuonSach();
            frm.maNV = maNV;
            frm.check = 1;
            frm.Show();
            this.Hide();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            var frm = new MuonTheoTheLoaiGUI();
            frm.check = 1;
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var frm = new ChucVuGUI();
            frm.maNV = maNV;
            frm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var frm = new NhanVienGUI();
            frm.maNV = maNV;
            frm.Show();
            this.Hide();
        }

        private void btnSoLanMuonTheoTheLoai_Click(object sender, EventArgs e)
        {
            var frm = new MuonTheoTheLoaiGUI();
            frm.maNV = maNV;
            frm.check = 1;
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new TheLoaiGUI();
            frm.maNV = maNV;
            frm.Show();
            this.Hide();
        }

        private void btnTaiLieu_Click(object sender, EventArgs e)
        {
            var frm = new TaiLieuGUI();
            frm.maNV = maNV;
            frm.Show();
            this.Hide();
        }

        private void btnTop10_Click(object sender, EventArgs e)
        {
            var frm = new Top10TaiLieuGUI();
            frm.maNV = maNV;
            frm.check2 = 1;
            frm.Show();
            this.Hide();
        }

        private void btnDoiTuong_Click(object sender, EventArgs e)
        {
            var frm = new DoiTuongGUI();
            frm.maNV = maNV;
            frm.Show();
            this.Hide();
        }

        private void btnDocGia_Click(object sender, EventArgs e)
        {
            var frm = new DocGiaGUI();
            frm.maNV = maNV;
            frm.Show();
            this.Hide();
        }

        private void btnMuonQuaHan_Click(object sender, EventArgs e)
        {
            var frm = new NgayMuonQuaHanGUI();
            frm.maNV = maNV;
            frm.check = 1;
            frm.Show();
            this.Hide();
        }

        private void TrangChu_QuanTriVien_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(maNV);
        }

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            var frm = new QuanLy_TraSach();
            frm.maNV = maNV;
            frm.check = 1;
            frm.Show();
            this.Hide();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tb == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Đăng xuất khỏi tài khoản?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tb == DialogResult.Yes)
            {
                var frm = new DangNhap();
                frm.Show();
                Hide();
            }
        }
    }
}
