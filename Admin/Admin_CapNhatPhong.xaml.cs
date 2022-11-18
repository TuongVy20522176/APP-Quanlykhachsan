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
    /// Interaction logic for Admin_CapNhatPhong.xaml
    /// </summary>
    public partial class Admin_CapNhatPhong : Window
    {
        public Admin_CapNhatPhong()
        {
            InitializeComponent();
        }

        private string MaPHONG;
        private static readonly RoomLogic phonglogic = new RoomLogic();
        private static readonly RoomTypeLogic loaiphonglogic = new RoomTypeLogic();
        public Admin_CapNhatPhong(PHONG phong) : this()
        {
            InitializeComponent();

            cmbLoaiPhong.ItemsSource = loaiphonglogic.GetRoomTypes();
            cmbLoaiPhong.DisplayMemberPath = "TENLP";
            cmbLoaiPhong.SelectedValuePath = "MALP";

            txtSoPhong.Text = phong.MAPHONG;
            cmbTinhTrang.Text = phong.TINHTRANG;
            cmbLoaiPhong.Text = phong.LOAIPHONG;

            MaPHONG = phong.MAPHONG;
        }
        private bool KiemTra()
        {
            if (string.IsNullOrWhiteSpace(txtSoPhong.Text))
            {
                new DialogCustoms("Vui lòng nhập số phòng", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cmbLoaiPhong.Text))
            {
                new DialogCustoms("Vui lòng chọn loại phòng", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cmbTinhTrang.Text))
            {
                new DialogCustoms("Vui lòng chọn tình trạng", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            else
            {
                int so;
                if (int.TryParse(txtSoPhong.Text, out so) == true || KiemTraTenPhong() == false)
                {
                    new DialogCustoms("Vui lòng nhập đúng định dạng số phòng ", "Thông báo", DialogCustoms.OK).Show();
                    return false;
                }
            }
            return true;
        }

        public bool KiemTraTenPhong()
        {
            string str = txtSoPhong.Text;
            int so;
            if (str.Length == 4)
            {
                if (str[0].Equals('P') && int.TryParse(str[1].ToString(), out so) && int.TryParse(str[2].ToString(), out so) && int.TryParse(str[3].ToString(), out so))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
        private void HuyButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            if (!KiemTra())
            {
                return;
            }
            else
            {
                var Phong = phonglogic.GetRoom_ID(MaPHONG);
                Phong.MAPHONG = txtSoPhong.Text;
                Phong.TINHTRANG = cmbTinhTrang.Text;
                Phong.LOAIPHONG = cmbLoaiPhong.Text;
                Phong.MAPHONG = MaPHONG;
                phonglogic.UpdateRoom();
                new DialogCustoms("Đã cập nhật thành công", "Thông báo", DialogCustoms.OK).Show();

                this.Close();
            }
        }

    }
}
