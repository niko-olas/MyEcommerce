using MyEcommerce.Application.API.CommerceLayer.Authentications.Models.Password.Req;
using MyEcommerce.Application.API.CommerceLayer.Authentications.Models.Password.Res;

namespace MyEcommerce.Application.API.CommerceLayer.Authentications
{
    public interface IAuthentication
    {
        Task<PasswordResponse> GetAuthenticationByPassword(PasswordRequest req, CancellationToken cancellation = default);
    }
}