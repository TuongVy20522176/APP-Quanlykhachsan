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
    /// Interaction logic for Admin_CapNhatLoaiPhong.xaml
    /// </summary>
    public partial class Admin_CapNhatLoaiPhong : Window
    {
        public Admin_CapNhatLoaiPhong()
        {
            InitializeComponent();
        }
        private string MaLP;
        private static RoomTypeLogic roomTypeLogic = new RoomTypeLogic();
        public Admin_CapNhatLoaiPhong(LOAIPHONG loaiPhong) : this()
        {
            InitializeComponent();

            TenLoaiPhong.Text = loaiPhong.TENLP.ToString();
            SoNguoi.Text = loaiPhong.SONGUOI.ToString();
            GiaNgay.Text = loaiPhong.DONGIA.ToString();
            ThongTin.Text = loaiPhong.THONGTIN.ToString();

            MaLP = loaiPhong.MALP.ToString();
        }
        private void HuyButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool KiemTra()
        {
            if (string.IsNullOrWhiteSpace(TenLoaiPhong.Text))
            {
                new DialogCustoms("Vui lòng nhập tên loại phòng", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(SoNguoi.Text))
            {
                new DialogCustoms("Vui lòng nhập số người tối đa", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(GiaNgay.Text))
            {
                new DialogCustoms("Vui lòng nhập giá ngày", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(ThongTin.Text))
            {
                new DialogCustoms("Vui lòng nhập thông tin", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            else
            {
                int so;
                if (int.TryParse(TenLoaiPhong.Text, out so) == true)
                {
                    new DialogCustoms("Vui lòng nhập đúng định dạng tên loại phòng", "Thông báo", DialogCustoms.OK).Show();
                    return false;
                }
                if (int.TryParse(SoNguoi.Text, out so) == false)
                {
                    new DialogCustoms("Vui lòng nhập đúng định dạng số người tối đa", "Thông báo", DialogCustoms.OK).Show();
                    return false;
                }
                if (int.TryParse(GiaNgay.Text, out so) == false)
                {
                    new DialogCustoms("Vui lòng nhập đúng định dạng giá ngày", "Thông báo", DialogCustoms.OK).Show();
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private void ThemButton_Click(object sender, RoutedEventArgs e)
        {
            if (!KiemTra())
            {
                return;
            }
            else
            {
                var LoaiPhong = roomTypeLogic.getLoaiPhong_maLP(MaLP);
                LoaiPhong.TENLP = TenLoaiPhong.Text;
                LoaiPhong.SONGUOI = (byte?)int.Parse(SoNguoi.Text);
                LoaiPhong.DONGIA = decimal.Parse(GiaNgay.Text);
                LoaiPhong.THONGTIN = ThongTin.Text;
                LoaiPhong.MALP = MaLP;
                roomTypeLogic.UpdateRoomType();
                this.Close();
            }
        }
    }
}
