using Labs.Bl;
using Labs.Models;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Labs.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        ISetting oClsSettings; 
        public SettingController(ISetting oISetting)
        {
            oClsSettings = oISetting;  
                
        }
        // GET: api/<SettingController>
        [HttpGet]
        public TbSettings Get()
        {
            return oClsSettings.GetAll(); 
        }

        // GET api/<SettingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SettingController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SettingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SettingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
