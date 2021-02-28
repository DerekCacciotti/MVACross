using System;
using System.Collections.Generic;
namespace MVA.Models
{
    public class Industry
    {
        public int codeIndustryPk { get; set; }
        public string industryName { get; set; }
    }

    public class IndustryRoot
    {
        public List<Industry> industry { get; set; }
    }


}
