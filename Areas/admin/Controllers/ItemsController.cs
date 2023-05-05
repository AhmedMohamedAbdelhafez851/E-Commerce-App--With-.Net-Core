using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;
using Labs.Bl;
using Labs.Models;
using Labs.utilities;

namespace Labs.Areas.admin.Controllers
{
     [Authorize(Roles = "Admin,data entry")]
    [Area("admin")]
    public class ItemsController : Controller
    {
        public ItemsController(IItems item, ICategories category,
            IItemTypes itemTypes, IOs os)
        {
            oClsItems = item;
            oClsCategories = category;
            oClsItemTypes = itemTypes;
            oClsOs = os;
        }
        IItems oClsItems;
        ICategories oClsCategories;
        IItemTypes oClsItemTypes;
        IOs oClsOs;
        [AllowAnonymous]
        public IActionResult List()
        {

            ViewBag.lstCategories = oClsCategories.GetAll();
            ViewBag.lstItemTypes = oClsItemTypes.GetAll();

            var items = oClsItems.GetAllItemData(null);
            return View(items);
        }

        public IActionResult Search(int id)
        {
            ViewBag.lstCategories = oClsCategories.GetAll();
            var items = oClsItems.GetAllItemData(id);
            return View("List", items);
        }

        // [Authorize(Roles = "Admin")]
        public IActionResult Edit(int? itemId)
        {
            var item = new TbItem();
            ViewBag.lstCategories = oClsCategories.GetAll();
            ViewBag.lstItemTypes = oClsItemTypes.GetAll();
            ViewBag.lstOs = oClsOs.GetAll();
            if (itemId != null)
            {
                item = oClsItems.GetById(Convert.ToInt32(itemId));
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(TbItem item, List<IFormFile> Files)
        {
            if (!ModelState.IsValid)
                return View("Edit", item);

            item.ImageName = await Healper.UploadImage(Files, "Items");

            oClsItems.Save(item);

            return RedirectToAction("List");
        }

        public IActionResult Delete(int itemId)
        {
            oClsItems.Delete(itemId);
            return RedirectToAction("List");
        }
    }
}
