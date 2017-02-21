using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class DayEvent
    {
        public long Id { get; set; }
        public User Owner { get; set; }
        public int Overtime { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }

        public void Update(DayEvent dayEvent)
        {
            this.Owner = dayEvent.Owner;
            this.Overtime = dayEvent.Overtime;
            this.Comment = dayEvent.Comment;
            this.Date = dayEvent.Date;
        }
    }
}
