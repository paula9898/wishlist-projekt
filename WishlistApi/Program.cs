using Application_Layer.WishlistServices;
using MongoDB.Driver;
using Wishlist.Domain.Entities;
using Wishlist.Domain.Repository;
using Wishlist.Infrastructure.Repositories;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = "mongodb://localhost:27017";

        // Add services to the container.
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        //builder.Services.AddOpenApi();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSingleton<IWishlistRepository, WishlistMongoRepository>();
        builder.Services.AddSingleton<IMongoClient>(new MongoClient(connectionString));
        builder.Services.AddSingleton<IMongoDatabase>(sp =>
        {
            var client = sp.GetRequiredService<IMongoClient>();
            return client.GetDatabase("WishlistDb");
        });
        builder.Services.AddSingleton<IMongoCollection<WishlistBase>>(sp =>
        {
            var database = sp.GetRequiredService<IMongoDatabase>();
            return database.GetCollection<WishlistBase>("wishlists");
        });
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
