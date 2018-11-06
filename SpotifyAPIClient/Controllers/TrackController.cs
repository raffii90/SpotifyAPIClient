using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spotify.Data;
using Spotify.Interfaces;
using Spotify.Models.ViewModels;
using Spotify.Services;
using Microsoft.AspNetCore.Mvc;

namespace Spotify.Controllers
{
    public class TrackController : Controller
    {
        private ITrackService _trackService = new TrackService(new TrackRepository(SpotifyAPIClient.Instance));

        // GET: /Track/Catalog
        public async Task<IActionResult> Catalog(string keywords, DateTime from, DateTime to, string trackName = null,
                                                 string albumName = null, string artistName = null, string genre = null,
                                                 int? limit = null, int? offset = null)
        {
            return View(await _trackService.GetTracksAsync(keywords, from, to, trackName, albumName, artistName, genre, limit, offset));
        }

        // GET: /Track/Search
        public IActionResult Search()
        {
            return View(new SearchTrackViewModel());
        }

        // POST: /Track/Search
        [HttpPost]
        public IActionResult Search([Bind] SearchTrackViewModel searchTracksViewModel)
        {
            return RedirectToAction("Catalog", new
            {
                keywords = searchTracksViewModel.Keyword,
                from = searchTracksViewModel.DateFrom,
                to = searchTracksViewModel.DateTo,
                trackName = searchTracksViewModel.TrackName,
                albumName = searchTracksViewModel.AlbumName,
                artistName = searchTracksViewModel.ArtistName,
                genre = searchTracksViewModel.Genre
            });
        }
    }
}
