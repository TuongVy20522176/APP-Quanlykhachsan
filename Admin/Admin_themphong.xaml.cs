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
    /// Interaction logic for Admin_themphong.xaml
    /// </summary>
    public partial class Admin_themphong : Window
    {
        public Admin_themphong()
        {
            InitializeComponent();

            cmbLoaiPhong.ItemsSource = loaiphonglogic.GetRoomTypes();
            cmbLoaiPhong.DisplayMemberPath = "TENLP";
            cmbLoaiPhong.SelectedValuePath = "MALP";
        }
        private static readonly RoomLogic P = new RoomLogic();
        private static readonly RoomTypeLogic loaiphonglogic = new RoomTypeLogic();
        private void HuyButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ThemButton_Click(object sender, RoutedEventArgs e) //Them PHONG
        {
            if (KiemTra() == true)
            {
                PHONG newP = new PHONG();
                newP.MAPHONG = txtSoPhong.Text;
                newP.TINHTRANG = cmbTinhTrang.Text;
                newP.LOAIPHONG = cmbLoaiPhong.SelectedValue.ToString();

                P.AddRoom(newP);
                new DialogCustoms("Đã thêm phòng " + newP.MAPHONG, "Thông báo", DialogCustoms.OK).Show();
                this.Close();
            }
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
        private void cmbLoaiPhong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
