using Labs.Models;  
namespace Labs.Bl
{
    public interface IItems
    {
        public List<TbItem> GetAll();                           // all column
        public List<VwItem> GetAllItemData(int? categoryId);
        public List<VwItem> GetRecommendedItems(int itemId);  // Detail(related)

        public TbItem? GetById(int itemId);
        public VwItem GetItemId(int id);  

        public bool Save(TbItem item);
        public bool Delete(int id);


    }                  
    public class ClsItems:IItems
    {
        LapShopContext context;  



        public ClsItems(LapShopContext ctx)
        {
            context= ctx;   
        }


        public List<TbItem> GetAll()

        {
                var lstitems = context.TbItems.ToList();
                return lstitems;
        }

        public List<VwItem> GetAllItemData(int? categoryId)
        {
            try
            {
       var lstItems = context.VwItems.Take(50).Where(a => (a.CategoryId == categoryId || categoryId == null || categoryId == 0)
       && a.CurrentState == 1 && !string.IsNullOrEmpty(a.ItemName)).OrderByDescending(a=>a.CreatedDate).ToList();
                return lstItems;
            }
            catch
            {
                return new List<VwItem>();

            }
        }
        public List<VwItem> GetRecommendedItems(int itemId)
        {
            try
            {
       var item = GetById(itemId);     // select to first column 
        var lstItems = context.VwItems.Where(a =>a.SalesPrice>item.SalesPrice-150 && a.SalesPrice<item.SalesPrice+150
        // business status 
       && a.CurrentState == 1).OrderByDescending(a => a.CreatedDate).ToList();
                return lstItems;


            }
            catch
            {
                return new List<VwItem>();

            }
        }
        public TbItem? GetById(int itemId) 
        {

            try
            {
                var item = context.TbItems.FirstOrDefault(a => a.ItemId == itemId && a.CurrentState==1);
                return item;

            }
            catch
            {
                return new TbItem();
            }

        }

        public VwItem GetItemId(int id)
        {
            try
            {
    var item = context.VwItems.FirstOrDefault(a => a.ItemId == id && a.CurrentState == 1);
                return item;

            }
            catch
            {
                return new VwItem();
            }

        }


        public bool Save(TbItem item)
        {
            item.CurrentState = 1; 

            try
            {
                if (item.ItemId == 0)
                {

                    item.CreatedBy = "1";
                    item.CreatedDate = DateTime.Now;
                    context.TbItems.Add(item);
                }
                else
                {
                    item.UpdatedBy = "1";
                    item.UpdatedDate = DateTime.Now;
                    context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int id)
        {

            try
            {
                var item = GetById(id);     // make select to delete
                item.CurrentState = 0;         //context.TbItems.Remove(item);
                context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;


                context.SaveChanges();
                return true;


            }
            catch
            {
                return false;

            }

        }



    }
}
