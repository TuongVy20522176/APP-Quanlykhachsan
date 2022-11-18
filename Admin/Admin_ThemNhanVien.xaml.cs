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
    /// Interaction logic for Admin_ThemNhanVien.xaml
    /// </summary>
    public partial class Admin_ThemNhanVien : Window
    {
        public Admin_ThemNhanVien()
        {
            InitializeComponent();
            CCCD.MaxLength = 12;
            SoDienThoai.MaxLength = 10;
        }
        private static readonly StaffLogic nhanvienlogic = new StaffLogic();

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

        private string CreateNextNhanVienId(string maxId)
        {
            if (maxId is null)
            {
                return "NV01";
            }
            string newIdString = $"0{int.Parse(maxId.Substring(2)) + 1}";
            return "NV" + newIdString.Substring(newIdString.Length - 2, 2);
        }


        private void ThemButton_Click(object sender, RoutedEventArgs e)
        {
            if (KiemTra() != true)
                return;
            else
            {
                var Nhanvien = nhanvienlogic.GetNHANVIENs();
                string last_nhanvien_id;
                if (Nhanvien.Any())
                {
                    var lastNhanvien = Nhanvien.Last();
                    last_nhanvien_id = lastNhanvien.MANV;
                }
                else
                    last_nhanvien_id = null;

                NHANVIEN newNV = new NHANVIEN();
                newNV.TENNV = TenNhanVien.Text;
                newNV.SDT = SoDienThoai.Text;
                newNV.CCCD = CCCD.Text;
                newNV.DIACHI = DiaChi.Text;
                newNV.GIOITINH = GioiTinh.Text;
                newNV.CHUCVU = ChucVu.Text;
                newNV.LUONG = decimal.Parse(Luong.Text);
                newNV.MANV = CreateNextNhanVienId(last_nhanvien_id);
                nhanvienlogic.AddStaff(newNV);
                new DialogCustoms("Đã thêm nhân viên " + newNV.TENNV, "Thông báo", DialogCustoms.OK).Show();
                this.Close();
            }
        }
        private void HuyButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
