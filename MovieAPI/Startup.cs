using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApp.Data.DataConnection;
using MovieApp.Data.Repositories;
using MovieApp.Business.Services;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace MovieAPI
{
    //class startup.cs is act as a middleware  
    public class Startup
    {
        // IConfiguration is an interface use to acess the key and value through appsettings ....
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // here the using IConfiguarton we can connect to the underlaying database or to make the connection 
            String sqlConnection = Configuration.GetConnectionString("SqlConnection");
            services.AddDbContext<MovieDBContext>(options => options.UseSqlServer(sqlConnection));
            services.AddTransient<IUser, User>();
            services.AddTransient<UserService ,UserService>();
            services.AddTransient<IMovie, Movie>();
            services.AddTransient<MovieService,MovieService>();
            services.AddTransient<ITheatre, Theatre>();
            services.AddTransient<TheatreService, TheatreService>();
            services.AddTransient<IMovieShowTime, MovieShowTime>();
            services.AddTransient<MovieShowTimeService, MovieShowTimeService>();
            services.AddTransient<IBooking, Booking>();
            services.AddTransient<BookingService, BookingService>();
            services.AddControllers();
            services.AddSwaggerGen();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["Jwt:Audience"],
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
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

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyMovieAPI");
            });

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
