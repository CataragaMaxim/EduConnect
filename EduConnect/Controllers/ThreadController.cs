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

     [HttpGet]
     public ActionResult Details(int id)
     {
          var thread = _threadBL.GetThreadById(id);
          if (thread == null)
          {
               return HttpNotFound();
          }

          var comments = _threadBL.GetCommentsByThreadId(id);

          ViewBag.Thread = thread;
          ViewBag.Comments = comments;

          return View();
     }

     [HttpPost]
     [ValidateAntiForgeryToken]
     public ActionResult AddComment(int threadId, string content)
     {
          var username = Session["Username"] as string;
          if (string.IsNullOrEmpty(username))
          {
               return RedirectToAction("Login", "User");
          }

          _threadBL.AddComment(threadId, username, content);

          return RedirectToAction("Details", new { id = threadId });
     }

     [HttpGet]
     public ActionResult Edit(int id)
     {
          var thread = _threadBL.GetThreadById(id);
          if (thread == null)
          {
               return HttpNotFound();
          }

          var currentUser = Session["Username"] as string;
          var currentRole = Session["Role"] as string;

          if (thread.Author != currentUser && currentRole != "Moderator")
          {
               return new HttpUnauthorizedResult("Nu ai drepturi sa editezi acest thread.");
          }

          var model = new AddThreadDTO
          {
               Id = thread.Id,
               Title = thread.Title,
               Description = thread.Description,
               Category = thread.Category
          };

          return View(model);
     }

     [HttpPost]
     [ValidateAntiForgeryToken]
     public ActionResult Edit(AddThreadDTO model)
     {
          if (!ModelState.IsValid)
          {
               return View(model);
          }

          var thread = _threadBL.GetThreadById(model.Id);
          if (thread == null)
          {
               return HttpNotFound();
          }

          var currentUser = Session["Username"] as string;
          var currentRole = Session["Role"] as string;

          if (thread.Author != currentUser && currentRole != "Moderator")
          {
               return new HttpUnauthorizedResult("Nu ai voie sa editezi acest thread.");
          }

          thread.Title = model.Title;
          thread.Description = model.Description;
          thread.Category = model.Category;

          _threadBL.UpdateThread(thread);

          return RedirectToAction("Details", new { id = thread.Id });
     }

     [HttpGet]
     public ActionResult Delete(int id)
     {
          var thread = _threadBL.GetThreadById(id);
          if (thread == null)
          {
               return HttpNotFound();
          }

          var currentUser = Session["Username"] as string;
          var currentRole = Session["Role"] as string;

          if (thread.Author != currentUser && currentRole != "Moderator")
          {
               return new HttpUnauthorizedResult("Nu ai voie sa stergi acest thread.");
          }

          return View(thread);
     }

     [HttpPost, ActionName("Delete")]
     [ValidateAntiForgeryToken]
     public ActionResult DeleteConfirmed(int id)
     {
          var thread = _threadBL.GetThreadById(id);
          if (thread == null)
          {
               return HttpNotFound();
          }

          var currentUser = Session["Username"] as string;
          var currentRole = Session["Role"] as string;

          if (thread.Author != currentUser && currentRole != "Moderator")
          {
               return new HttpUnauthorizedResult("Nu ai voie sa stergi acest thread.");
          }

          _threadBL.DeleteThread(id);
          return RedirectToAction("Index", "Categ"); // sau CategThreads daca ai categoriile
     }

}
