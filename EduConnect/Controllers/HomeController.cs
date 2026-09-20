using EduConnect.BusinessLogic;
using EduConnect.BusinessLogic.Interfaces;
using EduConnect.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
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
               if (Convert.ToInt32(Session["UserLevel"]) >= 1000)
               {
                    return RedirectToAction("Index", "Admin");
               }
               ISession session = new SessionBL(Session, Request, Response);
               var token = session.GetUserToken();

               ViewBag.Token = token;
               return View(); ;
          }

            [HttpGet]
            public ActionResult Contact()
        {
            return View();
        }


        public ActionResult About()
        {
            return View();
        }







    }
}