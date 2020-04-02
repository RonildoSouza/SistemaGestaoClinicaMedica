using Microsoft.AspNetCore.Components.Authorization;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Providers
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly AuthenticationState _anonymousAuthenticationState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        private readonly ApplicationState _applicationState;

        public CustomAuthenticationStateProvider(ApplicationState applicationState)
        {
            _applicationState = applicationState;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (string.IsNullOrWhiteSpace(_applicationState.Token))
                return Task.FromResult(_anonymousAuthenticationState);

            var jwtToken = new JwtSecurityToken(_applicationState.Token);

            if (jwtToken.ValidTo < DateTime.Now)
                return Task.FromResult(_anonymousAuthenticationState);

            var claims = jwtToken.Claims.ToList();
            CorrigeClaimType(ref claims);

            var authStateTask = Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"))));

            NotifyAuthenticationStateChanged(authStateTask);
            return authStateTask;
        }

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
