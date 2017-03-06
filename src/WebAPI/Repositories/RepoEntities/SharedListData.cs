using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Repositories.Entities
{
    public class SharedListData
    {
        public long Id { get; set; }
        public SharedList sharedList { get; set; }
        public string Field { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }
    }
}
