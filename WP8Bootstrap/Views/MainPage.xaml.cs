using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WP8Bootstrap.Resources;
using WP8Bootstrap.ViewModels;

namespace WP8Bootstrap.Views
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.DataContext = App.MainViewModel;
        }
    }
}