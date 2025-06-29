using System.Text.Json.Serialization;

namespace OnlineJobPortal.Common.Models.Eskiz;

public class EskizAuthData
{
    [JsonPropertyName("token")]
    public string Token { get; set; } = null!;
}
