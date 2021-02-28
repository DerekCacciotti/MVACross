using System;
using System.Collections.Generic;
namespace MVA.Models
{
    public class Outlier
    {
        public int codeOutlierPk { get; set; }
        public string outlierType { get; set; }
      
    }

     public class OutlierRoot
    {
        public List<Outlier> outliersobj { get; set; }
    }
}
