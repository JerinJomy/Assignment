using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDBDataStore.Schema.Models
{
    public class Producer
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(32)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string CompanyName { get; set; }

        public string Bio { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }
    }
}
