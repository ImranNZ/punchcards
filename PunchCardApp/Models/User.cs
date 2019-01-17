using System.Collections.Generic;

namespace PunchCardApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<PunchCard> PunchCards { get; set; }
    }
}