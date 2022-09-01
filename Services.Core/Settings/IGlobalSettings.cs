namespace Services.Core.Settings;

/// <summary>
///     Global settings service (config)
/// </summary>
public interface IGlobalSettings
{
    string Language { get; set; }
    string Server { get; }
    string Database { get; }
    string UserId { get; }
    string Password { get; }
    uint Port { get; }
}