using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class DayEvent
    {
        public long Id { get; set; }
        
        public User User { get; set; }

        public int Overtime { get; set; }
        public string Comment { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public void Update(DayEvent dayEvent)
        {
            this.User = dayEvent.User;
            this.Overtime = dayEvent.Overtime;
            this.Comment = dayEvent.Comment;
            this.Date = dayEvent.Date;
        }
    }
}
