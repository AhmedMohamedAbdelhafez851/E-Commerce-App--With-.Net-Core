using Labs.Models;

namespace Labs.Bl
{
    public interface IOs
    {

        public List<TbO> GetAll();

        public TbO? GetById(int osId);
        public bool Save(TbO os);
        public bool Delete(int id);  





    }
    public class ClsOs:IOs
    {
        LapShopContext context;

        public ClsOs(LapShopContext ctx)
        {
            context = ctx;
        }
        public List<TbO> GetAll()
        {
            try
            {
                var lstOs = context.TbOs.Where(a=>a.CurrentState==1).ToList();
                return lstOs;
            }
            catch
            {
                return new List<TbO>();

            }
        }
        public TbO? GetById(int osId)
        {
            try
            {
               var  os = context.TbOs.FirstOrDefault(a => a.OsId == osId&& a.CurrentState==1);
                return os; 

            }
            catch
            {
                return new TbO();
            }

        }

        public bool Save(TbO os)
        {
            try
            {
                if (os.OsId == 0)
                {

                    os.CreatedBy = "1";
                    os.CreatedDate = DateTime.Now;
                    context.TbOs.Add(os);
                }
                else
                {
                    os.UpdatedBy = "1";
                    os.UpdatedDate = DateTime.Now;
                    context.Entry(os).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                var os = GetById(id);
                //context.TbOs.Remove(os);
                os.CurrentState = 0; 
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
