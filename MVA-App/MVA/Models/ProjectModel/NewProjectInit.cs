using System;
namespace MVA.Models.ProjectModel
{
    public class NewProjectInit
    {
        public string ProjectName { get; set; }
        public int RoleFK { get; set; }
        public int ResearchTypeFK { get; set; }
        public int OutputTypeFK { get; set; }
    }
}
