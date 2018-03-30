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
using JobHunt.Services.Models;
using JobHunt.Services.Models.JobHunt;
using JobHunt.Services.Models.JobHunt.Employer;

namespace JobHunt.Services.Services.Implements
{
    public class EmployerService : IEmployerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<EmployerSearchResultViewModel> GetAll()
        {
            return null;
        }

        public async Task<EmployerDetailViewModel> GetEmployerById(Guid Id)
        {
            var result = await _unitOfWork.Repository<Employers>().GetById(Id).Select(e => new EmployerDetailViewModel
            {
                Title = e.Title,
                Followers = e.Followers,
                Description = e.Description
            }).FirstOrDefaultAsync();
            return result;
        }


        public Employers CreateEmployer()
        {
            return _unitOfWork.Repository<Employers>().GetQuery().FirstOrDefault();
        }

        public async Task<PaginatedResult<EmployerSearchResultViewModel>> SearchEmployer(SearchEmployerModel model)
        {
            var querry = _unitOfWork.Repository<Employers>().GetQuery();
            if (!string.IsNullOrEmpty(model.Keyword))
            {
                querry = querry.Where(e => e.Title.Contains(model.Keyword));
            }
            var pageIndex = model.PageNumber - 1;
            var totalCount = await querry.CountAsync();
            var results = await querry.OrderBy(o => o.InsAt)
                .Skip(pageIndex * model.PageSize)
                .Take(model.PageSize)
                .ToListAsync();

            var entity = results.Select(s => new EmployerSearchResultViewModel
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                Followers = s.Followers
            });
            return new PaginatedResult<EmployerSearchResultViewModel>(
                model.PageNumber,
                model.PageSize,
                totalCount,
                entity);
        }
    }
}
