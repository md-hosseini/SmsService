﻿using SMS.APIModel.RequestModels;
using SMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Service.Interface
{
    public interface ILogService
    {
        Task AddAsync(Log log);
    }
}
