using Dataaccess;
using Microsoft.AspNetCore.Mvc;
using PersonalApp.Configuration;
using PersonalApp.Utilites;

namespace PersonalApp.Controllers
{
    public class BaseController : Controller
    {
        private readonly IAppSettings appSettings;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICookiesHelper cookiesHelper;
        private readonly Utilites.StoredProcedure storedProcedure;

        public BaseController(IAppSettings appSettings, IUnitOfWork unitOfwork, ICookiesHelper cookiesHelper, IConfiguration configuration)
        {
            this.appSettings = appSettings;
            this.unitOfWork = unitOfwork;
            this.cookiesHelper = cookiesHelper;
            storedProcedure = new Utilites.StoredProcedure(configuration);
        }
    }
}
