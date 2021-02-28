using System;
using System.Collections.Generic;
namespace MVA.Models
{
    public class Degree
    {
     
            public int codeDegreePk { get; set; }
            public string degreeName { get; set; }

        public class DegreeRoot
        {
            public List<Degree> degrees { get; set; }
        }
    }
}
