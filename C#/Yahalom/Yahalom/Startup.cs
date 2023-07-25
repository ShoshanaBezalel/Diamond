using AutoMapper;
using BL;
using DAL.DB;
using DTO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
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

namespace Yahalom
{
//    public class Startup
//    {
//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public IConfiguration Configuration { get; }

//        // This method gets called by the runtime. Use this method to add services to the container.
//        public void ConfigureServices(IServiceCollection services)
//        {
//            // services.AddScoped<IUserBL, UserBL>();

//            // services.AddScoped<IUserDL, UserDL>();
//            services.AddScoped<IAuthBL, AuthBL>();

//            services.AddScoped<ICustomerBL, CustomerBL>();
//            //services.AddScoped<IUserDL, UserDL>();

//            services.AddScoped<ISupplierBL, SupplierBL>();
//            //services.AddScoped<ISupplierDL, SupplierDL>();

//            services.AddScoped<IInvitationBL, InvitationBL>();
//            //services.AddScoped<IInvitationDL, InvitationDL>();
//            services.AddScoped<IMyTasksBL, MyTasksBL>();

          
//            services.AddControllers();
//            services.AddSwaggerGen(c =>
//            {
//                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Yahalom", Version = "v1" });
//            });


//            services.AddDbContext<YahalomContext>(options => options.UseSqlServer(
//                           "Server=.;Database=Yahalom;Trusted_Connection=True;"), ServiceLifetime.Scoped);
//            services.AddAutoMapper(typeof(AutoMapping));
//            // services.AddScoped<IUserBL, UserBL>();
//            services.AddControllersWithViews();
//            //הרשאת התחברות לאנגולר
//            services.AddCors(options =>
//            {
//                options.AddPolicy("MyAllowSpecificOrigins", builder =>
//                {
//                    builder.WithOrigins("http://localhost:4200")
//                    .AllowAnyHeader()
//                    .AllowAnyMethod();
//                });
//            });


//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//                app.UseSwagger();
//                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Yahalom v1"));
//            }
           
//            app.UseHttpsRedirection();

//            app.UseRouting();

//            app.UseAuthorization();

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllers();
//            });
//            //הרשאת חיבור לאנגולר
//            app.UseCors("MyAllowSpecificOrigins");
//        }
//    }
//}


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
                services.AddCors(options =>
                {
                    options.AddPolicy("AllowOrigin",
                        builder => builder.WithOrigins("http://localhost:4200")
                                          .AllowAnyHeader()
                                          .AllowAnyMethod());
                });
                // services.AddScoped<IUserBL, UserBL>();

                // services.AddScoped<IUserDL, UserDL>();
                services.AddScoped<IAuthBL, AuthBL>();

                services.AddScoped<ICustomerBL, CustomerBL>();
                //services.AddScoped<IUserDL, UserDL>();

                services.AddScoped<ISupplierBL, SupplierBL>();
                //services.AddScoped<ISupplierDL, SupplierDL>();

                services.AddScoped<IInvitationBL, InvitationBL>();
            //services.AddScoped<IInvitationDL, InvitationDL>();
            services.AddScoped<IMyTasksBL, MyTasksBL>();

            services.AddControllers();
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Yahalom", Version = "v1" });
                });


                services.AddDbContext<YahalomContext>(options => options.UseSqlServer(
                               "Server=.;Database=Yahalom;Trusted_Connection=True;"), ServiceLifetime.Scoped);
                services.AddAutoMapper(typeof(AutoMapping));
                // services.AddScoped<IUserBL, UserBL>();
                services.AddControllersWithViews();
                //הרשאת התחברות לאנגולר
                services.AddCors(options =>
                {
                    options.AddPolicy("MyAllowSpecificOrigins", builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
                });


            }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                app.UseCors("AllowOrigin");
                app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseSwagger();
                    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Yahalom v1"));
                }

                app.UseHttpsRedirection();

                app.UseRouting();

                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
                //הרשאת חיבור לאנגולר
                app.UseCors("MyAllowSpecificOrigins");
            }
        }
    }
