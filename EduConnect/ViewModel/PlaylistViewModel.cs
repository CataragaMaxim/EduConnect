using EduConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduConnect.ViewModel
{
    public class PlaylistViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Video> Videos { get; set; } = new List<Video>();
    }

}