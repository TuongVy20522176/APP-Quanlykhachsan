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
using System.Windows.Shapes;

namespace PhanMemQuanLyKhachSan.Admin
{
    /// <summary>
    /// Interaction logic for Admin_CapNhatNV.xaml
    /// </summary>
    public partial class Admin_CapNhatNV : Window
    {
        public Admin_CapNhatNV()
        {
            InitializeComponent();
            CCCD.MaxLength = 12;
            SoDienThoai.MaxLength = 10;
        }
        private string MaNV;
        private static readonly StaffLogic nhanvienLogic = new StaffLogic();
        public Admin_CapNhatNV(NHANVIEN nhanvien) : this()
        {
            InitializeComponent();
            CCCD.MaxLength = 12;
            SoDienThoai.MaxLength = 10;

            TenNhanVien.Text = nhanvien.TENNV;
            GioiTinh.Text = nhanvien.GIOITINH;
            SoDienThoai.Text = nhanvien.SDT;
            CCCD.Text = nhanvien.CCCD;
            DiaChi.Text = nhanvien.DIACHI;
            ChucVu.Text = nhanvien.CHUCVU;
            Luong.Text = nhanvien.LUONG.ToString();

            MaNV = nhanvien.MANV;
        }
        private bool KiemTra()
        {
            if (string.IsNullOrWhiteSpace(TenNhanVien.Text))
            {
                new DialogCustoms("Vui lòng nhập tên nhân viên", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(GioiTinh.Text))
            {
                new DialogCustoms("Vui lòng chọn giới tính", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(CCCD.Text))
            {
                new DialogCustoms("Vui lòng nhập mã căn cước công dân", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(DiaChi.Text))
            {
                new DialogCustoms("Vui lòng nhập địa chỉ", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(ChucVu.Text))
            {
                new DialogCustoms("Vui lòng nhập chức vụ", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(SoDienThoai.Text))
            {
                new DialogCustoms("Vui lòng nhập số điện thoại", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(Luong.Text))
            {
                new DialogCustoms("Vui lòng nhập lương nhân viên", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            else
            {
                long check;
                int so;

                if (int.TryParse(TenNhanVien.Text, out so) == true)
                {
                    new DialogCustoms("Vui lòng nhập đúng định dạng tên nhân viên", "Thông báo", DialogCustoms.OK).Show();
                    return false;
                }

                if (int.TryParse(ChucVu.Text, out so) == true)
                {
                    new DialogCustoms("Vui lòng nhập đúng định dạng chức vụ", "Thông báo", DialogCustoms.OK).Show();
                    return false;
                }
                if (int.TryParse(DiaChi.Text, out so) == true)
                {
                    new DialogCustoms("Vui lòng nhập đúng định dạng địa chỉ", "Thông báo", DialogCustoms.OK).Show();
                    return false;
                }
                decimal s;
                if (decimal.TryParse(Luong.Text, out s) == false)
                {
                    new DialogCustoms("Vui lòng nhập đúng định dạng lương", "Thông báo", DialogCustoms.OK).Show();
                    return false;
                }

                else if (SoDienThoai.Text.Length < 10 || int.TryParse(SoDienThoai.Text, out so) == false)
                {
                    new DialogCustoms("Sai số điện thoại", "Thông báo", DialogCustoms.OK).Show();
                    return false;
                }
                else if (CCCD.Text.Length > 12 || CCCD.Text.Length < 12 || long.TryParse(CCCD.Text, out check) == false)
                {
                    new DialogCustoms("Sai mã căn cước công dân", "Thông báo", DialogCustoms.OK).Show();
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        private void CapNhatButton_Click(object sender, RoutedEventArgs e)
        {
            if (!KiemTra())
            {
                return;
            }
            else
            {
                NHANVIEN NhanVien = nhanvienLogic.GetStaff(MaNV);
                NhanVien.TENNV = TenNhanVien.Text;
                NhanVien.GIOITINH = GioiTinh.Text;
                NhanVien.SDT = SoDienThoai.Text;
                NhanVien.CCCD = CCCD.Text;
                NhanVien.DIACHI = DiaChi.Text;
                NhanVien.CHUCVU = ChucVu.Text;
                NhanVien.LUONG = Convert.ToDecimal(Luong.Text);
                nhanvienLogic.UpdateStaff();
                new DialogCustoms("Đã cập nhật thành công", "Thông báo", DialogCustoms.OK).Show();
                this.Close();
            }

        }

        private void HuyButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
