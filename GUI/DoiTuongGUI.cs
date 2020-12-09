using DTO;
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
using System.Text.RegularExpressions;

namespace GUI
{
    public partial class DoiTuongGUI : Form
    {
        public string maNV;
        public DoiTuongGUI()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        DoiTuong DT = new DoiTuong(); //khai bao lop doi tuong LOP
        DoiTuongBUS lopdt = new DoiTuongBUS(); //khai bao lop doi tuong logic
        //Data da = new Data();
        string pMaDoiTuong = "^[D][T][0-9]{2}$";
        string pTenDoiTuong = "^[a-zA-Z_ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶ" +
        "ẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợ" +
        "ụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ\\s]+$";

        public void LoadData()
        {
            dgvDoiTuong.DataSource = lopdt.Show();


        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtMaDTuong.ResetText();
            txtTenDTuong.ResetText();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaDTuong.TextLength == 0)
            {
                MessageBox.Show("Mã Đối Tượng Không Được Bỏ Trống");
            }
            else if (txtTenDTuong.TextLength == 0)
            {
                MessageBox.Show("Tên Đối tượng Không Được Bỏ Trống");
            }

            else
            {

                string err = "";
                if (!Regex.IsMatch(txtMaDTuong.Text, pMaDoiTuong))
                {
                    err += "\n Mã đối tượng phải bắt đầu bằng 'DT', tiếp sau là 2 số";
                }
                if (!Regex.IsMatch(txtTenDTuong.Text, pTenDoiTuong))
                {
                    err += "\n Họ tên phải là các kỹ tự Alphabet";
                }
                if (err == "")
                {

                    try
                    {
                        DT.MaDoiTuong = txtMaDTuong.Text;
                        DT.TenDoiTuong = txtTenDTuong.Text;
                        lopdt.Them(DT.MaDoiTuong, DT.TenDoiTuong);
                        MessageBox.Show("Thêm thành công!");
                        LoadData();
                        btnNhapLai_Click(sender, e);
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi thêm!");
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
            if (txtMaDTuong.TextLength == 0)
            {
                MessageBox.Show("Mã Đối Tượng Không Được Bỏ Trống");
            }
            else if (txtTenDTuong.TextLength == 0)
            {
                MessageBox.Show("Tên Đối tượng Không Được Bỏ Trống");
            }

            else
            {

                string err = "";
                if (!Regex.IsMatch(txtMaDTuong.Text, pMaDoiTuong))
                {
                    err += "\n Mã đối tượng phải bắt đầu bằng 'DT', tiếp sau là 2 số";
                }
                if (!Regex.IsMatch(txtTenDTuong.Text, pTenDoiTuong))
                {
                    err += "\n Họ tên phải là các kỹ tự Alphabet";
                }
                if (err == "")
                {
                    try
                    {
                        DT.MaDoiTuong = txtMaDTuong.Text;
                        DT.TenDoiTuong = txtTenDTuong.Text;
                        lopdt.Sua(DT.MaDoiTuong, DT.TenDoiTuong);
                        MessageBox.Show("Sửa thành công!");
                        LoadData();
                        btnNhapLai_Click(sender, e);
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi sửa!");
                    }
                }
            }
        }

        private void dgvDoiTuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            DataGridViewRow row = dgvDoiTuong.Rows[i];
            txtMaDTuong.Text = row.Cells[0].Value.ToString();
            txtTenDTuong.Text = row.Cells[1].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaDTuong.Text == "") {
                MessageBox.Show("Không được bỏ trống mã đối tượng");
                return;
            } 

            try
            {
                DialogResult rs = MessageBox.Show("Bạn có muốn xóa đối tượng đi không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    DT.MaDoiTuong = txtMaDTuong.Text;
                    lopdt.Xoa(DT.MaDoiTuong);
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi xóa!");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                dgvDoiTuong.DataSource = lopdt.TimTheoMa(txtMaDTuong.Text);
            }
            catch
            {
                MessageBox.Show("Khong tim thay!");
            }
        }

        private void DoiTuongGUI_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            //quay lai admin
            var frm = new TrangChu_QuanTriVien();
            frm.maNV = maNV;
            frm.Show();
            this.Hide();
        }
    }
}
