using Labs.Models;
namespace Labs.Bl
{
    public interface ISliders
    {
        public List<TbSlider> GetAll();                           // all column

        public TbSlider? GetById(int sliderId);

        public bool Save(TbSlider slider);
        public bool Delete(int id);


    }
    public class ClsSliders : ISliders
    {
        LapShopContext context;



        public ClsSliders(LapShopContext ctx)
        {
            context = ctx;
        }


        public List<TbSlider> GetAll()

        {
            var lstitems = context.TbSliders.ToList();
            return lstitems;
        }

        public TbSlider? GetById(int sliderId)
        {

            try
            {
                var slider = context.TbSliders.FirstOrDefault(a => a.SliderId== sliderId );
                return slider;

            }
            catch
            {
                return new TbSlider();
            }

        }



        public bool Save(TbSlider slider)
        {
            try
            {
                if (slider.SliderId == 0)
                {                   
                }
                else
                {
                    context.Entry(slider).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                context.Entry(id).State = Microsoft.EntityFrameworkCore.EntityState.Modified;


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
