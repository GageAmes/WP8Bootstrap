namespace WP8Bootstrap.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using WP8Bootstrap.Views;

    /// <summary> 
    /// A helper to provide navigation between pages within a ViewModel or elsewhere.
    /// </summary> 
    /// http://code.msdn.microsoft.com/wpapps/Sharing-CodeAdding-a4c4beb8
    public class NavigationHelper : INavigationHelper
    {
        private static readonly Dictionary<Type, string> PageRouting = new Dictionary<Type, string>
        { 
                { typeof(MainPage), "Views/MainPage.xaml" },
                { typeof(DetailsPage), "Views/DetailsPage.xaml" } 
        };

        public bool CanGoBack
        {
            get
            {
                return RootFrame.CanGoBack;
            }
        }

        private Frame RootFrame
        {
            get { return Application.Current.RootVisual as Frame; }
        }

        public void GoBack()
        {
            this.RootFrame.GoBack();
        }

        public void Navigate<TDestinationPage>(string query = "")
        {
            if (PageRouting.ContainsKey(typeof(TDestinationPage)))
            {
                string page = PageRouting[typeof(TDestinationPage)];
                this.RootFrame.Navigate(new Uri("/" + page + query, UriKind.Relative));
            }
        }
    }
}
