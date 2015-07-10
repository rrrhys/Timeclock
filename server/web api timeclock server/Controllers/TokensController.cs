using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace web_api_timeclock_server.Controllers
{
    public class TokensController : ApiController
    {
        // GET api/tokens
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/tokens/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/tokens
        public HttpResponseMessage Post(user user)
        {
            // we have been given user email and password.
            // if a user matches, send back the guid.

            using (var db = new CWTimeclockEntities())
            {
                var u = db.users.FirstOrDefault(f => f.email.ToLower() == user.email.ToLower());
                if (u != null)
                {
                    if (DataLayer.Utilities.VerifyPasswordMatchesUser(user.password, u))
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, u.token);
                    }
                }

                return Request.CreateResponse(HttpStatusCode.NotFound, "Could not find user.");
            }
        }

        // PUT api/tokens/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/tokens/5
        public void Delete(int id)
        {
        }
    }
}
