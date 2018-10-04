using System;
using System.ComponentModel.DataAnnotations;

namespace CloudNineAssignment.Models.ViewModels
{
    public class TrackViewModel
    {
        public string Name { get; set; }

        [Display(Name = "Album Name")]
        public string AlbumName { get; set; }

        public string Artists { get; set; }

        public string Duration { get; set; }

        public int Popularity { get; set; }
    }
}
