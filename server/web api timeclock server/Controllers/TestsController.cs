using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DataLayer;

namespace web_api_timeclock_server.Controllers
{
    [EnableCors(origins: "http://www.jstesting.dev", headers: "*", methods: "*")]
    public class TestsController : ApiController
    {
        public HttpResponseMessage setup()
        {

            using (var db = new CWTimeclockEntities())
            {
                var users = db.users.Where(u => u.email == "tester22@gmail.com");
                foreach (var u in users)
                {
                    var jobnumbers = db.job_numbers.Where(j => j.user_id == u.id);
                    foreach (var j in jobnumbers)
                    {
                        db.job_numbers.Remove(j);
                    }
                    db.users.Remove(u);
                }
                db.SaveChanges();


                return Request.CreateResponse(HttpStatusCode.OK);
            }



        }
    }
}
