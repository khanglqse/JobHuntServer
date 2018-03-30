using JobHunt.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using JobHunt.Data;
using JobHunt.Services.Models.JobHunt;
using JobHunt.Web.Models;

namespace JobHunt.Web.Controllers
{

    public class EmployerController : AsyncController
    {
        private IEmployerService _emService;

        public EmployerController(IEmployerService emService)
        {
            _emService = emService;
        }

        public ActionResult Index()
        {
            //var model = _userProfileService.GetAll();
            return null;
        }

        public async Task<ActionResult> SearchResult(SearchEmployerViewModel model)
        {
            var searchModel = new SearchEmployerModel
            {
                PageSize = model.PageSize,
                Keyword = model.Keyword,
                PageNumber = model.PageNumber
            };
            var result =await _emService.SearchEmployer(searchModel);
            return View(result);
        }

        public async Task<ActionResult> Employer(Guid id)
        {
            var result = await _emService.GetEmployerById(id);
            return View(result);
        }
        public ActionResult ManageJob()
        {
            return View();
        }
        public ActionResult PostNewJob()
        {
            return View();
        }
        public ActionResult ManageProfile()
        {
            return View();
        }
        public ActionResult ManageResume()
        {
            return View();
        }

    }
}