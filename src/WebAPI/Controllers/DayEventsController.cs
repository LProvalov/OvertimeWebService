using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace WebAPI.Controllers
{
    [EnableCors("AllowCors")]
    [Route("api/[controller]")]
    public class DayEventsController : Controller
    {
        public DayEventsController(IRepository repository)
        {
            DayEventsRepository = repository;
        }

        public IRepository DayEventsRepository { get; set; }

        [HttpGet]
        public IEnumerable<DayEventModel> GetAll()
        {
            return DayEventsRepository.GetDayEventsByUser(0);
        }

        [HttpGet("{id}", Name = "GetDayEvent")]
        public IActionResult Get(long id)
        {
            var item = DayEventsRepository.GetDayEvent(id);
            if(item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
    }
}
