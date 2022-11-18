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
    /// Interaction logic for Admin_QLLoaiPhong.xaml
    /// </summary>
    public partial class Admin_QLLoaiPhong : Page
    {
        private static readonly RoomTypeLogic roomTypeLogic = new RoomTypeLogic();
        public Admin_QLLoaiPhong()
        {
            InitializeComponent();
            TaiDanhSachLoaiPhong();
        }
        private void TaiDanhSachLoaiPhong()
        {
            lsvLoaiPhong.ItemsSource = roomTypeLogic.GetRoomTypes();
        }
        private void ThemLPButton_Click(object sender, RoutedEventArgs e)
        {
            Admin_ThemLoaiPhong themphong = new Admin_ThemLoaiPhong();
            themphong.ShowDialog();
            TaiDanhSachLoaiPhong();
        }
        private void SuaLPButton_Click(object sender, RoutedEventArgs e)
        {
            LOAIPHONG loaiPhong = (sender as Button).DataContext as LOAIPHONG;
            Admin_CapNhatLoaiPhong capnhat = new Admin_CapNhatLoaiPhong(loaiPhong);
            capnhat.ShowDialog();
            TaiDanhSachLoaiPhong();
        }
        private void XoaLPButton_Click(object sender, RoutedEventArgs e)
        {
            LOAIPHONG loaiPhong = (sender as Button).DataContext as LOAIPHONG;
            roomTypeLogic.DeleteRoomType(loaiPhong);
            TaiDanhSachLoaiPhong();
        }
    }
}
