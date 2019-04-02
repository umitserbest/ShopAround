using ShopAroundMobile.Helpers;
using ShopAroundMobile.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShopAroundMobile.ViewModels
{
    public class SuggestShopViewModel : INotifyPropertyChanged
    {
        
        public static int counter = 0;

        private bool _IsChecked;

        public bool IsChecked
        {
            get
            {
                return _IsChecked;
            }

            set
            {
                _IsChecked = value;

                if (_IsChecked == true)
                {
                   
                    counter++;
                    //OnPropertyChanged("IsChecked");
                    OnPropertyChanged("CheckedShops");
                }
                else
                {
                    counter--;
                    OnPropertyChanged("CheckedShops");
                }
               
            }
        }

        private int _CheckedShops;

        public int CheckedShops
        {
            get
            {
                return counter;
            }
           
        }



        public ObservableCollection<SuggestShopModel> SuggestShops { get; set; }
       
        public SuggestShopViewModel()
        {


            SuggestShops = new ObservableCollection<SuggestShopModel>();

            SuggestShops.Add(new SuggestShopModel
            {
                ShopImage = "https://upload.wikimedia.org/wikipedia/commons/2/28/Logo_of_Mavi.png",
                ShopName = "Mavi",
                
                
            });

            SuggestShops.Add(new SuggestShopModel
            {
                ShopImage = "https://upload.wikimedia.org/wikipedia/commons/4/4e/Pull_and_bear_logo_antiguo.jpg",
                ShopName = "Pull and Bear"
                 
            });

            SuggestShops.Add(new SuggestShopModel
            {
                ShopImage = "https://static.dezeen.com/uploads/2019/02/new-zara-logo-col-2-852x352.jpg",
                ShopName = "Zara"
            });

            SuggestShops.Add(new SuggestShopModel
            {
                ShopImage = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRUJMCD1CnIMZqivqXtF211-as7CL8EyGiEUBaFOen0WnuCCkcm",
                ShopName = "Koton"
            });

            SuggestShops.Add(new SuggestShopModel
            {
                ShopImage = "https://i.ebayimg.com/images/g/LJYAAOSwjXRXbI-N/s-l300.jpg",
                ShopName = "Adidas"

            });

           
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    }
}
