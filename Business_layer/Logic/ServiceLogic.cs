using Data_layer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_layer.Logic
{
    public class ServiceLogic
    {
        private readonly HotelContext hotelContext = new HotelContext();
        public IEnumerable<DICHVU> GetDICHVUs()
        {
            return hotelContext.DICHVUs.ToList();
        }
        public void AddService(DICHVU dichvu)
        {
            hotelContext.DICHVUs.Add(dichvu);
            hotelContext.SaveChanges();
        }
        public void UpdateService()
        {
            hotelContext.SaveChanges();
        }
        public void DeleteService(DICHVU dichvu)
        {
            hotelContext.DICHVUs.Remove(dichvu);
            hotelContext.SaveChanges();
        }
        public DICHVU GetDV_ID(string madv)
        {
            return hotelContext.DICHVUs.Find(madv);
        }
    }
}
