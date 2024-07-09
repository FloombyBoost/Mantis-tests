using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Chrome;

namespace Mantis_tests
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager) 
        {
        }

        public void Register(AccountData account)//
        {
           
            OpenMainPage();
            OpenRegistrationFrom();
            FillRegistrationForm(account);
            SubmitRegistration();
            String url = GetConfirmationURL(account);
            FillPasswordForm(url,account);
            SubmitPasswordForm();
         
        }

        private void SubmitPasswordForm()
        {
            driver.FindElement(By.CssSelector("button")).Click();
        }

        private string GetConfirmationURL(AccountData account)
        {
            String message = manager.Mail.GetLastMail(account);
            Match match = Regex.Match(message, @"http://\S*");
            return match.Value;
        }
        private void FillPasswordForm(string url, AccountData account)
        {
            
           
            driver.Url = url;

            driver.FindElement(By.Id("password")).SendKeys(account.Password); //id="realname"
            driver.FindElement(By.Id("password-confirm")).SendKeys(account.Password);  //password-confirm
        }

  

        public void OpenRegistrationFrom()
        {
            //driver.FindElements(By.CssSelector("back-to-login-link pull-left"))[0].Click();
            driver.FindElement(By.XPath("//a[@class='back-to-login-link pull-left']")).Click();
        }

        public void SubmitRegistration()
        {
            //driver.FindElement(By.CssSelector("input.Button")).Click();
            driver.FindElement(By.XPath("//input[@class = 'width-40 pull-right btn btn-success btn-inverse bigger-110']")).Click();
        }

        public  void FillRegistrationForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }

        public void OpenMainPage()
        {
           manager.Driver.Url = "http://localhost/mantisbt-2.26.2/login_page.php"; 
        }
    }
}


