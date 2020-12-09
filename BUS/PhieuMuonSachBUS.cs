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
    public class PhieuMuonSachBUS
    {
        ConnectionAccess obj = new ConnectionAccess();
        /*public string[] layThongTinPhieu(String maPhieu)
        {
            string[] list = obj.getPhieu(maPhieu);
            return list;
        }*/

        public string[] layThongTinPhieu2(String maPhieu)
        {
            string[] param = obj.getPhieu2(maPhieu);
            return param;
        }

        //hien thi chi tiet
        public DataTable chiTietMuonSach(string maPhieu)
        {
            string sql = "select PhieuMuonChiTiet5.MaS as 'a', TenTLieu as 'b', SLMuon as 'c', NgayTra as 'd', TrangThai as 'e' from PhieuMuonChiTiet5 inner join TaiLieu5 on TaiLieu5.MaTLieu = PhieuMuonChiTiet5.MaS inner join PhieuMuon5 on PhieuMuon5.MaPMuon = PhieuMuonChiTiet5.MaPMuon where PhieuMuon5.MaPMuon = '" + maPhieu + "' ";
            DataTable dtb = obj.getChiTietPhieu(sql);
            return dtb;
        }


        //Lấy tên độc giả
        public string tenDocGia(string ma)
        {
            string ht = "";
            try
            {
                ht = obj.getTenDocGia(ma).ToString();
            }
            //có lỗi thì rỗng "" -> lỗi không convert object null -> string 
            //(trong điều kiện không tìm thấy và object hoten = null)
            catch
            {
                return ht;
            }

            return ht;
        }

        //Lấy tên nhân viên
        public string tenNhanVien(string ma)
        {
            string ht = "";
            try
            {
                ht = obj.getTenNhanVien(ma).ToString();
            }
            //có lỗi thì rỗng "" -> lỗi không convert object null -> string 
            //(trong điều kiện không tìm thấy và object hoten = null)
            catch
            {
                return ht;
            }

            return ht;
        }

        //Lấy tên nhân viên
        public string tenSach(string ma)
        {
            string name = "";
            try
            {
                name = obj.getTaiLieu(ma).ToString();
            }
            //có lỗi thì rỗng "" -> lỗi không convert object null -> string 
            //(trong điều kiện không tìm thấy và object hoten = null)
            catch
            {
                return name;
            }

            return name;
        }

        //lấy bảng Tài liệu (Sách)
        public DataTable getTaiLieu()
        {
            DataTable dtb = new DataTable();
            string sql = "select * from TaiLieu5";
            dtb = obj.GetTable(sql);

            return dtb;
        }

        //thêm chi tiết bản ghi với mã tài liệu (bảng chi tiết) là giữ nguyên
        public void themChiTietTaiLieuMuon(PhieuMuonChiTiet CT) {
            string sql = "insert into PhieuMuonChiTiet5 values('" + CT.MaPMuon + "' ,'" + CT.MaSach + "','" + CT.SLMuon + "' , '" + CT.NgayTra + "', N'"+CT.TrangThai+"'   ) ";
            obj.ExecuteNonQuery(sql);
        }

        //xóa chi tiết mượn sách với PK là: Mã phiếu & Mã sách tương ứng.
        public void xoaChiTietTaiLieuMuon(string maPhieu, string maSach)
        {
            string sql = "DELETE PhieuMuonChiTiet5 WHERE MaPMuon = '" + maPhieu + "' AND MaS = '" + maSach + "'  ";
            obj.ExecuteNonQuery(sql);
        }

        //Sửa chi tiết mượn sách với PK là: Mã phiếu & Mã sách tương ứng.
        public void suaChiTietTaiLieuMuon(PhieuMuonChiTiet CT)
        {
            string sql = "update PhieuMuonChiTiet5 set MaS = '" + CT.MaSach + "', SLMuon = '" + CT.SLMuon + "', NgayTra = '" + CT.NgayTra + "', TrangThai = N'"+CT.TrangThai+"' where MaPMuon = '" + CT.MaPMuon + "' and MaS = '" + CT.MaSach + "' ";
            obj.ExecuteNonQuery(sql);
        }


        //hàm kiểm tra số lượng hợp lệ
        public Boolean check_soLuong(string ma, int sl_muon) {
            //sl có
            int sl_co = Convert.ToInt32(obj.getSoLuongTaiLieu(ma));  
            if (sl_co >= sl_muon) {
                return true;
            }
            return false;
        }

        //Edit: kiểm tra số lượng hợp lệ: <sl so sánh là phải là số lg mượn hiện tại + sl trong kho(sl có)> - tức là tổng số lượng đang có trong kho và số lượng mà mình đang mượn
        public Boolean check_soLuong_Sua(string maP ,string maS, int sl_muon_capnhat)
        {
            //sl có
            int sl_co = Convert.ToInt32(obj.getSoLuongTaiLieu(maS));
            //sl hiện tại đang mượn
            int sl_hien_tai_dang_muon = Convert.ToInt32(obj.getSoLuongMuon(maP, maS));

            int sl_coTheDapUng = sl_co + sl_hien_tai_dang_muon;

            if (sl_coTheDapUng >= sl_muon_capnhat)
            {
                return true;
            }
            return false;
        }

        //cập nhật lại số lượng trong bảng Tài liệu sau khi mượn
        public void capNhatSoLuongThem(string ma, int sl_muon) {
            //sl có & sl mượn
            int sl_co = Convert.ToInt32(obj.getSoLuongTaiLieu(ma));
            int sl_conLai = sl_co - sl_muon;

            //cập nhật lại sl trong bảng Tailieu5
            string sql = "update TaiLieu5 set SLuong = '" + sl_conLai + "' where MaTLieu = '" + ma + "' ";
            obj.ExecuteNonQuery(sql);
        }

        //cập nhật số lượng sau khi xóa:
        public void capNhatSoLuongXoa(string ma, int sl_xoa)
        {
            int sl_co = Convert.ToInt32(obj.getSoLuongTaiLieu(ma)) + sl_xoa; //sl có

            //cập nhật lại sl trong bảng Tailieu5
            string sql = "update TaiLieu5 set SLuong = '" + sl_co + "' where MaTLieu = '" + ma + "' ";
            obj.ExecuteNonQuery(sql);
        }

        //cập nhật số lượng sau khi "cập nhật"
        public void capNhatSoLuongCapNhat(string maP, string maS, int sl_sau)
        {
            
            //sl mượn ban đầu
            int sl_truoc = Convert.ToInt32(obj.getSoLuongMuon(maP, maS));

            //sl hient tai trong TaiLieu5
            int sl = Convert.ToInt32(obj.getSoLuongTaiLieu(maS));

            //số lượng (TaiLieu5) sau khi cập nhật 
            int sl1 = sl - (sl_sau - sl_truoc);
         
            //cập nhật lại sl trong bảng Tailieu5
            string sql = "update TaiLieu5 set SLuong = '"+sl1+"' where MaTLieu = '" + maS + "' ";

            obj.ExecuteNonQuery(sql);
        }

        //thêm mã phiếu
        public void themPhieu(PhieuMuon pm)
        {
            string sql = "insert into PhieuMuon5 values( '"+pm.MaPhieuMuon+"' , '"+pm.MaDocGia+"', '"+pm.NgayMuon+"', '"+pm.MaNhanVien+"')";
            obj.ExecuteNonQuery(sql);
        }

        //xóa phiếu mượn
        public void XoaPhieu(string maP)
        {
            //Xóa phiếu mượn
            string sql2 = "delete from PhieuMuon5 where MaPMuon = '" + maP + "' ";
            obj.ExecuteNonQuery(sql2);
        }

        //cập nhật phiếu mượnư
        public void SuaPhieu(PhieuMuon pm)
        {
            string sql = "update PhieuMuon5 set MaDGia = '"+pm.MaDocGia+"', NgayMuon = '"+pm.NgayMuon+"', MaNVien = '"+pm.MaNhanVien+"' where MaPMuon = '"+pm.MaPhieuMuon+"'  ";
            obj.ExecuteNonQuery(sql);
        }


    }
}
