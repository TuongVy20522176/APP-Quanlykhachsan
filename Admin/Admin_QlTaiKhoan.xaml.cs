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
    /// Interaction logic for Admin_QlTaiKhoan.xaml
    /// </summary>
    public partial class Admin_QlTaiKhoan : Page
    {
        public Admin_QlTaiKhoan()
        {
            InitializeComponent();
            HienThiTaiKhoan();
        }
        private static readonly AccountLogic tklogic = new AccountLogic();
        private void HienThiTaiKhoan()
        {
            var list = tklogic.GetTAIKHOANs();
            lvNhanVien.ItemsSource = list;
        }
        private void ThemTKButton_Click(object sender, RoutedEventArgs e)
        {
            Admin_ThemTK ttk = new Admin_ThemTK();
            ttk.ShowDialog();
            HienThiTaiKhoan();
        }
        private void click_SuaTK(object sender, RoutedEventArgs e)
        {

            TAIKHOAN taikhoan = (sender as Button).DataContext as TAIKHOAN;
            Admin_CapNhatTK cntk = new Admin_CapNhatTK(taikhoan);
            cntk.ShowDialog();

            HienThiTaiKhoan();
        }
        private void click_XoaTK(object sender, RoutedEventArgs e)
        {
            TAIKHOAN taikhoan = (sender as Button).DataContext as TAIKHOAN;
            var ThongBao = new DialogCustoms("Bạn có thật sự muỗn xóa " + taikhoan.TENTK, "Thông báo", DialogCustoms.YesNo);
            if (ThongBao.ShowDialog() == true)
            {
                tklogic.DeleteTaikhoan(taikhoan);
                new DialogCustoms("Xóa thành công", "Thông báo", DialogCustoms.OK).Show();
                HienThiTaiKhoan();
            }
        }
    }
}
