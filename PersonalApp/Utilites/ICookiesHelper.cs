using Dataaccess.Entites;
using PersonalModel.Models;

namespace PersonalApp.Utilites
{
    public interface ICookiesHelper
    {
        UserBusinessModel ReadUserModelFromCookie();
        void ClearCookies();
    }
}
