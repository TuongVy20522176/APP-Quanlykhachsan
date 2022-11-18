using Data_layer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_layer.Logic
{
    public class AccountLogic
    {
        private readonly HotelContext hotelContext = new HotelContext();
        public IEnumerable<TAIKHOAN> GetTAIKHOANs()
        {
            return hotelContext.TAIKHOANs.ToList();
        }
        public void AddTaikhoan(TAIKHOAN taikhoan)
        {
            hotelContext.TAIKHOANs.Add(taikhoan);
            hotelContext.SaveChanges();
        }
        public void UpdateTaikhoan(TAIKHOAN taikhoan)
        {
            hotelContext.SaveChanges();
        }
        public void DeleteTaikhoan(TAIKHOAN taikhoan)
        {
            hotelContext.TAIKHOANs.Remove(taikhoan);
            hotelContext.SaveChanges();
        }
        public TAIKHOAN GetTaikhoan(string tenTK)
        {
            var kh = hotelContext.TAIKHOANs.SingleOrDefault(c => c.TENTK == tenTK);
            return kh;
        }
    }
}
