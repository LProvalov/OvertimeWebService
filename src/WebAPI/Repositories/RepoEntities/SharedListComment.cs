using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Repositories.Entities
{
    public class SharedListComment
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }

        [ForeignKey("Owner")]
        public long OwnerId { get; set; }
        public virtual UserOfService Owner { get; set; }

        [ForeignKey("SharedList")]
        public long SharedListId { get; set; }
        public virtual SharedList SharedList { get; set; }

        public void Update(SharedListComment newValue)
        {
            this.Text = newValue.Text;
        }
    }
}
