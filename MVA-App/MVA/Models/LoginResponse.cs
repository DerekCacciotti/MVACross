using System;
namespace MVA.Models
{
    public class LoginResponse
    {

            public int Id { get; set; }
            public int HighestDegree { get; set; }
            public int Industry { get; set; }
            public string Username { get; set; }
            public string Token { get; set; }
        }
}
