using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShopAroundMobile.Helpers
{
    public class WebService
    {
        private const string ServiceURL = "http://shoparound.umitserbest.com/WebServices/UserService.asmx";

        public static async Task<string> SendDataAsync(string methodName, string data)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string requestURL = ServiceURL + "/" + methodName + "?" + data;

                    HttpResponseMessage response = await client.GetAsync(requestURL);                    

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();

                        return result;
                    }
                    else
                    {
                        return "Error";
                    }
                }
            }
            catch
            {
                return "Error";
            }
        }



        //public static async Task<string> Test()
        //{
        //    object userInfos = new { email = "test", password = "pass" };
        //    var jsonObj = JsonConvert.SerializeObject(userInfos);

        //    using (HttpClient client = new HttpClient())
        //    {
        //        StringContent content = new StringContent(jsonObj.ToString(), Encoding.UTF8, "application/json");
        //        var request = new HttpRequestMessage()
        //        {
        //            RequestUri = new Uri("http://shoparound.umitserbest.com/webservices/JqueryService.aspx/SignUp"),
        //            Method = HttpMethod.Post,
        //            Content = content
        //        };
        //        //you can add headers                
        //        //request.Headers.Add("key", "value");
        //        var response = await client.SendAsync(request);
        //        string dataResult = response.Content.ReadAsStringAsync().Result;
        //        return dataResult;
        //    }
        //}

    }
}
