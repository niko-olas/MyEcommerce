using Ecomotive.Domain.Primitives;
using MyEcommerce.Shared.Models.Req.Identity;
using MyEcommerce.Shared.Models.Res.Identity;
using Models = MyEcommerce.Shared.Models;

namespace MyEcommerce.Application.Core.Identity
{
    public interface IIdentityServices
    {
        Task<Result<LoginResponse>> Login(LoginRequest request, CancellationToken cancellationToken = default);
    }
}