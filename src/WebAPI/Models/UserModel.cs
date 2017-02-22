using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string CryptedPassword { get; set; }

        public Role Role { get; set; }

        public ICollection<DayEvent> DayEvents { get; set; }

        public void Update(User user)
        {
            Username = user.Username;
            Email = user.Email;
            CryptedPassword = user.CryptedPassword;
            Role = user.Role;
        }
    }
}
