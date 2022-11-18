﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Giao_dien_dang_nhap.Admin
{
    /// <summary>
    /// Interaction logic for TimeDate.xaml
    /// </summary>
    public partial class TimeDate : Page
    {
        public TimeDate()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.dateText.Text = DateTime.Now.ToString("dd/MM/yyyy    HH:mm:ss");
            }, this.Dispatcher);
        }
    }
}
