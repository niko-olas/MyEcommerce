using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEcommerce.Application.API.CommerceLayer.Authentications.Models.Password.Req
{
    public class PasswordRequest
    {
        public string grant_type { get; set; } = "password";
        public string username { get; set; }
        public string password { get; set; }
        public string client_id { get; set; }
      
    }
}
