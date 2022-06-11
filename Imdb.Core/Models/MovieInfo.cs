using System;
using System.Collections.Generic;

namespace Imdb.Core.Models
{
    public class MovieInfo
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<ActorContent> Actors { get; set; }
        public string Plot { get; set; }
        public ProducerContent Producer { get; set; }
    }

    public class ProducerContent
    {
        public int producerId { get; set; }
        public string producerName { get; set; }
    }

    public class ActorContent
    {
        public int actorId { get; set; }
        public string actorName{ get; set; }
    }
}
