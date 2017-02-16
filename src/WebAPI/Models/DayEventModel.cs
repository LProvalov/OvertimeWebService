using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class DayEventModel
    {
        public long Id { get; set; }
        public long OwnerId { get; set; }
        public int Overtime { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
