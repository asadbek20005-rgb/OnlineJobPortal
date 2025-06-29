using System.Text.Json.Serialization;

namespace OnlineJobPortal.Common.Models.Eskiz;

public class EskizAuthResponse
{
    [JsonPropertyName("message")]
    public string Message { get; set; } = null!;

    [JsonPropertyName("data")]
    public EskizAuthData Data { get; set; } = null!;
}
