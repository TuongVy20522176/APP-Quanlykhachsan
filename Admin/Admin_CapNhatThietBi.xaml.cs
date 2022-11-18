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
    /// Interaction logic for Admin_CapNhatThietBi.xaml
    /// </summary>
    public partial class Admin_CapNhatThietBi : Window
    {
        public Admin_CapNhatThietBi()
        {
            InitializeComponent();
        }
        private string MaTB;
        private static readonly FacilityLogic tblogic = new FacilityLogic();
        public Admin_CapNhatThietBi(THIETBI thietbi) : this()
        {
            InitializeComponent();

            txtTenTN.Text = thietbi.TENTB;

            MaTB = thietbi.MATB;

        }
        private bool KiemTra()
        {
            if (string.IsNullOrWhiteSpace(txtTenTN.Text))
            {
                new DialogCustoms("Vui lòng nhập tên thiết bị", "Thông báo", DialogCustoms.OK).Show();
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
                var Thietbi = tblogic.GetThietbi(MaTB);
                Thietbi.TENTB = txtTenTN.Text;
                Thietbi.MATB = MaTB;

                tblogic.UpdateThietbi(Thietbi);
                new DialogCustoms("Đã cập nhật thành công", "Thông báo", DialogCustoms.OK).Show();
                this.Close();
            }
        }
    }
}
