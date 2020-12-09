using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
namespace DAL
{
    public class TheLoaiAccess : ConnectionAccess
    {
        public List<TheLoai> dsTheLoai()
        {
            openConnection();
            List<TheLoai> dsTL = new List<TheLoai>();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM TheLoai5";
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                TheLoai tl = new TheLoai();
                tl.MaTLoai = reader.GetString(0);
                tl.TenTLoai = reader.GetString(1);
                tl.GhiChu = reader.GetString(2);
                dsTL.Add(tl);
            }
            reader.Close();
            return dsTL;
        }
        private bool checkMa(string ma)
        {
            openConnection();
            SqlCommand command = conn.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from TheLoai5 where MaTLoai=@ma";
            command.Parameters.Add("@ma", SqlDbType.NVarChar).Value = ma;
            command.Connection = conn;
            SqlDataReader read = command.ExecuteReader();
            if (read.Read())
                return true;
            read.Close();
            return false;
        }
        public bool themTheloai(TheLoai tl)
        {
            if (checkMa(tl.MaTLoai))
            {
                return false;
            }
            else
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "insert into TheLoai5 values(@ma, @ten,@ghiChu)";
                command.Parameters.Add("@ma", SqlDbType.NVarChar).Value = tl.MaTLoai;
                command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = tl.TenTLoai;
                command.Parameters.Add("@ghiChu", SqlDbType.NVarChar).Value = tl.GhiChu;
                command.Connection = conn;
                command.ExecuteNonQuery();
                return true;
            }
        }
        public bool suaTheLoai(TheLoai theLoai)
        {
            if (checkMa(theLoai.MaTLoai))
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "update TheLoai5 set TenTLoai=@ten,GhiChu=@ghiChu where MaTLoai=@ma";
                command.Parameters.Add("@ma", SqlDbType.NVarChar).Value = theLoai.MaTLoai;
                command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = theLoai.TenTLoai;
                command.Parameters.Add("@ghiChu", SqlDbType.NVarChar).Value = theLoai.GhiChu;
                command.Connection = conn;
                command.ExecuteNonQuery();
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<TheLoai> dsTheLoaiTimKiem(string ma)
        {
            openConnection();
            List<TheLoai> dsTL = new List<TheLoai>();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM TheLoai5 where MaTLoai=@ma";
            command.Parameters.Add("@ma", SqlDbType.NVarChar).Value = ma;
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                TheLoai tl = new TheLoai();
                tl.MaTLoai = reader.GetString(0);
                tl.TenTLoai = reader.GetString(1);
                tl.GhiChu = reader.GetString(2);
                dsTL.Add(tl);
            }
            reader.Close();
            return dsTL;
        }
        public bool xoaTheLoai(TheLoai theLoai)
        {
            if (checkMa(theLoai.MaTLoai))
            {
                try
                {
                    SqlCommand command = conn.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "delete TheLoai5 where MaTLoai=@ma";
                    command.Parameters.Add("@ma", SqlDbType.NVarChar).Value = theLoai.MaTLoai;
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

    }
}
