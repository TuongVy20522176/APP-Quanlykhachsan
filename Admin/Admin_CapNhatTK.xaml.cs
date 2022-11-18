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
    /// Interaction logic for Admin_CapNhatTK.xaml
    /// </summary>
    public partial class Admin_CapNhatTK : Window
    {
        public Admin_CapNhatTK()
        {
            InitializeComponent();
        }
        private string MATK;
        TAIKHOAN Taikhoan = new TAIKHOAN();
        private static readonly AccountLogic tklogic = new AccountLogic();
        public Admin_CapNhatTK(TAIKHOAN taikhoan) : this()
        {
            InitializeComponent();

            txtTaikhoan.Text = taikhoan.TENTK;
            txtMatkhau.Text = taikhoan.MATKHAU;
            cmbVaitro.Text = taikhoan.VAITRO;

            MATK = taikhoan.MATK;

            Taikhoan = taikhoan;
        }
        private bool KiemTra()
        {
            if (string.IsNullOrWhiteSpace(txtTaikhoan.Text))
            {
                new DialogCustoms("Vui lòng nhập tên tài khoản", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtMatkhau.Text))
            {
                new DialogCustoms("Vui lòng nhập mật khẩu", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cmbVaitro.Text))
            {
                new DialogCustoms("Vui lòng chọn vai trò", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }

            else
            {
                return true;
            }
        }

        private void HuyButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCapNhatTK_Click(object sender, RoutedEventArgs e)
        {
            if (!KiemTra())
            {
                return;
            }
            else
            {
                Taikhoan.TENTK = txtTaikhoan.Text;
                Taikhoan.MATKHAU = txtMatkhau.Text;
                Taikhoan.VAITRO = cmbVaitro.Text;

                tklogic.UpdateTaikhoan(Taikhoan);
                new DialogCustoms("Đã cập nhật thành công", "Thông báo", DialogCustoms.OK).Show();
                this.Close();
            }
        }
    }
}