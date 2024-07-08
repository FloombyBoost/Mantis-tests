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

        public RegistrationHelper Registration { get;  set; }
        public FRTPhelper Ftp { get;  set; }
        public JamesHelper James { get;  set; }
        public MailHelper Mail { get; set; }
        public LoginHelper login { get; set; }
        public ManagementMenuHelper ManagementMenu { get; set; }
        public ProjectManagementHelper ProjectManagement { get; set; }
        public MantisDB ConnectDB { get; set; }
        public AdminHelper Admin { get;  set; }
        public APIHelper API { get; set; }

        protected string baseURL;
        protected string baseURLadmin;
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            baseURL = "http://localhost";
            baseURLadmin = "http://localhost/mantisbt/mantisbt-2.26.2";
            driver = new ChromeDriver();
            Registration = new RegistrationHelper (this);
            Ftp = new FRTPhelper (this);
            James = new  JamesHelper(this);
            Mail = new MailHelper (this);
            login = new LoginHelper(this);
            ManagementMenu = new ManagementMenuHelper (this,baseURL);
            ProjectManagement = new ProjectManagementHelper (this);
            ConnectDB = new MantisDB ();
            Admin  = new AdminHelper(this, baseURLadmin);
            API = new APIHelper(this);



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

