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
using BUS;

namespace GUI
{
    public partial class DangNhap : Form
    {
        DangNhapBUS obj_BUS = new DangNhapBUS();
        public DangNhap()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        //dang nhap
        private void button1_Click(object sender, EventArgs e)
        {
            bool redirect = true;
            List<NhanVien> list = new List<NhanVien>();
            list = obj_BUS.dangnhap(txtTaiKhoan.Text, txtMatKhau.Text);

            if (list.Count == 0) {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!");
                return;
            }
            string ma = "";
            foreach(NhanVien nv in list)
            {
                if (nv.Quyen != 1) {
                    redirect = false;
                }
                ma = nv.MaNV;
            }

            //hiển thị form quản trị viên
            if (redirect) {
                var form = new TrangChu_QuanTriVien();
                form.maNV = ma;
                form.Show();
                this.Hide();

                //truyen tai khoan
                     
                return;
            }
            //hiển thị trang chủ thủ thư
            var frm = new TrangChu_ThuThu();
            frm.maNV = ma;
            frm.Show();
            this.Hide();
        }

        private void check_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = false;
            if (!check.Checked) {
                txtMatKhau.UseSystemPasswordChar = true;
                return;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tb == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
