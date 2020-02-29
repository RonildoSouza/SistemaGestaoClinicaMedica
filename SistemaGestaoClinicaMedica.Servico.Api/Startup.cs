using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SistemaGestaoClinicaMedica.Infra.CrossCutting.Config;
using SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Modelos;
using SistemaGestaoClinicaMedica.Infra.CrossCutting.IoC;
using SistemaGestaoClinicaMedica.Infra.Data;
using System;

namespace SistemaGestaoClinicaMedica.Servico.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<ContextoBancoDados>();

            var jwtConfigurationSection = Configuration.GetSection(nameof(JwtAutenticacaoConfig));

            #region Injeção de Dependência
            AplicacaoServicoDI.Registrar(services);

            DominioServicoDI.Registrar(services);

            ConfiguracaoDI.Registrar(services);

            services.Configure<JwtAutenticacaoConfig>(jwtConfigurationSection);
            #endregion

            #region Configuração de Autenticação JWT
            var jwtConfig = jwtConfigurationSection.Get<JwtAutenticacaoConfig>();

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters.IssuerSigningKey = jwtConfig.SymmetricSecurityKey;
                opt.TokenValidationParameters.ValidAudience = jwtConfig.Audience;
                opt.TokenValidationParameters.ValidIssuer = jwtConfig.Issuer;
                opt.TokenValidationParameters.ValidateIssuerSigningKey = true;
                opt.TokenValidationParameters.ValidateLifetime = true;
                opt.TokenValidationParameters.ClockSkew = TimeSpan.Zero;
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });
            #endregion

            #region Registra AutoMapper
            AutoMapperConfig.Registrar(services);
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
