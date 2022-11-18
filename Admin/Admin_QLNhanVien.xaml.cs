using Business_layer.Logic;
using Data_layer.Domain;
using Giao_dien_dang_nhap;
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

namespace PhanMemQuanLyKhachSan.Admin
{
    /// <summary>
    /// Interaction logic for Admin_QLNhanVien.xaml
    /// </summary>
    public partial class Admin_QLNhanVien : Page
    {
        public Admin_QLNhanVien()
        {
            InitializeComponent();
            HienThiNhanVien();
        }

        private static readonly StaffLogic staffLogic = new StaffLogic();
        List<NHANVIEN> list;
        private void ThemNVButton_Click(object sender, RoutedEventArgs e)
        {
            Admin_ThemNhanVien tnv = new Admin_ThemNhanVien();
            tnv.ShowDialog();
            HienThiNhanVien();

        }
        private void HienThiNhanVien()
        {
            list = new List<NHANVIEN>(staffLogic.GetNHANVIENs());
            NhanVienList.ItemsSource = list;
        }

        private void CapNhatButton_Click(object sender, RoutedEventArgs e)
        {
            NHANVIEN nhanvien = (sender as Button).DataContext as NHANVIEN;
            Admin_CapNhatNV cnnv = new Admin_CapNhatNV(nhanvien);
            cnnv.ShowDialog();
            HienThiNhanVien();
        }

        private void NhanVienList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void XoaButton_Click(object sender, RoutedEventArgs e)
        {
            NHANVIEN nhanvien = (sender as Button).DataContext as NHANVIEN;
            var ThongBao = new DialogCustoms("Bạn có thật sự muốn xóa " + nhanvien.TENNV, "Thông báo", DialogCustoms.YesNo);

            if (ThongBao.ShowDialog() == false)
            {
                staffLogic.DeleteStaff(nhanvien);
                new DialogCustoms("Xóa thành công", "Thông báo", DialogCustoms.OK).Show();
                HienThiNhanVien();
            }
        }
    }
}
