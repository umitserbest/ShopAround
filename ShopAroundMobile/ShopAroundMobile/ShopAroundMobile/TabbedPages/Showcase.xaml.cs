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
	public partial class Showcase : ContentPage
	{
       

		public Showcase ()
		{
			InitializeComponent ();
            //gridCreator();


             //mainGrid.Children.Add(subGrid, 0, 3);
            //mainGrid.Children.Add(subGrid, 0, 4);
            //mainGrid.Children.Add(subGrid, 0, 5);
            //mainGrid.IsVisible = true;
            //subGrid.IsVisible = true;
            //OthersubGrid.IsVisible = true;
            //mainGrid.Children.Add(subGrid, 0, 0);
            //mainGrid.Children.Add(OthersubGrid, 0, 1);
            //mainGrid.Children.Add(subGrid, 0, 2);

            //for (int i = 3; i <= 5; i++)
            //{
            //    subGrid.IsVisible = true;
            //    //OthersubGrid.IsVisible = true;
            //    mainGrid.Children.Add(subGrid, 0, i);
            //    //if (i % 2 == 0)
            //    //{
            //    //    mainGrid.Children.Add(subGrid, 0, i);
            //    //}
            //    //else
            //    //{
            //    //    mainGrid.Children.Add(OthersubGrid, 0, i);
            //    //}

            //}

            //scroll.Orientation = ScrollOrientation.Vertical;
            //scroll.Content = mainGrid;
            //Content = scroll;


        }

        void gridCreator()
        {
            for (int i = 0; i < 5; i++)
            {
                mainGrid.Children.Add(subGrid, 0, i);
            }
        }
	}
}