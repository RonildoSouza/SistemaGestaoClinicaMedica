using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Modelos;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Servicos.Autenticacao
{
    public sealed class JwtAutenticacaoServico : IAutenticacaoServico
    {
        private readonly IOptions<JwtAutenticacaoConfig> _jwtAutenticacaoConfig;

        public JwtAutenticacaoServico(IOptions<JwtAutenticacaoConfig> jwtAutenticacaoConfig)
        {
            _jwtAutenticacaoConfig = jwtAutenticacaoConfig;
        }

        public AutenticacaoSaida Autenticar(AutenticacaoEntrada entrada)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim("Data", ToJson(entrada)),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, entrada.CargoId),
            };

            var claimsIdentity = new ClaimsIdentity(new GenericIdentity(entrada.Id.ToString(), "Login"), claims);

            var criadoEm = DateTime.Now;
            var expiracao = criadoEm.AddHours(_jwtAutenticacaoConfig.Value.ExpirationInHours);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            var securityToken = jwtSecurityTokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Audience = _jwtAutenticacaoConfig.Value.Audience,
                Issuer = _jwtAutenticacaoConfig.Value.Issuer,
                SigningCredentials = _jwtAutenticacaoConfig.Value.SigningCredentials,
                Subject = claimsIdentity,
                NotBefore = criadoEm,
                Expires = expiracao
            });

            var formatacaoData = "yyyy-MM-dd HH:mm:ss";

            return new AutenticacaoSaida(
                true,
                criadoEm.ToString(formatacaoData),
                expiracao.ToString(formatacaoData),
                jwtSecurityTokenHandler.WriteToken(securityToken));
        }

        private string ToJson<T>(T obj)
        {
            if (obj == null)
                return null;

            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            });
        }
    }
}
