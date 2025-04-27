using SMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Service.Interface.Repository
{
    public interface ILogRepository
    {
        Task AddAsync(Log entity);
    }
}
