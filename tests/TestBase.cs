using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Mantis_tests
{
   
    public class TestBase
    {
      public static  bool group_perfom_long_UI_checks = true;
        public static bool contact_perfom_long_UI_checks = true;
        protected ApplicationManager app;

        [OneTimeSetUp]
        public void SetupApplicationManager()
        {
           
            app = ApplicationManager.GetInstanse();




        }
        public static Random rnd = new Random();

    

        public static string GenerateRandomString(int max)
        {
            
            int l =  Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0;i < l;i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 60)));
            }
            return builder.ToString();
            throw new NotImplementedException();
        }




















    }
}
