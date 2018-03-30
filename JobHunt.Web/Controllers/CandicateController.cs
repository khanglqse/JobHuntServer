using JobHunt.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobHunt.Data;

namespace JobHunt.Web.Controllers
{

    public class CandicateController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CandicateController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            _unitOfWork.Commit();

            return null;
        }
    }
}