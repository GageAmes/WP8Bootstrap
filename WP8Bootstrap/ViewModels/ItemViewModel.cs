namespace WP8Bootstrap.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Windows.Input;
    using WP8Bootstrap.Extensions;

    public class ItemViewModel : DefaultNotifyPropertyChanged
    {
        private string id;
        private string lineOne;
        private string lineTwo;
        private string lineThree;

        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                if (value != null && !value.Equals(id))
                {
                    id = value;
                    NotifyPropertyChanged("ID");
                }
            }
        }

        public string LineOne
        {
            get
            {
                return lineOne;
            }
            set
            {
                if (value != lineOne)
                {
                    lineOne = value;
                    NotifyPropertyChanged("LineOne");
                }
            }
        }

        public string LineTwo
        {
            get
            {
                return lineTwo;
            }
            set
            {
                if (value != lineTwo)
                {
                    lineTwo = value;
                    NotifyPropertyChanged("LineTwo");
                }
            }
        }

        public string LineThree
        {
            get
            {
                return lineThree;
            }
            set
            {
                if (value != lineThree)
                {
                    lineThree = value;
                    NotifyPropertyChanged("LineThree");
                }
            }
        }
    }
}