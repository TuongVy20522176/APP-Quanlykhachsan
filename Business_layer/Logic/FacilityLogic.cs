using Data_layer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_layer.Logic
{
    public class FacilityLogic
    {
        private readonly HotelContext hotelContext = new HotelContext();
        public IEnumerable<THIETBI> GetTHIETBIs()
        {
            return hotelContext.THIETBIs.ToList();
        }
        public void AddThietbi(THIETBI thietbi)
        {
            hotelContext.THIETBIs.Add(thietbi);
            hotelContext.SaveChanges();
        }
        public void UpdateThietbi(THIETBI thietbi)
        {
            hotelContext.SaveChanges();
        }
        public void DeleteThietbi(THIETBI thietbi)
        {
            hotelContext.THIETBIs.Remove(thietbi);
            hotelContext.SaveChanges();
        }
        public THIETBI GetThietbi(string MaTB)
        {
            var kh = hotelContext.THIETBIs.Find(MaTB);
            return kh;
        }
    }
}
