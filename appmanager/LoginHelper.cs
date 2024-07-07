using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;



namespace Mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void LoggOn(AccountData account)
        {

        }


        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }

                Logout(account);
            }
            Type(By.Name("username"), account.Name);
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
            Type(By.Name("password"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
        }

        private void Logout(AccountData account)
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.XPath("//i[@class = 'fa fa-angle-down ace-icon']")).Click();
                driver.FindElement(By.XPath("//ul[@class = 'user-menu dropdown-menu dropdown-menu-right dropdown-yellow dropdown-caret dropdown-close']/li[4]")).Click();
            }
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsElementPresent(By.XPath("//span[@class='user-info'][text()='" + account.Name + "']"));
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }



    }
}
