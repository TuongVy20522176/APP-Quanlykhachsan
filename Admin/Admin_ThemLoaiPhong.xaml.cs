using Business_layer.Logic;
using Data_layer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Giao_dien_dang_nhap.Admin
{
    /// <summary>
    /// Interaction logic for Admin_ThemLoaiPhong.xaml
    /// </summary>
    public partial class Admin_ThemLoaiPhong : Window
    {
        public Admin_ThemLoaiPhong()
        {
            InitializeComponent();
        }
        private static readonly RoomTypeLogic roomTypeLogic = new RoomTypeLogic();
        private bool KiemTra()
        {
            if (string.IsNullOrWhiteSpace(TenLoaiPhong.Text))
            {
                new DialogCustoms("Vui lòng nhập tên loại phòng", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(SoNguoi.Text))
            {
                new DialogCustoms("Vui lòng nhập số người tối đa", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(GiaNgay.Text))
            {
                new DialogCustoms("Vui lòng nhập giá ngày", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            else
            {
                int so;
                if (int.TryParse(TenLoaiPhong.Text, out so) == true)
                {
                    new DialogCustoms("Vui lòng nhập đúng định dạng tên loại phòng", "Thông báo", DialogCustoms.OK).Show();
                    return false;
                }
                if (int.TryParse(SoNguoi.Text, out so) == false)
                {
                    new DialogCustoms("Vui lòng nhập đúng định dạng số người tối đa", "Thông báo", DialogCustoms.OK).Show();
                    return false;
                }
                if (int.TryParse(GiaNgay.Text, out so) == false)
                {
                    new DialogCustoms("Vui lòng nhập đúng định dạng giá ngày", "Thông báo", DialogCustoms.OK).Show();
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        private void HuyButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private string CreateNextRoomTypeId(string maxId)
        {
            if (maxId is null)
            {
                return "0001";
            }
            string newIdString = $"000{int.Parse(maxId.Substring(2)) + 1}";
            return newIdString.Substring(newIdString.Length - 4, 4);
        }
        private void ThemButton_Click(object sender, RoutedEventArgs e)
        {

            if (!KiemTra())
            {
                return;
            }
            else
            {
                var RoomType = roomTypeLogic.GetRoomTypes();
                string last_RoomType_id;
                if (RoomType.Any())
                {
                    var lastGuest = RoomType.Last();
                    last_RoomType_id = lastGuest.MALP;
                }
                else
                    last_RoomType_id = null;

                LOAIPHONG loaiPhong = new LOAIPHONG();
                loaiPhong.MALP = CreateNextRoomTypeId(last_RoomType_id);
                loaiPhong.TENLP = TenLoaiPhong.Text;
                loaiPhong.SONGUOI = (byte?)int.Parse(SoNguoi.Text);
                loaiPhong.DONGIA = decimal.Parse(GiaNgay.Text);
                loaiPhong.THONGTIN = ThongTin.Text;
                roomTypeLogic.AddRoomType(loaiPhong);
                new DialogCustoms("Đã thêm loại phòng " + loaiPhong.TENLP, "Thông báo", DialogCustoms.OK).Show();
                this.Close();
            }
        }
    }
}
