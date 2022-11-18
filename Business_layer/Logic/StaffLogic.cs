using Data_layer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_layer.Logic
{
    public class StaffLogic
    {
        private readonly HotelContext hotelContext = new HotelContext();
        public IEnumerable<NHANVIEN> GetNHANVIENs()
        {
            return hotelContext.NHANVIENs.ToList();
        }
        public void AddStaff(NHANVIEN NHANVIEN)
        {
            hotelContext.NHANVIENs.Add(NHANVIEN);
            hotelContext.SaveChanges();
        }
        public void UpdateStaff()
        {
            hotelContext.SaveChanges();
        }
        public void DeleteStaff(NHANVIEN NHANVIEN)
        {
            hotelContext.NHANVIENs.Remove(NHANVIEN);
            hotelContext.SaveChanges();
        }
        public NHANVIEN GetStaff(string MANV)
        {
            var kh = hotelContext.NHANVIENs.Find(MANV);
            return kh;
        }
        public NHANVIEN GetStaff_CCCD(string cccd)
        {
            var kh = hotelContext.NHANVIENs.SingleOrDefault(c => c.CCCD == cccd);
            return kh;
        }
    }
}
