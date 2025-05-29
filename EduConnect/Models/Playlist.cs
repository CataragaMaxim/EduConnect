using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduConnect.Models
{
    public class Playlist
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Video> Videos { get; set; } = new List<Video>();
    }
}