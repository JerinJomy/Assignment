using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDBDataStore.Schema.Models
{
    public class RolesInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RolesId { get; set; }

        public Movie Movies { get; set; }

        public Actor Actors { get; set; }
    }
}
