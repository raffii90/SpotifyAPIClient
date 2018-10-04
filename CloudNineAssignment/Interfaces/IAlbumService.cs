using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CloudNineAssignment.Models.ViewModels;

namespace CloudNineAssignment.Interfaces
{
    public interface IAlbumService
    {
        Task<IEnumerable<AlbumViewModel>> GetAlbumsAsync(string keywords, DateTime from, DateTime to, string albumName = null,
                                                         string artist = null, int? limit = null, int? offset = null);
    }
}
