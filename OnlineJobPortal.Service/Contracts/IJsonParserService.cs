namespace OnlineJobPortal.Service.Contracts;

public interface IJsonParserService
{
    public object ParseResponseResult(string responseJson, Type typeOfT);
}
