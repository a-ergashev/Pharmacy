using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLog
{
    enum Gender
    {
        Erkak,
        Ayol
    }

    internal class User : SignIn
    {
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? email { get; set; }
        public Gender gen { get; set; }
        public DateTime birthDate { get; set; }
        
        public void Show()
        {
            Console.WriteLine($"{firstName} {lastName} {email} {gen} {birthDate}");
        }
    }
}
