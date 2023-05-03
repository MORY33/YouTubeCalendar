using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace YouTubeOfficial.Models
{
    public class User 
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}