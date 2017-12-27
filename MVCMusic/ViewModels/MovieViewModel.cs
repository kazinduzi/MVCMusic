using MVCMusic.Models;
using System.Collections.Generic;

namespace MVCMusic.ViewModels
{
    public class MovieViewModel
    {
        public IEnumerable<CustomerModel> Customers { get; set; }
        public MovieModel Movie { get; set; }
    }
}