using NUnit.Framework;
using System;
using System.Text;

namespace Mantis_tests
{

    public class TestBase 
    {
     
        protected ApplicationManager app;

        [OneTimeSetUp]
        public void SetupApplicationManager()
        {
           
            app = ApplicationManager.GetInstanse();

            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            app.login.Login(account);



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

        [TearDown]
        public void StopChrome()
        {
            app.Stop();
        }
        
        



















    }
}
