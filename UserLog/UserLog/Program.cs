using System;
using UserLog;

namespace Userlog
{
    public class Program
    {
        public static void Main(string[] args)
        {

            SignIn signIn = new SignIn("PolatAlimder", "7857215626");
            User? user = Validation.GetAudentification(signIn);
            
            if (user != null)
                user.Show();
            else
                Console.WriteLine("Topilmadi");
        }
    }
}