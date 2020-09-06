# Specification Pattern

## Purpose of the Specification Pattern

	- Encapsulates domain knowledge into a single unit
	- Reuse in various scenarios

## Use cases

	- In-memory validation
	- Retrieving data from the database
	- Creation of new objects

### Example
```
===== Implementation =====

public abstract class Specification<T>
{
    public abstract Expression<Func<T, bool>> ToExpression();

    public bool IsSatisfiedBy(T entity)
    {
        var predicate = ToExpression().Compile();
        return predicate(entity);
    }
}

public partial class Movie
{    
    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    public MpaaRating MpaaRating { get; set; }
    public string Genre { get; set; }
    public double Rating { get; set; }
}

public sealed class MovieForKidsSpecification : Specification<Movie>
{
    private readonly Movie _movie;

    public override Expression<Func<Movie, bool>> ToExpression()
    {
        return movie => movie.MpaaRating <= MpaaRating.PG;
    }
}

======== Using it ========

class Program
{
    static void Main(string[] args)
    {
        var movie = new Movie
        {
            Name = "Split",
            ReleaseDate = DateTime.UtcNow,
            MpaaRating = MpaaRating.G,
            Genre = "Horror",
            Rating = 9.1
        };

        var isSuitableForChildren = new MovieForKidsSpecification().IsSatisfiedBy(movie);
        if (!isSuitableForChildren)
        {
            Console.WriteLine("Noops for children!");
            return;
        }
        Console.WriteLine("Oooh yeah kids!");
    }
}

```

## General Guides

    - Avoid ISpecification interface
    - Make Specifications as specific as possible and strongly typed
    - Make Specifications immutable

## When NOT to use
    - If you DON'T need to Search Queries and Validate In-Memory objects 
        with the same logic (therefore you won't have code duplication), is NOT recommended to use Specification Pattern.
    - If the system is too simple, there is no need to implement such complex code as well.

### Evans and Fowler's Quote
<img src="https://github.com/matsennin/specification-pattern-in-csharp/blob/master/images/EricEvans%26MartinFowlerQuote.png" />
