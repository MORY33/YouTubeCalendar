using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
//using YouTubeOfficial.Models;
//using YouTubeOfficial.Migrations;

namespace YouTubeOfficial.Models
{
    public class UserMoviesContext : DbContext
    {
        public UserMoviesContext() : base("UserMovies")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }

    }

}
