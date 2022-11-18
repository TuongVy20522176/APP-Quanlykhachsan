using Data_layer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_layer.Logic
{
    public class RoomTypeLogic
    {
        private readonly HotelContext hotelContext = new HotelContext();
        public IEnumerable<LOAIPHONG> GetRoomTypes()
        {
            return hotelContext.LOAIPHONGs.ToList();
        }
        public void AddRoomType(LOAIPHONG loaiphong)
        {
            hotelContext.LOAIPHONGs.Add(loaiphong);
            hotelContext.SaveChanges();
        }
        public void UpdateRoomType()
        {
            hotelContext.SaveChanges();
        }
        public void DeleteRoomType(LOAIPHONG loaiphong)
        {
            hotelContext.LOAIPHONGs.Remove(loaiphong);
            hotelContext.SaveChanges();
        }
        public LOAIPHONG getLoaiPhong_tenLP(string tenLP)
        {
            return hotelContext.LOAIPHONGs.SingleOrDefault(c => c.TENLP == tenLP);
        }
        public LOAIPHONG getLoaiPhong_maLP(string maLP)
        {
            return hotelContext.LOAIPHONGs.Find(maLP);
        }
        public int getGiaLoaiPhong(string malp)
        {
            return (int)hotelContext.LOAIPHONGs.SingleOrDefault(c => c.MALP == malp).DONGIA;
        }
    }
}
