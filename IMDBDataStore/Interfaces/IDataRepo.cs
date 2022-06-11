using System.Collections.Generic;
using System.Threading.Tasks;
using Imdb.Core.Models;

namespace IMDBDataStore.Interfaces
{
    public interface IDataRepo
    {
        public Task<int> AddActor(ActorInfo actorInfo);
        public Task<int> AddProducer(ProducerInfo producerInfo);
        public Task<int> AddMovie(MovieInfo movieInfo);
        public List<MovieInfo> GetMovies();

    }
}
