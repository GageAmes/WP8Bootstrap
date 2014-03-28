namespace WP8Bootstrap.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Net;
    using System.Windows.Input;
    using Newtonsoft.Json;
    using WP8Bootstrap.Extensions;
    using WP8Bootstrap.Helpers;
    using WP8Bootstrap.Views;

    public class MainViewModel : DefaultNotifyPropertyChanged
    {
        private bool isDataLoaded;
        private bool isError;
        private bool isLoading;
        private DelegateCommand loadDataCommand;
        private DelegateCommand viewItemDetailsCommand;
        private INavigationHelper navigationHelper;

        public MainViewModel(INavigationHelper navigationHelper)
        {
            this.navigationHelper = navigationHelper;
            this.Items = new ObservableCollection<ItemViewModel>();
            this.isDataLoaded = false;
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }

        public bool IsDataLoaded
        {
            get
            {
                return this.isDataLoaded;
            }

            set
            {
                if (!value.Equals(this.isDataLoaded))
                {
                    this.isDataLoaded = value;
                    this.NotifyPropertyChanged("IsDataLoaded");
                }
            }
        }

        public bool IsError
        {
            get
            {
                return this.isError;
            }

            set
            {
                if (!value.Equals(this.isError))
                {
                    this.isError = value;
                    this.NotifyPropertyChanged("IsError");
                }
            }
        }

        public bool IsLoading
        {
            get
            {
                return this.isLoading;
            }

            set
            {
                if (!value.Equals(this.isLoading))
                {
                    this.isLoading = value;
                    this.NotifyPropertyChanged("IsLoading");
                }
            }
        }

        public ICommand LoadDataCommand
        {
            get
            {
                if (this.loadDataCommand == null)
                {
                    this.loadDataCommand = new DelegateCommand(o => this.LoadData());
                }
                return this.loadDataCommand;
            }
        }

        public ICommand ViewItemDetailsCommand
        {
            get
            {
                if (this.viewItemDetailsCommand == null)
                {
                    this.viewItemDetailsCommand = new DelegateCommand(item => this.ShowDetailsPage(item));
                }
                return this.viewItemDetailsCommand;
            }
        }

        /// <summary>
        /// Loads ItemViewModel objects from JSON into the Items collection.
        /// </summary>
        private void LoadData()
        {
            WebClient client = new WebClient();
            client.Headers["Accept"] = "text/json";
            client.DownloadStringCompleted += this.DataLoaded;

            if (!this.IsDataLoaded)
            {
                this.IsError = false;
                this.IsLoading = true;

                // Sample data; replace with real data
                client.DownloadStringAsync(new Uri("https://gist.githubusercontent.com/gageames/9819471/raw/2f7181cdbd76bac73150bb0d9155d1b201d6800e/WP8Bootstrap.json"));
            }
        }

        /// <summary>
        /// Callback for when the JSON has been downloaded from the web
        /// </summary>
        private void DataLoaded(object sender, DownloadStringCompletedEventArgs e)
        {
            JsonSerializer serializer = new JsonSerializer();

            if (!e.Cancelled && e.Error == null)
            {
                Collection<ItemViewModel> data = serializer.Deserialize<Collection<ItemViewModel>>(new JsonTextReader(new System.IO.StringReader(e.Result)));

                this.Items.Clear();
                foreach (ItemViewModel item in data)
                {
                    this.Items.Add(item);
                }

                this.IsDataLoaded = true;
            }
            else
            {
                this.IsError = true;
            }

            this.IsLoading = false;
        }

        private void ShowDetailsPage(object item)
        {
            App.ItemViewModel = item as ItemViewModel;
            this.navigationHelper.Navigate<DetailsPage>();
        }
    }
}