     using EduConnect.BusinessLogic;
     using EduConnect.BusinessLogic.Interfaces;
     using EduConnect.Domain.Entities.Courses;
     using EduConnect.Domain.Entities.User;
     using EduConnect.Domain.Enums;
     using System.Linq;
     using System.Web.Mvc;


     public class CourseController : Controller
     {
          private readonly ICourse _courseBL;

          public CourseController()
          {
               var bl = new BussinesLogic();
               _courseBL = bl.GetCourseBL();
          }

     [HttpGet]
     public ActionResult Index()
     {
          var username = Session["Username"] as string;
          var level = Session["UserLevel"] != null ? (int)Session["UserLevel"] : 0;

          var courses = _courseBL.GetAllCourses();

          // Moderatorii vad toate cursurile
          if (level >= (int)URole.Moderator)
               return View(courses);

          // Altii vad doar cursurile publice, cele create de ei sau unde sunt permisi
          var filtered = courses.Where(c =>
              c.AccessLevel == "Public" ||
              c.CreatedBy == username ||
              (!string.IsNullOrEmpty(c.AllowedUsers) && c.AllowedUsers.Split(',').Contains(username))
          );

          return View(filtered);
     }


     [HttpGet]
          public ActionResult Details(int id)
          {
               var course = _courseBL.GetCourseById(id);
               if (course == null) return HttpNotFound();

               var username = Session["Username"] as string;
               var level = Session["UserLevel"] != null ? (int)Session["UserLevel"] : 0;

               if (course.AccessLevel == "Private"
                   && course.CreatedBy != username
                   && level < (int)URole.Moderator
                   && (course.AllowedUsers == null || !course.AllowedUsers.Split(',').Contains(username)))
               {
                    return new HttpUnauthorizedResult("Nu ai acces la acest curs.");
               }

               return View(course);
          }

          [HttpGet]
          public ActionResult Create()
          {
               return View();
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Create(AddCourseDTO model)
          {
               var username = Session["Username"] as string;
               if (username == null)
                    return RedirectToAction("Login", "User");

               model.CreatedBy = username;

               var result = _courseBL.AddCourse(model);
               if (!result.Status)
               {
                    ModelState.AddModelError("", "Eroare la crearea cursului.");
                    return View(model);
               }

               return RedirectToAction("Index");
          }

          [HttpGet]
          public ActionResult Edit(int id)
          {
               var course = _courseBL.GetCourseById(id);
               if (course == null) return HttpNotFound();

               var username = Session["Username"] as string;
               var level = Session["UserLevel"] != null ? (int)Session["UserLevel"] : 0;

               if (course.CreatedBy != username && level < (int)URole.Moderator)
                    return new HttpUnauthorizedResult("Nu ai voie sa editezi acest curs.");

               var model = new AddCourseDTO
               {
                    Id = course.Id,
                    Title = course.Title,
                    Description = course.Description,
                    Category = course.Category,
                    AccessLevel = course.AccessLevel,
                    AllowedUsers = course.AllowedUsers,
                    Videos = course.VideoItems?.Select(v => new VideoDTO
                    {
                         Title = v.Title,
                         VideoUrl = v.VideoUrl,
                         Order = v.Order
                    }).ToList()
               };

               return View(model);
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Edit(AddCourseDTO model)
          {
               var username = Session["Username"] as string;
               var level = Session["UserLevel"] != null ? (int)Session["UserLevel"] : 0;

               var course = _courseBL.GetCourseById(model.Id);
               if (course == null) return HttpNotFound();

               if (course.CreatedBy != username && level < (int)URole.Moderator)
                    return new HttpUnauthorizedResult("Nu ai voie sa editezi acest curs.");

               model.CreatedBy = course.CreatedBy;
               _courseBL.UpdateCourse(model);

               return RedirectToAction("Details", new { id = model.Id });
          }

          [HttpGet]
          public ActionResult Delete(int id)
          {
               var course = _courseBL.GetCourseById(id);
               if (course == null) return HttpNotFound();

               var username = Session["Username"] as string;
               var level = Session["UserLevel"] != null ? (int)Session["UserLevel"] : 0;

               if (course.CreatedBy != username && level < (int)URole.Moderator)
                    return new HttpUnauthorizedResult("Nu ai voie sa stergi acest curs.");

               return View(course);
          }

          [HttpPost, ActionName("Delete")]
          [ValidateAntiForgeryToken]
          public ActionResult DeleteConfirmed(int id)
          {
               var course = _courseBL.GetCourseById(id);
               if (course == null) return HttpNotFound();

               var username = Session["Username"] as string;
               var level = Session["UserLevel"] != null ? (int)Session["UserLevel"] : 0;

               if (course.CreatedBy != username && level < (int)URole.Moderator)
                    return new HttpUnauthorizedResult("Nu ai voie sa stergi acest curs.");

               _courseBL.DeleteCourse(id);
               return RedirectToAction("Index");
          }
     }
