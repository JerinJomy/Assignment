using System;

namespace Imdb.Core.Models
{
    public class ProducerInfo
    {
        public string ProducerName { get; set; }
        public string Bio { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Company { get; set; }
        public GenderTypes Gender { get; set; }

    }
}
