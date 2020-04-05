using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Modelos;
using SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Servicos.Mail;
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
            services.AddControllers().AddNewtonsoftJson(cfg =>
            {
                cfg.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddDbContext<ContextoBancoDados>();

            var jwtConfigurationSection = Configuration.GetSection(nameof(JwtAutenticacaoConfig));
            var azureStorageConfigurationSection = Configuration.GetSection(nameof(AzureStorageConfig));

            services.AddEnviaEmail(
                "clinica@email.com", 
                "Sistema de Gestão de Clínica Médica",
                "mail-dev.brazilsouth.azurecontainer.io",
                25);

            #region Injeção de Dependência
            IoC.Registrar(services);

            services.Configure<JwtAutenticacaoConfig>(jwtConfigurationSection);
            services.Configure<AzureStorageConfig>(azureStorageConfigurationSection);
            #endregion

            #region Configuração Azure Storage
            var azureStorageConfig = azureStorageConfigurationSection.Get<AzureStorageConfig>();

            services.AddSingleton(new BlobContainerClient(azureStorageConfig.ConnectionString, azureStorageConfig.Container));
            #endregion

            #region Configuração de Autenticação JWT
            var jwtAutenticacaoConfig = jwtConfigurationSection.Get<JwtAutenticacaoConfig>();

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters.IssuerSigningKey = jwtAutenticacaoConfig.SymmetricSecurityKey;
                opt.TokenValidationParameters.ValidAudience = jwtAutenticacaoConfig.Audience;
                opt.TokenValidationParameters.ValidIssuer = jwtAutenticacaoConfig.Issuer;
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

            //app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
