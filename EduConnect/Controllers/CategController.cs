using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EduConnect.BusinessLogic;
using EduConnect.BusinessLogic.BLogic;
using EduConnect.BusinessLogic.CategBL;
using EduConnect.BusinessLogic.Interfaces;
using EduConnect.Domain.Entities.Categ;
using EduConnect.Domain.Entities.Thread;
using EduConnect.Domain.Entities.User;
using Microsoft.AspNet.Identity;

namespace EduConnect.Controllers
{
    public class CategController : Controller
    {
        private readonly CategBL _categ;
        private readonly IThread _threadBL;
        public CategController()
        {
            var bl = new BussinesLogic();
            _categ = new CategBL();
            _threadBL = bl.GetThreadBL();
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
        public ActionResult ViewCateg(int id)
        {
            var token = Session["UserToken"] as string;
            if (string.IsNullOrEmpty(token) && Request.Cookies["UserToken"] != null)
            {
                token = Request.Cookies["UserToken"].Value;
            }
            var Cbl = new CategBL();
            var Categs = Cbl.GetAllCategs() ?? new List<Categ>();
            //var categ = _categ.GetCategByUsername(auth.Username);
            //Session["Categname"] = categ.Name;
            //Session["CategDesc"] = categ.Description;
            return View(Categs[id]);
            //return View();
        }

        [HttpGet]
        public ActionResult CategThreads(string categ)
        {
            IEnumerable<UDbThreads> threads;

            if (categ == "All")
            {
                threads = _threadBL.GetAllThreads();
            }
            else
            {
                threads = _threadBL.GetAllThreads().Where(t => t.Category.Equals(categ, StringComparison.OrdinalIgnoreCase));
            }

            ViewBag.SelectedCategory = categ;
            return View(threads);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CategThreads(string categ, AddThreadDTO newThread)
        {
            if (ModelState.IsValid)
            {
                newThread.Category = categ;
                _threadBL.AddThread(newThread);
                ModelState.Clear(); // curăță formularul după submit
            }

            var threads = _threadBL.GetAllThreads().Where(t => t.Category.Equals(categ, StringComparison.OrdinalIgnoreCase));
            ViewBag.SelectedCategory = categ;
            return View(threads);
        }

    }
}