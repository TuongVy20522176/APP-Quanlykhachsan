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
    /// Interaction logic for Admin_ThemKhachHang.xaml
    /// </summary>
    public partial class Admin_ThemKhachHang : Window
    {
        public Admin_ThemKhachHang()
        {
            InitializeComponent();
            CCCD.MaxLength = 12;
            SoDienThoai.MaxLength = 10;
        }

        private static readonly GuestLogic guestLogic = new GuestLogic();

        private void HuyButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool Valid()
        {
            if (string.IsNullOrWhiteSpace(TenKhachHang.Text))
            {
                new DialogCustoms("Vui lòng nhập tên khách hàng", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(GioiTinh.Text))
            {
                new DialogCustoms("Vui lòng chọn giới tính", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(CCCD.Text))
            {
                new DialogCustoms("Vui lòng nhập mã căn cước công dân", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(DiaChi.Text))
            {
                new DialogCustoms("Vui lòng nhập địa chỉ", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(QuocTich.Text))
            {
                new DialogCustoms("Vui lòng nhập quốc tịch", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(SoDienThoai.Text))
            {
                new DialogCustoms("Vui lòng nhập số điện thoại", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            else
            {
                long check;
                int so;

                if (int.TryParse(TenKhachHang.Text, out so) == true)
                {
                    new DialogCustoms("Vui lòng nhập đúng định dạng tên khách hàng", "Thông báo", DialogCustoms.OK).Show();
                    return false;
                }

                if (int.TryParse(QuocTich.Text, out so) == true)
                {
                    new DialogCustoms("Vui lòng nhập đúng định dạng quốc tịch", "Thông báo", DialogCustoms.OK).Show();
                    return false;
                }
                if (int.TryParse(DiaChi.Text, out so) == true)
                {
                    new DialogCustoms("Vui lòng nhập đúng định dạng địa chỉ", "Thông báo", DialogCustoms.OK).Show();
                    return false;
                }

                else if (SoDienThoai.Text.Length < 10 || int.TryParse(SoDienThoai.Text, out so) == false)
                {
                    new DialogCustoms("Sai số điện thoại", "Thông báo", DialogCustoms.OK).Show();
                    return false;
                }
                else if (CCCD.Text.Length > 12 || CCCD.Text.Length < 12 || long.TryParse(CCCD.Text, out check) == false)
                {
                    new DialogCustoms("Sai mã căn cước công dân", "Thông báo", DialogCustoms.OK).Show();
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private string CreateNextGuestId(string maxId)
        {
            if (maxId is null)
            {
                return "KH0001";
            }
            string newIdString = $"000{int.Parse(maxId.Substring(2)) + 1}";
            return "KH" + newIdString.Substring(newIdString.Length - 4, 4);
        }
        private void ThemButton_Click(object sender, RoutedEventArgs e)
        {
            if (!KiemTra())
            {
                return;
            }
            else
            {
                var Guests = guestLogic.GetKHACHHANGs();
                string last_Guest_id;
                if (Guests.Any())
                {
                    var lastGuest = Guests.Last();
                    last_Guest_id = lastGuest.MAKH;
                }
                else
                    last_Guest_id = null;

                KHACHHANG newKH = new KHACHHANG();
                newKH.TENKH = TenKhachHang.Text;
                newKH.SODT = SoDienThoai.Text;
                newKH.CCCD = CCCD.Text;
                newKH.DIACHI = DiaChi.Text;
                newKH.GIOITINH = GioiTinh.Text;
                newKH.QUOCTICH = QuocTich.Text;
                newKH.MAKH = CreateNextGuestId(last_Guest_id);
                guestLogic.AddGuest(newKH);
                new DialogCustoms("Đã thêm khách hàng " + newKH.TENKH, "Thông báo", DialogCustoms.OK).Show();
                this.Close();
            }
        }
        private bool KiemTra()
        {
            if (string.IsNullOrWhiteSpace(TenKhachHang.Text))
            {
                new DialogCustoms("Vui lòng nhập tên khách hàng", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(GioiTinh.Text))
            {
                new DialogCustoms("Vui lòng chọn giới tính", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(CCCD.Text))
            {
                new DialogCustoms("Vui lòng nhập mã căn cước công dân", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(DiaChi.Text))
            {
                new DialogCustoms("Vui lòng nhập địa chỉ", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(QuocTich.Text))
            {
                new DialogCustoms("Vui lòng nhập quốc tịch", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(SoDienThoai.Text))
            {
                new DialogCustoms("Vui lòng nhập số điện thoại", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            else
            {
                long check;
                int so;

                if (int.TryParse(TenKhachHang.Text, out so) == true)
                {
                    new DialogCustoms("Vui lòng nhập đúng định dạng tên khách hàng", "Thông báo", DialogCustoms.OK).Show();
                    return false;
                }

                if (int.TryParse(QuocTich.Text, out so) == true)
                {
                    new DialogCustoms("Vui lòng nhập đúng định dạng quốc tịch", "Thông báo", DialogCustoms.OK).Show();
                    return false;
                }
                if (int.TryParse(DiaChi.Text, out so) == true)
                {
                    new DialogCustoms("Vui lòng nhập đúng định dạng địa chỉ", "Thông báo", DialogCustoms.OK).Show();
                    return false;
                }

                else if (SoDienThoai.Text.Length < 10 || int.TryParse(SoDienThoai.Text, out so) == false)
                {
                    new DialogCustoms("Sai số điện thoại", "Thông báo", DialogCustoms.OK).Show();
                    return false;
                }
                else if (CCCD.Text.Length > 12 || CCCD.Text.Length < 12 || long.TryParse(CCCD.Text, out check) == false)
                {
                    new DialogCustoms("Sai mã căn cước công dân", "Thông báo", DialogCustoms.OK).Show();
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
