using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;
using Google.Protobuf.WellKnownTypes;
namespace Mantis_tests
{
    [TestClass]
    public class LoginTest :TestBase

    {
        [Test]
        public void TestLogIn()
        {

            AccountData account = new AccountData()
            {
                Name = "Test12",
                Password = "Test",
                Email = "Test12@localhost.localdomain",
            };
            //app.login.Login(account);
           app.login.Logout(account);


        }

    }








}
