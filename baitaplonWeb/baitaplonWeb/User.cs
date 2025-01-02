using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace baitaplonWeb
{
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPass { get; set; }
        public bool Role { get; set; }

        public User(string username, string email, string password, string confirmpass, bool role)
        {
            Username = username;
            Email = email;
            Password = password;
            ConfirmPass = confirmpass;
            Role = role;
        }
    }
}