using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using GigHub.Models;
using GigHub.ViewModels;
using System.Data.Entity;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        private ApplicationDbContext _context;
        
        public GigsController()
        {
            _context = new ApplicationDbContext();           
        }

        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var attendingGigs = _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Gig)
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .ToList();
            var viewModel = new GigsViewModel()
            {
                UpcomingGigs = attendingGigs,
                ShowingAction = User.Identity.IsAuthenticated
            };

            return View("Gigs", viewModel);
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            //var currentUserId = User.Identity.GetUserId();
            //var artist = _context.Users.Single(m => m.Id == currentUserId);
            //var genre = _context.Genres.Single(g => g.Id == viewModel.Genre);
            if (! ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("Create", viewModel);
            }

            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                Venue = viewModel.Venue,
                GenreId = viewModel.Genre
            };

            _context.Gigs.Add(gig);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");

        }
    }
}