﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.APIModel.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
    }
}
