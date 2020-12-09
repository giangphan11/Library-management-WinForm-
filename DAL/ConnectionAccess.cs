using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    public class ConnectionAccess
    {

        public SqlConnection getConnect()
        {
            //return new SqlConnection(@"Data Source=GIANGPHAN;Initial Catalog=CSDL_QuanLyThuVien;Integrated Security=True");
            return new SqlConnection(@"Data Source=GIANGPHAN;Initial Catalog=QuanLyTV4;Integrated Security=True");
        }

        //lenh tra ve mot bang
        public DataTable GetTable(string sql)
        {
            SqlConnection conn = getConnect();
            conn.Open();
            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

        //lenh khong tra ve mot bang
        public void ExecuteNonQuery(string sql)
        {
            SqlConnection conn = getConnect();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cmd.Clone();
        }

        //lay danh sach nhan vien
        public List<NhanVien> layDsNhanVien(string sql)
        {
            SqlConnection conn = getConnect();
            conn.Open();
            List<NhanVien> dsNV = new List<NhanVien>();
            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                NhanVien nv = new NhanVien();

                nv.MaNV = reader.GetString(0);
                nv.HoTen = reader.GetString(1);
                nv.MaChucVu = reader.GetString(2);
                nv.TaiKhoan = reader.GetString(3);
                nv.MatKhau = reader.GetString(4);
                nv.Anh = reader.GetString(5);

                dsNV.Add(nv);
            }

            conn.Close();
            return dsNV;
        }


        //lay tat ca thong tin phieu muon
/*        public string[] getPhieu(string maPhieu)
        {
            //lay tat ca Phieu
            SqlConnection conn = getConnect();
            conn.Open();

            string sql1 = "select * from PhieuMuon5 where MaPMuon = '"+ maPhieu + "' ";
            SqlCommand command = new SqlCommand(sql1, conn);
            SqlDataReader reader = command.ExecuteReader();

            PhieuMuon pm = new PhieuMuon();
            while (reader.Read())
            {
                pm.MaPhieuMuon = reader.GetString(0);
                pm.MaDocGia = reader.GetString(1);
                pm.NgayMuon = reader.GetDateTime(2);
                pm.MaNhanVien = reader.GetString(3);
            }
            conn.Close();

            conn.Open();
            //lay ten doc gia
            string sql2 = "select Hten from DocGia5 where MaDGia = '" + pm.MaDocGia + "' ";
            SqlCommand command2 = new SqlCommand(sql2, conn);
            object tenDocGia = command2.ExecuteScalar();

            //lay ten nhan vien
            string sql3 = "select Hten from NhanVien5 where MaNVien = '" + pm.MaNhanVien + "' ";
            SqlCommand command3 = new SqlCommand(sql3, conn);
            object tenNhanVien = command3.ExecuteScalar();

            //gan
            string[] list = { pm.MaDocGia, tenDocGia + "", pm.NgayMuon + "", pm.MaNhanVien, tenNhanVien + "" };

            conn.Close();
            return list;
        }*/

        
         //lay thong tin phieu 2
        public string[] getPhieu2(string maPhieu)
        {
            SqlConnection conn = getConnect();
            conn.Open();

            string sql = "select PhieuMuon5.MaDGia, DocGia5.Hten, NgayMuon, NhanVien5.MaNVien, NhanVien5.Hten from PhieuMuon5 inner join DocGia5 on PhieuMuon5.MaDGia = DocGia5.MaDGia inner join NhanVien5 on NhanVien5.MaNVien = PhieuMuon5.MaNVien where MaPMuon = '"+maPhieu+"' ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            string[] param = new string[5];
            while (reader.Read())
            {
                param[0] = reader.GetString(0);
                param[1] = reader.GetString(1); 
                param[2] = reader.GetDateTime(2)+"";
                param[3] = reader.GetString(3);
                param[4] = reader.GetString(4);
            }
            return param;
        }

        //lay thong tin chi tiet
        public DataTable getChiTietPhieu(string sql)
        {
            SqlConnection conn = getConnect();
            conn.Open();
            SqlDataAdapter adt = new SqlDataAdapter(sql, conn);
            DataTable dtb = new DataTable();
            adt.Fill(dtb);

            return dtb;
        }

        //lấy tên đối tượng khi thay đổi text <dùng scalar>
        public object getTenDocGia(string ma)
        {
            object HoTen = null; //nếu như null thì không tìm thấy
            SqlConnection conn = getConnect();
            conn.Open();
            string sql = "select HTen from DocGia5 where MaDGia = '"+ma+"' ";
            SqlCommand cmd = new SqlCommand(sql, conn );
            HoTen = cmd.ExecuteScalar();

            return HoTen;
        }

        //lấy tên nhân viên khi thay đổi text
        public object getTenNhanVien(string ma)
        {
            object HoTen = null; //nếu như null thì không tìm thấy
            SqlConnection conn = getConnect();
            conn.Open();
            string sql = "select HTen from NhanVien5 where MaNVien = '" + ma + "' ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            HoTen = cmd.ExecuteScalar();

            return HoTen;
        }

        //lấy tên nhân viên khi thay đổi text
        public object getTaiLieu(string ma)
        {
            object tenTL = null; //nếu như null thì không tìm thấy
            SqlConnection conn = getConnect();
            conn.Open();
            string sql = "select TenTLieu from TaiLieu5 where MaTLieu = '" + ma + "' ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            tenTL = cmd.ExecuteScalar();

            return tenTL;
        }

        //lấy số lượng hiện tại của tài liệu
        public object getSoLuongTaiLieu(string ma) {
            SqlConnection conn = getConnect();
            conn.Open();

            string sql = "select Sluong from TaiLieu5 where MaTLieu = '" + ma + "' ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            object soluong = cmd.ExecuteScalar();

            return soluong;
        }

        //hàm lấy số lượng mượn hiện tại trong phieumuonchitiet5
        public object getSoLuongMuon(string maP, string maS)
        {
            SqlConnection conn = getConnect();
            conn.Open();

            string sql = "select SLMuon from PhieuMuonChiTiet5 where MaPMuon = '"+maP+"' and MaS = '"+maS+"' ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            object soluong = cmd.ExecuteScalar();

            return soluong;
        }

        //Phieu tra sach-----------------------------------------------------------------
        //lay thong tin phieu 2
        public string[] getPhieu3(string maDgia)
        {
            SqlConnection conn = getConnect();
            conn.Open();

            string sql = "select PhieuMuon5.MaDGia, DocGia5.Hten," +
                " NgayMuon, NhanVien5.MaNVien, NhanVien5.Hten from PhieuMuon5 " +
                "inner join DocGia5 on PhieuMuon5.MaDGia = DocGia5.MaDGia " +
                "inner join NhanVien5 on NhanVien5.MaNVien = PhieuMuon5.MaNVien " +
                "where MaPMuon = '" + maDgia + "' ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            string[] param = new string[5];
            while (reader.Read())
            {
                param[0] = reader.GetString(0);
                param[1] = reader.GetString(1);
                param[2] = reader.GetDateTime(2) + "";
                param[3] = reader.GetString(3);
                param[4] = reader.GetString(4);
            }
            return param;
        }

        protected SqlConnection conn;
        string strconn = @"Data Source=DESKTOP-DMOK647\MSSQLSERVER1;Initial Catalog=QuanLyTV4;Integrated Security=True;MultipleActiveResultSets=True";
        public void openConnection()
        {
            if (conn == null)
                conn = new SqlConnection(strconn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }
        public void closeConnection()
        {
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }


        //--------------------CONG-----------------------------------------------
        //lay thong tin chuc vu
        public string[] getChucVu(string maCvu)
        {
            SqlConnection conn = getConnect();
            conn.Open();

            string sql = "select * from ChucVu5 where MaCVu = '" + maCvu + "' ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            string[] param = new string[2];
            while (reader.Read())
            {
                param[0] = reader.GetString(0);
                param[1] = reader.GetString(1);
            }
            return param;
        }
        //Lay thong tin nhan vien
        public string[] getNhanVien(string maNV)
        {
            SqlConnection conn = getConnect();
            conn.Open();

            string sql = "select * from NhanVien5 where MaNVien = '" + maNV + "' ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            string[] param = new string[5];
            while (reader.Read())
            {
                param[0] = reader.GetString(0);
                param[1] = reader.GetString(1);
                param[1] = reader.GetString(2);
                param[1] = reader.GetString(3);
                param[1] = reader.GetString(4);
            }
            return param;
        }
    }
}
