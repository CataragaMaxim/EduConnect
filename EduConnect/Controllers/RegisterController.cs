using EduConnect.BusinessLogic;
using EduConnect.BusinessLogic.Interfaces;
using EduConnect.Domain.Entities.User.Reg;
using EduConnect.Domain.User.Auth;
using EduConnect.Domain.User.Reg;
using EduConnect.Models.Reg;
using System;
using System.Web;
using System.Web.Mvc;

namespace EduConnect.Controllers
{
     public class RegisterController : Controller
     {
          private readonly IUser _user;
          public RegisterController()
          {
               var bl = new BussinesLogic();
               _user = bl.GetUserBL();
          }

          // GET: Register
          public ActionResult Index()
          {
               return View(new UserRegData());
          }

          [HttpPost]
          public ActionResult Reg(UserRegData data)
          {
               if (!ModelState.IsValid)
               {
                    return View("Index", data);
               }

               var local = new RegDataActionDTO()
               {
                    Username = data.Username,
                    Password = data.Password,
                    Email = data.Email
               };

               var resp = _user.RegisterUserAction(local);

               if (resp.Status)
               {
                    var auth = new UserAuthAction()
                    {
                         Username = data.Username,
                         Password = data.Password,
                         LoginTime = DateTime.Now
                    };

                    string token = _user.AuthenticateUser(auth);

                    if (!string.IsNullOrEmpty(token))
                    {
                         var user = _user.GetUserByUsername(data.Username);

                         var session = new BussinesLogic().GetSessionBL(
                             new HttpSessionStateWrapper(System.Web.HttpContext.Current.Session),
                             new HttpRequestWrapper(System.Web.HttpContext.Current.Request),
                             new HttpResponseWrapper(System.Web.HttpContext.Current.Response)
                         );

                         session.SetUserSession(user.Username, (int)user.Level, token, user.Email);

                         return RedirectToAction("Index", "Home");
                    }

                    ModelState.AddModelError("", "Înregistrarea a fost reușită, dar autentificarea a eșuat.");
                    return View("Index", data);
               }

               // Înregistrare eșuată
               ModelState.AddModelError("", resp.Error ?? "Înregistrare eșuată.");
               return View("Index", data);
          }
     }
}
