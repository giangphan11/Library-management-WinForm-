using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class NhanVienGUI : Form
    {

        public string maNV;
        public NhanVienGUI()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        NhanVien NV = new NhanVien(); //khai bao lop doi tuong LOP
        NhanVienBUS lopnv = new NhanVienBUS(); //khai bao lop doi tuong logic
        //Data da = new Data();

        //regex
        string pMaNV = "^[N][V][0-9]{2}$";
        string pHoten = "^[a-zA-Z_ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶ" +
        "ẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợ" +
        "ụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ\\s]+$";
        string pTaikhoan = "^[a-z0-9_-]{3,16}$";
        string pMatkhau = "^[a-zA-Z0-9@_^]{6,}$";

        public void LoadData()
        {
            dgvNhanVien.DataSource = lopnv.Show();
        }

        private void NhanVienGUI_Load(object sender, EventArgs e)
        {
            LoadData();

            cbQuyen.Items.Add("Admin");
            cbQuyen.Items.Add("Thủ thư");
            cbQuyen.SelectedIndex = 0;

            cbMaCVu.DataSource = lopnv.cbDGV();
            cbMaCVu.DisplayMember = "TenCVu";
            cbMaCVu.ValueMember = "MaCVu";


            /* (dgvNhanVien.Columns["MaCVu"] as DataGridViewComboBoxColumn).DataSource = lopnv.cbDGV();
             (dgvNhanVien.Columns["MaCVu"] as DataGridViewComboBoxColumn).DisplayMember = "TenCVu";
             (dgvNhanVien.Columns["MaCVu"] as DataGridViewComboBoxColumn).ValueMember = "MaCVu";*/

            /*(dgvNhanVien.Columns["MaNVien"] as DataGridViewComboBoxColumn).DataSource = lopnv.Show();
            (dgvNhanVien.Columns["MaNVien"] as DataGridViewComboBoxColumn).DisplayMember = "Quyen";
            (dgvNhanVien.Columns["MaNVien"] as DataGridViewComboBoxColumn).ValueMember = "MaNVien";*/
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Equals("") || txtHoTen.Text.Equals("") || txtTaiKhoan.Text.Equals("") || txtMatKhau.Text.Equals(""))
            {
                MessageBox.Show("Nhập đầy đủ thông tin cần sửa!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Kiem tra tai khoan
            List<NhanVien> listNV = lopnv.kiemtra(txtTaiKhoan.Text);
            if (listNV.Count != 0)
            {
                MessageBox.Show("Đã tồn tại Tài khoản này");
                return;
            }

            if (!txtMaNV.Text.Equals("") && !txtHoTen.Text.Equals("") && !txtTaiKhoan.Text.Equals("") && !txtMatKhau.Text.Equals(""))
            {
                string err = "";

                if (!Regex.IsMatch(txtHoTen.Text, pHoten))
                {
                    err += "\n Họ tên phải là các kỹ tự Alphabet";
                }
                if (!Regex.IsMatch(txtTaiKhoan.Text, pTaikhoan))
                {
                    err += "\n Tài khoản phải là các số hoặc chữ, từ 3 đến 16 ký tự ";
                }
                if (!Regex.IsMatch(txtMatKhau.Text, pMatkhau))
                {
                    err += "\n Mật khẩu phải là các số hoặc chữ, tối thiểu 6 ký tự ";
                }

                if (err == "")
                {
                    try
                    {
                        string[] param = lopnv.layThongTinNVien(txtMaNV.Text);
                        if (param[0] == null)
                        {
                            MessageBox.Show("Không được thay đổi mã nhân viên!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //clearText();
                            return;
                        }
                        NV.MaNV = txtMaNV.Text;
                        NV.HoTen = txtHoTen.Text;
                        NV.MaChucVu = cbMaCVu.SelectedValue.ToString();
                        NV.TaiKhoan = txtTaiKhoan.Text;
                        NV.MatKhau = txtMatKhau.Text;
                        //lopnv.Sua(NV.MaNV, NV.HoTen, NV.MaChucVu, NV.TaiKhoan, NV.MatKhau, NV.Quyen);
                        MessageBox.Show("Sửa thành công!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();

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


        private void btnThem_Click(object sender, EventArgs e)
        {
            //Kiem tra tai khoan
            List<NhanVien> listNV = lopnv.kiemtra(txtTaiKhoan.Text);
            if (listNV.Count != 0) {
                MessageBox.Show("Đã tồn tại Tài khoản này");
                return;
            }

            string err = "";


            if (!Regex.IsMatch(txtMaNV.Text, pMaNV))
            {
                err += "\n Mã nhân viên phải bắt đầu bằng 'NV', tiếp sau là 2 số";
            }
            if (!Regex.IsMatch(txtHoTen.Text, pHoten))
            {
                err += "\n Họ tên phải là các kỹ tự Alphabet";
            }
            if (!Regex.IsMatch(txtTaiKhoan.Text, pTaikhoan))
            {
                err += "\n Tài khoản phải là các số hoặc chữ, từ 3 đến 16 ký tự ";
            }
            if (!Regex.IsMatch(txtMatKhau.Text, pMatkhau))
            {
                err += "\n Mật khẩu phải là các số hoặc chữ, tối thiểu 6 ký tự ";
            }

            if (err == "")
            {
                try
                {
                    NV.MaNV = txtMaNV.Text;
                    NV.HoTen = txtHoTen.Text;
                    NV.MaChucVu = cbMaCVu.SelectedValue.ToString();
                    NV.TaiKhoan = txtTaiKhoan.Text;
                    NV.MatKhau = txtMatKhau.Text;
                    NV.MaChucVu = "CV01";
                    if ("Admin".Equals(cbQuyen.SelectedItem))
                    {
                        NV.MaChucVu = "CV01";
                    }
                    else
                    {
                        NV.MaChucVu = "CV02";
                    }

                    //lopnv.Them(NV.MaNV, NV.HoTen, NV.MaChucVu, NV.TaiKhoan, NV.MatKhau, NV.Quyen);
                    MessageBox.Show("Thêm thành công!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadData();

                }
                catch
                {
                    MessageBox.Show("Lỗi thêm!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            DataGridViewRow row = dgvNhanVien.Rows[i];
            txtMaNV.Text = row.Cells[0].Value.ToString();
            txtHoTen.Text = row.Cells[1].Value.ToString();
            cbMaCVu.Text = row.Cells[2].Value.ToString();
            txtTaiKhoan.Text = row.Cells[3].Value.ToString();
            txtMatKhau.Text = row.Cells[4].Value.ToString();
            //cbQuyen.SelectedItem = ;
            if (row.Cells[5].Value.ToString().Trim().Equals("1"))
            {
                cbQuyen.SelectedIndex = 0;
            }
            else
            {
                cbQuyen.SelectedIndex = 1;
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rs = MessageBox.Show("Bạn có chác muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    string[] param = lopnv.layThongTinNVien(txtMaNV.Text);
                    if (txtMaNV.Text == "")
                    {
                        MessageBox.Show("Mã NV không được để trống");
                        return;
                    }
                    if (param[0] == null)
                    {
                        MessageBox.Show("Không tìm thấy mã NV :" + txtMaNV.Text);
                        //clearText();
                        return;
                    }
                    NV.MaNV = txtMaNV.Text;
                    lopnv.Xoa(NV.MaNV);
                    LoadData();
                    MessageBox.Show("Xóa thành công!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch
            {
                MessageBox.Show("Lỗi xóa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            
            LoadData();
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtMaNV.ResetText();
            txtHoTen.ResetText();
            txtMatKhau.ResetText();
            txtTaiKhoan.ResetText();
            txtMaNV.Focus();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần nhập mã tìm kiếm!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dgvNhanVien.DataSource = lopnv.TimTheoMa(txtMaNV.Text);
                if ((dgvNhanVien.RowCount - 1) == 0)
                {
                    MessageBox.Show("Không có kết quả tìm kiếm nào.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            var frm = new TrangChu_QuanTriVien();
            frm.maNV = maNV;
            frm.Show();
            Hide();
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
