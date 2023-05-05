//using Labs.Models;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore.Infrastructure;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Text;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace Labs.ApiControllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class LoginController : ControllerBase
//    {
//        IConfiguration configuration;
//        public LoginController(IConfiguration config)
//        {
//            configuration = config;
//        }
//        // GET: api/<LoginController>
//        [HttpGet]
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }

//        // GET api/<LoginController>/5
//        [HttpGet("{id}")]
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST api/<LoginController>
//        [HttpPost]
//        [AllowAnonymous]
//        public IActionResult Post([FromBody] UserModel model)
//        {
//            var response = Unauthorized();
//            UserModel user = AuthorizeUser(model);
//            if (user != null)
//            {
//                 var token = GenerateToken(model);
//                return Ok(new { token = token }); 
//            }
//            return response;
//        }
//        UserModel AuthorizeUser(UserModel model)
//        {
//            if (model.FirstName == "Saad" && model.Password == "123")
//            {
//                return new UserModel()
//                {
//                    FirstName = "Ali",
//                    Email = "info@851"
//                };
//            }
//            return null;
//        }
//        string GenerateToken(UserModel user)
//        {
//            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
//            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
//            var token = new JwtSecurityToken(configuration["Jwt:Issuer"]),
//                configuration["Jwt:Issuer"],
//                null , 
//                expires: DateTime.Now.AddMinutes(120) , 
//                signinCredentials: credentials) ;
//            return new JwtSecurityTokenHandler().WriteToken(token);
//        }

//        // PUT api/<LoginController>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }

//        // DELETE api/<LoginController>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//        //[HttpPost]
//        //[Route("Login")]
//        //[AllowAnonymous]
//        //public IActionResult Login([FromBody] ApplicationUser user)
//        //{
//        //IActionResult response = Unauthorized();
//        //var myuser = AuthonticateUser(user); 
//        //if(myuser!=null)
//        //{
//        //    var token = GenerateToken(user);
//        //    return Ok(new { token = token });  

//        //}
//        //return response; 
//        // }

//    }
//}
