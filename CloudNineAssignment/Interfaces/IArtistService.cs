using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CloudNineAssignment.Models.ViewModels;

namespace CloudNineAssignment.Interfaces
{
    public interface IArtistService
    {
        Task<IEnumerable<ArtistViewModel>> GetArtistsAsync(string name, DateTime from, DateTime to, string genre = null,
                                                           int? limit = null, int? offset = null);
    }
}
