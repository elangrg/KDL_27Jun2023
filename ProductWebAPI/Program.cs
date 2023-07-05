namespace ProductWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddScoped<Models.KNDProductDbContext>();
            builder.Services.AddOpenApiDocument();


            builder.Services.AddControllers().AddXmlSerializerFormatters();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}