using EduConnect.BusinessLogic;
using EduConnect.BusinessLogic.BLogic;
using EduConnect.BusinessLogic.Core;
using EduConnect.BusinessLogic.Interfaces;
using EduConnect.Domain.Entities.Thread;
using EduConnect.Domain.Entities.User;
using System.Web.Mvc;

public class ThreadController : Controller
{
    private readonly IThread _threadBL;

    public ThreadController()
    {
        var bl = new BussinesLogic();
        _threadBL = bl.GetThreadBL();
    }

    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(AddThreadDTO model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var username = Session["Username"] as string;
        if (string.IsNullOrEmpty(username))
        {
            return RedirectToAction("Login", "User");
        }

        model.Author = username;

        var response = _threadBL.AddThread(model);

        if (!response.Status)
        {
            ModelState.AddModelError("", response.Error ?? "Eroare la salvarea thread-ului.");
            return View(model);
        }

        return RedirectToAction("Index", "Categ");
    }
}
