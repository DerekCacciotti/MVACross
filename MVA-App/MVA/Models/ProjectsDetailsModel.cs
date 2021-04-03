using System;
using System.Collections.Generic;
namespace MVA.Models
{
    public class ProjectsDetailsModel
    {
        public int criteraPk { get; set; }
        public int projectFk { get; set; }
        public int numofParticipants { get; set; }
        public int baselinePoints { get; set; }
        public int interventionPoints { get; set; }
        public int? outlierFk { get; set; }
        public int minStaggerPoints { get; set; }
        public OutlierFkNavigation outlierFkNavigation { get; set; }
        public ProjectFkNavigation projectFkNavigation { get; set; }
    }

    public class OutlierFkNavigation
    {
        public int codeOutlierPk { get; set; }
        public string outlierType { get; set; }
        public List<object> criteras { get; set; }
    }

    public class ProjectFkNavigation
    {
        public int projectPk { get; set; }
        public string projectName { get; set; }
        public int roleFk { get; set; }
        public int typeFk { get; set; }
        public int? outputTypeFk { get; set; }
        public int criteraFk { get; set; }
        public DateTime projectCreateDate { get; set; }
        public string projectCreator { get; set; }
        public string dependentVariable { get; set; }
        public int upperLimit { get; set; }
        public string participants { get; set; }
        public string interventionCode { get; set; }
        public string analystCode { get; set; }
        public object outputTypeFkNavigation { get; set; }
        public object roleFkNavigation { get; set; }
        public object typeFkNavigation { get; set; }
        public List<object> criteras { get; set; }
        public List<object> projectAcls { get; set; }
    }



    
    }

