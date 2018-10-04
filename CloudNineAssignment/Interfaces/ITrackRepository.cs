using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CloudNineAssignment.Models;

namespace CloudNineAssignment.Interfaces
{
    public interface ITrackRepository
    {
        Task<IEnumerable<Track>> GetTracksAsync(string keywords, DateTime from, DateTime to, string trackName = null,
                                                string albumName = null, string artistName = null, string genre = null,
                                                int? limit = null, int? offset = null);
    }
}
