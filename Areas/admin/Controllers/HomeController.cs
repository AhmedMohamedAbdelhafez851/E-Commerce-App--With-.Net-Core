using Labs.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Labs.Areas.admin.Controllers
{
    [Area("admin")]                
    public class HomeController : Controller
    {
        [Authorization]          // custom authorizatoin 
        public IActionResult Index()
        {
            return View();
        }
    }
}
