using ShopAroundMobile.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ShopAroundMobile.ViewModels
{
    public class ShowcaseViewModel
    {
        private bool _productInfoVisible;
        public bool ProductInfoVisible
        {

            get
            {
                return _productInfoVisible;
            }
            set
            {
                _productInfoVisible = value;

                if(_productInfoVisible == true)
                {
                    // Show frame
                }
                else
                {
                    // Hide frame
                }
            }
        }


        public ObservableCollection<ShowcaseModel> Posts { get; set; }

        public ShowcaseViewModel()
        {
            Posts = new ObservableCollection<ShowcaseModel>();

            Posts.Add(new ShowcaseModel
            {
                ShopName="Mavi",
                Image = "https://upload.wikimedia.org/wikipedia/commons/2/28/Logo_of_Mavi.png"
            });

            Posts.Add(new ShowcaseModel
            {
                ShopName = "Zara",
                Image = "https://static.dezeen.com/uploads/2019/02/new-zara-logo-col-2-852x352.jpg"
            });

            Posts.Add(new ShowcaseModel
            {
                ShopName = "Adidas",
                Image = "https://i.ebayimg.com/images/g/LJYAAOSwjXRXbI-N/s-l300.jpg"
            });

            Posts.Add(new ShowcaseModel
            {
                ShopName = "Pull and Bear",
                Image = "https://upload.wikimedia.org/wikipedia/commons/4/4e/Pull_and_bear_logo_antiguo.jpg"
            });



        }
    }
}
