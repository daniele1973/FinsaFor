﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinsaWeb.Models.CoreNocciolo;
using FinsaWeb.Models.CoreNocciolo.UoW;
using FinsaWeb.Models.EF;
using FinsaWeb.Models.EF.UoW;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinsaWeb
{
    public class Startup
    {
        private IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("MyPolicyCORS", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddDbContext<FinsaContext>(opts => opts.UseSqlServer(
          configuration.GetConnectionString("DefaultConnection")));

            //services.AddTransient<CourseRepository, InMemoryCourseRepository>();
            services.AddTransient<ICorsiRepository, EFCorsiRepository>();
            services.AddTransient<ICorsiUnitOfWork, EFCorsiUnitOfWork>();

            //services.AddTransient<IEdizioniCorsiRepository, EFEdizioniCorsiRepository>();
            services.AddTransient<IEdizioniCorsiRepository, EFEdizioniCorsiRepository>();
            //services.AddTransient<IEdizioniCorsiUnitOfWork, EFEdizioniCorsiUnitOfWork>();

            services.AddTransient<IAllieviRepository, EFAllieviRepository>();
            services.AddTransient<IAllieviUnitOfWork, EFAllieviUnitOfWork>();

            services.AddTransient<ICorsiAllieviRepository, EFCorsiAllieviRepository>();

            services.AddTransient<ICorsiDocentiRepository, EFCorsiDocentiRepository>();

            services.AddTransient<IDocentiRepository, EFDocentiRepository>();
            services.AddTransient<IDocenteUnitOfWork, EFDocentiUnitOfWork>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("MyPolicyCORS");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
