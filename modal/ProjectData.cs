using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;
using Mantis_tests;

namespace Mantis_tests
{
    [Table(Name = "mantis_project_table")]
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        public ProjectData()
        {
        }


        [Column(Name = "id")]
        public string Id { get; set; }

        [Column(Name = "name")]
        public string Name { get; set; }

        [Column(Name = "description")]

        public string Description { get; set; }
       
       

        public bool Equals(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (Name == other.Name) && (Description == other.Description) && (Id == other.Id);
        }

        


        public int CompareTo(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (Id == other.Id)
            {
                return Id.CompareTo(other.Name);
            }

            return Id.CompareTo(other.Id);
        }

        public static List<ProjectData> GetProjectsListDB()
        {
            using (MantisDB db = new MantisDB())
            {
                return (from s in db.Projects select s).ToList();
            }
        }
    }
}