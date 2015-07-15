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
    
    public class UsersController : ApiController
    {
        CWTimeclockEntities db = new CWTimeclockEntities();
        // GET api/users
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/users/5
        public user Get(Guid user_token)
        {
                var user = db.users.FirstOrDefault(f => f.token == user_token);
                return user;
        }

        // POST api/users
        public HttpResponseMessage Post([FromBody]user u)
        {
                if (u.Valid())
                {
                    u.token = Guid.NewGuid();
                    u.id = Guid.NewGuid();
                    u.name = u.email.Substring(0, u.email.IndexOf("@"));
                    db.users.Add(u);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, new { id = u.id, token = u.token });

                }
                else
                {
                    return Request.CreateResponse((HttpStatusCode)422, "User exists in system.");
                }
        }


        // PUT api/users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/users/5
        public HttpResponseMessage Delete(Guid id, Guid user_token)
        {
            var user = db.users.FirstOrDefault(u => u.id == id && u.token == user_token);
            if (user != null)
            {
                db.users.Remove(user);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Could not find user.");
        }
    }
}
