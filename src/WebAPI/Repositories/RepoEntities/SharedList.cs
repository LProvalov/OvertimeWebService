using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Repositories.Entities
{
    public class SharedList
    {
        public SharedList()
        {
            this.CollectionOfData = new HashSet<SharedListData>();
            this.Comments = new List<SharedListComment>();
        }
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }

        [ForeignKey("Owner")]
        public long OwnerId { get; set; }        
        public virtual UserOfService Owner { get; set; }
        
        public virtual ICollection<SharedListData> CollectionOfData { get; set; }
        
        public virtual ICollection<SharedListComment> Comments { get; set; }

        public void Update(SharedList newEntity)
        {
            this.Title = newEntity.Title;
            if (newEntity.Owner != null) this.Owner = newEntity.Owner;
            if (newEntity.Comments != null) this.Comments = newEntity.Comments;
            if (newEntity.CollectionOfData != null) this.CollectionOfData = newEntity.CollectionOfData;
        }
    }
}
