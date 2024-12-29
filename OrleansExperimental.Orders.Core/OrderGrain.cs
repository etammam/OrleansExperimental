using Microsoft.Extensions.Logging;
using OrleansExperimental.IMessages;

namespace OrleansExperimental.Orders.Core;

public class OrderGrain : Grain, IOrderGrain
{
    private readonly ILogger<OrderGrain> _logger;

    private readonly static Dictionary<int, double> CustomerOrders = new Dictionary<int, double>()
    {
        {
            1, 2000
        },
        {
            2, 20233
        }
    };

    public OrderGrain(ILogger<OrderGrain> logger)
    {
        _logger = logger;
    }

    public override Task OnActivateAsync(CancellationToken cancellationToken)
    {
        var grainId = this.GetGrainId();
        _logger.LogInformation("orders grain activated with id: {grainId}", grainId);
        return base.OnActivateAsync(cancellationToken);
    }

    public Task<double> GetCustomerOrdersCountAsync()
    {
        var grainId = (int)this.GetGrainId().GetIntegerKey();
        CustomerOrders.TryGetValue(grainId, out var result);
        return Task.FromResult(result);
    }
}