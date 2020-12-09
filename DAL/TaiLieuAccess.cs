using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
namespace DAL
{
    public class TaiLieuAccess : ConnectionAccess
    {
        public List<TaiLieu> dsTaiLieu()
        {
            openConnection();
            List<TaiLieu> dsTL = new List<TaiLieu>();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM TaiLieu5";
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                TaiLieu taiLieu = new TaiLieu();
                taiLieu.MaTLieu = reader.GetString(0);
                taiLieu.TenTLieu = reader.GetString(1);
                taiLieu.MaTLoai = reader.GetString(2);
                taiLieu.SoLuong = reader.GetInt32(3);
                taiLieu.NhaXB = reader.GetString(4);
                taiLieu.NamXB = reader.GetInt32(5);
                taiLieu.TacGia = reader.GetString(6);
                dsTL.Add(taiLieu);
            }
            reader.Close();
            return dsTL;
        }
        private bool checkMa(string ma)
        {
            openConnection();
            SqlCommand command = conn.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from TaiLieu5 where MaTLieu=@ma";
            command.Parameters.Add("@ma", SqlDbType.NVarChar).Value = ma;
            command.Connection = conn;
            SqlDataReader read = command.ExecuteReader();
            if (read.Read())
                return true;
            read.Close();
            return false;
        }
        public bool themTaiLieu(TaiLieu taiLieu)
        {
            if (checkMa(taiLieu.MaTLieu))
                return false;
            else
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "insert into TaiLieu5 values(@ma, @ten,@maTheLoai,@soLung,@nxb,@namxb,@tg)";
                command.Parameters.Add("@ma", SqlDbType.NVarChar).Value = taiLieu.MaTLieu;
                command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = taiLieu.TenTLieu;
                command.Parameters.Add("@maTheLoai", SqlDbType.NVarChar).Value = taiLieu.MaTLoai;
                command.Parameters.Add("@soLung", SqlDbType.Int).Value = taiLieu.SoLuong;
                command.Parameters.Add("@nxb", SqlDbType.NVarChar).Value = taiLieu.NhaXB;
                command.Parameters.Add("@namxb", SqlDbType.Int).Value = taiLieu.NamXB;
                command.Parameters.Add("@tg", SqlDbType.NVarChar).Value = taiLieu.TacGia;
                command.Connection = conn;
                command.ExecuteNonQuery();
                return true;
            }
        }
        public bool suaTaiLieu(TaiLieu taiLieu)
        {
            if (checkMa(taiLieu.MaTLieu))
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "update TaiLieu5 set TenTLieu=@ten,MaTLoai=@maTLoai,SLuong=@sl,NXB=@nxb,NamXB=@namXB,TG=@tg where MaTLieu=@ma";
                command.Parameters.Add("@ma", SqlDbType.NVarChar).Value = taiLieu.MaTLieu;
                command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = taiLieu.TenTLieu;
                command.Parameters.Add("@maTLoai", SqlDbType.NVarChar).Value = taiLieu.MaTLoai;
                command.Parameters.Add("@nxb", SqlDbType.NVarChar).Value = taiLieu.NhaXB;
                command.Parameters.Add("@tg", SqlDbType.NVarChar).Value = taiLieu.TacGia;
                command.Parameters.Add("@sl", SqlDbType.Int).Value = taiLieu.SoLuong;
                command.Parameters.Add("@namXB", SqlDbType.Int).Value = taiLieu.NamXB;
                command.Connection = conn;
                command.ExecuteNonQuery();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool xoaTaiLieu(TaiLieu taiLieu)
        {
            if (checkMa(taiLieu.MaTLieu))
            {
                try
                {
                    SqlCommand command = conn.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "delete TaiLieu5 where MaTLieu=@ma";
                    command.Parameters.Add("@ma", SqlDbType.NVarChar).Value = taiLieu.MaTLieu;
                    command.Connection = conn;
                    command.ExecuteNonQuery();
                    return true;
                }
                catch { }
                return false;
            }
            else
            {
                return false;
            }
        }
        public List<TaiLieu> dsTaiLieuTimKiem(string maTL)
        {
            openConnection();
            List<TaiLieu> dsTL = new List<TaiLieu>();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM TaiLieu5 where MaTLoai=@ma";
            command.Parameters.Add("@ma", SqlDbType.NVarChar).Value = maTL;
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                TaiLieu taiLieu = new TaiLieu();
                taiLieu.MaTLieu = reader.GetString(0);
                taiLieu.TenTLieu = reader.GetString(1);
                taiLieu.MaTLoai = reader.GetString(2);
                taiLieu.SoLuong = reader.GetInt32(3);
                taiLieu.NhaXB = reader.GetString(4);
                taiLieu.NamXB = reader.GetInt32(5);
                taiLieu.TacGia = reader.GetString(6);
                dsTL.Add(taiLieu);
            }
            reader.Close();
            return dsTL;
        }
    }
}
