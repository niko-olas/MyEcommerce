using Ecomotive.Domain.Primitives;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.Options;
using MyEcommerce.Application.API.CommerceLayer.Authentications;
using MyEcommerce.Application.API.CommerceLayer.Settings;
using Models = MyEcommerce.Shared.Models;

namespace MyEcommerce.Application.Core.Identity
{
    public class IdentityServices : IIdentityServices
    {
        private readonly IAuthentication authentication;
        private readonly CommerceLayerSettings settings;

        public IdentityServices(IAuthentication authentication, IOptions<CommerceLayerSettings> options)
        {
            this.authentication = authentication;
            this.settings = options.Value;
        }

        public async Task<Result<Models.Res.Identity.LoginResponse>> Login(Models.Req.Identity.LoginRequest request, CancellationToken cancellationToken = default)
        {
            var response = await authentication.GetAuthenticationByPassword(new API.CommerceLayer.Authentications.Models.Password.Req.PasswordRequest()
            {
                client_id = settings.ClientId,
                password = request.Password,
                username = request.Usename,

            });

            if(response is null)
            {
                return Result.Fail<Models.Res.Identity.LoginResponse>(Error.None);
            }

            return new Models.Res.Identity.LoginResponse() { Token = response.access_token };
        }
    }
}
