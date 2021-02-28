using System;
using System.Collections.Generic;
namespace MVA.Models
{
    public class ResearchTypes
    {
        public int idcodeResearchTypePk { get; set; }
        public string researchType { get; set; }


    }
    public class ResearchTypesRoot
    {
        public List<ResearchTypes> types { get; set; }
    }
}
