using EduConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduConnect.Controllers
{
    public class CoursesController : Controller
    {
        public ActionResult Courses() // NU Courses()
        {
            var courses = new List<Courses> // sau Courses, dacă încă folosești clasa cu numele plural
        {
            new Courses {
                Id = 1,
                Title = "Introducere în ASP.NET MVC",
                Description = "Tutorial pentru începători.",
                YouTubeUrl = "https://www.youtube.com/watch?v=E7Voso411Vs"
            },
            new Courses {
                Id = 2,
                Title = "Bootstrap Responsiv",
                Description = "Cum să creezi UI modern.",
                YouTubeUrl = "https://www.youtube.com/watch?v=4sosXZsdy-s"
            },

            new Courses {
            Id = 3,
            Title = "Interfețe Responsive cu Bootstrap",
            Description = "Exemplu de utilizare a Bootstrap în pagini web.",
            YouTubeUrl = "https://www.youtube.com/watch?v=4sosXZsdy-s"
        },
            new Courses {
            Id = 4,
            Title = "Controlere și View-uri",
            Description = "Explorăm cum MVC mapează cererile HTTP.",
            YouTubeUrl = "https://www.youtube.com/watch?v=Z1CvkJ2BJnU"
        }
        };

            return View(courses); // va încărca Views/Courses/Index.cshtml
        }
    }


}
