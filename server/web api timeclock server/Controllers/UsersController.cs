using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace web_api_timeclock_server.Controllers
{
    public class UsersController : ApiController
    {
        // GET api/users
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/users/5
        public user Get(Guid token)
        {
            using(var db = new CWTimeclockEntities()){
                var user = db.users.FirstOrDefault(f => f.token == token);
                return user;
            }
        }

        // POST api/users
        public HttpResponseMessage Post([FromBody]user u)
        {
            using (var db = new CWTimeclockEntities())
            {
                if (u.Valid())
                {
                    u.token = Guid.NewGuid();
                    u.id = Guid.NewGuid();
                    u.name = u.email.Substring(0, u.email.IndexOf("@"));
                    db.users.Add(u);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, u.token);

                }
                else
                {
                    return Request.CreateResponse((HttpStatusCode)422, "User exists in system.");
                }
            }
        }


        // PUT api/users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/users/5
        public void Delete(int id)
        {
        }
    }
}
