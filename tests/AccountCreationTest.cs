using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;

namespace Mantis_tests 
{

    

    [TestFixture]
   
    public class AccountCreationTest : TestBase
    {
        [OneTimeSetUp]
        public void SetUpConfig() 
        {
            app.Ftp.BackUpFile("/config_inc.php");
            using (Stream localFile = File.Open("/config_inc.php", FileMode.Open))//\config_inc.php
            {
                app.Ftp.Upload("/config_inc.php", localFile);
            }
            
        }
        [Test]
        public void TestAccountRegisrtation()
        {

        AccountData account = new AccountData()
        {
            Name = "Test",
            Password = "Test",
            Email = "Test@localhost.localdomain",
        };

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
