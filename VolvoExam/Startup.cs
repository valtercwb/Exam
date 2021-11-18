using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VolvoExam.Application.Interface;
using VolvoExam.Application.Service;
using VolvoExam.Data.Entities;
using VolvoExam.Data.Interface;
using VolvoExam.Data.Repository;
using VolvoExam.ViewModels;

namespace VolvoExam
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
      services.AddControllersWithViews();


      services.AddScoped<ITruckService, TruckService>();
      services.AddScoped<ITruckRepository, TruckRepository>();
      var connectionString = Configuration["DefaultConnection:ConnectionString"];
      services.AddDbContext<Data.VolvoExamDbContext>(options => options.UseLazyLoadingProxies().UseNpgsql(connectionString));

      var config = new AutoMapper.MapperConfiguration(cfg =>
      {
        cfg.CreateMap<Truck, Application.Transients.TruckTransient>();
        cfg.CreateMap<TruckModel, Application.Transients.TruckModelTransient>();
        cfg.CreateMap<Application.Transients.TruckTransient, TruckViewModel>();
        cfg.CreateMap<TruckViewModel, Application.Transients.TruckTransient>();
        cfg.CreateMap<Application.Transients.TruckModelTransient, TruckModelViewModel>();
      });

      IMapper mapper = config.CreateMapper();
      services.AddSingleton(mapper);

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
      }
      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Truck}/{action=Index}/{id?}");
      });
    }
  }
}
