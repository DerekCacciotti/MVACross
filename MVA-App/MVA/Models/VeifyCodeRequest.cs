using System;
namespace MVA.Models
{
    public class VeifyCodeRequest
    {

        public int RoleFK { get; set; }
        public string Code { get; set; }
        public int UserFK { get; set; }

    }
}
