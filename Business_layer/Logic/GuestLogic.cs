using Data_layer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_layer.Logic
{
    public class GuestLogic
    {
        private readonly HotelContext hotelContext = new HotelContext();
        public IEnumerable<KHACHHANG> GetKHACHHANGs()
        {
            return hotelContext.KHACHHANGs.ToList();
        }
        public void AddGuest(KHACHHANG khachhang)
        {
            hotelContext.KHACHHANGs.Add(khachhang);
            hotelContext.SaveChanges();
        }
        public void UpdateGuest()
        {
            hotelContext.SaveChanges();
        }
        public void DeleteGuest(KHACHHANG khachhang)
        {
            hotelContext.KHACHHANGs.Remove(khachhang);
            hotelContext.SaveChanges();
        }
        public KHACHHANG GetGuest(string MAKH)
        {
            var kh = hotelContext.KHACHHANGs.Find(MAKH);
            return kh;
        }
        public KHACHHANG GetGuest_CCCD(string cccd)
        {
            var kh = hotelContext.KHACHHANGs.SingleOrDefault(c => c.CCCD == cccd);
            return kh;
        }
    }
}
