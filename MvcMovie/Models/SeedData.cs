using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "The Work and the Glory",
                        ReleaseDate = DateTime.Parse("2004-3-11"),
                        Genre = "Historical Fiction",
                        Price = 10.99M,
                        Rating = "G"
                    },

                    new Movie
                    {
                        Title = "Once I Was a Beehive ",
                        ReleaseDate = DateTime.Parse("2015-8-14"),
                        Genre = "Family Comedy",
                        Price = 14.99M,
                        Rating = "PG"
                    },

                    new Movie
                    {
                        Title = "The Single Ward",
                        ReleaseDate = DateTime.Parse("2002-02-01"),
                        Genre = "Religious Comedy",
                        Price = 5.99M,
                        Rating = "PG"
                    },

                    new Movie
                    {
                        Title = "The Saratov Approach",
                        ReleaseDate = DateTime.Parse("2013-10-01"),
                        Genre = "Drama Action",
                        Price = 7.99M,
                        Rating = "PG13"

                    }
                );
                context.SaveChanges();
            }
        }
    }
}