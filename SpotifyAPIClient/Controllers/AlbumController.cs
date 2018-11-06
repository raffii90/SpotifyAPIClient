using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spotify.Interfaces;
using Spotify.Data;
using Spotify.Models.ViewModels;
using Spotify.Services;

namespace Spotify.Controllers
{
    public class AlbumController : Controller
    {
        private IAlbumService _albumService = new AlbumService(new AlbumRepository(SpotifyAPIClient.Instance));

        // GET: /Album/Catalog
        public async Task<IActionResult> Catalog(string keywords, DateTime from, DateTime to, string albumName = null,
                                                       string artist = null, int? limit = null, int? offset = null)
        {
            return View(await _albumService.GetAlbumsAsync(keywords, from, to, albumName, artist, limit, offset));
        }

        // GET: /Album/Search
        public IActionResult Search()
        {
            return View(new SearchAlbumsViewModel());
        }

        // POST: /Album/Search
        [HttpPost]
        public IActionResult Search([Bind] SearchAlbumsViewModel searchAlbumsViewModel)
        {       
            return RedirectToAction("Catalog", new { 
                keywords = searchAlbumsViewModel.Keyword,
                from = searchAlbumsViewModel.ReleasedFrom,
                to = searchAlbumsViewModel.ReleasedTo,
                albumName = searchAlbumsViewModel.Name,
                artist = searchAlbumsViewModel.Artist,
            });
        }
    }
}
