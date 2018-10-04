using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudNineAssignment.Interfaces;
using CloudNineAssignment.Models;
using CloudNineAssignment.Models.ViewModels;

namespace CloudNineAssignment.Services
{
	public class TrackService : ITrackService
    {
        private readonly ITrackRepository _trackRepository;

        public TrackService(ITrackRepository trackRepository)
        {
            _trackRepository = trackRepository;
        }

        public async Task<IEnumerable<TrackViewModel>> GetTracksAsync(string keywords, DateTime from, DateTime to, 
                                                                      string trackName = null, string albumName = null, 
                                                                      string artistName = null, string genre = null, 
                                                                      int? limit = null, int? offset = null)
        {
            var tracks = await _trackRepository.GetTracksAsync(keywords, from, to, trackName, albumName,artistName, genre, limit, offset);
            List<TrackViewModel> trackViewModels = new List<TrackViewModel>();
            foreach (var item in tracks)
            {
                trackViewModels.Add(CreateTrackViewModel(item));
            }

            return trackViewModels;
        }

        private TrackViewModel CreateTrackViewModel(Track track)
        {
            TrackViewModel trackViewModel = new TrackViewModel()
            {
                Name = track.Name,
                AlbumName = track.AlbumName,
                Artists = string.Join(", ", track.Artists.ToArray()),
                //Duration = track.Duration.ToString(),
                Duration = TimeSpan.FromMilliseconds((double)track.Duration).ToString(@"mm\:ss"),
                Popularity = track.Popularity
            };

            return trackViewModel;
        }
    }
}
