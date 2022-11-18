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
    /// Interaction logic for Admin_CapNhatDichVu.xaml
    /// </summary>
    public partial class Admin_CapNhatDichVu : Window
    {
        public Admin_CapNhatDichVu()
        {
            InitializeComponent();
        }
        private string MADV;
        DICHVU Dichvu = new DICHVU();
        private static readonly ServiceLogic dvlogic = new ServiceLogic();
        public Admin_CapNhatDichVu(DICHVU dichvu) : this()
        {
            InitializeComponent();

            txtTenDichVu.Text = dichvu.TENDV;
            txtGia.Text = dichvu.DONGIA.ToString();

            MADV = dichvu.MADV;

            Dichvu = dichvu;
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
                new DialogCustoms("Vui lòng nhập đơn giá", "Thông báo", DialogCustoms.OK).Show();
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

        private void btnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            if (!KiemTra())
            {
                return;
            }
            else
            {
                var DichVu = dvlogic.GetDV_ID(MADV);
                DichVu.TENDV = txtTenDichVu.Text;
                DichVu.DONGIA = decimal.Parse(txtGia.Text);
                dvlogic.UpdateService();
                new DialogCustoms("Đã cập nhật thành công", "Thông báo", DialogCustoms.OK).Show();
                this.Close();
            }
        }
    }
}
