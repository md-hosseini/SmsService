using SMS.APIModel.RequestModels;
using SMS.Domain.Entities;
using SMS.Service.Interface;
using SMS.Service.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Service.Service
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;
        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }
        public async Task AddAsync(Log log)
        {
            await _logRepository.AddAsync(log);
        }
    }
}
