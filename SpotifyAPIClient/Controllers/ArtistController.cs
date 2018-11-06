using System;
using System.Threading.Tasks;
using Spotify.Data;
using Spotify.Interfaces;
using Spotify.Models.ViewModels;
using Spotify.Services;
using Microsoft.AspNetCore.Mvc;

namespace Spotify.Controllers
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
