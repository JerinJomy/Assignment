using System.Threading.Tasks;
using Imdb.Core.Models;

namespace Imdb.Core.ImdbDataService
{
    public interface IDataService
    {
        public  Task<int> CreateActor(ActorInfo actorInfo);
    }
}
