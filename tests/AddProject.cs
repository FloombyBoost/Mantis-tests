using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using Mantis_test;
using System.Security.Cryptography;




namespace Mantis_tests
{
    [TestFixture]
    public class AddProject : TestBase
    {
        [Test]
        public void AddProjects()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            ProjectData projectData = new ProjectData()
            {
                Name = GenerateRandomString(4),
                Description = GenerateRandomString(20)
            };

            List<ProjectData> OldData = ProjectData.GetProjectsListDB();



            // app.login.Login(account);
            app.ProjectManagement.CreateProject(projectData);
            List<ProjectData> NewData = ProjectData.GetProjectsListDB();
            ClassicAssert.AreEqual(OldData.Count + 1, NewData.Count);




            //OldData.Add(projectData);


            ProjectData newProjectDataLastAdding = NewData.Last();
            OldData.Add(newProjectDataLastAdding);
            NewData.Sort();
            OldData.Sort();


            //ClassicAssert.AreEqual(OldData, NewData);

            Assert.That(OldData, Is.EquivalentTo(NewData));

        }
            [Test]
            public void AddProjectsSOAP()
            {

            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            ProjectData projectData = new ProjectData()
            {
                Name = GenerateRandomString(4),
                Description = GenerateRandomString(20)
            };

            List<ProjectData> OldData = app.API.GetAllProjectsWebService(account);



            // app.login.Login(account);
            app.ProjectManagement.CreateProject(projectData);
            List<ProjectData> NewData = app.API.GetAllProjectsWebService(account);
            ClassicAssert.AreEqual(OldData.Count + 1, NewData.Count);




            //OldData.Add(projectData);


            ProjectData newProjectDataLastAdding = NewData.Last();
            OldData.Add(newProjectDataLastAdding);
            NewData.Sort();
            OldData.Sort();


            //ClassicAssert.AreEqual(OldData, NewData);

            Assert.That(OldData, Is.EquivalentTo(NewData));

        }







        
    }
}
