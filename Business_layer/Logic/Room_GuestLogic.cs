using Data_layer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_layer.Logic
{
    public class Room_GuestLogic
    {
        private readonly HotelContext hotelContext = new HotelContext();
        public IEnumerable<KHACHHANG_PHONG> GetGuest_Room()
        {
            return hotelContext.KHACHHANG_PHONG.ToList();
        }
        public void AddGuest_Room(KHACHHANG_PHONG g_r)
        {
            hotelContext.KHACHHANG_PHONG.Add(g_r);
            hotelContext.SaveChanges();
        }
        public void UpdateGuest_Room()
        {
            hotelContext.SaveChanges();
        }
        public void DeleteGuest_Room(KHACHHANG_PHONG g_r)
        {
            hotelContext.KHACHHANG_PHONG.Remove(g_r);
            hotelContext.SaveChanges();
        }
        public KHACHHANG_PHONG GetKhachHangDangThue(string MAKH)
        {
            Func<KHACHHANG_PHONG, bool> expression = g => g.MAKH == MAKH && g.TINHTRANG == "Đang thuê";
            var list = hotelContext.KHACHHANG_PHONG.SingleOrDefault(expression);
            return list;
        }
        public KHACHHANG_PHONG GetThongTinPhong_MaPhong(string maPhong)
        {
            Func<KHACHHANG_PHONG, bool> expression = g => g.MAPHONG == maPhong && g.TINHTRANG == "Đang thuê";
            var phong = hotelContext.KHACHHANG_PHONG.SingleOrDefault(expression);
            return phong;
        }
        public KHACHHANG_PHONG GetDatPhong(string maKH_P)
        {
            return hotelContext.KHACHHANG_PHONG.Find(maKH_P);
        }
        public KHACHHANG_PHONG GetKhachHangDangThue_MAPHONG(string maPhong)
        {
            Func<KHACHHANG_PHONG, bool> expression = g => g.MAPHONG == maPhong && g.TINHTRANG == "Đang thuê";
            var list = hotelContext.KHACHHANG_PHONG.SingleOrDefault(expression);
            return list;
        }
        public IEnumerable<KHACHHANG_PHONG> GetPhongDaDat(string maPhong)
        {
            Func<KHACHHANG_PHONG, bool> expression = g => g.MAPHONG == maPhong && g.TINHTRANG == "Đã đặt";
            var phong = hotelContext.KHACHHANG_PHONG.Where(expression);
            return phong;
        }
        public KHACHHANG_PHONG NhanPhong(string maPHONG)
        {
            DateTime now = DateTime.Now;
            Func<KHACHHANG_PHONG, bool> expression = g => g.MAPHONG == maPHONG
            && g.TINHTRANG == "Đã đặt" && DateTime.Compare((DateTime)g.NGAYTHUE, now) <= 0 && DateTime.Compare(now, (DateTime)g.NGAYTRA) <= 0;
            return hotelContext.KHACHHANG_PHONG.SingleOrDefault(expression);
        }
        public KHACHHANG_PHONG GetKhachHangDaDat(string maPhong, string maKH)
        {
            Func<KHACHHANG_PHONG, bool> expression = g => g.MAPHONG == maPhong && g.TINHTRANG == "Đã đặt" && g.MAKH == maKH;
            var list = hotelContext.KHACHHANG_PHONG.SingleOrDefault(expression);
            return list;
        }
    }
}
