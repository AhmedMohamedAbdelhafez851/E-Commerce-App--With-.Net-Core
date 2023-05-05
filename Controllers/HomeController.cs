using Microsoft.AspNetCore.Mvc;
using Labs.Models;
using Microsoft.EntityFrameworkCore;
using Labs.Bl;
namespace Labs.Controllers
{

    public class HomeController : Controller
    {
        IItems oClsItems;
        ISliders oClsSliders; 
        ICategories oClsCategories;    
        public HomeController(IItems item , ISliders slider , ICategories category)
        {
            oClsItems = item;  
            oClsSliders = slider;  
            oClsCategories = category; 

        }
        public IActionResult Index()
        {
            //var categories = context.TbCategories.Where(s => s.CategoryName.EndsWith("e") && s.CreatedDate < DateTime.Now)
            //              .OrderBy(a => a.CategoryName).OrderBy(d => d.CreatedDate).ToList();
            VmHomePage vm = new VmHomePage(); 
            
             vm.lstAllItems = oClsItems.GetAllItemData(null).Take(12).ToList();
            vm.lstRecommendedItems = oClsItems.GetAllItemData(null).Skip(60).Take(10).ToList();
            vm.lstNewItems = oClsItems.GetAllItemData(null).Skip(90).Take(10).ToList();

            vm.lstNewItems = oClsItems.GetAllItemData(null).Skip(200).Take(10).ToList();
            vm.lstFreeDelivry = oClsItems.GetAllItemData(null).Take(4).ToList();
            vm.lstSliders = oClsSliders.GetAll();
            vm.lstCategories = oClsCategories.GetAll().Take(4).ToList(); 




            return View(vm);
        }

    }
}
