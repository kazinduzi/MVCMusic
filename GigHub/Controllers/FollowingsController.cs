using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    [Authorize]
    public class FollowingsController : Controller
    {
        private ApplicationDbContext _context;
        private string _userId;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
            
        }

        public ActionResult Followers()
        {
            _userId = User.Identity.GetUserId();
            var followers = _context.Followings.Where(f => f.FolloweeId == _userId).Select(u => u.Follower).ToList();
            var followees = _context.Followings.Where(f => f.FollowerId == _userId).Select(u => u.Followee).ToList();

            var followingsViewModel = new FollowingsViewModel()
            {
               Followers = followers,
               Followees = followees
            };

            return View(followingsViewModel);
        }
    }
}