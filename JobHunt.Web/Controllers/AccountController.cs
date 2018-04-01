using JobHunt.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Facebook;
using JobHunt.Services.Models.Login;

namespace JobHunt.Web.Controllers
{
    public class AccountController : Controller
    {
        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }
        private readonly IAuthenticationService _authenticationService;
        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]

        
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }
        [AllowAnonymous]
        public ActionResult Facebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = "359217404563814",
                client_secret = "4de3a996445f41a06949ae49ae6a0f87",
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email"
            });

            return Redirect(loginUrl.AbsoluteUri);
        }

        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = "359217404563814",
                client_secret = "4de3a996445f41a06949ae49ae6a0f87",
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });

            var accessToken = result.access_token;

            Session["AccessToken"] = accessToken;
            fb.AccessToken = accessToken;

            dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email");

            string email = me.email;
            string firstname = me.first_name;
            string middlename = me.middle_name;
            string lastname = me.last_name;

            var model = new SignOnModel
            {
                FirstName = firstname,
                Platform = "Facebook",
                Email = email,
                MiddleName = middlename,
                LastName = lastname,
                FullName = firstname,
                Username = lastname,
            };
            _authenticationService.CreateUser(model);

            // Set the auth cookie
            FormsAuthentication.SetAuthCookie(email, false);
            return RedirectToAction("Index", "Home");
        }


    }
}