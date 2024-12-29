using Microsoft.AspNetCore.Mvc;
using Orleans.Configuration;
using OrleansExperimental.IMessages;

namespace OrleansExperimental.Customers.Api;

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

        app.MapGet("/{customerId}", async ([FromRoute] int customerId, IGrainFactory grainFactory) =>
        {
            var customerGrain = grainFactory.GetGrain<ICustomerGrain>(customerId);
            var customerOrderTotal = await customerGrain.GetCustomerOrderTotalAsync();
            return Results.Ok(new
            {
                customerId = customerId,
                customerOrderTotal,
            });
        });

        app.Run();
    }
}