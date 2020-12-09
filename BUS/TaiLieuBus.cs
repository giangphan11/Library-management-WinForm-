using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BUS
{
    public class TaiLieuBUS
    {
        TaiLieuAccess taiLieuAccess = new TaiLieuAccess();
        public List<TaiLieu> layDanhSachTaiLieu()
        {
            return taiLieuAccess.dsTaiLieu();
        }
        public bool themTaiLieu(TaiLieu taiLieu)
        {
            return taiLieuAccess.themTaiLieu(taiLieu);
        }
        public bool suaTaiLieu(TaiLieu taiLieu)
        {
            return taiLieuAccess.suaTaiLieu(taiLieu);
        }
        public bool xoaTaiLieu(TaiLieu taiLieu)
        {
            return taiLieuAccess.xoaTaiLieu(taiLieu);
        }
        public List<TaiLieu> layDanhSachTaiLieu(string ma)
        {
            return taiLieuAccess.dsTaiLieuTimKiem(ma);
        }
    }
}
