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
    public class NgayMuonQuaHanBUS
    {
        ConnectionAccess da = new ConnectionAccess();
        public DataTable Show()
        {
            string sql = "select DocGia5.MaDGia as 'a' , DocGia5.Hten as 'b' ,TaiLieu5.MaTLieu as 'c' ," +
                "TaiLieu5.TenTLieu as 'd',PhieuMuon5.NgayMuon as 'e',(DATEDIFF(day, PhieuMuon5.NgayMuon," +
                " getdate() )-30) AS 'f' from PhieuMuonChiTiet5 " +
                "inner join TaiLieu5 on PhieuMuonChiTiet5.MaS=TaiLieu5.MaTLieu " +
                "inner join PhieuMuon5 on PhieuMuonChiTiet5.MaPMuon=PhieuMuon5.MaPMuon " +
                "inner join DocGia5 on PhieuMuon5.MaDGia=DocGia5.MaDGia " +
                "where (DATEDIFF(day, PhieuMuon5.NgayMuon, getdate() )-30) >0 and TrangThai = N'Đang mượn' ";
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
