using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDBDataStore.Schema.Models
{
    public class Actor

    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar(32)")]
        [Required]
        public string Name { get; set; }

        public string Bio { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }
    }
}
