using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using System.Diagnostics;
using FFImageLoading.Forms;
using System.ComponentModel;
using static ShopAroundMobile.Carousel.carouselVm;

namespace ShopAroundMobile.Carousel
{
    public class carouselVm /*: INotifyPropertyChanged*/
    {
        public ObservableCollection<carouselModel> Carousels { get; set; }

        myItemSource M1 = new myItemSource();

        public carouselVm()
        {
            try
            {
                Carousels = new ObservableCollection<carouselModel>();

                Carousels.Add(new carouselModel
                {
                   //Image1 = 
                   //Image2 = "explore",
                   //Image3 = "profile",
                   //Image4 = "home"

                    MyItemsSource = M1.MyItemsSource
                   
                });

                Carousels.Add(new carouselModel
                {
                    MyItemsSource = M1.MyItemsSource
                });

                Carousels.Add(new carouselModel
                {
                    MyItemsSource = M1.MyItemsSource
                });

                //Carousels.Add(new carouselModel
                //{
                //    ShopName = "Zara",
                //    MyItemsSource = MyItemsSource,
                //    MyCommand = MyCommand
                //});

                //Carousels.Add(new carouselModel
                //{
                //    ShopName = "Mavi",
                //    MyItemsSource = MyItemsSource,
                //    MyCommand = MyCommand
                //});

                //MyItemsSource = new ObservableCollection<View>()
                //{
                //    new CachedImage() { Source = "texture.jpg",  DownsampleToViewSize = true},
                //    new CachedImage() { Source = "home.png", DownsampleToViewSize = true },
                //    new CachedImage() { Source = "explore.png", DownsampleToViewSize = true }
                //};


                //MyCommand = new Command(() =>
                //{
                //    Debug.WriteLine("Position selected.");
                //});
            }
            catch(Exception)
            {
                    
            }
        }
        

        //ObservableCollection<View> _myItemsSource;
        //public ObservableCollection<View> MyItemsSource
        //{
        //    set
        //    {
        //        _myItemsSource = value;
        //        OnPropertyChanged("MyItemsSource");
        //    }
        //    get
        //    {
        //        return _myItemsSource;
        //    }
        //}

        //public Command MyCommand { protected set; get; }

        //public event PropertyChangedEventHandler PropertyChanged;

        //protected virtual void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

    }
}
