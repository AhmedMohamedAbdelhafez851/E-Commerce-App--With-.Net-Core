using Labs.Bl;
using Labs.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;  
namespace Labs.Areas.Test.Controllers
{
    [Area("Test")]
    public class OrdersController : Controller
    {
        IItems iItemServices; 
        public OrdersController(IItems itemservice)
        {
            iItemServices = itemservice; 
        }
        public IActionResult Cart()
        {
            string sessionCart = string.Empty;
            if (HttpContext.Session.GetString("Cart") != null)
                sessionCart = HttpContext.Session.GetString("Cart");

            var cart = JsonConvert.DeserializeObject<ShopingCart>(sessionCart);  



            return View(cart);
        }
         
        public IActionResult AddToCart(int itemId)
        {
            ShopingCart cart;
            if (HttpContext.Session.GetString("Cart") != null)
                cart = JsonConvert.DeserializeObject<ShopingCart>(HttpContext.Session.GetString("Cart"));
            else
                cart = new ShopingCart(); 


            var item =  iItemServices.GetById(itemId);     // get on item   
            var itemInList = cart.lstItems.Where(a=>a.ItemId==itemId).FirstOrDefault();
            if (itemInList != null)
            {
                itemInList.Qty++;
                itemInList.Total = itemInList.Qty * itemInList.Price; 
            }
            else
            {


                cart.lstItems.Add(new ShoppingCartItem
                {
                    ItemId = item.ItemId,
                    ItemName = item.ItemName,
                    Price = item.SalesPrice,
                    Qty = 1,
                    Total = item.SalesPrice

                });
            }
            cart.Total = cart.lstItems.Sum(a=>a.Total); 
            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart) );

            return RedirectToAction("Cart");   
        }
    }
}
