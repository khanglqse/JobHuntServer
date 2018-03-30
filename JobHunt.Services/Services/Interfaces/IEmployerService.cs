using JobHunt.Services.Models.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobHunt.Data.Entities.JobHunt;

namespace JobHunt.Services.Services.Interfaces
{
    public interface IEmployerService
    {
  
        List<EmployerModel> GetAll();
        Employers CreateEmployer();

    }
}
