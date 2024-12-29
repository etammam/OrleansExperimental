using Orleans.Configuration;

namespace OrleansExperimental.Orders.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.AddKeyedRedisClient("redis");

        builder.Host.UseOrleans(_ =>
        {
        });
        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");

        app.Run();
    }
}