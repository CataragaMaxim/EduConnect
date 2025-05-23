﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EduConnect.BusinessLogic.CategBL;
using EduConnect.Domain.Entities.Categ;

namespace EduConnect.Controllers
{
    public class CategController : Controller
    {
        private readonly CategBL _categ;
        public CategController()
        {
            _categ = new CategBL();
        }
        // GET: Categ
        public ActionResult Index()
        {
            var token = Session["UserToken"] as string;
            if (string.IsNullOrEmpty(token) && Request.Cookies["UserToken"] != null)
               {
                token = Request.Cookies["UserToken"].Value;
               }
            var Cbl = new CategBL();
            var Categs = Cbl.GetAllCategs() ?? new List<Categ>();
            return View(Categs);
            //return View();
        }
    }
}