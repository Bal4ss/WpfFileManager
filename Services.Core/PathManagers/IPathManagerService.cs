namespace Services.Core.PathManagers;

public interface IPathManagerService
{
    string DefaultPath { get; }
    string CurrentPath { get; }
    string CurrentPathFolder { get; }
    string TextJsonFile { get; }
    string DbPath { get; }
}