using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BUS
{
    public class PhieuTraSachBUS
    {
        ConnectionAccess obj = new ConnectionAccess();

        public DataTable timkiem(string maDocGia)
        {
            string sql = "select MaPMuon as 'a', DocGia5.Hten as 'b', " +
                "NhanVien5.Hten as 'c', NgayMuon as 'd'  from PhieuMuon5 " +
                "inner join NhanVien5 on PhieuMuon5.MaNVien = NhanVien5.MaNVien " +
                "inner join DocGia5 on PhieuMuon5.MaDGia = DocGia5.MaDGia " +
                "where PhieuMuon5.MaDGia = '"+maDocGia+"'  ";
            DataTable dt = obj.GetTable(sql);
            return dt;
        }

        //lay kiem tra ma doc gia = cach kiem tra ten co = null khong
        public bool check_maDG(string maDG) {
            object name = obj.getTenDocGia(maDG);
            if (name == null) {
                return false;
            }
            return true;
        }

        //lay thong tin phieu(chi tiet hon - inner join)
        public string[] layThongTinPhieu(String maPhieu)
        {
            string[] param = obj.getPhieu3(maPhieu);
            return param;
        }

        //hien thi chi tiet nhung tai lieu muon
        public DataTable chiTietMuonSach(string maPhieu)
        {
            string sql = "select PhieuMuonChiTiet5.MaS as 'a', TenTLieu as 'b', SLMuon as 'c', NgayTra as 'd' from PhieuMuonChiTiet5 inner join TaiLieu5 on TaiLieu5.MaTLieu = PhieuMuonChiTiet5.MaS inner join PhieuMuon5 on PhieuMuon5.MaPMuon = PhieuMuonChiTiet5.MaPMuon where PhieuMuon5.MaPMuon = '" + maPhieu + "' and TrangThai = N'Đang mượn' ";
            DataTable dtb = obj.getChiTietPhieu(sql);
            return dtb;
        }

        //tra sach 
        public void traSach(string maP, string maS, int sl_tra, string ngayTra ) {
            //update trang thai = 1
            string sql = "update PhieuMuonChiTiet5 set TrangThai = N'Đã trả', NgayTra = '"+ngayTra+"' " +
                "where MaPMuon = '" + maP + "' and MaS = '" + maS + "'";
            obj.ExecuteNonQuery(sql);

            //cap nhat lai so luong trong TaiLieu5
            //lay so luong sach ban dau
            int sl_bandau = Convert.ToInt32(obj.getSoLuongTaiLieu(maS));
            int sl_update = sl_bandau + sl_tra;
            string sql2= "update TaiLieu5 set SLuong = '"+ sl_update + "' where MaTLieu = '"+maS+"' ";
            obj.ExecuteNonQuery(sql2);
        }
    }
}
