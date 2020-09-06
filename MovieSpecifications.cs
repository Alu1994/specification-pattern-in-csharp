using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SpecificationPattern
{
    public partial class Movie
    {
        public sealed class MovieForKidsSpecification : Specification<Movie>
        {
            public override Expression<Func<Movie, bool>> ToExpression()
            {
                return movie => movie.MpaaRating <= MpaaRating.PG;
            }
        }

        public sealed class AvailableOnCDSpecification : Specification<Movie>
        {
            private const int MonthsBeforeDVDIsOut = 6;

            public override Expression<Func<Movie, bool>> ToExpression()
            {
                return movie => movie.ReleaseDate <= DateTime.UtcNow.AddMonths(-MonthsBeforeDVDIsOut);
            }
        }
    }
}
