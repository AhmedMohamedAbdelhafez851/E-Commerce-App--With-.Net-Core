using Labs.Models;

namespace Labs.Bl
{
    public interface ISetting
    {

        public TbSettings GetAll();

        public bool Save(TbSettings os);  

    }
    public class ClsSetting : ISetting
    {
        LapShopContext context;

        public ClsSetting(LapShopContext ctx)
        {
            context = ctx;
        }
        public TbSettings GetAll()
        {
            try
            {
                var lstOs = context.Settings.FirstOrDefault(); 
                return lstOs;
            }
            catch
            {
                return new TbSettings();

            }
        }
        public bool Save(TbSettings sett)
        {
            try
            {
              
                context.Entry(sett).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                
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
