using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using EFDemo.Infra.Entities;

// NAMESPACE DOĞRU OLMALI
namespace EFDemo.Infra.DataGenerator
{
    // internal yerine public yapın (erişilebilir olması için)
    public static class DataGenerator
    {
        private static List<ActorEntity> _cachedActors;

        public static List<ActorEntity> GenerateActors(int count)
        {
            if (_cachedActors != null && _cachedActors.Count == count)
                return _cachedActors;

            var actorFaker = new Faker<ActorEntity>("tr")
                .RuleFor(g => g.Id, f => Guid.NewGuid())
                .RuleFor(g => g.CreatedDate, f => f.Date.Past(5))
                .RuleFor(g => g.FirstName, f => f.Name.FirstName())
                .RuleFor(g => g.LastName, f => f.Name.LastName())
                .RuleFor(g => g.Movies, f => new List<MovieEntity>());

            _cachedActors = actorFaker.Generate(count);
            return _cachedActors;
        }

        public static List<MovieEntity> GenerateMovies(int count, List<ActorEntity> actors = null)
        {
            var locale = "tr";

            var genreFaker = new Faker<GenreEntity>(locale)
                .RuleFor(g => g.Id, f => Guid.NewGuid())
                .RuleFor(g => g.CreatedDate, f => f.Date.Past(5))
                .RuleFor(g => g.ModifiedDate, f => f.Date.Past(2))
                .RuleFor(g => g.Name, f => f.Commerce.Categories(1).First());

            var directorFaker = new Faker<DirectorEntity>(locale)
                .RuleFor(g => g.Id, f => Guid.NewGuid())
                .RuleFor(g => g.CreatedDate, f => f.Date.Past(5))
                .RuleFor(g => g.FirstName, f => f.Name.FirstName())
                .RuleFor(g => g.LastName, f => f.Name.LastName())
                .RuleFor(g => g.FullName, f => f.Name.FullName());

            var genresList = genreFaker.Generate(5);
            var directorsList = directorFaker.Generate(5);

            var actorsList = actors ?? GenerateActors(20);

            var movieFaker = new Faker<MovieEntity>(locale)
                .RuleFor(g => g.Id, f => Guid.NewGuid())
                .RuleFor(g => g.CreatedDate, f => f.Date.Past(5))
                .RuleFor(g => g.ModifiedDate, f => f.Date.Past(2))
                .RuleFor(g => g.Name, f => f.Lorem.Sentence(3))
                .RuleFor(g => g.Director, f => f.PickRandom(directorsList))
                .RuleFor(g => g.Genre, f => f.PickRandom(genresList))
                .RuleFor(g => g.Actors, f => new List<ActorEntity>());

            var movies = movieFaker.Generate(count);

            var faker = new Faker();
            foreach (var movie in movies)
            {
                var selectedActors = faker.PickRandom(actorsList, faker.Random.Number(1, 5)).ToList();
                foreach (var actor in selectedActors)
                {
                    movie.Actors.Add(actor);
                }
            }

            return movies;
        }
    }
}