using FatchDataModule.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace FatchDataModule.Configuration
{
    public static class FatchDataModuleConfig
    {
        public static void RegisterFatchDataModule(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<WeatherForecastService>();
        }
    }
}
