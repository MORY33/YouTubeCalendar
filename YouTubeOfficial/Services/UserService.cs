using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeOfficial.Models;

namespace YouTubeOfficial.Services
{
    public class UserService
    {
        private UserMoviesContext _context;

        public UserService(UserMoviesContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
        public void AddNewUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public List<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }
        public List<Movie> GetAllMoviesForUser(int userId)
        {
            return _context.Movies.Where(m => m.UserId == userId).ToList();
        }

        public void AddNewMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }
        public void RemoveMovie(int movieId)
        {
            using (var context = new UserMoviesContext())
            {
                var movieToRemove = context.Movies.FirstOrDefault(m => m.ID == movieId);
                if (movieToRemove != null)
                {
                    context.Movies.Remove(movieToRemove);
                    context.SaveChanges();
                }
            }
        }
    }
}