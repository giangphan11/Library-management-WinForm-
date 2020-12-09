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
    public partial class ChucVuGUI : Form
    {
        public string maNV;
        public ChucVuGUI()
        {
            InitializeComponent();
        }
        ChucVu CV = new ChucVu(); //khai bao lop doi tuong LOP
        ChucVuBUS lopcv = new ChucVuBUS(); //khai bao lop doi tuong logic
        //Data da = new Data();

        //regex
        string pMacv = "^[C][V][0-9]{2}$";
        string pTencv = "^[a-zA-Z_ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶ" +
            "ẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợ" +
            "ụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ\\s]+$";

        public void LoadData()
        {
            dgvChucVu.DataSource = lopcv.Show();
        }

        private void ChucVuGUI_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            //lam moi
            txtMaChucVu.ResetText();
            txtTenChucVu.ResetText();
            txtMaChucVu.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string err = "";


            if (!Regex.IsMatch(txtMaChucVu.Text, pMacv))
            {
                err += "\n Mã chức vụ cần bắt đầu bằng 'cv', tiếp sau là 2 số. ";
            }
            if (!Regex.IsMatch(txtTenChucVu.Text, pTencv))
            {
                err += "\n Tên chức vụ là các ký tự Alphabet ";
            }

            if (err == "")
            {
                try
                {
                    CV.MaChucVu = txtMaChucVu.Text;
                    CV.TenChucVu = txtTenChucVu.Text;
                    lopcv.Them(CV.MaChucVu, CV.TenChucVu);
                    MessageBox.Show("Thêm thành công!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadData();
                    btnNhapLai_Click(sender, e);
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaChucVu.Text.Equals("") || txtTenChucVu.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng chọn đối tượng cần sửa!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (!txtMaChucVu.Text.Equals("") && !txtTenChucVu.Text.Equals(""))
            {
                //MessageBox.Show(CV.MaChucVu);
                string err = "";

                if (!Regex.IsMatch(txtTenChucVu.Text, pTencv))
                {
                    err += "\n Tên chức vụ là các ký tự Alphabet ";
                }

                if (err == "")
                {
                    string[] param = lopcv.layThongTinCVu(txtMaChucVu.Text);
                    if (param[0] == null)
                    {
                        MessageBox.Show("Không được thay đổi mã chức vụ!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //clearText();
                        return;
                    }
                    CV.MaChucVu = txtMaChucVu.Text;
                    CV.TenChucVu = txtTenChucVu.Text;
                    lopcv.Sua(CV.MaChucVu, CV.TenChucVu);
                    MessageBox.Show("Sửa thành công!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    btnNhapLai_Click(sender, e);
                }
                else
                {
                    MessageBox.Show(err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvTheLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            DataGridViewRow row = dgvChucVu.Rows[i];
            txtMaChucVu.Text = row.Cells[0].Value.ToString();
            txtTenChucVu.Text = row.Cells[1].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rs = MessageBox.Show("Bạn có chác muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    string[] param = lopcv.layThongTinCVu(txtMaChucVu.Text);
                    if (txtMaChucVu.Text == "")
                    {
                        MessageBox.Show("Mã CV không được để trống");
                        return;
                    }
                    if (param[0] == null)
                    {
                        MessageBox.Show("Không tìm thấy mã CV :" + txtMaChucVu.Text);
                        //clearText();
                        return;
                    }
                    CV.MaChucVu = txtMaChucVu.Text;
                    lopcv.Xoa(CV.MaChucVu);
                    LoadData();
                    MessageBox.Show("Xóa thành công!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Lỗi xóa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtMaChucVu.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần nhập mã tìm kiếm!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dgvChucVu.DataSource = lopcv.TimTheoMa(txtMaChucVu.Text);
                if ((dgvChucVu.RowCount - 1) == 0)
                {
                    MessageBox.Show("Không có kết quả tìm kiếm nào.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnXemToanBo_Click(object sender, EventArgs e)
        {
            LoadData();
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
