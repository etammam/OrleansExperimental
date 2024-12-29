namespace OrleansExperimental.IMessages;

public interface IOrderGrain : IGrainWithIntegerKey
{
    Task<double> GetCustomerOrdersCountAsync();
}