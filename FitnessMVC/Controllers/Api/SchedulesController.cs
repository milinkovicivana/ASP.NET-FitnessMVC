using FitnessMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FitnessMVC.Controllers.Api
{
    public class SchedulesController : ApiController
    {
        private ApplicationDbContext _context;

        public SchedulesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _context.Schedules.ToList());
        }

        [HttpPost]
        public HttpResponseMessage Create([FromBody] Schedule schedule)
        {
            
            try
            {
                _context.Schedules.Add(schedule);
                _context.SaveChanges();

                var message = Request.CreateResponse(HttpStatusCode.Created, schedule);
                message.Headers.Location = new Uri(Request.RequestUri + schedule.Id.ToString());
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
          
        }

        [HttpPut]
        public HttpResponseMessage Update(int id, [FromBody] Schedule schedule)
        {
            try
            {
                var scheduleInDb = _context.Schedules.SingleOrDefault(s => s.Id == id);

                if (scheduleInDb == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Schedule with id " + id.ToString() + " not found.");
                }

                scheduleInDb.Day = schedule.Day;
                scheduleInDb.Time = schedule.Time;
                scheduleInDb.InstructorId = schedule.InstructorId;
                scheduleInDb.ProgramId = schedule.ProgramId;

                _context.SaveChanges();

                var message = Request.CreateResponse(HttpStatusCode.OK, scheduleInDb);
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
          
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var schedule = _context.Schedules.SingleOrDefault(s => s.Id == id);

                if (schedule == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Schedule with id " + id.ToString() + " not found.");
                }

                _context.Schedules.Remove(schedule);
                _context.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            
        }
    }
}
