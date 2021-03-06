﻿using JobHunt.Services.Models.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobHunt.Data.Entities.JobHunt;
using JobHunt.Services.Models;
using JobHunt.Services.Models.JobHunt;
using JobHunt.Services.Models.JobHunt.Employer;

namespace JobHunt.Services.Services.Interfaces
{
    public interface IEmployerService
    {
  
        List<EmployerSearchResultViewModel> GetAll();
      Task<EmployerDetailViewModel> GetEmployerById(Guid Id);
        Employer CreateEmployer();
        Task<PaginatedResult<EmployerSearchResultViewModel>> SearchEmployer(SearchEmployerModel model);

    }
}
