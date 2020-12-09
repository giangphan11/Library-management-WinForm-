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
    public class DoiTuongBUS
    {

        ConnectionAccess da = new ConnectionAccess();

        //lay thong tin do ra datagridview
        public DataTable Show()
        {
            string sql = "select * from DoiTuong5";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }

        public void Them(string MaDTuong, string TenDTuong)
        {
            string sql = "insert into DoiTuong5(MaDTuong,TenDTuong) values('" + MaDTuong + "',N'" + TenDTuong + "')";
            da.ExecuteNonQuery(sql);
            //return sql; 
        }

        //capnhat
        public void Sua(string MaDTuong, string TenDTuong)
        {
            string sql = "update DoiTuong5 set TenDTuong = N'" + TenDTuong + "' where MaDTuong = '" + MaDTuong + "'";
            da.ExecuteNonQuery(sql);
        }

        //xoa
        public void Xoa(string MaDTuong)
        {

            string sql = "delete DoiTuong5 where MaDTuong = '" + MaDTuong + "'";
            da.ExecuteNonQuery(sql);
        }

        public DataTable TimTheoMa(string key)
        {
            string sql = "select * from DoiTuong5 where MaDTuong like '%" + key + "%'";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }

    }
}