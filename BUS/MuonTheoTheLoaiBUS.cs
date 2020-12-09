using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class MuonTheoTheLoaiBUS
    {
        ConnectionAccess da = new ConnectionAccess();

        //lay thong tin do ra datagridview
        public DataTable Show(DateTime batDau, DateTime ketThuc)
        {
            string sql = "SELECT TaiLieu5.MaTLoai, TheLoai5.TenTLoai, COUNT(MaS)as 'SoLanMuon', TheLoai5.GhiChu "
                            + "From TheLoai5 "
                                        + " inner join TaiLieu5 on TaiLieu5.MaTLoai = TheLoai5.MaTLoai"
                                        + " inner join PhieuMuonChiTiet5 on TaiLieu5.MaTLieu = PhieuMuonChiTiet5.MaS"
                                        + " inner join PhieuMuon5 on PhieuMuonChiTiet5.MaPMuon = PhieuMuon5.MaPMuon"
                                        + " WHERE NgayMuon BETWEEN '" + batDau + "' AND '" + ketThuc + "'"
                                        + " GROUP BY  TaiLieu5.MaTLoai, TheLoai5.TenTLoai,TheLoai5.GhiChu";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);

            return dt;
        }

        public string getTenNhanVien(string ma)
        {
            string ten = da.getTenNhanVien(ma).ToString();
            return ten;
        }

    }
}
