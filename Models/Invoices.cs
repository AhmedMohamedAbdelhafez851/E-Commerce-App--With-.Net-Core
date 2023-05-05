namespace Labs.Models
{
    public class Invoices
    {
        public Invoices()
        {
            InvoiceItems = new List<InvoiceDetail>();
        }

        public int InvoiceId { get; set; } 
        public int InvoiceNumber { get; set; }  

        public DateTime DateTime { get; set; }

        public string Discription { get; set;  }

        public int CustomerId { get; set; }

        public string HasShipped { get; set; }          

        public List<InvoiceDetail> InvoiceItems { get; set; }   
        

    }
}
