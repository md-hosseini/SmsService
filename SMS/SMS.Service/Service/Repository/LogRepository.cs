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
    public class LogRepository : ILogRepository
    {
        private readonly ApplicationDbContext _context;
        protected readonly DbSet<Log> _dbSet;

        public LogRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Log>();
        }
        public async Task AddAsync(Log entity)
        {
            await _dbSet.AddAsync(entity);
        }
    }
}
