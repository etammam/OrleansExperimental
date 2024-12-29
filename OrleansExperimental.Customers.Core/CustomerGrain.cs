using Microsoft.Extensions.Logging;
using OrleansExperimental.IMessages;

namespace OrleansExperimental.Customers.Core;

public class CustomerGrain : Grain, ICustomerGrain
{
    private readonly ILogger<CustomerGrain> _logger;

    public CustomerGrain(ILogger<CustomerGrain> logger)
    {
        _logger = logger;
    }

    public override Task OnActivateAsync(CancellationToken cancellationToken)
    {
        var grainId = this.GetGrainId();
        _logger.LogInformation("customer grain activated with id: {grainId}", grainId);
        return base.OnActivateAsync(cancellationToken);
    }

    public Task<int> GetCustomersCountAsync()
    {
        return Task.FromResult(Enumerable.Range(0, 200).First());
    }

    public async Task<double> GetCustomerOrderTotalAsync()
    {
        var customerId = (int) this.GetPrimaryKeyLong();
        var orderGrain = this.GrainFactory.GetGrain<IOrderGrain>(customerId);
        var customerOrderTotals = await orderGrain.GetCustomerOrdersCountAsync();
        return customerOrderTotals * 10;
    }
}