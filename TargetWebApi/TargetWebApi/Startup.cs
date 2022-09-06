using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TargetWebApi.Business;
using TargetWebApi.Business.Implementations;
using TargetWebApi.Models.Context;
using TargetWebApi.Repository;
using TargetWebApi.Repository.Generic;

namespace TargetWebApi
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

            var connection = Configuration["SQLConnection:SQLConnectionString"];
            services.AddDbContext<SQLContext>(options => options.UseSqlServer(connection));

            services.AddScoped<IProdutoBusiness, ProdutoBusinessImplementation>();
            services.AddScoped<IFornecedorBusiness, FornecedorBusinessImplementation>();

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

            services.AddSwaggerGen(c => {
            c.SwaggerDoc("v1",
                new OpenApiInfo { 
                    Title = "Teste Target",
                    Version = "v1",
                    Description = "",
                    Contact = new OpenApiContact()
                    {
                        Name = "Rafael Cortez",
                        Url = new Uri("https://github.com/RNCortez/TargetTeste")
                    }
                });

                
            });
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

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            RewriteOptions option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
