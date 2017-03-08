using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Repositories.Entities
{
    public class SharedListData
    {
        public long Id { get; set; }
        public string Field { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("SharedList")]
        public long SharedListId { get; set; }        
        public virtual SharedList SharedList { get; set; }

        public void Update(SharedListData newValue)
        {
            this.Field = newValue.Field;
            this.Priority = newValue.Priority;
            this.IsActive = newValue.IsActive;
            if (newValue.SharedList != null) this.SharedList = newValue.SharedList;
        }
    }
}
