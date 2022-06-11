using System;

namespace Imdb.Core.Models
{
    public class ActorInfo
    {
        public string ActorName { get; set; }
        public string Bio { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderTypes Gender { get; set; }
    }
}
