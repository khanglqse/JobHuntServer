using JobHunt.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobHunt.Data;

namespace JobHunt.Web.Controllers
{

    public class EmployerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            _unitOfWork.Commit();
            //var model = _userProfileService.GetAll();
            return null;
        }
    }
}