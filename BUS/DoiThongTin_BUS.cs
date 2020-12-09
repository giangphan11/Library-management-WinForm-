using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class DoiThongTin_BUS
    {
        ConnectionAccess obj_DAL = new ConnectionAccess();   

        //Lấy thông tin nhan viên
        public List<NhanVien> getNhanVien(string ma)
        {
            List<NhanVien> list = new List<NhanVien>();
            list = obj_DAL.layDsNhanVien("select * from NhanVien5 where MaNVien = '"+ma+"' ");

            return list;
        }

        public void capnhat_hoten(string hoten, string ma) {
            string sql = "update NhanVien5 set HTen = N'" + hoten + "' where MaNVien = '" + ma + "' ";
            obj_DAL.ExecuteNonQuery(sql);
        }

        public void capnhat_hoten_matkhau(string hoten, string matkhau, string ma)
        {
            string sql = "update NhanVien5 set HTen = N'" + hoten + "', Mkhau = '"+matkhau+"' where MaNVien = '" + ma + "' ";
            obj_DAL.ExecuteNonQuery(sql);
        }

        public List<NhanVien> kiemTraTonTai(string taikhoan, string matkhau)
        {
            List<NhanVien> list = new List<NhanVien>();
            list = obj_DAL.layDsNhanVien("select * from NhanVien5 where TKhoan = '" + taikhoan + "' and Mkhau = '" + matkhau + "' ");
            

            return list;
        }

    }
}
