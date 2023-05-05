using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Labs.resources;
        

namespace Labs.Models
{
    public partial class TbItem
    {
        public TbItem()
        {
            TbItemDiscounts = new HashSet<TbItemDiscount>();
            TbItemImages = new HashSet<TbItemImage>();
            TbPurchaseInvoiceItems = new HashSet<TbPurchaseInvoiceItem>();
            TbSalesInvoiceItems = new HashSet<TbSalesInvoiceItem>();
            Customers = new HashSet<TbCustomer>();
        }
        [ValidateNever]



        public int ItemId { get; set; }

        [Required(ErrorMessage = "Please Enter Item Name") ]        
        public string ItemName { get; set; } = null!;
        [Required(ErrorMessage = "Please Enter Sales Price")]
        [DataType(DataType.Currency , ErrorMessage ="Please Enter Currency")]
        [Range(50 , 100000 , ErrorMessage ="Please Enter Price In System Range")]

        public decimal SalesPrice { get; set; }
        [Required(ErrorMessage = "Please Enter Purchase Price")]
        [DataType(DataType.Currency, ErrorMessage = "Please Enter Currency")]
        [Range(50, 100000, ErrorMessage = "Please Enter Price In System Range")]
        public decimal PurchasePrice { get; set; }
        [Required(ErrorMessage = "Please Enter Category")]

        public int CategoryId { get; set; }
        public string? ImageName { get; set; }
        [ValidateNever]
        public DateTime CreatedDate { get; set; }
        [ValidateNever]

        public string CreatedBy { get; set; } = null!;
        [ValidateNever]

        public int CurrentState { get; set; }

        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "Please Enter Gpu ")]

        public string? Gpu { get; set; }
        [Required(ErrorMessage = "Please Enter Hard Disk ")]


        public string? HardDisk { get; set; }
        [Required(ErrorMessage = "Please Enter Item Type ")]

        public int? ItemTypeId { get; set; }
        [Required(ErrorMessage = "Please Enter Processor ")]

        public string? Processor { get; set; }
        [Required(ErrorMessage = "Please Enter Ram Size ")]
        [Range(1 , 500 ,ErrorMessage ="Please Enter Ram In Range")]


        public int? RamSize { get; set; }
        [Required(ErrorMessage = "Please Enter Screen Reslution ")]

        public string? ScreenReslution { get; set; }
        [Required(ErrorMessage = "Please Screen Ram Size ")]

        public string? ScreenSize { get; set; }
        [Required(ErrorMessage = "Please Enter Weight ")]

        public string? Weight { get; set; }
        [Required(ErrorMessage ="Please Enter Os ")]
        public int? OsId { get; set; }
        [ValidateNever]
        public virtual TbCategory Category { get; set; } = null!;
        [ValidateNever]
        public virtual TbItemType? ItemType { get; set; }
        [ValidateNever]
        public virtual TbO? Os { get; set; }
        public virtual ICollection<TbItemDiscount> TbItemDiscounts { get; set; }
        public virtual ICollection<TbItemImage> TbItemImages { get; set; }
        public virtual ICollection<TbPurchaseInvoiceItem> TbPurchaseInvoiceItems { get; set; }
        public virtual ICollection<TbSalesInvoiceItem> TbSalesInvoiceItems { get; set; }

        public virtual ICollection<TbCustomer> Customers { get; set; }
    }
}
