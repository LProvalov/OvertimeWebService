using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Role
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
