using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BUS
{
    public class TheLoaiBUS
    {
        TheLoaiAccess theLoaiAccess = new TheLoaiAccess();

        public List<TheLoai> getListTheLoai()
        {
            return theLoaiAccess.dsTheLoai();
        }
        public bool themTheLoai(TheLoai theLoai)
        {
            return theLoaiAccess.themTheloai(theLoai);
        }
        public bool xoaTheLoai(TheLoai theLoai)
        {
            return theLoaiAccess.xoaTheLoai(theLoai);
        }
        public bool upodateTheLoai(TheLoai theLoai)
        {
            return theLoaiAccess.suaTheLoai(theLoai);
        }
        public List<TheLoai> getListTheLoai(string ma)
        {
            return theLoaiAccess.dsTheLoaiTimKiem(ma);
        }
    }
}
