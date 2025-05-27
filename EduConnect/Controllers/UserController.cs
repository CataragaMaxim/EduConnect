using EduConnect.BusinessLogic;
using EduConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduConnect.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
               var session = new SessionBL(Session, Request, Response);

               if (Session["UserLevel"] == null || Convert.ToInt32(Session["UserLevel"]) == 0)
               {
                    return RedirectToAction("Index", "Home");
               }

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
}