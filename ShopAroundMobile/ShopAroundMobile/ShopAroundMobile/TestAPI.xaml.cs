using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShopAroundMobile.Helpers;
using ShopAroundMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopAroundMobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TestAPI : ContentPage
	{
		public TestAPI ()
		{
            InitializeComponent();
		}

        private async void SignUpAsync(object sender, EventArgs e)
        {
            SignUpModel signUpModel = new SignUpModel("test", "test", "test");
            string signUpObject = JsonConvert.SerializeObject(signUpModel);

            ((Button)sender).Text = await WebService.SendDataAsync("SignUp", "signUpObject=" + signUpObject);      
        }

        private async void SignInAsync(object sender, EventArgs e)
        {
            SignInModel signInModel = new SignInModel("test", "test");
            string signInObject = JsonConvert.SerializeObject(signInModel);

            ((Button)sender).Text = await WebService.SendDataAsync("SignIn", "signInObject=" + signInObject);
        }

        //private async void Test()
        //{
        //    object userInfos = new { email = "test", password = "pass" };
        //    var jsonObj = JsonConvert.SerializeObject(userInfos);

        //    using (HttpClient client = new HttpClient())
        //    {
        //        StringContent content = new StringContent(jsonObj.ToString(), Encoding.UTF8, "application/json");
        //        var request = new HttpRequestMessage()
        //        {
        //            RequestUri = new Uri("http://shoparound.umitserbest.com/webservices/UserService.asmx/SignUp"),
        //            Method = HttpMethod.Post,
        //            Content = content
        //        };
        //        //you can add headers                
        //        //request.Headers.Add("key", "value");
        //        var response = await client.SendAsync(request);
        //        string dataResult = response.Content.ReadAsStringAsync().Result;

        //    }
        //}

        //private async void metodo2()
        //{
        //    var client = new HttpClient();
        //    client.BaseAddress = new Uri("http://mysite.com/Public/api/customers/add");

        //    string jsonData = @"{""first_name"" : ""Sashell"", ""last_name"" : ""hijo de haskell"",  ""phone"" : ""555-555-555"",  ""email"" : ""blancavergas@gmail.com"", ""address"" : ""revolucion 205"", ""city"" : ""mexico"", ""state"" : ""MX""}";

        //    try
        //    {
        //        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //        HttpResponseMessage response = await client.PostAsync("", content);

        //        // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
        //        var result = await response.Content.ReadAsStringAsync();
        //    }
        //    catch (Exception er)
        //    {
        //        //var lb = er.ToString();
        //        //var js = "xs";
        //    }
        //}


    }
}