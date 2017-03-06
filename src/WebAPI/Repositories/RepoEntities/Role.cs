using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Repositories.Entities
{
    public class Role
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<UserOfService> Users { get; set; }
    }
}
