using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CloudNineAssignment.Interfaces;
using CloudNineAssignment.Models;
using CloudNineAssignment.Models.ViewModels;
using System.Linq;

namespace CloudNineAssignment.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

       public async Task<IEnumerable<AlbumViewModel>> GetAlbumsAsync(string keywords, DateTime from, DateTime to, 
                                                                     string albumName = null, string artist = null, 
                                                                     int? limit = null, int? offset = null)
        {
            var albums = await _albumRepository.GetAlbumsAsync(keywords, from, to, albumName, artist, limit, offset);
            List<AlbumViewModel> albumViewModels = new List<AlbumViewModel>();
            foreach (var item in albums)
            {
                albumViewModels.Add(CreateAlbumViewModel(item));
            }

            return albumViewModels;
        }

        private AlbumViewModel CreateAlbumViewModel(Album album) {
            AlbumViewModel albumViewModel = new AlbumViewModel()
            {
                Name = album.Name,
                Type = album.Type,
                ReleaseDate = album.ReleaseDate,
                NumberOfTracks = album.NumberOfTracks,
                Artists = string.Join(", ", album.Artists.ToArray())
            };

            return albumViewModel;
        }
    }
}
