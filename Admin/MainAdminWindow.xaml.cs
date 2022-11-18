using PhanMemQuanLyKhachSan.Admin;
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
    /// Interaction logic for MainAdminWindow.xaml
    /// </summary>
    public partial class MainAdminWindow : Window
    {
        public MainAdminWindow()
        {
            InitializeComponent();
            Date.Content = new TimeDate();
        }

        private void GuestButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Admin_QLKhachHang();
        }

        private void ServiceButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Admin_QLDichVu();
        }

        private void RoomButtom_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Admin_QuanLyPhong();
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            login.Show();
            this.Close();
        }

        private void ThietBiButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Admin_QLThietBi();
        }

        private void TaiKhoanButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Admin_QlTaiKhoan();
        }

        private void RoomTypeButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Admin_QLLoaiPhong();
        }
        private void NhanVienButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Admin_QLNhanVien();
        }
    }
}
