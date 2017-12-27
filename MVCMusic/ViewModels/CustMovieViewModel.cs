using MVCMusic.Models;
using System.Collections.Generic;

namespace MVCMusic.ViewModels
{
    public class CustMovieViewModel
    {
        public List<MovieModel> Movies { get; set; }
        public List<CustomerModel> Customers { get; set; }
    }
}