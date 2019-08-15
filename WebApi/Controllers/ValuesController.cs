using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Ragu", "Balagi", "Karuppaiah" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            string response = "";
            if (id.Equals("hi"))
                response = "hello";
            else if (id.Equals("hello"))
                response = "hi";
            else
                response = "sorry";
            return response;
        }

        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    string response = "";

        //    if (id % 400 == 0)
        //        response = "IsLeapYear : true";
        //    else if (id % 4 == 0 && id % 100 != 0)
        //        response = "IsLeapYear : true";
        //    else
        //        response = "IsLeapYear : false";
        //    return response;
        //}

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
