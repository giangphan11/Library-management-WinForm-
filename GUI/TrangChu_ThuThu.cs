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
    public partial class TrangChu_ThuThu : Form
    {
        public string maNV;
        public TrangChu_ThuThu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new QuanLy_MuonSach();
            frm.maNV = maNV;
            frm.check = 0;
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frm = new QuanLy_TraSach();
            frm.maNV = maNV;
            frm.check = 0;
            frm.Show();
            this.Hide();
        }

        private void btnSoLanMuonTheoTheLoai_Click(object sender, EventArgs e)
        {
            var frm = new MuonTheoTheLoaiGUI();
            frm.check = 0;
            frm.maNV = maNV;
            frm.Show();
            this.Hide();
        }

        private void btnTop10_Click(object sender, EventArgs e)
        {
            var frm = new Top10TaiLieuGUI();
            frm.maNV = maNV;
            frm.check2 = 0;
            frm.Show();
            this.Hide();
        }

        private void btnMuonQuaHan_Click(object sender, EventArgs e)
        {
            var frm = new NgayMuonQuaHanGUI();
            frm.maNV = maNV;
            frm.check = 0;
            frm.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var frm = new DoiThongTin();
            frm.maNV = maNV;
            frm.Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tb == DialogResult.Yes)
            {
                //this.Dispose();
                Application.Exit();
            }
        }

        //dang xuat
        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
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
