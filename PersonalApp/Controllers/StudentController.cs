using Dataaccess;
using Dataaccess.Entites;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using PersonalApp.Configuration;
using PersonalApp.Utilites;
using PersonalModel.Models;
using System.Diagnostics.Contracts;
using System.Net;

namespace PersonalApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IAppSettings appSettings;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICookiesHelper cookiesHelper;
        private readonly Utilites.StoredProcedure storedProcedure;
        
        public StudentController(IAppSettings appSettings, IUnitOfWork unitOfwork, ICookiesHelper cookiesHelper, IConfiguration configuration)
        {
            this.appSettings = appSettings;
            this.unitOfWork = unitOfwork;
            this.cookiesHelper = cookiesHelper;
            storedProcedure = new Utilites.StoredProcedure(configuration);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(student model)
        {
            try
            {
                
                Customer data = new Customer();
                data.Name = model.Name;
                data.Email = model.Email;
                unitOfWork.customerRepo.Add(data);
                unitOfWork.Save();
                return RedirectToAction("Index", "Student");
            }
            catch(Exception ex)
            {

            }
            return View();
        }


        public void SendNotofy(string v)
        {
            Console.WriteLine(v);
        }


    }
}
