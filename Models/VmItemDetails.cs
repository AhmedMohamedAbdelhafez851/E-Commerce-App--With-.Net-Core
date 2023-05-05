using System.Data;

namespace Labs.Models
{
    public class VmItemDetails
    {
        public VmItemDetails()
        {
            Item = new VwItem();
            lstItemImages = new List<TbItemImage>();
            lstRecommendedItems = new List<VwItem>();
        }
        
        public VwItem Item { get;  set;  }     // vwitem exit in database  // this is result
        public List<TbItemImage>? lstItemImages { get; set; }
        public List<VwItem> lstRecommendedItems { get; set; }             //  recommended in the list vwitem 

    }
}
