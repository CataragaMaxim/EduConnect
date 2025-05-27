using EduConnect.BusinessLogic;
using EduConnect.Models;
using System;
using System.Security.Policy;
using System.Web.Mvc;

public class UserController : Controller
{
     private bool IsUserLoggedIn()
     {
          return Session["UserLevel"] != null && Convert.ToInt32(Session["UserLevel"]) > 0;
     }

     [HttpGet]
     public ActionResult Settings()
     {
          if (!IsUserLoggedIn())
               return RedirectToAction("Index", "Home");

          var session = new SessionBL(Session, Request, Response);
          var username = Session["Username"] as string;
          var email = session.GetUserEmail();

          var model = new UserSettingsVM
          {
               Username = username,
               Email = email
          };

          return View(model);
     }

     [HttpPost]
     public ActionResult Settings(UserSettingsVM model)
     {
          if (!IsUserLoggedIn())
               return RedirectToAction("Index", "Home");

          var bl = new BussinesLogic();
          var userBL = bl.GetUserBL();
          var session = new SessionBL(Session, Request, Response);
          var currentUsername = Session["Username"] as string;

          var updateResult = userBL.UpdateUserSettings(currentUsername, model.Username, model.Email);

          if (updateResult.Success)
          {
               var token = session.GetUserToken();
               session.SetUserSession(model.Username, (int)Session["UserLevel"], token, model.Email);
          }

          model.Message = updateResult.Message;
          return View(model);
     }

     public ActionResult Index()
     {
          if (!IsUserLoggedIn())
               return RedirectToAction("Index", "Home");

          var session = new SessionBL(Session, Request, Response);
          var viewModel = new UserProfileVM
          {
               Username = Session["Username"] as string,
               Role = Session["UserLevel"].ToString(),
               Email = session.GetUserEmail(),
               ProfileImageUrl = Url.Content("~/Images/users/img-1.jpg")
          };

          return View(viewModel);
     }
}
