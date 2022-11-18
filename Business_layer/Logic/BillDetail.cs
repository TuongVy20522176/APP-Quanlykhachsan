using Data_layer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_layer.Logic
{
    public class BillDetail
    {
        private readonly HotelContext hotelContext = new HotelContext();
        public IEnumerable<CTHOADON> GetCTHOADONs()
        {
            return hotelContext.CTHOADONs.ToList();
        }
        public void AddBill(CTHOADON cthoadon)
        {
            hotelContext.CTHOADONs.Add(cthoadon);
            hotelContext.SaveChanges();
        }
        public void UpdateBill()
        {
            hotelContext.SaveChanges();
        }
        public void DeleteBill(CTHOADON cthoadon)
        {
            hotelContext.CTHOADONs.Remove(cthoadon);
            hotelContext.SaveChanges();
        }

        public CTHOADON FindBillDetail_BillID_ServiceID(string maHD, string maDV)
        {
            var ctdv = hotelContext.CTHOADONs.Find(maHD, maDV);
            return ctdv;  
        }
        public IEnumerable<CTHOADON> GetCTHOADON_Theo_MAHD(string maHD)
        {
            var listDV = hotelContext.CTHOADONs
                .Where(c => c.MAHD == maHD)
                .Select(c => new {c.MACTHD, c.MAHD, c.NOIDUNG, c.SOLUONG, c.THANHTIEN}).ToList();
            List<CTHOADON> result = new List<CTHOADON>();
            foreach(var dv in listDV)
            {
                CTHOADON newDV = new CTHOADON()
                {
                    MAHD = dv.MAHD,
                    MACTHD = dv.MACTHD,
                    NOIDUNG = dv.NOIDUNG,
                    SOLUONG = dv.SOLUONG,
                    THANHTIEN = dv.THANHTIEN,
                };
                result.Add(newDV);
            }
            return result;
        }
    }
}
