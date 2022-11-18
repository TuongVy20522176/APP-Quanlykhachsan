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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Giao_dien_dang_nhap.Admin
{
    /// <summary>
    /// Interaction logic for Admin_QLKhachHang.xaml
    /// </summary>
    public partial class Admin_QLKhachHang : Page
    {
        public Admin_QLKhachHang()
        {
            InitializeComponent();
        }
        private static readonly GuestLogic guestLogic = new GuestLogic();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var list = guestLogic.GetKHACHHANGs();
            KhachHangList.ItemsSource = list;
        }
        private void ThemKHButton_Click(object sender, RoutedEventArgs e)
        {
            Admin_ThemKhachHang tkh = new Admin_ThemKhachHang();
            tkh.ShowDialog(); 
        }
        private void HienDanhSachKhachHang()
        {
            var list = guestLogic.GetKHACHHANGs();
            KhachHangList.ItemsSource = list;
        }
        private void CapNhatButton_Click(object sender, RoutedEventArgs e)
        {
            KHACHHANG khachhang = (sender as Button).DataContext as KHACHHANG;
            Admin_CapNhatKhachHang window = new Admin_CapNhatKhachHang(khachhang);
            window.ShowDialog();
            HienDanhSachKhachHang();
        }

        private void XoaButton_Click(object sender, RoutedEventArgs e)
        {
            KHACHHANG khachHang = (sender as Button).DataContext as KHACHHANG;
            var ThongBao = new DialogCustoms("Bạn có thật sự muốn xóa " + khachHang.TENKH, "Thông báo", DialogCustoms.YesNo);
            ThongBao.ShowDialog();
            guestLogic.DeleteGuest(khachHang);
            new DialogCustoms("Xóa thành công", "Thông báo", DialogCustoms.OK).Show();
            HienDanhSachKhachHang();
        }
    }
}
