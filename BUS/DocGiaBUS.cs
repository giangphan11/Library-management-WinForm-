using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;


namespace BUS
{
    public class DocGiaBUS
    {
        ConnectionAccess da = new ConnectionAccess();
        //lop_DTO L = new lop_DTO();
        DocGia Dg = new DocGia();
        DoiTuong Dt = new DoiTuong();

        //lay thong tin do ra datagridview
        public DataTable Show()
        {
            string sql = "select * from DocGia5";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public DataTable cbDGV()
        {
            string sql = "select * from DoiTuong5";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public void InsertLop(string MaDGia, string HTen, string GTinh, DateTime NSinh, string MaDTuong, DateTime NgayCap, DateTime NgayGHan)
        {
            string sql = "insert into DocGia5 values(N'" + MaDGia + "',N'" + HTen + "',N'" + GTinh + "','" + NSinh + "','" + MaDTuong + "','" + NgayCap + "','" + NgayGHan + "')";
            da.ExecuteNonQuery(sql);
        }
        public void UpdateLop(string MaDGia, string HTen, string GTinh, DateTime NSinh, string MaDTuong, DateTime NgayCap, DateTime NgayGHan)
        {
            string sql = "update DocGia5 set HTen=N'" + HTen + "'," + "GTinh = N'" + GTinh + "'," + "NSinh='" + NSinh + "'," + "MaDtuong='" + MaDTuong + "'," + "NgayCap='" + NgayCap + "'," + "NgayGHan='" + NgayGHan + "'" + "Where MaDGia='" + MaDGia + "'";
            da.ExecuteNonQuery(sql);
        }
        public void DeleteLop(string ml)
        {
            string sql = "delete DocGia5 where MaDGia='" + ml + "'";
            da.ExecuteNonQuery(sql);
        }
        public DataTable LookLop(string dk)
        {
            string sql = "select * from DocGia5 Where MaDGia like '%" + dk + "%'";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }

    }
}
