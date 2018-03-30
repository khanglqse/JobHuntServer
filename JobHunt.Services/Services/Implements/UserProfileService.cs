//using JobHunt.Services.Services.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using JobHunt.Services.Models.Administration;

//using JobHunt.DataAccess;
//using JobHunt.DataAccess.Entities;
//using AutoMapper;

//namespace JobHunt.Services.Services.Implements
//{
//    public class UserProfileService : IUserProfileService
//    {
//        private readonly IUnitOfWorkFactory<UnitOfWork, JobHuntContext> _unitOfWork;

//        public UserProfileService(IUnitOfWorkFactory<UnitOfWork, JobHuntContext> unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }

//        public List<UserProfileModel> GetAll()
//        {
//            return _unitOfWork.Create().Repository<User>().Where(t => !t.IsDeleted).Select(a => new UserProfileModel
//            {
//                DisplayName = a.FirstName + a.LastName,
//                Name = a.FirstName
//            }).ToList();
//        }
//    }
//}
