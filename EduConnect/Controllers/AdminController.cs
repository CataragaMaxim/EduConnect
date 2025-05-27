using EduConnect.BusinessLogic;
using EduConnect.BusinessLogic.Interfaces;
using EduConnect.Domain.Entities.User;
using EduConnect.Models.Admin;
using System;
using System.Web.Mvc;

namespace EduConnect.Controllers
{
     public class AdminController : Controller
     {
          private readonly IAdmin _adminBL;

          public AdminController()
          {
               _adminBL = new BussinesLogic().GetAdminBL();
          }

          private bool IsAdminLoggedIn()
          {
               return Session["UserLevel"] != null && Convert.ToInt32(Session["UserLevel"]) >= 1000;
          }

          public ActionResult Index()
          {
               if (!IsAdminLoggedIn())
               {
                    return RedirectToAction("Index", "Home");
               }

               var session = new SessionBL(Session, Request, Response);
               var viewModel = new AdminProfileVM
               {
                    Username = Session["Username"] as string,
                    Role = Session["UserLevel"].ToString(),
                    Email = session.GetUserEmail(),
                    ProfileImageUrl = Url.Content("~/Images/team/img-1.jpg")
               };

               return View(viewModel);
          }

          public ActionResult Database(string selectedTable)
          {
               if (!IsAdminLoggedIn())
               {
                    return RedirectToAction("Index", "Home");
               }

               object data = null;

               switch (selectedTable)
               {
                    case "Users":
                         data = _adminBL.GetAllUsers();
                         break;
                         // case "Forum":
                         //     data = _adminBL.GetAllThreads();
                         //     break;
               }

               ViewBag.Data = data;
               return View();
          }

          [HttpGet]
          public ActionResult EditUser(int id)
          {
               var user = _adminBL.GetUserById(id);
               if (user == null)
                    return HttpNotFound();

               return View(user);
          }

          [HttpPost]
          public ActionResult EditUser(UDbTable updatedUser)
          {
               bool result = _adminBL.UpdateUser(updatedUser);

               if (!result)
                    return HttpNotFound();

               return RedirectToAction("Database", new { selectedTable = "Users" });
          }

          public ActionResult DeleteUser(int id)
          {
               bool result = _adminBL.DeleteUser(id);

               if (!result)
                    return HttpNotFound();

               return RedirectToAction("Database", new { selectedTable = "Users" });
          }
     }
}
