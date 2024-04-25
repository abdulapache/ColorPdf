using Dataaccess;
using Microsoft.AspNetCore.Mvc;
using PersonalModel.Models;

namespace PersonalApp.Controllers
{
    public class PdfController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> PdfColorFile(PdfColorRequest model)
        {

            try
            {
                if (model.pdfFileName != null)
                {
                    
                }
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("LeaderApplication", "Pl");
        }


    }
}
