using System;
namespace MVA.Models
{
    public class CreateUserModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string emailaddress { get; set; }
        public int HighestDegree { get; set; }
        public int Industry { get; set; }
    }
}
