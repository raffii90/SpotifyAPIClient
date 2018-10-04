using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CloudNineAssignment.Models;

namespace CloudNineAssignment.Interfaces
{
    public interface IAlbumRepository
    {
        Task<IEnumerable<Album>> GetAlbumsAsync(string keywords, DateTime from, DateTime to, string albumName = null, 
                                                string artist = null, int? limit = null, int? offset = null);
    }
}
