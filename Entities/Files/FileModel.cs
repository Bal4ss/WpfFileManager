using System.IO;
using Entities.Enums;

namespace Entities.Files;

public readonly struct FileModel
{
    public FileModel(string fullPath, FileTypes type)
    {
        FullPath = fullPath;
        Type = type;
    }

    public string FileName => Path.GetFileName(FullPath);
    public string FullPath { get; }
    public FileTypes Type { get; }
}