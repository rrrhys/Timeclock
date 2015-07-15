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
    public class EntriesController : ApiController
    {
        CWTimeclockEntities db = new CWTimeclockEntities();
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
        public HttpResponseMessage Post([FromBody]WrapWithToken wrapper)
        {
            var entry = Newtonsoft.Json.JsonConvert.DeserializeObject<entry>(wrapper.payload.ToString());
            var user_token = wrapper.user_token;

                var user = db.users.FirstOrDefault(u => u.token == user_token);
                if (user != null)
                {
                    entry.id = Guid.NewGuid();
                    entry.user_id = user.id;
                    if (entry.time_to == DateTime.MinValue)
                    {
                        entry.time_to = entry.time_from;
                    }

                    // does user own job number and work type requested?
                    var job_number = db.job_numbers.FirstOrDefault(j => j.id == entry.job_number_id && j.user_id == user.id);
                    var work_type = db.work_types.FirstOrDefault(j => j.id == entry.work_type_id && j.user_id == user.id);

                    if (job_number != null && work_type != null)
                    {

                        db.entries.Add(entry);
                        db.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entry);
                    }
                }
            return Request.CreateResponse(HttpStatusCode.MethodNotAllowed, "You do not have permission to create this resource.");
        }

        // PUT api/entries/5
        public HttpResponseMessage Put(Guid entry_token, [FromBody]WrapWithToken wrapper)
        {
            var whiteList = new[] { "time_to", "comments", };
            var sentEntry = Newtonsoft.Json.JsonConvert.DeserializeObject<entry>(wrapper.payload.ToString());
            var user_token = wrapper.user_token;
                var user = db.users.FirstOrDefault(u => u.token == user_token);
                if (user != null)
                {
                    // require the user token for security here.
                    var foundEntry = db.entries.FirstOrDefault(e => e.user_id == user.id && e.id == entry_token);
                    if (foundEntry != null)
                    {

                        foreach (var columnAllowed in whiteList)
                        {
                            var value = sentEntry.GetType().GetProperty(columnAllowed).GetValue(sentEntry);
                            foundEntry.GetType().GetProperty(columnAllowed).SetValue(foundEntry, value);
                        }
                        foundEntry.hours = Convert.ToDecimal(Math.Round((foundEntry.time_to - foundEntry.time_from).TotalHours, 1));
                        db.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK, true);
                    }
                }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Could not find entry.");
        }

        // DELETE api/entries/5
        public HttpResponseMessage Delete(Guid id, Guid user_token)
        {
            var user = db.users.FirstOrDefault(u => u.token == user_token);
            if (user != null)
            {
                var entry = db.entries.FirstOrDefault(f => f.id == id && f.user_id == user.id);

                if (entry != null)
                {
                    db.entries.Remove(entry);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, entry);
                }
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Could not find entry or user.");

        }
    }
}
