using System;
using System.Collections.Generic;

namespace Spotify.Models
{
    public class Album
    {
        public virtual string Name { get; set; }
        public virtual string Type { get; set; }
        public virtual DateTime ReleaseDate { get; set; }
        public virtual int NumberOfTracks { get; set; }
        public virtual IList<string> Artists { get; set; }
    }
}
