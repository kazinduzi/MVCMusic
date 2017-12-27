using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GigHub.Controllers
{
    

    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;
        private string _userId;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
            _userId = User.Identity.GetUserId();

        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var alreadyExists = _context.Attendances.Any(a => a.AttendeeId == _userId && a.GigId == dto.GigId);
            if (alreadyExists)
                return BadRequest("The attendance already exists.");
            
            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = _userId
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
            
        }

        [HttpPost]
        public IHttpActionResult Unattend(AttendanceDto dto)
        {
            var attendance = _context.Attendances.Single(a => a.AttendeeId == _userId && a.GigId == dto.GigId);
            if (attendance != null)
            {                
                _context.Attendances.Remove(attendance);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest("No attendance exists for User: {0}" + User.Identity.Name);
        }
    }
}
