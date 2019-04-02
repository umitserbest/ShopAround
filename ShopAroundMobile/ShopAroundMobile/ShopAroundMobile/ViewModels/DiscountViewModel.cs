using ShopAroundMobile.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ShopAroundMobile.ViewModels
{
    public class DiscountViewModel
    {
        public ObservableCollection<Discounts> Discounts {get; set;}

        public DiscountViewModel()
        {
            Discounts = new ObservableCollection<Discounts>();

            Discounts.Add(new Discounts
            {
                DiscountText = "Zara published a discount for Zara's customers. Get the discount code.",
                DiscountImage = "https://static.dezeen.com/uploads/2019/02/new-zara-logo-col-2-852x352.jpg",
                DiscountDetail = "Click here to get the code"
            });

            Discounts.Add(new Discounts
            {
                DiscountText = "Mavi published a discount for Zara's customers. Get the discount code.",
                DiscountImage = "https://upload.wikimedia.org/wikipedia/commons/2/28/Logo_of_Mavi.png",
                DiscountDetail = "Click here to get the code"
            });

            Discounts.Add(new Discounts
            {
                DiscountText = "Adidas published a discount for Zara's customers. Get the discount code.",
                DiscountImage = "https://i.ebayimg.com/images/g/LJYAAOSwjXRXbI-N/s-l300.jpg",
                DiscountDetail = "Click here to get the code"
            });
        }
    }
}
