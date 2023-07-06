using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace APIGatewayMicroservice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
                  .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddOcelot(builder.Configuration);
     

            var app = builder.Build();

            // Configure the HTTP request pipeline.



            if (app.Environment.IsDevelopment())
            {
                
            }

            app.UseOcelot();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}