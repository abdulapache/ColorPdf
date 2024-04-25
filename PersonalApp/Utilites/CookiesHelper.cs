using Dataaccess.Entites;
using Newtonsoft.Json;
using PersonalModel.Models;
using System.Text.Json;
using JsonException = Newtonsoft.Json.JsonException;

namespace PersonalApp.Utilites
{
    public class CookiesHelper : ICookiesHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CookiesHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public UserBusinessModel ReadUserModelFromCookie()
        {
            UserBusinessModel userModel = new UserBusinessModel();

            HttpContext context = _httpContextAccessor.HttpContext;

            // Get the cookie from the request cookies
            string cookieValue = context.Request.Cookies["UserCookies"];
            if (string.IsNullOrEmpty(cookieValue))
            {

                return userModel;
            }



            try
            {
                userModel = JsonConvert.DeserializeObject<UserBusinessModel>(cookieValue);


            }
            catch (JsonException ex)
            {

            }
            return userModel;
        }
        public void ClearCookies()
        {
            HttpContext context = _httpContextAccessor.HttpContext;
            foreach (var cookie in context.Request.Cookies.Keys)
            {
                context.Response.Cookies.Delete(cookie);
            }
        }
    }
}
