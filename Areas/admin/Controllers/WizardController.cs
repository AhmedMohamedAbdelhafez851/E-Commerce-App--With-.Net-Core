using Microsoft.AspNetCore.Mvc;

namespace Labs.Areas.admin.Controllers
{
    [Area("admin")]
    public class WizardController : Controller
    {
        public IActionResult Profile()
        {
  
            return View();
        }
        public IActionResult Acc()
        {

            return View();
        }
        public IActionResult Popups()
        {
            return View(); 
        }
    }
}
