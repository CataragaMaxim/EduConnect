using EduConnect.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using EduConnect.BusinessLogic.Interfaces;
using EduConnect.Models.Auth;
using System.Web.Configuration;
using EduConnect.Domain.Entities.User;
using EduConnect.Domain.User.Auth;

namespace EduConnect.Controllers
{
     public class AuthController : Controller
     {
          private IUser _user;
          private ISession _session;

          protected override void OnActionExecuting(ActionExecutingContext filterContext)
          {
               var bl = new BussinesLogic();
               _user = bl.GetUserBL();
               _session = bl.GetSessionBL(
                   new HttpSessionStateWrapper(System.Web.HttpContext.Current.Session),
                   new HttpRequestWrapper(System.Web.HttpContext.Current.Request),
                   new HttpResponseWrapper(System.Web.HttpContext.Current.Response)
               );
               base.OnActionExecuting(filterContext);
          }

          public ActionResult Index()
          {
               return View(new UserAuthData());
          }

          public ActionResult Logout()
          {
               _session.ClearUserSession();
               return RedirectToAction("Index", "Home");
          }

          [HttpPost]
          public ActionResult Auth(UserAuthData data)
          {
               var auth = new UserAuthAction()
               {
                    LoginTime = DateTime.Now,
                    Password = data.Password,
                    Username = data.Username
               };

               string token = _user.AuthenticateUser(auth);
               if (!string.IsNullOrEmpty(token))
               {
                    var user = _user.GetUserByUsername(auth.Username);
                    _session.SetUserSession(user.Username, (int)user.Level, token, user.Email);
                    return RedirectToAction("Index", "Home");
               }

               ModelState.AddModelError("", "Autentificare eșuata. Verifica datele.");
               return View("Index", data);
          }
     }

}