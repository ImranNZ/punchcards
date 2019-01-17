using System;

namespace PunchCardApp.Models
{
    public class PunchCard
    {
        public int Id { get; set; }
        public DateTime PunchIn { get; set; }
        public DateTime PunchOut { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}