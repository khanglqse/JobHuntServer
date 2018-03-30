using JobHunt.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobHunt.Services.Models.Administration;
using JobHunt.Data;
using JobHunt.Data.Entities.JobHunt;
using JobHunt.Data.Entities.Login;
using JobHunt.Services.Models;
using JobHunt.Services.Models.JobHunt;

namespace JobHunt.Services.Services.Implements
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthenticationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public UserProfileModel Login(string userName, string password)
        {
            return _unitOfWork.Repository<User>().GetQuery().Select(a => new UserProfileModel
            {
                Id = a.Id,
                DisplayName = a.DisplayName,
                Role = a.Roles.ToList()
            }).FirstOrDefault(u => u.UserName == userName);
        }
    }
}
