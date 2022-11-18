using Data_layer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_layer.Logic
{
    public class RoomLogic
    {
        private readonly HotelContext hotelContext = new HotelContext();
        public IEnumerable<PHONG> GetPHONGs()
        {
            return hotelContext.PHONGs.ToList();
        }
        public void AddRoom(PHONG phong)
        {
            hotelContext.PHONGs.Add(phong);
            hotelContext.SaveChanges();
        }
        public void UpdateRoom()
        {
            hotelContext.SaveChanges();
        }
        public void DeleteRoom(PHONG phong)
        {
            hotelContext.PHONGs.Remove(phong);
            hotelContext.SaveChanges();
        }
        public PHONG GetRoom_ID(string MaP)
        {
            var kh = hotelContext.PHONGs.Find(MaP);
            return kh;
        }

        public IEnumerable<PHONG> GetPHONG_Trongs(DateTime? ngayBD, DateTime? ngayKT)
        {
            List<PHONG> phongList = new List<PHONG>();
            List<KHACHHANG_PHONG> PHONG_phong = new List<KHACHHANG_PHONG>();  
          
            var list_room = hotelContext.PHONGs
                    .Select(c => new { c.MAPHONG, c.LOAIPHONG, c.TINHTRANG})
                    .Where(c => c.TINHTRANG == "Đã dọn dẹp");

            var list_PHONG_PHONG = hotelContext.KHACHHANG_PHONG
                .Join(hotelContext.PHONGs,
                        phong => phong.MAPHONG,
                        kh_p => kh_p.MAPHONG,
                        (phong, kh_p) => new
                        {
                            MAPHONG = phong.MAPHONG,
                            LOAIPHONG = kh_p.LOAIPHONG,
                            TINHTRANG = phong.TINHTRANG,
                            NGAYBD = phong.NGAYTHUE,
                            NGAYKT = phong.NGAYTRA,
                        });

            var list_hired_room = list_PHONG_PHONG
                .Select(c => new { c.MAPHONG, c.LOAIPHONG, c.TINHTRANG, c.NGAYBD, c.NGAYKT })
                .Where(c => c.NGAYBD >= ngayBD )
                .Where(c => c.NGAYKT <= ngayKT)
                .Select(c => new { c.MAPHONG, c.LOAIPHONG, c.TINHTRANG })
                .Distinct();

            var result = list_room.Except(list_hired_room);

            foreach(var Phong in result)
            {
                PHONG p = new PHONG();
                p.MAPHONG = Phong.MAPHONG;
                p.TINHTRANG=Phong.TINHTRANG;
                p.LOAIPHONG = Phong.LOAIPHONG;
                phongList.Add(p);
            }

            return phongList.ToList();
        }
        public IEnumerable<PHONG> GetPHONG_TheoLoai(int songuoi)
        {
            var list_PHONG = hotelContext.LOAIPHONGs
                .Join(hotelContext.PHONGs,
                        lp => lp.MALP,
                        phong => phong.LOAIPHONG,
                        (lp, phong) => new
                        {
                            MAPHONG = phong.MAPHONG,
                            LOAIPHONG = lp.MALP,
                            TINHTRANG = phong.TINHTRANG,
                            SONGUOI = lp.SONGUOI,
                        }).Where(c => c.SONGUOI == songuoi);

            var result = new List<PHONG>();
            foreach(var phong in list_PHONG)
            {
                var p = new PHONG();
                p.MAPHONG = phong.MAPHONG;
                p.LOAIPHONG = phong.LOAIPHONG;
                p.TINHTRANG = phong.TINHTRANG;
                result.Add(p);  
            }
            return result.ToList();
        }
        public IEnumerable<PHONG> GetPHONG_TheoNgays(DateTime? ngayChon)
        {
            var list_room = hotelContext.PHONGs.ToList();

            var list_KHACHHANG_PHONG = hotelContext.KHACHHANG_PHONG
                .Join(hotelContext.PHONGs,
                        phong => phong.MAPHONG,
                        kh_p => kh_p.MAPHONG,
                        (phong, kh_p) => new
                        {
                            MAPHONG = phong.MAPHONG,
                            LOAIPHONG = kh_p.LOAIPHONG,
                            TINHTRANG = phong.TINHTRANG,
                            NGAYBD = phong.NGAYTHUE,
                            NGAYKT = phong.NGAYTRA,
                        })
                .Select(c=> new {c.MAPHONG, c.LOAIPHONG, c.TINHTRANG, c.NGAYBD, c.NGAYKT})
                .Where(c => c.NGAYBD < ngayChon)
                .Where(c => c.NGAYKT > ngayChon)
                .Where(c => c.TINHTRANG == "Da dat")
                .Select(c => new { c.MAPHONG, c.LOAIPHONG, c.TINHTRANG});

            List<PHONG> result = new List<PHONG>();
            foreach (var phong in list_KHACHHANG_PHONG)
            {
                PHONG reseve_room = new PHONG();
                reseve_room.MAPHONG = phong.MAPHONG;
                reseve_room.LOAIPHONG = phong.LOAIPHONG;
                reseve_room.TINHTRANG = phong.TINHTRANG;    
                if(list_room.Contains(reseve_room))
                {
                    result.Add(reseve_room);
                    list_room.Remove(reseve_room);
                }    
            }

            foreach(var phong in list_room)
            {
                result.Add(phong);
            }    
            return result.ToList();
        }
    }
}
