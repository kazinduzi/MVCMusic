using MVCMusic.DAL;
using MVCMusic.Models;
using MVCMusic.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace MVCMusic.Controllers
{
    public class MoviesController : Controller
    {
        private MusicContext _context;

        // Constructor
        public MoviesController()
        {
            _context = new MusicContext();
        }

        // Dispose disposable DbContext
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
            var movieViewModel = new CustMovieViewModel()
            {
                Movies = _context.Movies.ToList(),
                Customers = _context.Customers.ToList()
            };
            
            return View(movieViewModel);
        }

        // GET: Detail/{id}
        public ActionResult Detail(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            return View(movie);
        }

        public ActionResult New()
        {
            var viewModel = new MovieViewModel
            {
                Customers = _context.Customers.ToList()
            };
            return View(viewModel);
        }

        // GET: Edit/{id}
        public ActionResult Edit(int id)
        {
            var movieViewModel = new MovieViewModel
            {
                Customers = _context.Customers.ToList(),
                Movie = _context.Movies.Single(m => m.Id == id)
            };

            return View(movieViewModel);
        }

        [HttpPost]
        public ActionResult SaveMovie(MovieModel Movie)
        {
            if (Movie.Id == 0)
            {
                _context.Movies.Add(Movie);
            } else
            {
                var movieFromDb = _context.Movies.Single(m => m.Id == Movie.Id);
                movieFromDb.Name = Movie.Name;
                movieFromDb.Genre = Movie.Genre;
                movieFromDb.Duration = Movie.Duration;
                movieFromDb.ReleasedDate = Movie.ReleasedDate;
                movieFromDb.MovieCustomerId = Movie.MovieCustomerId;
            }
            
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}