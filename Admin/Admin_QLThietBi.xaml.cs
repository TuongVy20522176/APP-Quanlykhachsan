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
    /// Interaction logic for Admin_QLThietBi.xaml
    /// </summary>
    public partial class Admin_QLThietBi : Page
    {
        public Admin_QLThietBi()
        {
            InitializeComponent();
            HienThiThietbi();
        }
        private static readonly FacilityLogic TB = new FacilityLogic();
        private void ThietBiButton_Click(object sender, RoutedEventArgs e)
        {
            Admin_ThemThietBi ttb = new Admin_ThemThietBi();
            ttb.ShowDialog();
            HienThiThietbi();
        }
        private void HienThiThietbi()
        {
            var list = TB.GetTHIETBIs();
            lsvTienNghi.ItemsSource = list;
        }
        private void btnSuaTienNghi_Click(object sender, RoutedEventArgs e)
        {
            THIETBI thietbi = (sender as Button).DataContext as THIETBI;
            Admin_CapNhatThietBi cndv = new Admin_CapNhatThietBi(thietbi);
            cndv.ShowDialog();

            HienThiThietbi();
        }
        private void btnXoaTienNghi_Click(object sender, RoutedEventArgs e)
        {
            THIETBI thietbi = (sender as Button).DataContext as THIETBI;
            var ThongBao = new DialogCustoms("Bạn có thật sự muỗn xóa " + thietbi.TENTB, "Thông báo", DialogCustoms.YesNo);
            if (ThongBao.ShowDialog() == true)
            {
                TB.DeleteThietbi(thietbi);
                new DialogCustoms("Xóa thành công", "Thông báo", DialogCustoms.OK).Show();
                HienThiThietbi();
            }
        }

    }
}
