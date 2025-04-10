
using MarketPulse.APIs.Helpers;
using MarketPulse.Core.IGenericRepository;
using MarketPulse.Repository;
using MarketPulse.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MarketPulse.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var WebApplicationbuilder = WebApplication.CreateBuilder(args);


            #region Add services to the container
            WebApplicationbuilder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            WebApplicationbuilder.Services.AddEndpointsApiExplorer();
            WebApplicationbuilder.Services.AddSwaggerGen();

            WebApplicationbuilder.Services.AddDbContext<StoreContext>(options =>
            {
                options.UseSqlServer(WebApplicationbuilder.Configuration.GetConnectionString("DefaultConnectionString"));
            }
            );

            WebApplicationbuilder.Services.AddScoped(typeof(IGenericRepository<>) , typeof(GenericRepository<>));
            WebApplicationbuilder.Services.AddAutoMapper(typeof(MappingProfiles));


            #endregion

            var app = WebApplicationbuilder.Build();

            #region Update Database and Seed Data
            using var Scope = app.Services.CreateScope();

            var Services = Scope.ServiceProvider;

            var _dbContext = Services.GetRequiredService<StoreContext>();
            // Ask Clr to create object from the database explicitly

            var ILoggerFactory = Services.GetRequiredService<ILoggerFactory>();
            try
            {

                await _dbContext.Database.MigrateAsync();
                await StoreContextSeed.SeedAsync(_dbContext);
            }
            catch (Exception ex)
            {
                var loogger = ILoggerFactory.CreateLogger<Program>();
                loogger.LogError(ex, "An error occurred during migration");
            } 
            #endregion

            #region Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(); 

          //  app.UseAuthorization();


            app.MapControllers();

            app.Run(); 
            #endregion
        }
    }
}
