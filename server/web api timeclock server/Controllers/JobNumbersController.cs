using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace web_api_timeclock_server.Controllers
{
    [EnableCors(origins: "http://www.jstesting.dev", headers: "*", methods: "*")]
    public class JobNumbersController : ApiController
    {
        CWTimeclockEntities db = new CWTimeclockEntities();

        // GET api/jobnumbers
        public HttpResponseMessage Get(Guid user_token)
        {

                var user = db.users.FirstOrDefault(u => u.token == user_token);
                if (user != null)
                {
                    var jobnumbers = db.job_numbers.Where(w => w.user_id == user.id).ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, jobnumbers);
                }

            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // GET api/jobnumbers/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/jobnumbers
        public HttpResponseMessage Post([FromBody]WrapWithToken wrapper)
        {

            var job_number = Newtonsoft.Json.JsonConvert.DeserializeObject<job_numbers>(wrapper.payload.ToString());
            var user_token = wrapper.user_token;

                var user = db.users.FirstOrDefault(u => u.token == user_token);
                if (user != null)
                {
                    job_number.user_id = user.id;
                    job_number.id = Guid.NewGuid();
                    db.job_numbers.Add(job_number);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, job_number);
                }

            return Request.CreateResponse(HttpStatusCode.MethodNotAllowed, "You do not have permission to create this resource.");

        }

        // PUT api/jobnumbers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/jobnumbers/5
        public HttpResponseMessage Delete(Guid id, Guid user_token)
        {
            var user = db.users.FirstOrDefault(u => u.token == user_token);
            if (user != null)
            {
                var job = db.job_numbers.FirstOrDefault(f => f.id == id && f.user_id == user.id);

                if (job != null)
                {
                    db.job_numbers.Remove(job);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, job);
                }
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Could not find job number or user.");

        }
    }
}
