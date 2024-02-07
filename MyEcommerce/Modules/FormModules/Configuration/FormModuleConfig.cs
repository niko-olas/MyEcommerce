using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MyEcommerce.Services;

namespace FatchDataModule.Configuration
{
    public static class FormModuleConfig
    {
        public static void RegisterFormModule(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<ItemService>();
        }
    }
}
