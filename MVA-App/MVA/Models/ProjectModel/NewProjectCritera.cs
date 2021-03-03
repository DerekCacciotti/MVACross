using System;
namespace MVA.Models.ProjectModel
{
    public class NewProjectCritera
    {
        public NewProjectInit ProojectData { get; set; }
        public int numofParticpants { get; set; }
        public int numofBaselinePoints { get; set; }
        public int numofinterventionPoints { get; set; }
        public int numOfMinStaggerPoints { get; set; }
        public int? outlierFK { get; set; }

    }
}
