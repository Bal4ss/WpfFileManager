namespace Services.Core.PathManagers;

/// <summary>
///     Path service
/// </summary>
public interface IPathManagerService
{
    string DefaultPath { get; }
    string CurrentPath { get; }
    string CurrentPathFolder { get; }
    string TextJsonFile { get; }
}