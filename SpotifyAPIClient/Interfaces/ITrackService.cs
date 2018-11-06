using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Spotify.Models.ViewModels;

namespace Spotify.Interfaces
{
    public interface ITrackService
    {
        Task<IEnumerable<TrackViewModel>> GetTracksAsync(string keywords, DateTime from, DateTime to, string trackName = null,
                                                         string albumName = null, string artistName = null, string genre = null,
                                                         int? limit = null, int? offset = null);
    }
}
