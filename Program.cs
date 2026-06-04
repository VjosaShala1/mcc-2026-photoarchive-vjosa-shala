using Microsoft.EntityFrameworkCore;
using PhotoArchive.API.Data;

namespace PhotoArchive.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

           
                app.UseSwagger();
                app.UseSwaggerUI();
            

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}