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
    }
}