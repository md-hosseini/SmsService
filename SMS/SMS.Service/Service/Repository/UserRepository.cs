using Microsoft.EntityFrameworkCore;
using SMS.Domain;
using SMS.Domain.Entities;
using SMS.Service.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Service.Service.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        protected readonly DbSet<User> _dbSet;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<User>();
        }
        public async Task<User?> GetUser(string username, string password)
        {
            return await _dbSet.SingleOrDefaultAsync(r => r.UserName == username && r.Password == password);
        }
    }
}
