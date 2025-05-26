using AutoMapper.Configuration;
using EduConnect.Web.Models;
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
               var token = Session["UserToken"] as string;

               if (string.IsNullOrEmpty(token) && Request.Cookies["UserToken"] != null)
               {
                    token = Request.Cookies["UserToken"].Value;
               }

               //if (string.IsNullOrEmpty(token))
               //{
               //     return RedirectToAction("Index", "Auth");
               //}

               ViewBag.Token = token;
               return View();
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