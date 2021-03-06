using System;
namespace MVA.Models
{
    public class Critera
    { 
        public int NumofParticipants { get; set; }
        public int BaselinePoints { get; set; }
        public int InterventionPoints { get; set; }
        public int? OutlierFk { get; set; }
        public int MinStaggerPoints { get; set; }



    }
}
