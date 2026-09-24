using Application_Layer.WishlistServices;
using Wishlist.Domain.Repository;
using Wishlist.Infrastructure.Repositories;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        //builder.Services.AddOpenApi();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSingleton<IWishlistRepository, WishlistInMemoryRepository>();
        builder.Services.AddScoped<AddItemToWishlistHandler>();
    

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            //app.UseSwaggerUI();

            app.UseSwaggerUI
                (options => // UseSwaggerUI is called only in Development.
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });

        }
        app.MapGet("/", () => "Hello World!");
        app.MapControllers();

        //app.UseHttpsRedirection();

      
        app.Run();
    }
}
