﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEcommerce.Shared.Models.Req.Identity
{
    public class LoginRequest
    {
        public string Usename { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
