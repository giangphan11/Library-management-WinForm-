using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NhanVienBUS
    {
        ConnectionAccess da = new ConnectionAccess();

        //lay thong tin do ra datagridview
        public DataTable Show()
        {
            string sql = "select MaNVien, HTen, TenCVu, TKhoan, Mkhau,Quyen  from NhanVien5 inner join ChucVu5 on NhanVien5.MaCVu = ChucVu5.MaCVu";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public DataTable cbDGV()
        {
            string sql = "select * from ChucVu5";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }

        public void Them(string maNV, string hTen, string maCVu, string tKhoan, string mKhau, int quyen)
        {
            string sql = "insert into NhanVien5(MaNVien,Hten, MaCVu, TKhoan, Mkhau, Quyen) values('" + maNV + "',N'"
                + hTen + "','" + maCVu + "','" + tKhoan + "','" + mKhau + "','" + quyen + "')";
            da.ExecuteNonQuery(sql);
            //return sql; 
        }

        //capnhat
        public void Sua(string maNV, string hTen, string maCVu, string tKhoan, string mKhau, int quyen)
        {
            string sql = "update NhanVien5 set Hten = N'" + hTen + "', MaCVu='" + maCVu + "', TKhoan='" +
                tKhoan + "', Mkhau='" + mKhau + "', Quyen='" + quyen + "' where MaNVien = '" + maNV + "'";
            da.ExecuteNonQuery(sql);
        }


        //xoa
        public void Xoa(string maCVu)
        {
            string sql = "delete NhanVien5 where MaNVien = '" + maCVu + "'";
            da.ExecuteNonQuery(sql);
        }

        public DataTable TimTheoMa(string key)
        {
            string sql = "select * from NhanVien5 where MaNVien like '%" + key + "%'";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public string[] layThongTinNVien(String manv)
        {
            string[] param = da.getNhanVien(manv);
            return param;
        }

        //kiem tra tai khoan trung
        public List<NhanVien> kiemtra(string tk)
        {
            List<NhanVien> list = new List<NhanVien>();
            list = da.layDsNhanVien("select * from NhanVien5 where TKhoan = '" + tk + "' ");

            return list;
        }
    }
}
