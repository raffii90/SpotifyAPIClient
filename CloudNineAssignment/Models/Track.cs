using System;
using System.Collections.Generic;

namespace CloudNineAssignment.Models
{
    public class Track
    {
        public virtual string Name { get; set; }
        public virtual string AlbumName { get; set; }
        public virtual IList<string> Artists { get; set; }
        public virtual int Duration { get; set; }
        public virtual int Popularity { get; set; }
    }
}
