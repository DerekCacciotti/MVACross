using System;
using System.Collections.Generic;
namespace MVA.Models
{
    public class OutputTypes
    {
        public int idcodeOutputTypePk { get; set; }
        public string outputType { get; set; }
    }

    public class OutputTypesRoot
    {
        public List<OutputTypes> outputtypes { get; set; }
    }
}
