using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace jsonweb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        HttpClient client = new HttpClient();
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return JsonConvert.SerializeObject(new TestObject(1, 2, "x"));
         
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<TestObject> Get(int id)
        {
            try
            {
                var d = await client.GetStringAsync("gettesturl.com/id?=5");

                TestObject gettest = JsonConvert.DeserializeObject<TestObject>(d);
                return gettest;
            }
            catch (Exception e )
            {
                Console.Write(e.Message);
                return null;
            }
      

        }

        [HttpGet]
        public ActionResult<string> Get(string searchvalue)
        {
            try
            {
                return JsonConvert.SerializeObject(DbService.Search(searchvalue));
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return null;
            }
       

        }
        // POST api/values
        [HttpPost]
        public void Post([FromBody] string testobj)
        {
            try
            {
                TestObject obj = JsonConvert.DeserializeObject<TestObject>(testobj);
                DbService.Upsert(obj);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);

            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string testobj)
        {
            try
            {
                TestObject obj = JsonConvert.DeserializeObject<TestObject>(testobj);
                DbService.Update(id, obj);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                
            }

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {

                DbService.Delete(id);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
               
            }
        }

    }
}
