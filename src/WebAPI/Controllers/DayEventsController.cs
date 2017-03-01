using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using WebAPI.Models;

using WebAPI.Repositories;

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
        public IEnumerable<DayEvent> GetAll()
        {
            return DayEventsRepository.GetAll();
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
