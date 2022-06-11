using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Imdb.Core.Models;
using IMDBDataStore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IMDBWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IMDBDataController : ControllerBase
    {
        private readonly IDataRepo dataRepo;

        public IMDBDataController(IDataRepo dataRepo)
        {
            this.dataRepo = dataRepo;
        }

        [HttpGet]
        [Route("test")]
        public IActionResult TestAction()
        {
            var actor = new MovieInfo()
            {
                MovieName = "Movie1",
                Plot = "new Movie",
                Producer = new ProducerContent() { producerId = 1, producerName = "jerin" },
                Actors = new List<ActorContent>() { new ActorContent() { actorId = 1, actorName = "jerin" }, new ActorContent() { actorId = 2, actorName = "jerin1" } },
                ReleaseDate = DateTime.Now
            };
            return Ok(actor);
        }

        [HttpPost]
        [Route("actor")]
        public async Task<IActionResult> CreateActor(ActorInfo actorInfo)
        {
            var actorId = await dataRepo.AddActor(actorInfo);
            return Ok(actorId);
        }

        [HttpPost]
        [Route("producer")]
        public async Task<IActionResult> CreateProducer(ProducerInfo producerInfo)
        {
            var producerId = await dataRepo.AddProducer(producerInfo);
            return Ok(producerId);
        }

        [HttpPost]
        [Route("movie")]
        public async Task<IActionResult> CreateMovie(MovieInfo movieInfo)
        {
            var movieId = await dataRepo.AddMovie(movieInfo);
            return Ok(movieId);
        }

        [HttpGet]
        [Route("movie")]
        public IActionResult GetMovies(MovieInfo movieInfo)
        {
            var movieList = dataRepo.GetMovies();
            return Ok(movieList);
        }
    }
}
