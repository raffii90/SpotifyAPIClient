using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CloudNineAssignment.Interfaces;
using CloudNineAssignment.Models;
using CloudNineAssignment.Models.ViewModels;
using System.Linq;

namespace CloudNineAssignment.Services
{
	public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public async Task<IEnumerable<ArtistViewModel>> GetArtistsAsync(string name, DateTime from, DateTime to, string genre = null, 
                                                                  int? limit = null, int? offset = null)
        {
            var artist = await _artistRepository.GetArtistsAsync(name, from, to, genre, limit, offset);
            List<ArtistViewModel> artistViewModels = new List<ArtistViewModel>();
            foreach (var item in artist)
            {
                artistViewModels.Add(CreateArtistViewModel(item));
            }

            return artistViewModels;
        }

        private ArtistViewModel CreateArtistViewModel(Artist artist)
        {
            ArtistViewModel artistViewModel = new ArtistViewModel()
            {
                Name = artist.Name,
                Genres = string.Join(", ", artist.Genres.ToArray()),
                Popularity = artist.Popularity
            };

            return artistViewModel;
        }
    }
}
