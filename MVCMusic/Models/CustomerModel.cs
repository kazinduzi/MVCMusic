using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace MVCMusic.Models
{
    public class CustomerModel
    {
        public int ID { get; set; }

        [Required]
        public string CustomerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Country { get; set; }

        public virtual ICollection<MovieModel> Movies { get; set; }

    }
    
}