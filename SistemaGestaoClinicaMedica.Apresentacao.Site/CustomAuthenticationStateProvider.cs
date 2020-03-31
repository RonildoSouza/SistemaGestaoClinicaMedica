using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private static string _savedToken;
        private readonly AuthenticationState _anonymousAuthenticationState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (string.IsNullOrWhiteSpace(_savedToken))
                return Task.FromResult(_anonymousAuthenticationState);

            var claims = new JwtSecurityToken(_savedToken).Claims.ToList();

            CorrigeClaimType(ref claims);

            return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"))));
        }

        public void SetaUsuarioComoAutenticado(string email)
        {
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, email) }, "apiauth"));
            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
            NotifyAuthenticationStateChanged(authState);
        }

        public void SetaUsuarioComoNaoAutenticado()
        {
            var authState = Task.FromResult(_anonymousAuthenticationState);
            NotifyAuthenticationStateChanged(authState);
        }

        public static void SetaTokenJwt(string jwt) => _savedToken = jwt;

        private void CorrigeClaimType(ref List<Claim> claims)
        {
            for (int i = 0; i < claims.Count; i++)
            {
                var claim = claims[i];
                if (claim.Type == "role")
                    claims[i] = new Claim(ClaimTypes.Role, claim.Value);
            }
        }
    }
}
