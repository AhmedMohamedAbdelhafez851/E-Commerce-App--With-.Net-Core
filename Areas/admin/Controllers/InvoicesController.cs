using Microsoft.AspNetCore.Mvc;
using Labs.Models;
using Microsoft.VisualBasic;

namespace Labs.Areas.admin.Controllers
{
    [Area("admin")]
    public class InvoicesController : Controller
    {
        public IActionResult Index()
        {
            List<Customers> lstCustomers = new List<Customers>();

            lstCustomers.Add(new Customers()
            {
                CustomerId = 1,
                CustomerName = "Ahmed"
            });

            lstCustomers.Add(new Customers()
            {
                CustomerId = 2,
                CustomerName = "Mohamed"
            });


            lstCustomers.Add(new Customers()
            {
                CustomerId = 3 , 
                CustomerName = "Hafez"
            });
             ViewBag.Customers = lstCustomers;

            var invoice = new Labs.Models.Invoices();
            invoice.InvoiceItems.Add(new InvoiceDetail()
            {
                 price =50 , 
                 Quantity = 1 ,
                 ItemId= 1  , 



            });
            invoice.InvoiceItems.Add(new InvoiceDetail()
            {
                price = 80,
                Quantity = 4,
                ItemId = 2,



            });

            invoice.InvoiceItems.Add(new InvoiceDetail()
            {
                price = 100,
                Quantity = 5 , 
                ItemId = 3,



            });
            return View(invoice);
        }
    }
}
