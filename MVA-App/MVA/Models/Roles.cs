using System;
using System.Collections.Generic;
namespace MVA.Models
{
    public class Roles
    {
        public int codeRolePk { get; set; }
        public string roleName { get; set; }
       
    }

    public class RootRoles
    {
        public List<Roles> rolesobj { get; set; }
    }
}
