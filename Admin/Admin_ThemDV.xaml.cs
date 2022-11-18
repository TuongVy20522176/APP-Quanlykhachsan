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
    /// Interaction logic for Admin_ThemDV.xaml
    /// </summary>
    public partial class Admin_ThemDV : Window
    {
        public Admin_ThemDV()
        {
            InitializeComponent();
        }
        private static readonly ServiceLogic DichVu = new ServiceLogic();
        private void HuyButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private string CreateNextDichVuId(string maxId)
        {
            if (maxId is null)
            {
                return "DV01";
            }
            string newIdString = $"0{int.Parse(maxId.Substring(2)) + 1}";
            return "DV" + newIdString.Substring(newIdString.Length - 2, 2);
        }
        private void ThemButton_Click(object sender, RoutedEventArgs e) //Them dịch vụ
        {
            if (!KiemTra())
            {
                return;
            }
            else
            {
                var dichvu = DichVu.GetDICHVUs();
                string last_dichvu_id;
                if (dichvu.Any())
                {
                    var lastDichvu = dichvu.Last();
                    last_dichvu_id = lastDichvu.MADV;
                }
                else
                    last_dichvu_id = null;

                DICHVU newDV = new DICHVU();
                newDV.TENDV = txtTenDichVu.Text;
                newDV.DONGIA = int.Parse(txtGia.Text);

                newDV.MADV = CreateNextDichVuId(last_dichvu_id);
                DichVu.AddService(newDV);
                new DialogCustoms("Đã thêm dịch vụ " + newDV.TENDV, "Thông báo", DialogCustoms.OK).Show();
                this.Close();
            }
        }
        private bool KiemTra()
        {
            if (string.IsNullOrWhiteSpace(txtTenDichVu.Text))
            {
                new DialogCustoms("Vui lòng nhập tên dịch vụ", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtGia.Text))
            {
                new DialogCustoms("Vui lòng nhập giá", "Thông báo", DialogCustoms.OK).Show();
                return false;
            }
            else
            {
                int so;
                if (int.TryParse(txtTenDichVu.Text, out so) == true)
                {
                    new DialogCustoms("Vui lòng nhập đúng định đạng tên dịch vụ", "Thông báo", DialogCustoms.OK).Show();
                    return false;
                }
                if (int.TryParse(txtGia.Text, out so) == false)
                {
                    new DialogCustoms("Vui lòng nhập đúng định đạng giá", "Thông báo", DialogCustoms.OK).Show();
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
