using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuMuonChiTiet
    {
        public string MaPMuon { get; set; }
        public string MaSach { get; set; }
        public int SLMuon { get; set; }
        public DateTime NgayTra { get; set; }

        public string TrangThai{ get; set; }
    }
}
