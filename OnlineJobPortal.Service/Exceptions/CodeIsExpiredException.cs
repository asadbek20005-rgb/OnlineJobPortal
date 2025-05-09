namespace OnlineJobPortal.Service.Exceptions;

public class CodeIsExpiredException : Exception
{
    public CodeIsExpiredException() : base("Code is expired")
    {
        
    }
}
