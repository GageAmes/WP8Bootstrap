namespace WP8Bootstrap.Views
{
    using System.Windows.Navigation;
    using Microsoft.Phone.Controls;

    public partial class DetailsPage : PhoneApplicationPage
    {
        public DetailsPage()
        {
            InitializeComponent();

            this.DataContext = App.ItemViewModel;
        }
    }
}