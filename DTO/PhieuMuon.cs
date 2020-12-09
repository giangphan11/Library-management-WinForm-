using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuMuon
    {
        public string MaPhieuMuon { get; set; }
        public string MaDocGia { get; set; }
        public string MaNhanVien { get; set; }
        public DateTime NgayMuon { get; set; }

        public PhieuMuon() { }

        public PhieuMuon(string maPhieu, string maDG, string maNV, DateTime ngay)
        {
            MaPhieuMuon = maPhieu;
            MaDocGia = maDG;
            MaNhanVien = maNV;
            NgayMuon = ngay;
        }
    }
}
