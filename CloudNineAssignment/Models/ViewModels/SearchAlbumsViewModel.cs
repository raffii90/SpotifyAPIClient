using System;
using System.ComponentModel.DataAnnotations;

namespace CloudNineAssignment.Models.ViewModels
{
    public class SearchAlbumsViewModel
    {
        public string Keyword { get; set; }

        [Display(Name = "Release Date Start")]
        [DataType(DataType.Date)]
        public DateTime ReleasedFrom { get; set; } = DateTime.Now.AddYears(-1);

        [Display(Name = "Release Date End")]
        [DataType(DataType.Date)]
        public DateTime ReleasedTo { get; set; } = DateTime.Now;

        public string Name { get; set; }

        public string Artist { get; set; }
    }
}
