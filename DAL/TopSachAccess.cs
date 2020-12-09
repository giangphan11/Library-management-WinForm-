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
    public class TopSachAccess : ConnectionAccess
    {
        public List<TopSach> layDanhSachTop10Sach()
        {
            List<TopSach> dsSach = new List<TopSach>();
            openConnection();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PROC_TOP10";
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string ten = reader.GetString(0);
                string tenTLoai = reader.GetString(1);
                int sl = reader.GetInt32(2);
                string ghiChu = reader.GetString(3);
                TopSach topSach = new TopSach(ten, tenTLoai, sl, ghiChu);
                dsSach.Add(topSach);
            }
            reader.Close();
            return dsSach;
        }
        public List<TopSach> layDanhSachTop10Sach(DateTime start, DateTime end)
        {
            List<TopSach> dsSach = new List<TopSach>();
            openConnection();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PROC_TOP10TL";
            command.Parameters.Add("@START", SqlDbType.Date).Value = start;
            command.Parameters.Add("@END", SqlDbType.Date).Value = end;
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string ten = reader.GetString(0);
                string tenTLoai = reader.GetString(1);
                int sl = reader.GetInt32(2);
                string ghiChu = reader.GetString(3);
                TopSach topSach = new TopSach(ten, tenTLoai, sl, ghiChu);
                dsSach.Add(topSach);
            }
            reader.Close();
            return dsSach;
        }
    }
}
