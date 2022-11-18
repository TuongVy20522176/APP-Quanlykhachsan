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
    /// Interaction logic for Admin_ThemThietBi.xaml
    /// </summary>
    public partial class Admin_ThemThietBi : Window
    {
        public Admin_ThemThietBi()
        {
            InitializeComponent();
        }

        private void HuyButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private static readonly FacilityLogic TB = new FacilityLogic();

        private string CreateNextThietBiId(string maxId)
        {
            if (maxId is null)
            {
                return "TB01";
            }
            string newIdString = $"0{int.Parse(maxId.Substring(2)) + 1}";
            return "TB" + newIdString.Substring(newIdString.Length - 2, 2);
        }

        private void CapNhatButton_Click(object sender, RoutedEventArgs e)
        {
            var thietbi = TB.GetTHIETBIs();
            string last_thietbi_id;
            if (thietbi.Any())
            {
                var lastthietbi = thietbi.Last();
                last_thietbi_id = lastthietbi.MATB;
            }
            else
                last_thietbi_id = null;

            THIETBI newTB = new THIETBI();
            newTB.TENTB = txtTenTN.Text;


            newTB.MATB = CreateNextThietBiId(last_thietbi_id);
            TB.AddThietbi(newTB);
            new DialogCustoms("Đã thêm thiết bị " + newTB.TENTB, "Thông báo", DialogCustoms.OK).Show();
            this.Close();

        }
    }
}
