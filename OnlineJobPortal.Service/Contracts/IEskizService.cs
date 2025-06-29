namespace OnlineJobPortal.Service.Contracts;

public interface IEskizService
{
    Task<Tuple<bool, string>> SendSmsAsync(string phoneNumber, string code);
}
