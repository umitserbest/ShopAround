using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopAroundMobile.TabbedPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Explore : ContentPage
	{
      
        //Grid mainGrid = new Grid();
        //Grid grid;

        public Explore ()
		{
			InitializeComponent ();

            BindingContext = new ExploreViewModel();

           // _listView.ItemTemplate = new DataTemplate(typeof(CustomCell));


            //mainGrid = new Grid();

            //mainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            //mainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            //mainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            //mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });


            //grid = new Grid();

            //grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            //grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            //grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            //grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            //grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            //grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });


            ////// Grid Row definitions
            ////var row1 = new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) };
            ////var row2 = new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) };
            ////var row3 = new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) };

            ////// Grid Column definitions
            ////var column1 = new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) };
            ////var column2 = new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) };
            ////var column3 = new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) };

            //var boxview1 = new BoxView() { BackgroundColor = Color.Red };
            //var boxview2 = new BoxView() { BackgroundColor = Color.Green };
            //var boxview3 = new BoxView() { BackgroundColor = Color.Yellow };
            //var boxview4 = new BoxView() { BackgroundColor = Color.Black };
            //var boxview5 = new BoxView() { BackgroundColor = Color.Blue };
            //var boxview6 = new BoxView() { BackgroundColor = Color.Pink };
            //var boxview7 = new BoxView() { BackgroundColor = Color.Purple };
            //var boxview8 = new BoxView() { BackgroundColor = Color.Gray };
            //var boxview9 = new BoxView() { BackgroundColor = Color.Orange };

            //grid.Children.Add(boxview1, 0, 0);
            //grid.Children.Add(boxview2, 0, 1);
            //grid.Children.Add(boxview3, 1, 0);
            //Grid.SetRowSpan(boxview3, 2);
            //Grid.SetColumnSpan(boxview3, 2);
            //grid.Children.Add(boxview4, 0, 2);
            //grid.Children.Add(boxview5, 1, 2);
            //grid.Children.Add(boxview6, 2, 2);
            //grid.Children.Add(boxview7, 0, 3);
            //grid.Children.Add(boxview8, 1, 3);
            //grid.Children.Add(boxview9, 2, 3);


            ////mainGrid.Children.Add(grid,0,0);
            ////mainGrid.Children.Add(grid, 0, 1);
            ////mainGrid.Children.Add(grid, 0, 2);

            ////CreateGrid(newgrid);

            //for (int i = 0; i < 3; i++)
            //{
            //    mainGrid.Children.Add(grid, 0, i);

            //}

            ////mainGrid.Children.Add(grid, 0, 0);
            ////mainGrid.Children.Add(grid, 0, 1);


            //var scroll = new ScrollView();
            //scroll.Orientation = ScrollOrientation.Vertical;
            //scroll.Content = mainGrid;
            //Content = scroll;


        }

    }
}