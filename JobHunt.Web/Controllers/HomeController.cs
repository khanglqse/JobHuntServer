using JobHunt.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobHunt.Web.Controllers
{
    public class HomeController : Controller
    {
        private IEmployerService _emService;

        public HomeController(IEmployerService emService)
        {
            _emService = emService;
        }

        public ActionResult Index()
        {
           var a =  _emService.CreateEmployer();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}