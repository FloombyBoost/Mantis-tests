using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Mantis_tests;

namespace Mantis_test
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager) { }

        public ProjectManagementHelper CreateProject(ProjectData project)
        {
            manager.ManagementMenu.GoToManagePage();
            manager.ManagementMenu.GoToProjectManage();
            InitNewProjectCreation();
            FillProjectForm(project);
            SubmitProjectCreation();
            return this;
        }

        public ProjectManagementHelper DeleteProject(string projectName)
        {
            manager.ManagementMenu.GoToManagePage();
            manager.ManagementMenu.GoToProjectManage();
            SelectProject(projectName);
            SubmitProjectDeleting();
            return this;
        }

        private void SubmitProjectDeleting()
        {
            driver.FindElement(By.XPath("//button[@formaction= 'manage_proj_delete.php']")).Click();
            driver.FindElement(By.XPath("//input[@type = 'submit']")).Click();
        }

        private void SelectProject(string projectName)
        {
            driver.FindElement(By.XPath("//tr/td/a[contains(text(), '" + projectName + "')]")).Click();
        }

        public void SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@type = 'submit']")).Click();
        }

        public void FillProjectForm(ProjectData project)
        {
            Type(By.Id("project-name"), project.Name);
            Type(By.Id("project-description"), project.Description);
        }

        public void InitNewProjectCreation()
        {
            driver.FindElement(By.XPath("//button[@type = 'submit']")).Click();
        }

       

       
    }
}