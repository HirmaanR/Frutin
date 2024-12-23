using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            EmailService email = new EmailService();
            bool result = email.SendEmail("new user","rashidabadi.8511@gmail.com");
        }
    }
}
