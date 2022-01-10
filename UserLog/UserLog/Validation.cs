using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLog
{
    internal static class Validation
    {
        public static User? GetAudentification(SignIn signIn)
        {
            foreach(string dataLine in File.ReadLines(@"D:\Akbar's\repos\dotNet\data.txt"))
            {
                string[] data = dataLine.Split();
                if(signIn.Password == data[3] && signIn.Login == data[4])
                {
                    User user = new User();
                    #region Adding information
                    user.lastName = data[0];
                    user.firstName = data[1];
                    user.email = data[2];
                    user.gen = (data[5] == "Erkak") ? Gender.Erkak : Gender.Ayol;
                    
                    string[] dateValues = data[6].Split('/');
                    user.birthDate = new DateTime(int.Parse(dateValues[2]), int.Parse(dateValues[1]), int.Parse(dateValues[0]));
                    #endregion
                    return user;
                }
            }
            return null;
        }
    }
}
