﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEcommerce.Application.API.CommerceLayer.Authentications.Models.Password.Res
{
    public class PasswordResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
        public string scope { get; set; }
        public int created_at { get; set; }
        public string owner_id { get; set; }
        public string owner_type { get; set; }
    }
}