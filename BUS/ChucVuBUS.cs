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
    public class ChucVuBUS
    {

        ConnectionAccess da = new ConnectionAccess();

        //lay thong tin do ra datagridview
        public DataTable Show()
        {
            string sql = "select * from ChucVu5";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }

        public void Them(string maCVu, string tenCVu)
        {
            string sql = "insert into ChucVu5(MaCVu,TenCVu) values(N'" + maCVu + "',N'" + tenCVu + "')";
            da.ExecuteNonQuery(sql);
            //return sql; 
        }

        //capnhat
        public void Sua(string maCVu, string tenCVu)
        {
            string sql = "update ChucVu5 set TenCVu = N'" + tenCVu + "' where MaCVu = '" + maCVu + "'";
            da.ExecuteNonQuery(sql);
        }

        //xoa
        public bool Xoa(string maCVu)
        {

            if (checkMa(maCVu))
            {
                string sql = "delete ChucVu5 where MaCVu = '" + maCVu + "'";
                da.ExecuteNonQuery(sql);
                return true;
            }
            else {
                return false;
            }
            
            
        }

        public DataTable TimTheoMa(string key)
        {
            string sql = "select * from ChucVu5 where MaCVu like '%" + key + "%'";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        private bool checkMa(string ma)
        {
            string sql = "select * from ChucVu5 where MaCVu = '" + ma + "'";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            if (dt.Columns.Count<0)
            {
                return false;
            }
            else {
                return true;
            }
        }

        public string[] layThongTinCVu(String macv)
        {
            string[] param = da.getChucVu(macv);
            return param;
        }

    }
}
