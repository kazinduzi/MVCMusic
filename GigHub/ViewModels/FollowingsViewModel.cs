using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub.ViewModels
{
    public class FollowingsViewModel
    {
        public IEnumerable<ApplicationUser> Followers { get; set; }
        public IEnumerable<ApplicationUser> Followees { get; set; }
    }
}