using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Repositories.Entities
{
    public class SharedList
    {
        public long Id { get; set; }
        public UserOfService UserOfService { get; set; }
        public string Title { get; set; }
        public ICollection<UserOfService> Viewers { get; set; }
        public ICollection<SharedListData> Datas { get; set; }
        public ICollection<SharedListComments> Comments { get; set; }
    }
}
