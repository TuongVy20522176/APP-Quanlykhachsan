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
    /// Interaction logic for Admin_ThemTK.xaml
    /// </summary>
    public partial class Admin_ThemTK : Window
    {
        public Admin_ThemTK()
        {
            InitializeComponent();
        }
        private static readonly AccountLogic TKLogic = new AccountLogic();
        private void HuyButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnThemTK_Click(object sender, RoutedEventArgs e)
        {
            var taikhoan = TKLogic.GetTAIKHOANs();
            string last_taikhoan_id;
            if (taikhoan.Any())
            {
                var lastTK = taikhoan.Last();
                last_taikhoan_id = lastTK.MATK;
            }
            else
                last_taikhoan_id = null;

            TAIKHOAN newTK = new TAIKHOAN();
            newTK.TENTK = txtTaiKhoan.Text;
            newTK.MATKHAU = txtMatKhau.Text;
            newTK.VAITRO = cmbVaiTro.SelectedValue.ToString();

            newTK.MATK = CreateNextTaiKhoanId(last_taikhoan_id);
            TKLogic.AddTaikhoan(newTK);
            new DialogCustoms("Đã thêm tài khoản " + newTK.TENTK, "Thông báo", DialogCustoms.OK).Show();
            this.Close();
        }
        private string CreateNextTaiKhoanId(string maxId)
        {
            if (maxId is null)
            {
                return "001";
            }
            string newIdString = $"0{int.Parse(maxId.Substring(2)) + 1}";
            return newIdString.Substring(newIdString.Length - 2, 2);
        }
        private void Button_Click(object sender, RoutedEventArgs e) //Them dịch vụ
        {

        }
    }
}
