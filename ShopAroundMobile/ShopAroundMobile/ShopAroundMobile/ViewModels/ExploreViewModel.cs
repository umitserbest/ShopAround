using Newtonsoft.Json;
using ShopAroundMobile.Helpers;
using ShopAroundMobile.Model;
using ShopAroundWeb.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ShopAroundMobile.TabbedPages
{
    public class ExploreViewModel
    {
        string path = "https://shoparound.umitserbest.com/shopassets/products/";

        public ObservableCollection<ExploreGrid> ExploreGrids { get; set; }
        
        List<ProductModel> Products = new List<ProductModel>();


        private async Task<bool> GetProductImagesAync()
        {
            ProductModel signUpModel = new ProductModel();
            string signUpObject = JsonConvert.SerializeObject(signUpModel);

            string result = await WebService.SendDataAsync("GetProducts", null);

            if (result != null)
            {
              
               Products = JsonConvert.DeserializeObject<List<ProductModel>>(result);
                return true;
                
            }


            return false;
        }

        private async void Temp()
        {
            if(await GetProductImagesAync())
            {
                ExploreGrids = new ObservableCollection<ExploreGrid>();
                for (int i = 0; i < 8; i++)
                {
                    ExploreGrids.Add(new ExploreGrid
                    {
                        Image1 = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS5CzzlZuYVrpKeaAyzOxhRhd6w1X0W80AUvWECoX334Z2wdlIl",
                        Image2 = "https://www.yazilimkodlama.com/wp-content/uploads/2016/04/csharp_logo_3.jpg",
                        Image3 = "https://montemagno.com/content/images/2019/01/xamarin-joins-microsoft.png",

                        Image4 = "https://immibbilisim.com/uploads/images/articles/lr1QwkMVjiIw1eCtlt1j.jpg",
                        Image5 = "https://internetdevels.com/sites/default/files/public/blog_preview/xamarin_mobile_app_development.png",
                        Image6 = "https://montemagno.com/content/images/2019/01/xamarin-joins-microsoft.png",

                        Image7 = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS5CzzlZuYVrpKeaAyzOxhRhd6w1X0W80AUvWECoX334Z2wdlIl",
                        Image8 = "https://internetdevels.com/sites/default/files/public/blog_preview/xamarin_mobile_app_development.png",
                        Image9 = "https://www.yazilimkodlama.com/wp-content/uploads/2016/04/csharp_logo_3.jpg"

                    });
                }
            }

          

            List<ExploreGrid> exploreGrids = new List<ExploreGrid>();

            //for (int i = 0; i < 1; i += 9)
            //{

            //    ExploreGrid exploreGrid = new ExploreGrid();

            //    exploreGrid.Image1 = path + Products[i].CoverImage;
            //    exploreGrid.Image2 = path + Products[i + 1].CoverImage;
            //    exploreGrid.Image3 = path + Products[i + 2].CoverImage;

            //    exploreGrid.Image4 = path + Products[i + 3].CoverImage;
            //    exploreGrid.Image5 = "https://internetdevels.com/sites/default/files/public/blog_preview/xamarin_mobile_app_development.png";
            //    exploreGrid.Image6 = "https://montemagno.com/content/images/2019/01/xamarin-joins-microsoft.png";

            //    exploreGrid.Image7 = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS5CzzlZuYVrpKeaAyzOxhRhd6w1X0W80AUvWECoX334Z2wdlIl";
            //    exploreGrid.Image8 = "https://internetdevels.com/sites/default/files/public/blog_preview/xamarin_mobile_app_development.png";
            //    exploreGrid.Image9 = "https://www.yazilimkodlama.com/wp-content/uploads/2016/04/csharp_logo_3.jpg";


            //    //exploreGrids.Add(exploreGrid);
            //    ExploreGrids.Add(exploreGrid);
            //}



        }



        public ExploreViewModel()
        {
           Temp();

        }

    }
}
