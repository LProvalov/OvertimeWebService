using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Repositories.Entities
{
    public class SharedListComments
    {
        public long Id { get; set; }
        public SharedList SharedList { get; set; }
        public string Text { get; set; }
        public UserOfService Owner { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
