
using System.Net.Http.Json;

namespace MyEcommerce.Application.API.CommerceLayer.Authentications
{
    public class Authentication : IAuthentication
    {
        private readonly HttpClient client;

        public Authentication(HttpClient client)
        {
            this.client = client;
        }


        public async Task<Models.Password.Res.PasswordResponse> GetAuthenticationByPassword(Models.Password.Req.PasswordRequest req, CancellationToken cancellation = default)
        {
            var res = await client.PostAsJsonAsync("oauth/token", req, cancellation);

            if (res.IsSuccessStatusCode)
            {
                return await res.Content.ReadFromJsonAsync<Models.Password.Res.PasswordResponse>() ?? throw new NullReferenceException();
            }

            throw new HttpRequestException();
        }
    }
}
