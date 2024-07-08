using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using NUnit.Framework.Legacy;
using System.Collections.Generic;



namespace Mantis_tests

{
    [TestFixture]
    public class RemoveProject : TestBase
    {
        [Test]
        public void RemoveProjects()
        {

            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            //app.login.Login(account);

            List<ProjectData> oldProjects = ProjectData.GetProjectsListDB();
            ProjectData toBeDeleted = oldProjects[0];

            app.ProjectManagement.DeleteProject(toBeDeleted.Name);

            List<ProjectData> newProjects = ProjectData.GetProjectsListDB();

            ClassicAssert.AreEqual(oldProjects.Count - 1, newProjects.Count);

            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();
            ClassicAssert.AreEqual(oldProjects, newProjects);

            foreach (ProjectData project in newProjects)
            {
                ClassicAssert.AreNotEqual(project.Id, toBeDeleted.Id);
            }
        }



        [Test]
        public void RemoveProjectsSOAP()
        {


           

                AccountData account = new AccountData()
                {
                    Name = "administrator",
                    Password = "root"
                };

                //app.login.Login(account);

                List<ProjectData> oldProjects = app.API.GetAllProjectsWebService(account);
                ProjectData toBeDeleted = oldProjects[0];

                app.ProjectManagement.DeleteProject(toBeDeleted.Name);

                List<ProjectData> newProjects = app.API.GetAllProjectsWebService(account);

                ClassicAssert.AreEqual(oldProjects.Count - 1, newProjects.Count);

                oldProjects.RemoveAt(0);
                oldProjects.Sort();
                newProjects.Sort();
                ClassicAssert.AreEqual(oldProjects, newProjects);

                foreach (ProjectData project in newProjects)
                {
                    ClassicAssert.AreNotEqual(project.Id, toBeDeleted.Id);
                }
            

        }

    }
}
