using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Repositories.Entities
{
    [Table("User")]
    public class UserOfService
    {
        public UserOfService()
        {
            SharedLists = new List<SharedList>();
            Comments = new List<SharedListComment>();
        }

        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string SharedListIdsViewed { get; set; }
        [Required]
        public string CryptedPassword { get; set; }

        [ForeignKey("Role")]
        public long RoleId { get; set; }        
        public virtual Role Role { get; set; }
        
        public virtual ICollection<SharedList> SharedLists { get; set; }
                
        public virtual ICollection<SharedListComment> Comments { get; set; }

        public void Update(UserOfService user)
        {
            Username = user.Username;
            Email = user.Email;
            CryptedPassword = user.CryptedPassword;
            Role = user.Role;
            SharedLists = user.SharedLists;
            //Comments = user.Comments;
        }
    }
}
