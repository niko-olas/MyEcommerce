using Microsoft.Extensions.Configuration;
using MyEcommerce.Application.API.CommerceLayer.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEcommerce.Application.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string GetRequiredValue(this IConfiguration configuration, string name) =>
            configuration[name] ?? throw new InvalidOperationException($"Configuration missing value for: {(configuration is IConfigurationSection s ? s.Path + ":" + name : name)}");

        public static TValue GetRequiredValue<TValue>(this IConfiguration configuration, string name)
        {
            return configuration
            .GetSection(name)
            .Get<TValue>() ?? throw new InvalidOperationException($"Configuration missing value for: {(configuration is IConfigurationSection s ? s.Path + ":" + name : name)}");

        }




    }
}
