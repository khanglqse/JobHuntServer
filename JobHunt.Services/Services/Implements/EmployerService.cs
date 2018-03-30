using JobHunt.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JobHunt.Services.Models.Administration;
using JobHunt.Data;
using JobHunt.Data.Entities.JobHunt;

namespace JobHunt.Services.Services.Implements
{
    public class EmployerService : IEmployerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<EmployerModel> GetAll()
        {
            return
                null;
        }


        public Employers CreateEmployer()
        {
            return _unitOfWork.Repository<Employers>().Get().FirstOrDefault();
        }
    }
}
