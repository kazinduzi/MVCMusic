using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCMusic.Models
{
    public class MovieModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public DateTime ReleasedDate { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [ForeignKey("Customer")]
        public int MovieCustomerId { get; set; }

        public CustomerModel Customer { get; set; }
    }
}