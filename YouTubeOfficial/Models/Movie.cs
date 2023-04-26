using System;
using System.Data.Entity;
using System.Linq;

namespace YouTubeOfficial.Models
{
    public class Movie : DbContext
    {
        public int ID { get; set; }
        public DateTime sessionDate { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }

}