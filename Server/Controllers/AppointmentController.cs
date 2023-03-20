using Microsoft.AspNetCore.Mvc;
using BlazorSchedulerCrud.Server.Models;
using BlazorSchedulerCrud.Shared;
using Microsoft.AspNet.OData;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorSchedulerCrud.Server.Controllers
{
    public class AppointmentController : ODataController
    {
        private ScheduleDataContext _db;
        public AppointmentController(ScheduleDataContext context)
        {
            _db = context;
            if (context.EventsData.Count() == 0)
            {
                foreach (var b in DataSource.GetEvents())
                {
                    context.EventsData.Add(b);
                }
                context.SaveChanges();
            }

        }
        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_db.EventsData);
        }

        public async Task Post([FromBody] Appointment events)
        {
            _db.EventsData.Add(events);
            await _db.SaveChangesAsync();
        }

        public async Task Put([FromODataUri] int key, [FromBody] Appointment events)
        {
            var entity = await _db.EventsData.FindAsync(key);
            _db.Entry(entity).CurrentValues.SetValues(events);
            await _db.SaveChangesAsync();
        }

        public async Task Patch([FromODataUri] int key, [FromBody] Appointment events)
        {
            var entity = await _db.EventsData.FindAsync(key);
            _db.Entry(entity).CurrentValues.SetValues(events);
            await _db.SaveChangesAsync();
        }

        public async Task Delete([FromODataUri] int key)
        {
            var od = _db.EventsData.Find(key);
            _db.EventsData.Remove(od);
            await _db.SaveChangesAsync();
        }
    }
}
