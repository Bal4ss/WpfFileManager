namespace Services.Core.Settings;

public interface IGlobalSettings
{
    string Language { get; set; }
    string Server { get; }
    string Database { get; }
    string UserId { get; }
    string Password { get; }
    uint Port { get; }
}