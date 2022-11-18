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
    /// Interaction logic for Admin_QLDichVu.xaml
    /// </summary>
    public partial class Admin_QLDichVu : Page
    {
        public Admin_QLDichVu()
        {
            InitializeComponent();
            TaiDanhSachDichVu();
        }

        private static readonly ServiceLogic serviceLogic = new ServiceLogic();
        private void ThemDVButton_Click(object sender, RoutedEventArgs e)
        {
            Admin_ThemDV tdv = new Admin_ThemDV();
            tdv.ShowDialog();
            TaiDanhSachDichVu();
        }

        private void TaiDanhSachDichVu()
        {
            lsDichVu.ItemsSource = serviceLogic.GetDICHVUs().ToList();
        }

        private void XoaDVButton_CLick(object sender, RoutedEventArgs e)
        {
            DICHVU dichvu = (sender as Button).DataContext as DICHVU;
            var ThongBao = new DialogCustoms("Bạn có thật sự muốn xóa " + dichvu.TENDV, "Thông báo", DialogCustoms.YesNo);
            ThongBao.ShowDialog();
            serviceLogic.DeleteService(dichvu);
            new DialogCustoms("Xóa thành công", "Thông báo", DialogCustoms.OK).Show();
            TaiDanhSachDichVu();
        }

        private void CapNhatDVButton_Click(object sender, RoutedEventArgs e)
        {
            DICHVU dv = (sender as Button).DataContext as DICHVU;  
            Admin_CapNhatDichVu window = new Admin_CapNhatDichVu(dv);
            window.ShowDialog();
            TaiDanhSachDichVu();
        }
    }
}
