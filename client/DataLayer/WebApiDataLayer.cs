using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class WebApiDataLayer : TimeclockDataInterface
    {
        /// <summary>
        /// Wrap a payload with a user token, for the webapi services that only like one method param.
        /// </summary>

        static Uri BaseAddress = new Uri("http://54.153.140.231/");
        string UserEndpoint = "api/users";
        string TokenEndpoint = "api/tokens";
        string WorkTypesEndpoint = "api/worktypes";
        string JobNumbersEndpoint = "api/jobnumbers";
        string EntrysEndpoint = "api/entries";
        public bool CheckTokenIsValid(Guid? token)
        {
           var t = _checkTokenIsValid(token);
           t.Wait();
           return t.Result;
        }

        private async Task<bool> _checkTokenIsValid(Guid? token)
        {
           using (var client = GetHttpClient())
            {
                HttpResponseMessage response = client.GetAsync(UserEndpoint + "?user_token=" + token).Result;
                if (response.IsSuccessStatusCode)
                {
                    user user = await response.Content.ReadAsAsync<user>();
                    if (user != null)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public Guid? CreateJobEntry(entry e, Guid user_token)
        {
            var t = _createJobEntry(e, user_token);
            t.Wait();
            if (t.Result != null)
            {

                return t.Result.id;
            }
            else { return null; }
        }

        private async Task<entry> _createJobEntry(entry e, Guid user_token)
        {
            using (var client = GetHttpClient())
            {
                if (e.time_to == DateTime.MinValue)
                {
                    e.time_to = e.time_from;
                }

                var payload = new WrapWithToken { payload = e, user_token = user_token };
                HttpResponseMessage response = client.PostAsJsonAsync(EntrysEndpoint, payload).Result;

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<entry>();
                }
                else
                {

                }
                return null;
            }
        }

        public job_numbers CreateJobNumbers(string p, Guid user_token)
        {
            var t = _createJobNumbers(p, user_token);
            t.Wait();
            return t.Result;

        }


        private async Task<job_numbers> _createJobNumbers(string job_number, Guid user_token)
        {

            using (var client = GetHttpClient())
            {
               
                job_numbers j = new job_numbers { job_number = job_number };


                var payload = new WrapWithToken { payload = j, user_token = user_token };
                HttpResponseMessage response = client.PostAsJsonAsync(JobNumbersEndpoint, payload).Result;

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<job_numbers>();
                }
                else
                {

                }
                return null;
            }
        }

        private static HttpClient GetHttpClient()
        {
            var httpClientHandler = new HttpClientHandler
                        {
                            Proxy = new WebProxy("http://localhost:8888", false),
                            UseProxy = true
                        };

            var client = new  HttpClient(httpClientHandler,true);
            
                client.BaseAddress = BaseAddress;

            return client;
        }


        public Guid? CreateUser(string email, string password)
        {
            var t = _createUser(email, password);
            t.Wait();
            var d = t.Result;
            return d;
        }

        private async Task<Guid?> _createUser(string email, string password)
        {
            using (var client = GetHttpClient())
            {
                user u = new user();
                u.email = email;
                u.password = BCrypt.Net.BCrypt.HashPassword(password);
                    HttpResponseMessage response = client.PostAsJsonAsync(UserEndpoint, u).Result;
                    
                    if (response.IsSuccessStatusCode)
                    {
                        dynamic content = response.Content.ReadAsAsync<ExpandoObject>().Result;
                        var token = content.token;
                        return new Guid(token);
                    }
                    else
                    {

                    }
                return null;
            }
        }


        public work_types CreateWorkType(string p, Guid user_token)
        {
            var t = _createWorkType(p, user_token);
            t.Wait();
            return t.Result;

        }


        private async Task<work_types> _createWorkType(string work_type, Guid user_token)
        {
            using (var client = GetHttpClient())
            {
                work_types j = new work_types { work_type = work_type };


                var payload = new WrapWithToken { payload = j, user_token = user_token };
                HttpResponseMessage response = client.PostAsJsonAsync(WorkTypesEndpoint, payload).Result;

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<work_types>();
                }
                else
                {

                }
                return null;
            }
        }


        public Guid? GetTokenForUser(string email, string password)
        {
            var t = _getTokenForUser(email, password);
            t.Wait();
            return t.Result;
        }

        private async Task<Guid?> _getTokenForUser(string email, string password)
        {
            using (var client = GetHttpClient())
            {
                user User = new user { email = email, password = password };
                HttpResponseMessage response = client.PostAsJsonAsync(TokenEndpoint,User).Result;
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<Guid>();
                }
                return null;
            }
        }

        public job_numbers[] ListJobNumbers(Guid user_token)
        {
            var t = _listJobNumbers(user_token);
            t.Wait();
            return t.Result;

        }

        private async Task<job_numbers[]> _listJobNumbers(Guid user_token)
        {
            using (var client = GetHttpClient())
            {
                HttpResponseMessage response = client.GetAsync(JobNumbersEndpoint + "?user_token=" + user_token).Result;
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<job_numbers[]>();
                }
                return null;
            }
        }

        public work_types[] ListWorkTypes(Guid user_token)
        {
            var t = _listWorkTypes(user_token);
            t.Wait();
            return t.Result;
        }

        private async Task<work_types[]> _listWorkTypes(Guid user_token)
        {
            using (var client = GetHttpClient())
            {
                HttpResponseMessage response = client.GetAsync(WorkTypesEndpoint + "?user_token=" + user_token).Result;
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<work_types[]>();
                }
                return null;
            }
        }

        public bool UpdateEntry(Guid entryToken, string comments, Guid user_token)
        {
            var t = _updateEntry(entryToken, comments, user_token);
            t.Wait();
            return t.Result;
        }

        private async Task<bool> _updateEntry(Guid entryToken, string comments, Guid user_token)
        {
            using (var client = GetHttpClient())
            {
                entry E = new entry();
                E.id = entryToken;
                E.time_to = DateTime.Now;
                E.comments = comments;
               

                var payload = new WrapWithToken { payload = E, user_token = user_token };

                HttpResponseMessage response = client.PutAsJsonAsync("/api/entries/?entry_token=" + entryToken.ToString(), payload).Result;
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<bool>();
                }
            }
            return false;
        }
    }
}
