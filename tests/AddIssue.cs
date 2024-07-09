using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using Google.Protobuf.WellKnownTypes;
using Mantis_tests;

namespace Mantis_tests
{
    [TestFixture]
    public class AddIssues : TestBase
    {
        [Test]
        public void AddIssue()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            IssueData issueData = new IssueData()
            {
                Summary = "Summary test",
                Description = "Description text",
                Category = "General"
            };
            app.login.Login(account);
            List<ProjectData> Listproject = ProjectData.GetProjectsListDB();
            ProjectData projectData = Listproject.First();

            app.API.CreateNewIssue(account, projectData, issueData);
        }
    }
}