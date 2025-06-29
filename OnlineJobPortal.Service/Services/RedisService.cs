using Newtonsoft.Json;
using OnlineJobPortal.Service.Contracts;
using StackExchange.Redis;

namespace OnlineJobPortal.Service.Services;

public class RedisService(IConnectionMultiplexer connectionMultiplexer) : IRedisService
{
    private readonly IDatabase _database = connectionMultiplexer.GetDatabase();
    public async Task<T?> GetItemAsync<T>(string key)
    {
        string? json = await _database.StringGetAsync(key);
        if (json is null)
            return default;
        var item = JsonConvert.DeserializeObject<T>(json);
        
        return item;
    }

    public async Task SetItemAsync<T>(string key, T item)
    {
        string json = JsonConvert.SerializeObject(item);
        await _database.StringSetAsync(key, json, TimeSpan.FromMinutes(2));
    }
}
