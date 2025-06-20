using Newtonsoft.Json;
using OnlineJobPortal.Common.Results;
using OnlineJobPortal.Service.Contracts;

namespace OnlineJobPortal.Service.Services;

public class JsonParserService : IJsonParserService
{
    public object ParseResponseResult(string responseJson, Type typeOfT)
    {
        var genericType = typeof(RootData<>).MakeGenericType(typeOfT);

        var resultObject = JsonConvert.DeserializeObject(responseJson, genericType);

        var resultProperty = genericType.GetProperty("Result");
        return resultProperty?.GetValue(resultObject)!;
    }
}
