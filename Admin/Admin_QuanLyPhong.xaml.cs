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
    /// Interaction logic for Admin_QuanLyPhong.xaml
    /// </summary>
    public partial class Admin_QuanLyPhong : Page
    {
        public Admin_QuanLyPhong()
        {
            InitializeComponent();
            HienThiPhong();
        }
        private static readonly RoomLogic P = new RoomLogic();
        private static readonly RoomTypeLogic roomTypeLogic = new RoomTypeLogic();
        private void ThemPhongButton_Click(object sender, RoutedEventArgs e)
        {
            Admin_themphong tp = new Admin_themphong();
            tp.ShowDialog();
            HienThiPhong();
        }
        private void HienThiPhong()
        {
            var list = P.GetPHONGs();
            lsvPhong.ItemsSource = list;
        }
        private void XoaButton_Click(object sender, RoutedEventArgs e)
        {
            PHONG phong = (sender as Button).DataContext as PHONG;
            var ThongBao = new DialogCustoms("Bạn có thật sự muỗn xóa " + phong.MAPHONG, "Thông báo", DialogCustoms.YesNo);
            ThongBao.ShowDialog();
            if (ThongBao.ShowDialog() == true)
            {
                P.DeleteRoom(phong);
                new DialogCustoms("Xóa thành công", "Thông báo", DialogCustoms.OK).Show();
                HienThiPhong();
            }
        }
        private void CapNhatButton_Click(object sender, RoutedEventArgs e)
        {
            PHONG phong = (sender as Button).DataContext as PHONG;
            Admin_CapNhatPhong cnp = new Admin_CapNhatPhong(phong);
            cnp.ShowDialog();
            HienThiPhong();
        }

        private void lsvPhong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
