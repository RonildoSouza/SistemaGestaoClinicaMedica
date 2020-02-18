using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Modelos
{
    public sealed class JwtAutenticacaoConfig
    {
        public string Key { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int ExpirationInHours { get; set; }
        public SymmetricSecurityKey SymmetricSecurityKey => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
        public SigningCredentials SigningCredentials => new SigningCredentials(SymmetricSecurityKey, SecurityAlgorithms.HmacSha256);
    }
}
