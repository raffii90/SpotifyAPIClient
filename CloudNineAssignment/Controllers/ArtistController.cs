using System;
using System.Threading.Tasks;
using CloudNineAssignment.Data;
using CloudNineAssignment.Interfaces;
using CloudNineAssignment.Models.ViewModels;
using CloudNineAssignment.Services;
using Microsoft.AspNetCore.Mvc;

namespace CloudNineAssignment.Controllers
{
    public class ArtistController : Controller
    {
        private IArtistService _artistService = new ArtistService(new ArtistRepository(SpotifyAPIClient.Instance));

        // GET: /Artist/Catalog
        public async Task<IActionResult> Catalog(string name, DateTime from, DateTime to, string genre = null,
                                                 int? limit = null, int? offset = null)
        {
            return View(await _artistService.GetArtistsAsync(name, from, to, genre, limit, offset));
        }

        // GET: /Artist/Search
        public IActionResult Search()
        {
            return View(new SearchArtistsViewModel());
        }

        // POST: /Artist/Search
        [HttpPost]
        public IActionResult Search([Bind] SearchArtistsViewModel searchArtistsViewModel)
        {
            return RedirectToAction("Catalog", new
            {
                name = searchArtistsViewModel.Name,
                from = searchArtistsViewModel.DateFrom,
                to = searchArtistsViewModel.DateTo,
                genre = searchArtistsViewModel.Genre,
            });
        }
    }
}
