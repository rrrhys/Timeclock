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
    public class WorkTypesController : ApiController
    {
        CWTimeclockEntities db = new CWTimeclockEntities();
        // GET api/worktypes
        public HttpResponseMessage Get(Guid user_token)
        {
                var user = db.users.FirstOrDefault(u => u.token == user_token);
                if(user != null){
                    var worktypes = db.work_types.Where(w => w.user_id == user.id).ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, worktypes);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // GET api/worktypes/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/worktypes
        public HttpResponseMessage HttpResponseMessage([FromBody]WrapWithToken wrapper)
        {

            var work_type = Newtonsoft.Json.JsonConvert.DeserializeObject<work_types>(wrapper.payload.ToString());
            var user_token = wrapper.user_token;

                var user = db.users.FirstOrDefault(u => u.token == user_token);
                if (user != null)
                {
                    work_type.user_id = user.id;
                    work_type.id = Guid.NewGuid();
                    db.work_types.Add(work_type);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, work_type);
                }

            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // PUT api/worktypes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/worktypes/5
        public HttpResponseMessage Delete(Guid id, Guid user_token)
        {
            var user = db.users.FirstOrDefault(u => u.token == user_token);
            if (user != null)
            {
                var work = db.work_types.FirstOrDefault(f => f.id == id && f.user_id == user.id);

                if (work != null)
                {
                    db.work_types.Remove(work);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, work);
                }
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Could not find work type or user.");

        }
    }
}
