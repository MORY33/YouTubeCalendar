using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace YouTubeOfficial.Models
{
    public class UserMoviesContext : DbContext
    {
        public UserMoviesContext() : base("UserMovies")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Video> Videos { get; set; }

    }

}
