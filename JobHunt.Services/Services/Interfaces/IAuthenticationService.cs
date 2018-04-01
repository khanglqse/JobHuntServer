using JobHunt.Services.Models.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobHunt.Data.Entities.JobHunt;
using JobHunt.Services.Models;
using JobHunt.Services.Models.JobHunt;
using JobHunt.Services.Models.JobHunt.Employer;
using JobHunt.Services.Models.Login;

namespace JobHunt.Services.Services.Interfaces
{
    public interface IAuthenticationService
    {
  
        UserProfileModel Login(string userName, string password);

        bool CreateUser(SignOnModel model);
    }
}
