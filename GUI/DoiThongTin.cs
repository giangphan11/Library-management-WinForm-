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
    public partial class DoiThongTin : Form
    {
        DoiThongTin_BUS obj = new DoiThongTin_BUS();
        public string maNV;
        public DoiThongTin()
        {
            InitializeComponent();
        }

        private void DoiThongTin_Load(object sender, EventArgs e)
        {
            pn1.Enabled = false;
            txtTaiKhoan.Enabled = false;
            show(maNV);

        }

        //lay thong tin nhan vien
        public void show(string maNV) {
            List<NhanVien> nv = obj.getNhanVien(maNV);
            foreach (NhanVien item in nv) {
                txtMaNV.Text = item.MaNV;
                txtTaiKhoan.Text = item.TaiKhoan;
                txtHoTen.Text = item.HoTen;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new TrangChu_ThuThu();
            frm.maNV = maNV;

            frm.Show();
            this.Hide();
        }

        private void radioDoiMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            pn1.Enabled = true;
            txtMatKhauXacNhan.Hide();
            lbXacNhanMK.Hide();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            radioDoiMatKhau.Checked = false;
            pn1.Enabled = false;
            txtMatKhauXacNhan.Show();
            lbXacNhanMK.Show();
        }

        private void DoiThongTin_Click(object sender, EventArgs e)
        {
            radioDoiMatKhau.Checked = false;
            pn1.Enabled = false;
            txtMatKhauXacNhan.Show();
            lbXacNhanMK.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radioDoiMatKhau.Checked == false)
            {
                if (txtHoTen.Text == "" || txtMatKhauXacNhan.Text == "")
                {
                    MessageBox.Show("Hãy điền đầy đủ thông tin");
                    return;
                }

                //kiem tra mat khau
                List<NhanVien> list = obj.kiemTraTonTai(txtTaiKhoan.Text, txtMatKhauXacNhan.Text);
                if (list.Count == 0)
                {
                    MessageBox.Show("Mật khẩu cũ không đúng!");
                    return;
                }

                //cap nhat ten nhan vien
                try
                {
                    obj.capnhat_hoten(txtHoTen.Text, maNV);
                    MessageBox.Show("Cập nhật thành công");
                    show(maNV);
                }
                catch
                {
                    MessageBox.Show("Có Lỗi");
                }
            }
            else {
                //khong dc de trong
                if (txtMatKhauCu.Text == "" || txtMatKhauMoi.Text == "" || txtNhapLai.Text == "" || txtHoTen.Text == "")
                {
                    MessageBox.Show("Hãy điền đầy đủ thông tin");
                    return;
                }


                //kiem tra xac nhan mat khau
                if (!txtMatKhauMoi.Text.Equals(txtNhapLai.Text)) {
                    MessageBox.Show("Mật khẩu không khớp");
                    return;
                }

                //kiem tra mat khau
                List<NhanVien> list = obj.kiemTraTonTai(txtTaiKhoan.Text, txtMatKhauCu.Text);
                if (list.Count == 0)
                {
                    MessageBox.Show("Mật khẩu cũ không đúng!");
                    return;
                }

                //cap nhat ho ten va mat khau
                try
                {
                    obj.capnhat_hoten_matkhau(txtHoTen.Text, txtMatKhauMoi.Text, maNV);
                    MessageBox.Show("Cập nhật thành công");
                    show(maNV);
                }
                catch {
                    MessageBox.Show("Có lỗi");   
                }
               
            }


        }

        private void button2_Click(object sender, EventArgs e)
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
