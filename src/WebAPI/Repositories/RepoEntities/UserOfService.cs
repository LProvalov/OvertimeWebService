using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Repositories.Entities
{
    public class UserOfService : User
    {
        public UserOfService() : base() { }
        
        public ICollection<SharedList> SharedLists { get; set; }
        public ICollection<SharedListComments> Comments { get; set; }
    }
}
