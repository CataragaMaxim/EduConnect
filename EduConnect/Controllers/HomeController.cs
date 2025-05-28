using EduConnect.BusinessLogic;
using EduConnect.BusinessLogic.Interfaces;
using EduConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduConnect.Controllers
{
    public class HomeController : Controller
    {
          // GET: Home
          public ActionResult Index()
          {
               ISession session = new SessionBL(Session, Request, Response);
               var token = session.GetUserToken();

               ViewBag.Token = token;
               return View(); ;
          }
          
     }
}