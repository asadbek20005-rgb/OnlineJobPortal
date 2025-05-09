namespace OnlineJobPortal.Service.Contracts;

public interface IRedisService
{
    Task SetItemAsync<T>(string key, T item);
    Task<T?> GetItemAsync<T>(string key);
}
