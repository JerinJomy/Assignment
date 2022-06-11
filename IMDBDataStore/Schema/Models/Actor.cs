using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDBDataStore.Schema.Models
{
    public class Actor

    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string Name { get; set; }

        public string Bio { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
