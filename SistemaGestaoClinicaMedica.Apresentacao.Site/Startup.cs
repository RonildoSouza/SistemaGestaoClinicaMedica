using AutoMapper;
using Blazored.LocalStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SistemaGestaoClinicaMedica.Apresentacao.Site.AutoMapper;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Providers;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos;
using SistemaGestaoClinicaMedica.Dominio.Documentos;
using SistemaGestaoClinicaMedica.Infra.CrossCutting.IoC.Extensions;
using System;
using System.Globalization;
using System.Net.Http;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            var apiUrlBase = Configuration.GetValue<string>("ApiUrlBase");
            Uri.TryCreate(apiUrlBase, UriKind.Absolute, out Uri uri);

            services.AddSingleton(new HttpClient
            {
                BaseAddress = uri,
            });

            services.RegistrarTudoPorAssembly(typeof(IServicoBase<,>).Assembly, "Servico");
            services.RegistrarTudoPorAssembly(typeof(IConstroiDocumento).Assembly, "Documento");
            services.AddBlazoredLocalStorage();
            services.AddBlazoredToast();
            services.AddAutoMapper(typeof(DTOParaViewModel), typeof(ViewModelParaDTO));

            services.AddSingleton<ApplicationState>();
            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            services.AddAuthorizationCore();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var cultureInfo = new CultureInfo("pt-BR");
            cultureInfo.NumberFormat.CurrencySymbol = "R$";

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
