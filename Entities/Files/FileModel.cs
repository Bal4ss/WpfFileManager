using Entities.Enums;

namespace Entities.Files;

public readonly struct FileModel
{
    private readonly string _fullPath;
    
    public FileModel(string fullPath)
    {
        _fullPath = fullPath;
    }

    public string FileName => Path.GetFileName(_fullPath);
    public string FullPath => _fullPath;

    public FileTypes Type => File.GetAttributes(_fullPath) == FileAttributes.Directory
        ? FileTypes.Folder
        : FileTypes.Program;
}