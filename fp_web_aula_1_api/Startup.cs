using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fp_web_aula_1_core.Models;
using fp_web_aula_1_core.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace fp_web_aula_1_api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ILogerApi, LogerApi>();
            services.AddScoped<INoticiaService, NoticiaService>();

            var connection = @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.AspNetCore.NewDb2;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<CopaContext>
            (options => options.UseSqlServer(connection));


            services.Configure<GzipCompressionProviderOptions>(
             o => o.Level = System.IO.Compression.CompressionLevel.Fastest);
            services.AddResponseCompression(o =>
            {
                o.Providers.Add<GzipCompressionProvider>();
            });

            services.AddCors(x =>
            {
                x.AddPolicy("Default",
                builder =>
                {
                    builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod(); ;
                });
            });

            services.AddMvc(
                o =>
                {
                    o.RespectBrowserAcceptHeader = true;
                    o.OutputFormatters.Add(new XmlSerializerOutputFormatter());
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("Default");
            app.UseMvc(r =>
            {
                r.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
