﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Data : DataLayer.TimeclockDataInterface
    {

        public job_numbers[] ListJobNumbers(Guid user_token)
        {
            using (var context = new CWTimeclockEntities())
            {
                var user = context.users.FirstOrDefault(f => f.token == user_token);
                
                if (user != null)
                {
                    return context.job_numbers.Where(j => j.user_id == user.id).ToArray();
                }
                else
                {
                    throw new UserNotFoundException("Couldn't find user for token.");
                }

            }
        }

        public job_numbers CreateJobNumbers(string p, Guid user_token)
        {
            using (var context = new CWTimeclockEntities())
            {
                var user = context.users.FirstOrDefault(f => f.token == user_token);
                if (user != null)
                {
                    job_numbers j = new job_numbers();
                    j.job_number = p;
                    j.id = Guid.NewGuid();
                    j.user_id = user_token;
                    context.job_numbers.Add(j);
                    context.SaveChanges();

                    return j;
                }
                else
                {
                    throw new UserNotFoundException("Couldn't find user for token.");
                }
            }
        }

        public work_types[] ListWorkTypes(Guid user_token)
        {

            using (var context = new CWTimeclockEntities())
            {
                var user = context.users.FirstOrDefault(f => f.token == user_token);
                if (user != null)
                {
                    return context.work_types.Where(w => w.user_id == user.id).ToArray();
                }
                else
                {
                    throw new UserNotFoundException("Couldn't find user for token.");
                }
            }
        }

        public work_types CreateWorkType(string p, Guid user_token)
        {
            using (var context = new CWTimeclockEntities())
            {
                work_types w = new work_types();
                w.work_type = p;
                w.id = Guid.NewGuid();
                w.user_id = user_token;
                context.work_types.Add(w);
                context.SaveChanges();
                return w;
            }
        }

        public bool UpdateEntry(Guid entryToken, string comments, Guid user_token)
        {
            using (var context = new CWTimeclockEntities())
            {
                var user = context.users.FirstOrDefault(u => u.token == user_token);

                if (user != null)
                {

                    var entry = context.entries.FirstOrDefault(e => e.id == entryToken && e.user_id == user.id);

                    entry.time_to = DateTime.Now;
                    entry.comments = comments;
                    entry.hours = Convert.ToDecimal(Math.Round((entry.time_to - entry.time_from).TotalHours, 1));
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>A token useful for updating this users data</returns>
        public Guid? CreateUser(string email, string password)
        {
            using (var context = new CWTimeclockEntities())
            {
                var u = new user();
                u.email = email;
                u.name = email.Substring(0, email.IndexOf("@"));
                u.token = Guid.NewGuid();
                u.id = Guid.NewGuid();
                u.password = BCrypt.Net.BCrypt.HashPassword(password);
                context.users.Add(u);
                context.SaveChanges();
                return u.token;
            }
        }

        public Guid? GetTokenForUser(string email, string password)
        {
            using (var context = new CWTimeclockEntities())
            {
                List<int> test = new List<int>();
                test.OrderByDescending(i => i);
                var user = context.users.FirstOrDefault(u => u.email.ToLower() == email.ToLower());
                if (user == null) return null;
                if (Utilities.VerifyPasswordMatchesUser(password, user))
                {
                    context.Entry(user).State = EntityState.Detached;
                    return user.token;
                }
                else
                {
                    return null;
                }
            }
        }

        public Guid? CreateJobEntry(entry e, Guid user_token)
        {

            using (var context = new CWTimeclockEntities())
            {
                var user = context.users.FirstOrDefault(f => f.token == user_token);
                if (user != null)
                {
                    e.time_to = DateTime.Now;
                    e.user_id = user.id;
                    e.id = Guid.NewGuid();
                    context.entries.Add(e);
                    context.SaveChanges();
                    return e.id;
                }
                else
                {
                    throw new UserNotFoundException("Couldn't find user for token.");
                }
            }
        }

        public bool CheckTokenIsValid(Guid? token)
        {
            using (var context = new CWTimeclockEntities())
            {
                var user = context.users.FirstOrDefault(f => f.token == token);
                return user != null;
            }
        }
    }


    public partial class job_numbers
    {
        public override string ToString()
        {
            return this.job_number;
        }

    }

    public partial class work_types
    {
        public override string ToString()
        {
            return this.work_type;
        }

    }

    public partial class entry
    {
        private void Create()
        {

        }
    }

    public partial class user{
        public bool Valid(){
            // checks if a new user is valid to add. Email is unique etc.
            using(var db = new CWTimeclockEntities()){
                if(db.users.Count(u => u.email.ToLower() == this.email.ToLower()) > 0){
                    return false;
                }
            }

            return true;
        }
    }
}
