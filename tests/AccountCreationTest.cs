using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Collections.Generic;

namespace Mantis_tests 
{

    

    [TestFixture]
   
    public class AccountCreationTest : TestBase
    {
        [OneTimeSetUp]
        public void SetUpConfig() 
        {
            app.Ftp.BackUpFile("/config_inc.php");
            using (Stream localFile = File.Open("C:\\xampp\\htdocs\\mantisbt-2.26.2\\config\\config_inc.php", FileMode.Open))//\config_inc.php
            {
                app.Ftp.Upload("/config_inc.php", localFile);
            }
            
        }
        [Test]
        public void TestAccountRegisrtation()
        {

        AccountData account = new AccountData()
        {
            Name = "Test12",
            Password = "Test",
            Email = "Test12@localhost.localdomain",
        };

            AccountData accountAdmin = new AccountData()
            {
                Name = "administrator",
                Password = "root",
              
            };


            List<AccountData> accounts = app.Admin.GetAllAccounts();
            AccountData existingAccount = accounts.Find(x => x.Name == account.Name);
            if (existingAccount != null)
            {
                app.Admin.DeleteAccount(existingAccount);
            }

            app.James.Delete(account);
            app.James.Add(account);
            app.login.Logout(accountAdmin);
            app.Registration.Register(account);
        }








        [TearDown]
        public void RestoreConfig()
        {
            app.Ftp.RestoreBackUpFile("/config_inc.php");
            { }
        }
    }




}
