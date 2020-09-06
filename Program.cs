using System;

namespace SpecificationPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var movie = new Movie
            {
                Name = "Split",
                ReleaseDate = DateTime.UtcNow.AddYears(-1),
                MpaaRating = MpaaRating.G,
                Genre = "Horror",
                Rating = 9.1
            };
            
            var isForKids = new Movie.MovieForKidsSpecification().Or(new Movie.AvailableOnCDSpecification().Not()).IsSatisfiedBy(movie);
            var isAvailableOnCD = new Movie.AvailableOnCDSpecification().IsSatisfiedBy(movie);

            if (!isForKids)
            {
                Console.WriteLine("Noops for children!");
                if(isAvailableOnCD)
                    Console.WriteLine("Available on DVD!");
            }
            else
            {
                Console.WriteLine("Oooh yeah kids!");
                if (isAvailableOnCD)
                    Console.WriteLine("Available on DVD!");
            }

            Console.ReadLine();
        }
    }
}
