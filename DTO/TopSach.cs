using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TopSach
    {
        public static int STT;
        public int SoLanMuon { get; set; }
        public string TenSach { get; set; }
        public string TenTheLoai { get; set; }
        public string GhiChu { get; set; }

        public TopSach()
        {
            STT = 0;
        }
        public TopSach(string tenSach, string tenTLoai, int slMuon, string ghiChu)
        {
            STT++;
            this.TenSach = tenSach;
            this.TenTheLoai = tenTLoai;
            this.SoLanMuon = slMuon;
            this.GhiChu = ghiChu;
        }
    }
}
