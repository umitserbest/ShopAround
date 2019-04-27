using ShopAroundMobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShopAroundMobile.ViewModels
{
    //public class ImageTappedCommand : ICommand
    //{
    //    ExploreViewModel viewModel;

    //    public ImageTappedCommand(ExploreViewModel explore)
    //    {
    //        this.viewModel = explore;
    //    }

    //    public event EventHandler CanExecuteChanged;

    //    public bool CanExecute(object parameter)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Execute(object parameter)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}


    public class ExploreViewModel
    {
        public ICommand imageTapped { get; set; }
        public INavigation Navigation { get; set; }

        public ExploreViewModel()
        {
            imageTapped = new Command(onTapped);
        }

        public async void onTapped(object s)
        {
            //await Navigation.PushAsync(new PhotoDetailPage(image.Source,));
        }
    }
}
