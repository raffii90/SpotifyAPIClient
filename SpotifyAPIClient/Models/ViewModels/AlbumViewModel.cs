using System;
using System.ComponentModel.DataAnnotations;

namespace Spotify.Models.ViewModels
{
    public class AlbumViewModel
    {
        public string Name { get; set; }

        public string Type { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Number of Tracks")]
        public int NumberOfTracks { get; set; }

        public string Artists { get; set; }
    }
}
