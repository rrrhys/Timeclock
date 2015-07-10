using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace web_api_timeclock_server.Controllers
{
    public class EntriesController : ApiController
    {
        // GET api/entries
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/entries/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/entries
        public void Post([FromBody]string value)
        {
        }

        // PUT api/entries/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/entries/5
        public void Delete(int id)
        {
        }
    }
}
