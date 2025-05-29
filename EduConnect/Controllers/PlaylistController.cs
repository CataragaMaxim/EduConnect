using EduConnect.Models;
using EduConnect.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduConnect.Controllers
{
    public class PlaylistController : Controller
    {
        public static List<Playlist> Playlists = new List<Playlist>();

        [HttpGet]
        public ActionResult Create()
        {
            return View(new PlaylistViewModel
            {
                Videos = new List<Video> { new Video() } // un câmp de start
            });
        }

        [HttpPost]
        public ActionResult Create(PlaylistViewModel model)
        {
            if (ModelState.IsValid)
            {
                var playlist = new Playlist
                {
                    Name = model.Name,
                    Description = model.Description,
                    Videos = model.Videos
                };

                Playlists.Add(playlist);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Index()
        {
            return View(Playlists);
        }
    }
}