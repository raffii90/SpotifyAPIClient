using System;
using System.ComponentModel.DataAnnotations;

namespace Spotify.Models.ViewModels
{
    public class SearchArtistsViewModel
    {
        public string Name { get; set; }

        public string Genre { get; set; }

        [Display(Name = "Date Start")]
        [DataType(DataType.Date)]
        public DateTime DateFrom { get; set; } = DateTime.Now.AddYears(-1);

        [Display(Name = "Date End")]
        [DataType(DataType.Date)]
        public DateTime DateTo { get; set; } = DateTime.Now;
    }
}
