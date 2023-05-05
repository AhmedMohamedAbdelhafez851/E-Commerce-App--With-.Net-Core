using Labs.Models;

namespace Labs.Bl
{
    public interface IItemTypes
    {
        public List<TbItemType> GetAll();
        public TbItemType GetById(int ItemTypeId);
        public bool Save(TbItemType itemType);
        public bool Delete(int id);  









    }
    public class ClsItemTypes:IItemTypes
    {
        LapShopContext context;  

        public ClsItemTypes(LapShopContext ctx)
        {
            context = ctx;  
        }
        public List<TbItemType> GetAll()
        {
            try
            {
                var lstCategories = context.TbItemTypes.Where(a=>a.CurrentState==1).ToList();
                return lstCategories;
            }
            catch
            {
                return new List<TbItemType>();

            }
        }
        public TbItemType GetById(int ItemTypeId)
        {
            try
            {
                var itemType = context.TbItemTypes.FirstOrDefault(a => a.ItemTypeId == ItemTypeId&&a.CurrentState==1);
                return itemType;

            }
            catch
            {
                return new TbItemType();
            }

        }

        public bool Save(TbItemType itemType)
        {
            try
            {
                if (itemType.ItemTypeId == 0)
                {

                    itemType.CreatedBy = "1";
                    itemType.CreatedDate = DateTime.Now;
                    context.TbItemTypes.Add(itemType);
                }
                else
                {
                    itemType.UpdatedBy = "1";
                    itemType.UpdatedDate = DateTime.Now;
                    context.Entry(itemType).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                var itemType = GetById(id);
                //context.TbItemTypes.Remove(itemType);
                itemType.CurrentState = 0; 
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

