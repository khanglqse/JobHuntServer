using JobHunt.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobHunt.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        //public ActionResult Login(string userName, string password)
        //{
        //    var result = _authenticationService.Login(userName, password);
        //    if (result !=null)
        //    {
        //        RedirectToAction()
        //    }
        //    return View();
        //}

       
    }
}