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
        private const int MAX_REQUEST = 5;

        public static async Task<string> SendDataAsync(string methodName, string data)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string requestURL = ServiceURL + "/" + methodName + "?" + data;

                    for (int request = 0; request < MAX_REQUEST; request++)
                    {
                        HttpResponseMessage response = await client.GetAsync(requestURL);

                        if (response.IsSuccessStatusCode)
                        {
                            string result = await response.Content.ReadAsStringAsync();

                            if(result != "null")
                            {
                                return result;
                            }
                            await Task.Delay(500);
                        }
                        else
                        {
                            return "Error";
                        }
                    }
                    return "null";
                   
                }
            }
            catch
            {
                return "Error";
            }
        }

        public async Task<string> SendDataNoStaticAsync(string methodName, string data)
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


    }
}
