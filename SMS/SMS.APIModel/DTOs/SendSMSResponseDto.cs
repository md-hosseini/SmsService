﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.APIModel.DTOs
{
    public class SendSMSResponseDto
    {
        public string Response { get; set; }
        public int Status { get; set; }
        public bool IsSucceeded { get; set; }
    }
}
