//using Labs.Bl;
//using Labs.Models;
//using Microsoft.AspNetCore.Mvc;
//using System.Text.Json.Serialization;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace Labs.ApiControllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ItemsController : ControllerBase
//    {
//        IItems oItem;
//        public ItemsController(IItems iitem)
//        {
//            oItem = iitem;
//        }
//        // GET: api/<ItemsController>
//        [HttpGet]
//        public ApiResponse Get()       // i send data       
//        {
//            ApiResponse oApiResponse = new ApiResponse();
//            oApiResponse.Data = oItem.GetAll();
//            oApiResponse.Errors = null;
//            oApiResponse.StatusCode = "200";
//            return oApiResponse;
//        }

//        // GET api/<ItemsController>/5
//        [HttpGet("{id}")]
//        public ApiResponse Get(int id)
//        {
//            ApiResponse oApiResponse = new ApiResponse();
//            oApiResponse.Data = oItem.GetById(id);
//            oApiResponse.Errors = null;
//            oApiResponse.StatusCode = "200";
//            return oApiResponse;
//        }

//        // GET api/<ItemsController>/5
//        //[HttpGet("{categoryId}")]
//        //[Route("GetByCategoryId/{categoryId}")]
//        //public ApiResponse GetByCategoryId(int categoryId)
//        //{
//        //    ApiResponse oApiResponse = new ApiResponse();
//        //    oApiResponse.Data = oItem.GetAllItemData(categoryId);
//        //    oApiResponse.Errors = null;
//        //    oApiResponse.StatusCode = "200";
//        //    return oApiResponse;
//        //}


//        // POST api/<ItemsController>
//        [HttpPost]
//        public ApiResponse Post([FromBody] TbItem item)
//        {
//            //  i request data and make validaion on data that enter 
//            try
//            {
//                oItem.Save(item);
//                ApiResponse oApiResponse = new ApiResponse();
//                oApiResponse.Data = "done";
//                oApiResponse.Errors = null;
//                oApiResponse.StatusCode = "200";
//                return oApiResponse;
//            }
//            catch (Exception ex)
//            {
//                ApiResponse oApiResponse = new ApiResponse();
//                oApiResponse.Data = null;
//                oApiResponse.Errors = ex.Message;
//                oApiResponse.StatusCode = "502";
//                return oApiResponse;

//            }





//        }

       
//    }
//}
