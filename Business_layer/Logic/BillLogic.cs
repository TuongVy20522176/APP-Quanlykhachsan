using Data_layer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_layer.Logic
{
    public class BillLogic
    {
        private readonly HotelContext hotelContext = new HotelContext();
        public IEnumerable<HOADON> GetHOADONs()
        {
            return hotelContext.HOADONs.ToList();
        }
        public void AddBill(HOADON hoadon)
        {
            hotelContext.HOADONs.Add(hoadon);
            hotelContext.SaveChanges();
        }
        public void UpdateBill()
        {
            hotelContext.SaveChanges();
        }
        public void DeleteBill(HOADON hoadon)
        {
            hotelContext.HOADONs.Remove(hoadon);
            hotelContext.SaveChanges();
        }
        public HOADON get_Bill_GuestID(string MAKH)
        {
            return hotelContext.HOADONs.Find(MAKH);
        }
        public HOADON get_Bill_KhachHangDangThue(string MaKH, string MaPhong)
        {
            Func<HOADON, bool> expression = c => c.MAKH == MaKH && c.MAPHONG == MaPhong && c.TINHTRANG == "Đang thuê";    
            return hotelContext.HOADONs.SingleOrDefault(expression);
        }
        public HOADON get_Bill_ID(string MAHD)
        {
            return hotelContext.HOADONs.Find(MAHD);
        }
    }
}
