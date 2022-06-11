using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDBDataStore.Schema.Models
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(32)")]
        public string MovieName { get; set; }
        public string Plot { get; set; }

        public DateTime DateTime { get; set; }

        public Producer Producer { get; set; }
    }
}
