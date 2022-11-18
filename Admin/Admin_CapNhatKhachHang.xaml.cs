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
    /// Interaction logic for Admin_CapNhatKhachHang.xaml
    /// </summary>
    public partial class Admin_CapNhatKhachHang : Window
    {
        public Admin_CapNhatKhachHang()
        {
            InitializeComponent();
            CCCD.MaxLength = 12;
            SoDienThoai.MaxLength = 10;
        }
        private string MaKH;
        private static readonly GuestLogic guestLogic = new GuestLogic();
        public Admin_CapNhatKhachHang(KHACHHANG khach) : this()
        {
            InitializeComponent();
            CCCD.MaxLength = 12;
            SoDienThoai.MaxLength = 10;

            TenKhachHang.Text = khach.TENKH;
            GioiTinh.Text = khach.GIOITINH;
            SoDienThoai.Text = khach.SODT;
            CCCD.Text = khach.CCCD;
            DiaChi.Text = khach.DIACHI;
            QuocTich.Text = khach.QUOCTICH;
            MaKH = khach.MAKH;
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

        private void HuyButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            if (!KiemTra())
            {
                return;
            }
            else
            {
                var Khach = guestLogic.GetGuest(MaKH);
                Khach.TENKH = TenKhachHang.Text;
                Khach.GIOITINH = GioiTinh.Text;
                Khach.SODT = SoDienThoai.Text;
                Khach.CCCD = CCCD.Text;
                Khach.DIACHI = DiaChi.Text;
                Khach.QUOCTICH = QuocTich.Text;
                Khach.MAKH = MaKH;
                guestLogic.UpdateGuest();
                new DialogCustoms("Đã cập nhật thành công", "Thông báo", DialogCustoms.OK).Show();
                this.Close();
            }
        }
    }
}
