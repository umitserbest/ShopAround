using Newtonsoft.Json;
using ShopAroundWeb.Database;
using ShopAroundWeb.Models;
using System.Web.Script.Services;
using System.Web.Services;

namespace ShopAroundWeb.WebServices
{
    /// <summary>
    /// Summary description for UserService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UserService : WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void SignUp(string signUpObject)
        {
            try
            {
                UserSignUpModel model = JsonConvert.DeserializeObject<UserSignUpModel>(signUpObject);

                if (DatabaseForUser.IsAvailableUsername(model.Username) && DatabaseForUser.IsAvailableEmail(model.Email))
                {
                    bool result = DatabaseForUser.SignUp(model);

                    Context.Response.Write(result);
                }
                else
                {
                    Context.Response.Write("false");
                }                
            }
            catch
            {
                Context.Response.Write("false");
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void SignIn(string signInObject)
        {
            try
            {
                UserSignInModel model = JsonConvert.DeserializeObject<UserSignInModel>(signInObject);
               
                string result = DatabaseForUser.SignIn(model);

                if (result != null)
                {
                    Context.Response.Write(result);
                }
                else
                {
                    Context.Response.Write("false");
                }
            }
            catch
            {
                Context.Response.Write("false");
            }
        }
    }
}