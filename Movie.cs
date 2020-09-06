using System;

namespace SpecificationPattern
{
    public partial class Movie
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public MpaaRating MpaaRating { get; set; }
        public string Genre { get; set; }
        public double Rating { get; set; }
    }    

    public enum MpaaRating
    {
        G = 1,
        PG = 2,
        PG13 = 3,
        R = 4,
    }
}
