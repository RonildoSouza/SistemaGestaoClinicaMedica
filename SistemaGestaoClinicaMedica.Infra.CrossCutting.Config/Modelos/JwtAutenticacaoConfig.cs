using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Modelos
{
    public sealed class JwtAutenticacaoConfig
    {
        private readonly SecurityKey _key;

        public JwtAutenticacaoConfig()
        {
            using var provider = new RSACryptoServiceProvider(2048);
            _key = new RsaSecurityKey(provider.ExportParameters(true));

            SigningCredentials = new SigningCredentials(_key, SecurityAlgorithms.RsaSha256Signature);
        }

        public string Key { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int ExpirationInHours { get; set; }
        public SymmetricSecurityKey SymmetricSecurityKey => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
        public SigningCredentials SigningCredentials { get; }
    }
}
