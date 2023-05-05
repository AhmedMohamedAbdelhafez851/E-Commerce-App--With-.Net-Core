using Microsoft.EntityFrameworkCore.Storage;
using System.Diagnostics.Contracts;

namespace Labs.Models
{
    public class InvoiceDetail
    {
        public int InvoiceDetailId { get; set; }
        public int InvoiceId { get; set; }  
         

        public int ItemId { get; set; }

        public int CustomerId { get; set; }


        public decimal price { get; set; }

        public int Quantity { get; set; }       

    }
}
