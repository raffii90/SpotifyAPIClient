﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Spotify.Models;

namespace Spotify.Interfaces
{
    public interface IArtistRepository
    {
        Task<IEnumerable<Artist>> GetArtistsAsync(string name, DateTime from, DateTime to, string genre = null,
                                                  int? limit = null, int? offset = null);
    }
}
