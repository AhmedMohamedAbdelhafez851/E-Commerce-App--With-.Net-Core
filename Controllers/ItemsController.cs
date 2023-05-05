using Microsoft.AspNetCore.Mvc;
using Labs.Bl;
using Labs.Models;  

namespace Labs.Controllers
{
    public class ItemsController : Controller
    {
       
        IItems oItem; 
        IItemImages oItemImages;    
        public ItemsController(IItems iItem, IItemImages oItemImages)
        {
            oItem = iItem;
            this.oItemImages = oItemImages; 
        }
        public IActionResult ItemDetails(int id)
        {
            var item = oItem.GetItemId(id);
            VmItemDetails vm = new VmItemDetails();
            vm.Item = item;
            vm.lstRecommendedItems = oItem.GetRecommendedItems(id).Take(15-3).ToList(); 
            vm.lstItemImages = oItemImages.GetByItemId(id); 
            return View(vm);
        }
        public IActionResult ItemList()
        {
            return View(); 
        }
       
       [HttpGet]
     public IActionResult GetData()
        {
            var data = new { message = "Hello, world!" };
            return Json(data);
        }
    }
}
