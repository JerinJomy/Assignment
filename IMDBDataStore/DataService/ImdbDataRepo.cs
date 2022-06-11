using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Imdb.Core.Exceptions;
using Imdb.Core.Models;
using IMDBDataStore.Interfaces;
using IMDBDataStore.Schema.Context;
using IMDBDataStore.Schema.Models;

namespace IMDBDataStore.DataService
{
    public class ImdbDataRepo : IDataRepo
    {
        private readonly IMDBContext dbContext;

        public ImdbDataRepo(IMDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> AddActor(ActorInfo actorInfo)
        {
            try
            {
                var gender = dbContext.Gender.Where(g => g.Id == (int)actorInfo.Gender);

                var actor = new Actor()
                {
                    Name = actorInfo.ActorName,
                    Bio = actorInfo.Bio,
                    DateOfBirth = actorInfo.DateOfBirth,
                    Gender = gender.FirstOrDefault(),
                };

                await dbContext.Actors.AddAsync(actor);
                await dbContext.SaveChangesAsync();
                return actor.Id;
            }
            catch (Exception ex)
            {
                throw new DataOperationException(ex.Message);
            }
        }

        public async Task<int> AddMovie(MovieInfo movieInfo)
        {
            using var transaction = dbContext.Database.BeginTransaction();
            try
            {
                var producer = dbContext.Producers.FirstOrDefault(pr => pr.Id == movieInfo.Producer.producerId);
                var movie = new Movie()
                {
                    MovieName = movieInfo.MovieName,
                    Plot = movieInfo.Plot,
                    DateTime = movieInfo.ReleaseDate,
                    Producer = producer,
                };

                await dbContext.Movies.AddAsync(movie);
                await dbContext.SaveChangesAsync();
                await AddRoles(movieInfo, movie);
                transaction.Commit();
                return movie.Id;
            }
            catch (Exception ex)
            {

                throw new DataOperationException(ex.Message);
            }
        }

        public async Task<int> AddProducer(ProducerInfo producerInfo)
        {
            using var transaction = dbContext.Database.BeginTransaction();
            try
            {
                var gender = dbContext.Gender.Where(g => g.Id == (int)producerInfo.Gender);
                var producer = new Producer()
                {
                    Name = producerInfo.ProducerName,
                    Bio = producerInfo.Bio,
                    CompanyName = producerInfo.Company,
                    DateOfBirth = producerInfo.DateOfBirth,
                    Gender = gender.FirstOrDefault()
                };

                await dbContext.Producers.AddAsync(producer);
                await dbContext.SaveChangesAsync();
                transaction.Commit();

                return producer.Id;
            }
            catch (Exception ex)
            {
                throw new DataOperationException(ex.Message);
            }
        }

        public List<MovieInfo> GetMovies()
        {
            try
            {
                var movies = dbContext.Movies.Join(dbContext.Producers,
               o => o.Producer.Id, i => i.Id,
               (o, i) => new MovieInfo()
               {
                   MovieId = o.Id,
                   MovieName = o.MovieName,
                   Plot = o.Plot,
                   ReleaseDate = o.DateTime,
                   Producer = new ProducerContent() { producerId = i.Id, producerName = i.Name }
               }).ToList<MovieInfo>();

                AddActor(movies);

                return movies;
            }
            catch (Exception ex)
            {

                throw new DataOperationException(ex.Message);
            }

        }

        private void AddActor(List<MovieInfo> movieInfos)
        {
            foreach (var movie in movieInfos)
            {
                var actors = dbContext.Actors.Join(dbContext.RolesInfo.Where(r => r.Movies.Id == movie.MovieId),
                 o => o.Id, i => i.Actors.Id,
                 (o, i) => new ActorContent() { actorId = o.Id, actorName = o.Name }).
                ToList<ActorContent>();

                movie.Actors = actors;
            }

        }

        private async Task AddRoles(MovieInfo movieInfo, Movie movie)
        {
            foreach (var actor in movieInfo.Actors)
            {
                var movieActor = dbContext.Actors.FirstOrDefault(ac => ac.Id == actor.actorId);
                var roles = new RolesInfo() { Actors = movieActor, Movies = movie };
                await dbContext.RolesInfo.AddAsync(roles);
                await dbContext.SaveChangesAsync();
            }
        }

    }
}
