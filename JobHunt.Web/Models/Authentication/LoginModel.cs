using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobHunt.Web.Models.Authentication
{
    public class LoginModel
    {
            public string UserName { get; set; }
            public int Password { get; set; } = 1; //default is 1 and 20
    }
}