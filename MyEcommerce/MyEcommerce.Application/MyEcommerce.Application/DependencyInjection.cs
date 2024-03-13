using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MyEcommerce.Application.Extensions;
using MyEcommerce.Application.API.CommerceLayer.Authentications;
using MyEcommerce.Application.API.CommerceLayer.Settings;
using System.Reflection;
using Blazored.LocalStorage;
using MyEcommerce.Application.Provider;
using MyEcommerce.Application.Core.Identity;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace MyEcommerce.Application;

public static class DependencyInjection
{
    public static IHostApplicationBuilder AddApplicationServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddMediatR(options => options.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));



        builder.AddAuthenticationServices();

        builder.AddCommerciaLayerHttpClient();

        builder.AddServices();

        return builder;
    }

    public static IHostApplicationBuilder AddServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddScoped<IIdentityServices, IdentityServices>();

        return builder;

    }

    public static IHostApplicationBuilder AddCommerciaLayerHttpClient(this IHostApplicationBuilder builder)
    {
        builder.Services.Configure<CommerceLayerSettings>(builder.Configuration.GetSection(CommerceLayerSettings.SettingKey));

        var configuration = builder.Configuration.GetRequiredValue<CommerceLayerSettings>(CommerceLayerSettings.SettingKey);
        var services = builder.Services;

        builder.Services.AddHttpClient<IAuthentication, Authentication>(
        (serviceProvider, httpclient) =>
        {
            httpclient.BaseAddress = new UriBuilder(configuration.BaseUrl).Uri;
        });




        return builder;
    }


    public static IHostApplicationBuilder AddAuthenticationServices(this IHostApplicationBuilder builder)
    {

        builder.Services.AddBlazoredLocalStorage();

        builder.Services.AddAuthorization();

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

        });

        builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

   
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddCascadingAuthenticationState();

        return builder;
    }



}

