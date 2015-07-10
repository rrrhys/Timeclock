using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace DataLayer
{
    public class Utilities
    {

        public static bool VerifyPasswordMatchesUser(string password, DataLayer.user user)
        {
            return BCrypt.Net.BCrypt.Verify(password, user.password);
        }

    }
}
