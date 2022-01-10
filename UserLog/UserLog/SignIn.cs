using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLog
{
    internal class SignIn
    {
        public string? Login { get; set; }
        public string? Password { get; set; }
        public SignIn(string login, string password)
        {
            this.Login = login;
            this.Password = password;
        }
        public SignIn() { }
    }
}
