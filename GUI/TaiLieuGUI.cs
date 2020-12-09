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
    public partial class TaiLieuGUI : Form
    {
        public string maNV;
        public TaiLieuGUI()
        {
            InitializeComponent();
        }
        private void loadCombo()
        {
            TheLoaiBUS theLoaiBUS = new TheLoaiBUS();
            List<TheLoai> dsTheLoai = theLoaiBUS.getListTheLoai();
            cboMaTLoai.DataSource = dsTheLoai.ToList();
            cboMaTLoai.DisplayMember = "TenTLoai";
            cboMaTLoai.ValueMember = "MaTLoai";
        }
        private void loadData()
        {
            TaiLieuBUS taiLieuBUS = new TaiLieuBUS();
            List<TaiLieu> dsTaiLieu = taiLieuBUS.layDanhSachTaiLieu();
            int row = 0;
            gvTaiLieu.Rows.Clear();
            foreach (TaiLieu taiLieu in dsTaiLieu)
            {
                gvTaiLieu.Rows.Add();
                gvTaiLieu.Rows[row].Cells[0].Value = taiLieu.MaTLieu;
                gvTaiLieu.Rows[row].Cells[1].Value = taiLieu.TenTLieu;
                gvTaiLieu.Rows[row].Cells[2].Value = taiLieu.MaTLoai;
                gvTaiLieu.Rows[row].Cells[3].Value = taiLieu.SoLuong;
                gvTaiLieu.Rows[row].Cells[4].Value = taiLieu.NhaXB;
                gvTaiLieu.Rows[row].Cells[5].Value = taiLieu.NamXB;
                gvTaiLieu.Rows[row].Cells[6].Value = taiLieu.TacGia;
                row++;
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            loadCombo();
            loadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gvTaiLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = e.RowIndex;
            if (vt != -1 && vt < gvTaiLieu.Rows.Count - 1)
            {
                DataGridViewRow row = gvTaiLieu.Rows[vt];
                txtMaTL.Text = row.Cells[0].Value.ToString();
                txtTenTL.Text = row.Cells[1].Value.ToString();
                cboMaTLoai.SelectedValue = row.Cells[2].Value.ToString();
                txtSL.Text = row.Cells[3].Value.ToString();
                txtNXB.Text = row.Cells[4].Value.ToString();
                txtNamXB.Text = row.Cells[5].Value.ToString();
                txtTacGia.Text = row.Cells[6].Value.ToString();
            }
        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            loadData();
            txtMaTL.Text = "";
            txtTenTL.Text = "";
            txtSL.Text = "";
            txtNXB.Text = "";
            txtNamXB.Text = "";
            txtTacGia.Text = "";
            txtMaTL.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            TaiLieu taiLieu = new TaiLieu();
            taiLieu.MaTLieu = txtMaTL.Text;
            taiLieu.TenTLieu = txtTenTL.Text;
            taiLieu.MaTLoai = cboMaTLoai.SelectedValue.ToString();
            taiLieu.SoLuong = int.Parse(txtSL.Text);
            taiLieu.NhaXB = txtNXB.Text;
            taiLieu.NamXB = int.Parse(txtNamXB.Text);
            taiLieu.TacGia = txtTacGia.Text;
            TaiLieuBUS taiLieuBUS = new TaiLieuBUS();
            if (taiLieuBUS.themTaiLieu(taiLieu))
            {
                MessageBox.Show("Thêm tài liệu thành công !");
                loadData();
            }
            else
            {
                MessageBox.Show("Thêm tài liệu thất bại !");
                return;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            TaiLieu taiLieu = new TaiLieu();
            taiLieu.MaTLieu = txtMaTL.Text;
            taiLieu.TenTLieu = txtTenTL.Text;
            taiLieu.MaTLoai = cboMaTLoai.SelectedValue.ToString();
            taiLieu.SoLuong = int.Parse(txtSL.Text);
            taiLieu.NhaXB = txtNXB.Text;
            taiLieu.NamXB = int.Parse(txtNamXB.Text);
            taiLieu.TacGia = txtTacGia.Text;
            TaiLieuBUS taiLieuBUS = new TaiLieuBUS();
            if (taiLieuBUS.suaTaiLieu(taiLieu))
            {
                MessageBox.Show("Sửa tài liệu thành công !");
                loadData();
            }
            else
            {
                MessageBox.Show("Sửa tài liệu thất bại !");
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            TaiLieu taiLieu = new TaiLieu();
            taiLieu.MaTLieu = txtMaTL.Text;
            taiLieu.TenTLieu = txtTenTL.Text;
            taiLieu.MaTLoai = cboMaTLoai.SelectedValue.ToString();
            taiLieu.SoLuong = int.Parse(txtSL.Text);
            taiLieu.NhaXB = txtNXB.Text;
            taiLieu.NamXB = int.Parse(txtNamXB.Text);
            taiLieu.TacGia = txtTacGia.Text;
            TaiLieuBUS taiLieuBUS = new TaiLieuBUS();
            DialogResult dialog = MessageBox.Show("Bạn có chắc xoá tài liệu " + taiLieu.MaTLieu + "?", "Xác nhận xoá",
                MessageBoxButtons.OKCancel);
            if (dialog == DialogResult.OK)
            {
                if (taiLieuBUS.xoaTaiLieu(taiLieu))
                {
                    MessageBox.Show("Xoá tài liệu thành công !");
                    loadData();
                }
                else
                {
                    MessageBox.Show("Xoá tài liệu thất bại !");
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TaiLieuBUS taiLieuBUS = new TaiLieuBUS();
            string ma = cboMaTLoai.SelectedValue.ToString();
            List<TaiLieu> dsTaiLieu = taiLieuBUS.layDanhSachTaiLieu(ma);
            int row = 0;
            gvTaiLieu.Rows.Clear();
            foreach (TaiLieu taiLieu in dsTaiLieu)
            {
                gvTaiLieu.Rows.Add();
                gvTaiLieu.Rows[row].Cells[0].Value = taiLieu.MaTLieu;
                gvTaiLieu.Rows[row].Cells[1].Value = taiLieu.TenTLieu;
                gvTaiLieu.Rows[row].Cells[2].Value = taiLieu.MaTLoai;
                gvTaiLieu.Rows[row].Cells[3].Value = taiLieu.SoLuong;
                gvTaiLieu.Rows[row].Cells[4].Value = taiLieu.NhaXB;
                gvTaiLieu.Rows[row].Cells[5].Value = taiLieu.NamXB;
                gvTaiLieu.Rows[row].Cells[6].Value = taiLieu.TacGia;
                row++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new TrangChu_QuanTriVien();
            frm.maNV = maNV;
            frm.Show();
            Hide();
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
