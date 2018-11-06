using System;
using System.ComponentModel.DataAnnotations;

namespace Spotify.Models.ViewModels
{
    public class SearchTrackViewModel
    {
        public string Keyword { get; set; }

        [Display(Name = "Track name")]
        public string TrackName { get; set; }

        [Display(Name = "Album name")]
        public string AlbumName { get; set; }

        [Display(Name = "Artist name")]
        public string ArtistName { get; set; }

        public string Genre { get; set; }

        [Display(Name = "Date start")]
        [DataType(DataType.Date)]
        public DateTime DateFrom { get; set; } = DateTime.Now.AddYears(-1);

        [Display(Name = "Date end")]
        [DataType(DataType.Date)]
        public DateTime DateTo { get; set; } = DateTime.Now;
    }
}
