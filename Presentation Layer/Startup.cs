using AutoMapper;
using Business_Layer.Services;
using Data_Access_Layer;
using Data_Access_Layer.Contexts;
using Data_Access_Layer.DbInitializer;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.DTOs;

namespace Presentation_Layer
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
            services.AddScoped<IUnitOfWork, AirportUnitOfWork>();
            services.AddScoped<AirportService>();
            services.AddMvc();
            var mapper = MapperConfiguration().CreateMapper();
            services.AddAutoMapper();

            services.AddDbContext<AirportContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("AirportConnectionString"), b => b.MigrationsAssembly("Presentation Layer")));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AirportContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();

            AirportDbInitializer.Initialize(context);
        }

        public MapperConfiguration MapperConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Flight, FlightDTO>();
                cfg.CreateMap<Departure, DepartureDTO>();
                cfg.CreateMap<Pilot, PilotDTO>();
                cfg.CreateMap<Plane, PlaneDTO>();
                cfg.CreateMap<PlaneType, PlaneTypeDTO>();
                cfg.CreateMap<Stewardess, StewardessDTO>();
                cfg.CreateMap<Ticket, TicketDTO>();
            });
            return config;
        }
    }
}
