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

namespace EduConnect.Controllers
{
    public class AuthController : Controller
    {
          private readonly IAuth _auth;
          public AuthController()
          {
               var bl = new BusinessLogic.BussinesLogic();
               _auth = bl.GetAuthBL();
          }
          // GET: Auth
          public ActionResult Index()
        {
            return View(new UserDataLogin());
        }
          [HttpPost]
          public ActionResult Auth(UserDataLogin login)
          {
               var data = new UserLoginDTO()
               {
                    Password = login.Password,
                    Username = login.Username
               };

               string token = _auth.UserAuthLogic(data);
               return View();
          }
    }
}