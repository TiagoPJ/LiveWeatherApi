using Application;
using Application.Configuracao;
using Application.Configuracao.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Service.Implementation;
using Service.Interfaces;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace Api
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
            services.BuildServiceProvider();
            var projectConfiguration = new ProjectConfiguration();
            new ConfigureFromConfigurationOptions<ProjectConfiguration>(Configuration.GetSection("ProjectConfiguration")).Configure(projectConfiguration);

            services.AddSingleton(projectConfiguration);
            services.AddScoped<ILiveWeatherService, LiveWeatherService>();
            services.AddScoped<IMessages, Messages>();
            services.AddMvcCore().AddJsonFormatters().AddApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.OperationFilter<SetBodyParameters>();
                c.SwaggerDoc("v1",
                   new Info
                   {
                       Title = "LiveWeatherApi",
                       Version = "v1",
                       Description = "Live weather forecast."
                   });

                string caminhoAplicacao =
                    PlatformServices.Default.Application.ApplicationBasePath;
                string nomeAplicacao =
                    PlatformServices.Default.Application.ApplicationName;
                string caminhoXmlDoc =
                    Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                c.IncludeXmlComments(caminhoXmlDoc);
            });

            // Configura��o do CORS
            services.AddCors(o => o.AddPolicy("CorsConfig", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            AdapterDtoDomain.MapperRegister();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider provider)
        {
            //Adicionado a configuração do cors ao Config.
            app.UseCors("CorsConfig");

            app.UseDeveloperExceptionPage();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Live Weather Forecast");
            });
        }
    }
}
