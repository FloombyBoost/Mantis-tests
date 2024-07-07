using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using Mantis_test;

namespace Mantis_tests
{
    public class ApplicationManager
    {
  

        protected IWebDriver driver;

        public RegistrationHelper Registration { get; private set; }
        public FRTPhelper Ftp { get; private set; }
        public JamesHelper James { get; private set; }
        public MailHelper Mail { get; private set; }
        public LoginHelper login { get; private set; }
        public ManagementMenuHelper ManagementMenu { get; private set; }
        public ProjectManagementHelper ProjectManagement { get; private set; }
        public MantisDB ConnectDB { get; private set; }

        protected string baseURL;
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            baseURL = "http://localhost";
            driver = new ChromeDriver();
            Registration = new RegistrationHelper (this);
            Ftp = new FRTPhelper (this);
            James = new  JamesHelper(this);
            Mail = new MailHelper (this);
            login = new LoginHelper(this);
            ManagementMenu = new ManagementMenuHelper (this,baseURL);
            ProjectManagement = new ProjectManagementHelper (this);
            ConnectDB = new MantisDB ();



        }

         ~ApplicationManager()//ДУРАЦКИЙ БАГ!!!
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        public static ApplicationManager GetInstanse()
        {
             if (! app.IsValueCreated) 
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost/mantisbt-2.26.2/login_page.php";
                app.Value = newInstance;
               

            }
            return app.Value;
        }
        public IWebDriver Driver 
        {
            get { return driver; }
            
        }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        

        }


    }

