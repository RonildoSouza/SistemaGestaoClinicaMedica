using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaGestaoClinicaMedica.Aplicacao.DTO.Login;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Constantes;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly ILoginServico _loginServico;

        public LoginModel(ILoginServico loginServico)
        {
            _loginServico = loginServico;
        }

        public string ReturnUrl { get; set; }

        public async Task<IActionResult> OnGetAsync([FromQuery]string email, [FromQuery]string senha)
        {
            string returnUrl = Url.Content("~/");

            try { await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme); } catch { }

            try
            {
                var _loginEntradaDTO = new LoginEntradaDTO
                {
                    Email = email,
                    Senha = senha
                };

                var loginSaida = await _loginServico.LoginAsync(_loginEntradaDTO);

                if (loginSaida == null)
                    return LocalRedirect($"{returnUrl}");

                var jwtToken = new JwtSecurityToken(loginSaida.Token);

                var claims = jwtToken.Claims.ToList();
                CorrigeClaimType(ref claims);

                HttpContext.Response.Cookies.Append("token", loginSaida.Token);

                var cargoId = claims.FirstOrDefault(_ => _.Type == ClaimTypes.Role)?.Value;

                if (cargoId == CargosConst.Recepcionista)
                    returnUrl += "calendario-de-consultas";

                if (cargoId == CargosConst.Laboratorio)
                    returnUrl += "realiza-exames";

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt")),
                    new AuthenticationProperties
                    {
                        IsPersistent = true,
                        RedirectUri = Request.Host.Value,
                    });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return LocalRedirect(returnUrl);
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
