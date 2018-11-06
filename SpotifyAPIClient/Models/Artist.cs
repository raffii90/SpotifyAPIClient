using System.Collections.Generic;

namespace Spotify.Models
{
    public class Artist
    {
        public virtual string Name { get; set; }
        public virtual IList<string> Genres { get; set; }
        public virtual int Popularity { get; set; }
    }
}
