using System;
namespace MVA.Models
{
    public class Project
    {
        public int ProjectPk { get; set; }
        public string ProjectName { get; set; }
        public int RoleFk { get; set; }
        public int TypeFk { get; set; }
        public int? OutputTypeFk { get; set; }
        public int? CriteraFk { get; set; }
        public DateTime ProjectCreateDate { get; set; }
        public string ProjectCreator { get; set; }
        public string DependentVariable { get; set; }
        public int UpperLimit { get; set; }
        public string Participants { get; set; }
        public string InterventionCode { get; set; }
        public string AnalystCode { get; set; }
        
    }
}
