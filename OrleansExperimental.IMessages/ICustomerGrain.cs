namespace OrleansExperimental.IMessages;

public interface ICustomerGrain : IGrainWithIntegerKey
{
    Task<int> GetCustomersCountAsync();
    Task<double> GetCustomerOrderTotalAsync();
}