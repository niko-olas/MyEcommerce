using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEcommerce.Application.API.CommerceLayer.Settings
{
    public class CommerceLayerSettings
    {
        public static string SettingKey = "CommerceLayer";
        public string BaseUrl { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
        public int ExpirationTime { get; set; } = 0;

    }
}
