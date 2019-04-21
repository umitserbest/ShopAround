using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;

using FFImageLoading;
using FFImageLoading.Forms;
using Xamarin.Forms;

namespace ShopAroundMobile
{
    public class myItemSource : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public myItemSource()
        {
            MyItemsSource = new ObservableCollection<View>()
            {
                new CachedImage() { Source = "texture.jpg",  DownsampleToViewSize = true},
                new CachedImage() { Source = "home.png", DownsampleToViewSize = true },
                new CachedImage() { Source = "explore.png", DownsampleToViewSize = true }
            };

            MyCommand = new Command(() =>
            {
                Debug.WriteLine("Position selected.");
            });
        }

        ObservableCollection<View> _myItemsSource;
        public ObservableCollection<View> MyItemsSource
        {
            set
            {
                _myItemsSource = value;
                OnPropertyChanged("MyItemsSource");
            }
            get
            {
                return _myItemsSource;
            }
        }

        public Command MyCommand { protected set; get; }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
